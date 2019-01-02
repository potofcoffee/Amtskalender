using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Amtskalender
{
    public class CalendarRepository
    {

        public List<Outlook.MAPIFolder> GetAll()
        {
            List<Outlook.MAPIFolder> Folders = new List<Outlook.MAPIFolder>();
            // get all calendars
            foreach (Outlook.Store store in Globals.ThisAddIn.Application.Session.Stores)
            {
                foreach (Outlook.MAPIFolder Folder in this.GetCalendarSubFolders(store.GetRootFolder())) Folders.Add(Folder);
            }
            return Folders;
        }

        public List<Outlook.MAPIFolder> GetCalendarSubFolders(Outlook.MAPIFolder folder)
        {
            List<Outlook.MAPIFolder> Folders = new List<Outlook.MAPIFolder>();
            foreach (Outlook.MAPIFolder subFolder in folder.Folders)
            {
                if (subFolder.DefaultMessageClass == "IPM.Appointment") Folders.Add(subFolder);
                if (subFolder.Folders.Count > 0)
                {
                    foreach (Outlook.MAPIFolder Folder in this.GetCalendarSubFolders(subFolder)) Folders.Add(Folder);
                }
            }
            return Folders;
        }

        public Outlook.MAPIFolder GetFolderFromNameString(String name)
        {
            string calendarName = name.Substring(0, name.IndexOf(" ("));
            string storeName = name.Substring(name.IndexOf(" (") + 2);
            storeName = storeName.Substring(0, storeName.Length - 1);

            List<Outlook.MAPIFolder> Folders = this.GetAll();
            foreach (Outlook.MAPIFolder Folder in Folders)
            {
                if ((Folder.Name == calendarName) && (Folder.Store.DisplayName == storeName)) return Folder;
            }
            return null;
        } 


    }
}
