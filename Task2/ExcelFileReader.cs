using ExcelDataReader;
using System.Data;
using Task2.Models;

namespace Task2
{
    public static class ExcelFileReader
    {
        static ExcelFileReader()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        public static IEnumerable<Turnover> ReadFile(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var data = reader.AsDataSet();
                    var dataTable = data.Tables[0];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string? cellString = row[0].ToString();
                        if (cellString?.Length == 4 && Int32.TryParse(cellString, out int balanceAccount))
                        {
                            var turnover = new Turnover
                            {
                                BalanceAccount = balanceAccount,
                                IncomingBalanceActive = Convert.ToDecimal(row[1]),
                                IncomingBalancePassive = Convert.ToDecimal(row[2]),
                                Debit = Convert.ToDecimal(row[3]),
                                Credit = Convert.ToDecimal(row[4]),
                                OutgoingBalanceActive = Convert.ToDecimal(row[5]),
                                OutgoingBalancePassive = Convert.ToDecimal(row[6]),
                            };
                            yield return turnover;
                        }
                    }
                }
            }
        }
    }
}
