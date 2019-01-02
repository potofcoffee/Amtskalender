using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;

namespace Amtskalender
{
    public partial class DlgCreateCalendarReport : Form
    {
        private List<MAPIFolder> calendars = new List<MAPIFolder>();

        public DlgCreateCalendarReport()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }





        private void DlgCreateCalendarReport_Load(object sender, EventArgs e)
        {
            startDate.MaxDate = DateTime.Today;
            endDate.MaxDate = DateTime.Today;

            foreach (MAPIFolder Folder in Globals.ThisAddIn.Calendars.GetAll()) this.calendars.Add(Folder);
            
            MAPIFolder defaultCalendar = Globals.ThisAddIn.Application.Session.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
            foreach (MAPIFolder calendar in this.calendars)
            {
                int idx = this.calendarList.Items.Add(calendar.Name + " (" + calendar.Store.DisplayName + ")");
                if (defaultCalendar == calendar) this.calendarList.SetItemChecked(idx, true);
            }
        }

        private MAPIFolder FindCalendarFolder(string name)
        {
            string calendarName = name.Substring(0, name.IndexOf(" ("));
            string storeName = name.Substring(name.IndexOf(" (") + 2);
            storeName = storeName.Substring(0, storeName.Length - 1);

            foreach (MAPIFolder folder in this.calendars)
            {
                if ((folder.Name == calendarName) && (folder.Store.DisplayName == storeName)) return folder;
            }
            return null;
        }

        public List<MAPIFolder> GetSelectedCalendars()
        {
            List<MAPIFolder> myList = new List<MAPIFolder>();
            foreach (string calendar in this.calendarList.CheckedItems)
            {
                myList.Add(this.FindCalendarFolder(calendar));
            }
            return myList;
        }

        public DateTime getStartDate()
        {
            return this.startDate.Value;
        }

        public DateTime getEndDate()
        {
            return this.endDate.Value;
        }

    }
}
