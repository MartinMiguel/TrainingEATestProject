using EAAutoFramework.Helpers.Data;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace EAAutoFramework.Helpers
{
	public class ExcelHelpers
	{
		private static List<DataCollection> _dataCol = new List<DataCollection>();

		public static void PopulateInCollection(string fileName)
		{
			DataTable table = ExcelToDataTable(fileName);

			for (int row = 1; row <= table.Rows.Count; row++)
			{
				for (int col = 0; col < table.Columns.Count; col++)
				{
					DataCollection dtTable = new DataCollection()
					{
						rowNumber = row,
						colName = table.Rows[0][col].ToString(),
						colValue = table.Rows[row - 1][col].ToString()

					};
					_dataCol.Add(dtTable);
				}
			}
		}

		public static string ReadData(int rowNumber, string columnName)
		{
			try
			{
				string data = (from colData in _dataCol
							   where colData.colName == columnName && colData.rowNumber == rowNumber
							   select colData.colValue).SingleOrDefault();
				return data.ToString();
			}
			catch (Exception e)
			{
				return null;
			}
		}



		private static DataTable ExcelToDataTable(string fileName)
		{
			DataTable resultTable = null;
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
			//open file and returns as Stream
			using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
			{
				using (var excelReader = ExcelReaderFactory.CreateReader(stream))
				{
					//Return as DataSet
					DataSet result = excelReader.AsDataSet();
					//Get all the Tables
					DataTableCollection table = result.Tables;
					//Store it in DataTable
					resultTable = table["Credentials"];
				}
			}

			return resultTable;
		}
	}
}
