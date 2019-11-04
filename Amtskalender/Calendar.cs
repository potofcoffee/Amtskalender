using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Amtskalender
{
    class Calendar
    {

        private Outlook.MAPIFolder Folder;

        public Calendar(Outlook.MAPIFolder CalendarFolder)
        {
            this.Folder = CalendarFolder;
        }

        /// <summary>
        /// Get all the AppointmentItems in a given Month
        /// </summary>
        public IEnumerable<Outlook.AppointmentItem> GetAllForMonth(DateTime referenceDate)
        {
            DateTime startDate = new DateTime(referenceDate.Year, referenceDate.Month, 1, 0, 0, 0);
            DateTime endDate = startDate.AddMonths(1).AddSeconds(-1);

            return GetAllForRange(startDate, endDate);
        }

        public IEnumerable<Outlook.AppointmentItem> GetAllForRange(DateTime startDate, DateTime endDate)
        {
            List<Outlook.AppointmentItem> Items = new List<Outlook.AppointmentItem>();

            Outlook.Items FolderItems = Folder.Items;
            string filter = "[Start] >= '"
                + startDate.ToString("g")
                + "' AND [End] <= '"
                + endDate.ToString("g") + "'";
            FolderItems.IncludeRecurrences = true;
            FolderItems.Sort("[Start]", Type.Missing);

            foreach (Outlook.AppointmentItem Item in FolderItems.Restrict(filter)) Items.Add(Item);
            return Items;

        }

        public void DeleteBirthdays()
        {
            List<Outlook.AppointmentItem> Items = new List<Outlook.AppointmentItem>();
            foreach (Outlook.AppointmentItem Item in Folder.Items)
            {
                if (Item.Subject.StartsWith("Geburtstag von"))
                {
                    Items.Add(Item);
                }
            }
            foreach (Outlook.AppointmentItem Item in Items) Item.Delete();
        }
    }
}
