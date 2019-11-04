using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Amtskalender
{
    public partial class DlgCategorize : Form
    {

        private BindingList<Outlook.AppointmentItem> SourceItems = new BindingList<Outlook.AppointmentItem>();
        private BindingList<Outlook.AppointmentItem> List1Items = new BindingList<Outlook.AppointmentItem>();
        private BindingList<Outlook.AppointmentItem> List2Items = new BindingList<Outlook.AppointmentItem>();
        private BindingList<Outlook.AppointmentItem> List3Items = new BindingList<Outlook.AppointmentItem>();
        private BindingList<Outlook.AppointmentItem> List4Items = new BindingList<Outlook.AppointmentItem>();
        private BindingList<Outlook.AppointmentItem> List5Items = new BindingList<Outlook.AppointmentItem>();
        private BindingList<Outlook.AppointmentItem> List6Items = new BindingList<Outlook.AppointmentItem>();
        private BindingList<Outlook.MAPIFolder> Calendars = new BindingList<Outlook.MAPIFolder>();

        private List<BindingList<Outlook.AppointmentItem>> BindingLists = new List<BindingList<Outlook.AppointmentItem>>();
        private List<ListBox> RecipientListboxes = new List<ListBox>();
        private Outlook.MAPIFolder DefaultCalendar = Globals.ThisAddIn.Calendars.GetDefault();


        public DlgCategorize()
        {
            InitializeComponent();

            // add binding lists
            listBox1.DataSource = List1Items;
            listBox2.DataSource = List2Items;
            listBox3.DataSource = List3Items;
            listBox4.DataSource = List4Items;
            listBox5.DataSource = List5Items;
            listBox6.DataSource = List6Items;

            // create RecipientListBoxes list for easier handling
            RecipientListboxes.Add(listBox1);
            RecipientListboxes.Add(listBox2);
            RecipientListboxes.Add(listBox3);
            RecipientListboxes.Add(listBox4);
            RecipientListboxes.Add(listBox5);
            RecipientListboxes.Add(listBox6);

            // same for BindingLists
            BindingLists.Add(List1Items);
            BindingLists.Add(List2Items);
            BindingLists.Add(List3Items);
            BindingLists.Add(List4Items);
            BindingLists.Add(List5Items);
            BindingLists.Add(List6Items);

            // add drag-and-drop handlers
            SourceItemsList.MouseDown += new MouseEventHandler(SourceItemsList_MouseDown);
            SourceItemsList.MouseMove += new MouseEventHandler(SourceItemsList_MouseMove);
            SourceItemsList.DragEnter += new DragEventHandler(RecipientListBox_DragEnter);
            SourceItemsList.DragDrop += new DragEventHandler(RecipientListBox_DragDrop);
            foreach (ListBox Box in RecipientListboxes)
            {
                Box.MouseDown += new MouseEventHandler(SourceItemsList_MouseDown);
                Box.MouseMove += new MouseEventHandler(SourceItemsList_MouseMove);
                Box.DragEnter += new DragEventHandler(RecipientListBox_DragEnter);
                Box.DragDrop += new DragEventHandler(RecipientListBox_DragDrop);
            }

            // add double-click handlers
            foreach (ListBox Box in RecipientListboxes) Box.MouseDoubleClick += new MouseEventHandler(AppointmentItemDoubleClick);

            // add format handlers
            SourceItemsList.Format += new ListControlConvertEventHandler(AppointmentItemListFormat);
            foreach (ListBox Box in RecipientListboxes) Box.Format += new ListControlConvertEventHandler(AppointmentItemListFormat);

            // configure calendar list
            CalendarList.DataSource = Calendars;
            CalendarList.Format += new ListControlConvertEventHandler(CalendarListFormat);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DlgCategorize_Load(object sender, EventArgs e)
        {
            SourceItemsList.DataSource = SourceItems;

            // populize calendar list
            foreach (Outlook.MAPIFolder Folder in Globals.ThisAddIn.Calendars.GetAll()) Calendars.Add(Folder);
            //   CalendarList.SelectedItem = DefaultCalendar;
            
            foreach (Outlook.MAPIFolder Item in CalendarList.Items)
            {
                if (Item.Name == DefaultCalendar.Name && Item.Store.DisplayName == DefaultCalendar.Store.DisplayName)
                {
                    CalendarList.SelectedItem = Item;
                }
            }
        }

        private void LoadItems()
        {
            // clear all the sublists
            SourceItems.Clear();
            foreach (BindingList<Outlook.AppointmentItem> BL in BindingLists) BL.Clear();

            Outlook.MAPIFolder Folder = (Outlook.MAPIFolder)CalendarList.SelectedItem;
            Calendar Calendar = new Calendar(Folder);

            // triage: find which box to add the element to
            foreach (Outlook.AppointmentItem Item in Calendar.GetAllForMonth(this.ReferenceDate.Value).OrderBy(s => s.Start))
            {
                List<string> Cats = CategoryTools.SplitCategories(Item.Categories);
                ListBox TargetBox = null;
                ListBox TmpBox = null;
                foreach (string Category in Cats)
                {
                    TmpBox = GetListBoxForCategory(Category);
                    if (TmpBox != null) TargetBox = TmpBox;
                }
                if (TargetBox == null) TargetBox = SourceItemsList;
                ((BindingList<Outlook.AppointmentItem>)TargetBox.DataSource).Add(Item);
            }
        }

        private void CalendarList_SelectedIndexChanged() { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadItems();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AppointmentItemListFormat(object sender, ListControlConvertEventArgs e)
        {
            Outlook.AppointmentItem Item = (Outlook.AppointmentItem)e.ListItem;
            e.Value = Item.Start.ToShortDateString() + " " + Item.Subject;
        }


        private void CalendarListFormat(object sender, ListControlConvertEventArgs e)
        {
            Outlook.MAPIFolder Item = (Outlook.MAPIFolder)e.ListItem;
            e.Value = Item.Name + " (" + Item.Store.DisplayName + ")";
        }

        private string GetListBoxCategory(ListBox Box)
        {
            if (Box.Name == "listBox1") return "Amtskalender: Gottesdienst/Taufe/Abendmahl";
            if (Box.Name == "listBox2") return "Amtskalender: Amtshandlungen";
            if (Box.Name == "listBox3") return "Amtskalender: Seelsorge/Diakonie";
            if (Box.Name == "listBox4") return "Amtskalender: Mitarbeiterschaft/Gremien/Dienstbesprechung";
            if (Box.Name == "listBox5") return "Amtskalender: Bibelarbeit/Erwachsenenbildung";
            if (Box.Name == "listBox6") return "Amtskalender: Unterricht/Jugendarbeit";
            return "";
        }

        private ListBox GetListBoxForCategory(string category)
        {
            if (category == "Amtskalender: Gottesdienst/Taufe/Abendmahl") return listBox1;
            if (category == "Amtskalender: Amtshandlungen") return listBox2;
            if (category == "Amtskalender: Seelsorge/Diakonie") return listBox3;
            if (category == "Amtskalender: Mitarbeiterschaft/Gremien/Dienstbesprechung") return listBox4;
            if (category == "Amtskalender: Bibelarbeit/Erwachsenenbildung") return listBox5;
            if (category == "Amtskalender: Unterricht/Jugendarbeit") return listBox6;
            return null;
        }

        private void SortListBox(ListBox Box)
        {
            BindingList<Outlook.AppointmentItem> BL = (BindingList<Outlook.AppointmentItem>)Box.DataSource;
            List<Outlook.AppointmentItem> SortableList = BL.ToList<Outlook.AppointmentItem>();
            BL.Clear();
            foreach (Outlook.AppointmentItem Item in SortableList.OrderBy(s => s.Start)) BL.Add(Item);
        }


        // drag and drop stuff follows...

        private Point mDownPos;
        void SourceItemsList_MouseDown(object sender, MouseEventArgs e)
        {
            mDownPos = e.Location;
        }

        void SourceItemsList_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            int index = ((ListBox)sender).IndexFromPoint(e.Location);
            if (index < 0) return;
            if (Math.Abs(e.X - mDownPos.X) >= SystemInformation.DragSize.Width ||
                Math.Abs(e.Y - mDownPos.Y) >= SystemInformation.DragSize.Height)
                DoDragDrop(new DragObject((ListBox)sender, ((ListBox)sender).Items[index]), DragDropEffects.Move);
        }

        void RecipientListBox_DragEnter(object sender, DragEventArgs e)
        {
            DragObject obj = e.Data.GetData(typeof(DragObject)) as DragObject;
            if (obj != null && obj.source != sender) e.Effect = e.AllowedEffect;
        }

        void RecipientListBox_DragDrop(object sender, DragEventArgs e)
        {
            ListBox SenderBox = (ListBox)sender;
            DragObject obj = e.Data.GetData(typeof(DragObject)) as DragObject;
            Outlook.AppointmentItem Item = (Outlook.AppointmentItem)obj.item;
            // add object to target listbox
            ((BindingList<Outlook.AppointmentItem>)SenderBox.DataSource).Add(Item);
            // remove object from source listbox
            ((BindingList<Outlook.AppointmentItem>)obj.source.DataSource).Remove(Item);

            // reassign categories
            Outlook.AppointmentItem ChangeItem = GetUpdateableItem(Item);
            string senderCategory = GetListBoxCategory(obj.source);
            if (senderCategory != "") ChangeItem.Categories = CategoryTools.RemoveCategory(ChangeItem.Categories, senderCategory);
            string newCategory = GetListBoxCategory(SenderBox);
            if (newCategory != "") ChangeItem.Categories = CategoryTools.AddCategory(ChangeItem.Categories, newCategory);
            ChangeItem.Save();

            SortListBox(SenderBox);
        }

        private Outlook.AppointmentItem GetUpdateableItem(Outlook.AppointmentItem Item)
        {
            if (Item.IsRecurring) return Item.Parent; else return Item;
        }

        private class DragObject
        {
            public ListBox source;
            public object item;
            public DragObject(ListBox box, object data) { source = box; item = data; }
        }

        // Month selection

        private void btnMonthPrev_Click(object sender, EventArgs e)
        {
            ReferenceDate.Value = ReferenceDate.Value.AddMonths(-1);
            LoadItems();
        }

        private void btnMonthNext_Click(object sender, EventArgs e)
        {
            ReferenceDate.Value = ReferenceDate.Value.AddMonths(1);
            LoadItems();
        }

        private void ReferenceDate_ValueChanged(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void AppointmentItemDoubleClick(object sender, EventArgs e)
        {

        }

        private void AppointmentItemDoubleClick(object sender, MouseEventArgs e)
        {
            int index = ((ListBox)sender).IndexFromPoint(e.Location);
            Outlook.AppointmentItem Item = (Outlook.AppointmentItem)((ListBox)sender).Items[index];
            Item.Display(true);
            LoadItems();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
