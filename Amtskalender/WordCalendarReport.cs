using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace Amtskalender
{
    class WordCalendarReport
    {

        private Word.Application Application;
        private List<Outlook.AppointmentItem> Items;
        private DateTime StartDate;
        private DateTime EndDate;

        private Word.Document Document;


        private List<Outlook.AppointmentItem> TopicalList1 = new List<Outlook.AppointmentItem>();
        private List<Outlook.AppointmentItem> TopicalList2 = new List<Outlook.AppointmentItem>();
        private List<Outlook.AppointmentItem> TopicalList3 = new List<Outlook.AppointmentItem>();
        private List<Outlook.AppointmentItem> TopicalList4 = new List<Outlook.AppointmentItem>();
        private List<Outlook.AppointmentItem> TopicalList5 = new List<Outlook.AppointmentItem>();
        private List<Outlook.AppointmentItem> TopicalList6 = new List<Outlook.AppointmentItem>();
        private List<List<Outlook.AppointmentItem>> TopicalLists = new List<List<Outlook.AppointmentItem>>();

        private bool IsFirstParagraph = true;

        public WordCalendarReport(DateTime startDate, DateTime endDate, List<Outlook.AppointmentItem> items)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Items = items;

            // create collection of TopicalLists
            TopicalLists.Add(TopicalList1);
            TopicalLists.Add(TopicalList2);
            TopicalLists.Add(TopicalList3);
            TopicalLists.Add(TopicalList4);
            TopicalLists.Add(TopicalList5);
            TopicalLists.Add(TopicalList6);


            // create Word application
            this.Application = new Word.Application();
            this.Application.Visible = true;

            // create document
            this.Document = this.Application.Documents.Add();
        }

        private Word.Paragraph CreateParagraph(string text, int fontSize = 10)
        {
            if (!this.IsFirstParagraph) this.Document.Paragraphs.Add();
            this.IsFirstParagraph = false;
            Word.Paragraph par = this.Document.Paragraphs.Add();
            par.Range.Text = text;
            par.Range.Font.Name = "Times New Roman";
            par.Range.Font.Size = fontSize;
            return par;
        }

        private void CreatePageBreak()
        {
            Word.Paragraph par = this.CreateParagraph("", 1);
            par.Range.InsertBreak(Word.WdBreakType.wdPageBreak);
        }

        private Word.Paragraph CreatePageHeading(string text)
        {
            if (!this.IsFirstParagraph) CreatePageBreak();
            Word.Paragraph par = this.CreateParagraph(text, 18);
            par.Range.Font.Bold = 1;
            return par;
        }

        private IEnumerable<Outlook.AppointmentItem> FilterItemsByDateRange(List<Outlook.AppointmentItem> items, DateTime start, DateTime end) {
            return items.Where(i => i.Start >= start && i.Start <= end);
        }


        private IEnumerable<Outlook.AppointmentItem> FilterItemsByDay(List<Outlook.AppointmentItem> items, DateTime day)
        {
            DateTime dayEnd = new DateTime(day.Year, day.Month, day.Day, 23, 59, 59);
            return FilterItemsByDateRange(items, day, dayEnd);
        }

        private IEnumerable<Outlook.AppointmentItem> FilterItemsByMonth(List<Outlook.AppointmentItem> items, DateTime referenceDay)
        {
            DateTime start = new DateTime(referenceDay.Year, referenceDay.Month, 1, 0, 0, 0);
            DateTime end = start.AddMonths(1).AddSeconds(-1);
            return FilterItemsByDateRange(items, start, end);
        }


        private List<Outlook.AppointmentItem> GetTopicalList(Outlook.AppointmentItem Item)
        {
            if (CategoryTools.HasCategory(Item.Categories, "Amtskalender: Gottesdienst/Taufe/Abendmahl")) return TopicalList1;
            if (CategoryTools.HasCategory(Item.Categories, "Amtskalender: Amtshandlungen")) return TopicalList2;
            if (CategoryTools.HasCategory(Item.Categories, "Amtskalender: Seelsorge/Diakonie")) return TopicalList3;
            if (CategoryTools.HasCategory(Item.Categories, "Amtskalender: Mitarbeiterschaft/Gremien/Dienstbesprechung")) return TopicalList4;
            if (CategoryTools.HasCategory(Item.Categories, "Amtskalender: Bibelarbeit/Erwachsenenbildung")) return TopicalList5;
            if (CategoryTools.HasCategory(Item.Categories, "Amtskalender: Unterricht/Jugendarbeit")) return TopicalList6;
            return null;
        }

        public void Output()
        {
            // need to start at the beginning of the month
            DateTime CurrentMonthStart = new DateTime(this.StartDate.Year, this.StartDate.Month, 1, 0, 0, 0);
            List<Outlook.AppointmentItem> MonthItems = new List<Outlook.AppointmentItem>();

            while (CurrentMonthStart <= this.EndDate)
            {
                // clear Lists
                foreach (List<Outlook.AppointmentItem> List in TopicalLists) List.Clear();
                MonthItems.Clear();

                // get all items for this month
                foreach (Outlook.AppointmentItem Item in this.FilterItemsByMonth(this.Items, CurrentMonthStart))
                {
                    MonthItems.Add(Item);
                    List<Outlook.AppointmentItem> TopicalList = GetTopicalList(Item);
                    if (TopicalList != null) TopicalList.Add(Item);
                }

                // output this month
                CreateMonthlyTopics(CurrentMonthStart);
                CreateMonthlyCalendar(CurrentMonthStart, MonthItems);

                // advance to next month
                CurrentMonthStart = CurrentMonthStart.AddMonths(1);
            }

        }

        private string TopicalListToText(List<Outlook.AppointmentItem> List)
        {
            string Text = "";
            foreach (Outlook.AppointmentItem Item in List)
            {
                Text += Item.Start.ToString("dd") + ". " + Item.Subject + '\r' + '\n';
            }
            return Text;
        }

        private Word.Table CreateTopicalTable(DateTime CurrentMonthStart, int startingCategory)
        {
            this.CreatePageHeading(CurrentMonthStart.ToString("MMMM yyyy"));

            // create new table
            Word.Paragraph CurrentParagraph = this.CreateParagraph("");
            Word.Table Table = this.Document.Tables.Add(CurrentParagraph.Range, 2, 3);
            Table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            Table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            Table.Range.Font.Size = 12;
            Table.Range.Font.Name = "Times New Roman";
            Table.Rows[1].Height = this.Application.CentimetersToPoints((float)1.4);
            Table.Rows[1].Range.Font.Bold = 0;
            Table.Rows[2].Height = this.Application.CentimetersToPoints((float)21);
            Table.Rows[2].Range.Font.Bold = 0;


            for (int i = 1; i<= 3; i++)
            {
                Table.Cell(1, i).Range.Text = Globals.ThisAddIn.Categories[startingCategory-1+i].Replace("Amtskalender: ", "").Replace("/", ", ");
            }

            return Table;
        }

        private void CreateMonthlyTopics(DateTime CurrentMonthStart) {
            Word.Table Table = CreateTopicalTable(CurrentMonthStart, 0);
            Table.Cell(2, 1).Range.Text = TopicalListToText(TopicalList1);
            Table.Cell(2, 2).Range.Text = TopicalListToText(TopicalList2);
            Table.Cell(2, 3).Range.Text = TopicalListToText(TopicalList3);

            Table = CreateTopicalTable(CurrentMonthStart, 3);
            Table.Cell(2, 1).Range.Text = TopicalListToText(TopicalList6);
            Table.Cell(2, 2).Range.Text = TopicalListToText(TopicalList5);
            Table.Cell(2, 3).Range.Text = TopicalListToText(TopicalList4);
        }

        private void CreateMonthlyCalendar(DateTime CurrentDay, List<Outlook.AppointmentItem> Items)
        {
            DateTime MonthEnd = CurrentDay.AddMonths(1).AddSeconds(-1);

            this.CreatePageHeading(CurrentDay.ToString("MMMM yyyy"));

            // create new table
            Word.Paragraph CurrentParagraph = this.CreateParagraph("");
            Word.Table Table = this.Document.Tables.Add(CurrentParagraph.Range, MonthEnd.Day, 3);
            Table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            Table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleNone;

            // format table
            Table.Range.Font.Size = 10;
            Table.Range.Font.Name = "Times New Roman";
            Table.Range.Font.Bold = 0;
            Table.Columns[1].Width = this.Application.CentimetersToPoints((float)0.75);
            Table.Columns[2].Width = this.Application.CentimetersToPoints((float)0.75);
            Table.Columns[3].Width = this.Application.CentimetersToPoints((float)14.5);

            while (CurrentDay <= MonthEnd)
            {
                Table.Rows[CurrentDay.Day].HeightRule = Word.WdRowHeightRule.wdRowHeightExactly;
                Table.Rows[CurrentDay.Day].Height = this.Application.CentimetersToPoints((float)0.5);

                Table.Cell(CurrentDay.Day, 1).Range.Text = CurrentDay.Day.ToString();
                Table.Cell(CurrentDay.Day, 2).Range.Text = CurrentDay.ToString("ddd");

                // Appointments for the day
                int ctr = 0;
                string dayText = "";
                foreach (Outlook.AppointmentItem item in this.FilterItemsByDay(Items, CurrentDay))
                {
                    if (ctr > 0) dayText = dayText + " // ";
                    dayText = dayText + item.Subject;
                    ctr++;
                }
                if (dayText != "") Table.Cell(CurrentDay.Day, 3).Range.Text = dayText;

                if (CurrentDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    Table.Rows[CurrentDay.Day].Borders[Word.WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                }

                CurrentDay = CurrentDay.AddDays(1);
            }

        }

    }
}
