using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EAAutoFramework.Helpers
{
    public class HtmlHelperTable
    {
        private static List<TableDataCollection> _tableDataCollections;

        public static void ReadTable(IWebElement table)
        {
            //Initialize the table
            _tableDataCollections = new List<TableDataCollection>();

            //Get all the columns from the table
            var columns = table.FindElements(By.TagName("th"));

            //Get all the rows
            var rows = table.FindElements(By.TagName("tr"));

            //Create row index
            int rowIndex = 0;
            foreach (var row in rows)
            {
                int colIndex = 0;
                var colDatas = row.FindElements(By.TagName("td"));
                //Store data only if it has value in row
                if(colDatas.Count != 0)
                {
                    foreach (var colValue in colDatas)
                    {
                        _tableDataCollections.Add(new TableDataCollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = columns[colIndex].Text != "" ? columns[colIndex].Text : colIndex.ToString(),
                            ColumnValue = colValue.Text,
                            ColumnSpecialValues = GetControl(colValue)
                        }
                    }
                }
            }
        }

        private static ColumnSpecialValue GetControl(IWebElement columnValue)
        {
            ColumnSpecialValue columnSpecialValue = null;

            if (columnValue.FindElements(By.TagName("a")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("a")),
                    ControlType = "hyperlink"
                };
            }
            if (columnValue.FindElements(By.TagName("input")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("input")),
                    ControlType = "input"
                };
            }

            return columnSpecialValue;
        }

    }

    public class TableDataCollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public ColumnSpecialValue ColumnSpecialValue { get; set; }
    }

    public class ColumnSpecialValue
    {
        public IEnumerable<IWebElement> ElementCollection { get; set;}
        public string ControlType   { get; set; }
    }
}
