using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Amtskalender
{
    public partial class ThisAddIn
    {
        public CalendarRepository Calendars = new CalendarRepository();
        public List<String> Categories = new List<String>();

        private void CreateMissingCategories()
        {
            foreach (String CategoryName in Categories)
            {
                bool found = false;
                foreach (Outlook.Category Category in Application.GetNamespace("MAPI").Categories) if (Category.Name == CategoryName) found = true;
                if (!found) Application.GetNamespace("MAPI").Categories.Add(CategoryName, Outlook.OlCategoryColor.olCategoryColorNone);
            }
        }


        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Categories.Add("Amtskalender: Gottesdienst/Taufe/Abendmahl");
            Categories.Add("Amtskalender: Amtshandlungen");
            Categories.Add("Amtskalender: Seelsorge/Diakonie");
            Categories.Add("Amtskalender: Unterricht/Jugendarbeit");
            Categories.Add("Amtskalender: Bibelarbeit/Erwachsenenbildung");
            Categories.Add("Amtskalender: Mitarbeiterschaft/Gremien/Dienstbesprechung");
            CreateMissingCategories();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Hinweis: Outlook löst dieses Ereignis nicht mehr aus. Wenn Code vorhanden ist, der 
            //    muss ausgeführt werden, wenn Outlook heruntergefahren wird. Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=506785.
        }

        /// <summary>
        /// Create a calendar report
        /// This will show the create dialog, where source calendars and date range can be selected.
        /// It will then create a new word document in the prescribed calendar format and fill it with
        /// the info for the calendars and dates selected.
        /// </summary>
        public void CreateCalendarReport()
        {
            // show dialog to select date range and calendars
            DlgCreateCalendarReport dialog = new DlgCreateCalendarReport();
            DialogResult DlgResult = dialog.ShowDialog();
            if (DlgResult == DialogResult.OK) {

                List <Outlook.AppointmentItem> items = new List<Outlook.AppointmentItem>();
                DateTime startDate = dialog.getStartDate();
                DateTime endDate = dialog.getEndDate();

                // set correct time values 
                startDate = new DateTime(startDate.Year, startDate.Month, 1, 0, 0, 0);
                endDate = new DateTime(endDate.Year, endDate.Month, 1, 0, 0, 0).AddMonths(1).AddSeconds(-1);

                // get all AppointmentItems
                foreach (Outlook.MAPIFolder folder in dialog.GetSelectedCalendars()) {
                    Calendar Calendar = new Calendar(folder);
                    foreach (Outlook.AppointmentItem Item in Calendar.GetAllForRange(startDate, endDate)) items.Add(Item);
                }

                // output to word document
                WordCalendarReport report = new WordCalendarReport(startDate, endDate, items);
                report.Output();
            }
        }

        /// <summary>
        /// Show the "Categorize" dialog
        /// This dialog allows easy drag and drop of AppointmentItems into one of the six prescribed calendar
        /// categories. On drop, they will be automatically recategorized.
        /// </summary>
        public void Categorize()
        {
            DlgCategorize dialog = new DlgCategorize();
            dialog.Show();
        }

        /// <summary>
        /// Show the rules for automatic categorization
        /// @TODO: Implement rules
        /// </summary>
        public void ShowRules()
        {
        }

        /// <summary>
        /// Delete all birthdays from default calendar
        /// </summary>
        public void DeleteAllBirthdays()
        {
            Calendar DefaultCalendar = new Calendar(Calendars.GetDefault());
            DefaultCalendar.DeleteBirthdays();
        }

        #region Von VSTO generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
