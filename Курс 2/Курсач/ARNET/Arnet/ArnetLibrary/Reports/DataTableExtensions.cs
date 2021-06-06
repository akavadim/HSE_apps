using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace Arnet.Reports
{
    public static class DataTableExtensions
    {
        public static byte[] ToCsv(this DataTable dataTable)
        {
            string res;

            string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                                  Select(column => column.ColumnName).
                                  ToArray();

            var header = string.Join(",", columnNames)+"\n";
            res = header;

            IEnumerable<string> valueLines = dataTable.AsEnumerable()
                               .Select(row => string.Join(",", row.ItemArray)+"\n");
            res+=string.Concat(valueLines);

            return Encoding.GetEncoding(1251).GetBytes(res);
        }
    }
}
