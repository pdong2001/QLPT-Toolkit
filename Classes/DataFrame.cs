using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Collection
{
    class DataFrame
    {
        private List<List<string>> rows = new List<List<string>>();
        private List<string> columns = new List<string>();

        public List<List<string>> Rows { get => rows; set => rows = value; }
        public List<string> Columns { get => columns; set => columns = value; }

    }
    class Cell<K, V>
    {
        public K Column { get; }
        public V Value { get; set; }
        public Cell(K Column, V Value)
        {
            this.Column = Column;
            this.Value = Value;
        }
    }
    class Row
    {
        List<Cell<string, string>> data = new List<Cell<string, string>>();
        public int Count { get => data.Count; }
        public Cell<string, string> this[int index] { get => data[index]; set => data[index] = value; }
        public Row(string ColumnName, params object[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                this.data.Add(new Cell<string, string>(ColumnName, data[i].ToString()));
            }
        }
    }
    class RowCollection
    {
        List<Row> data;
        List<string> Columns = new List<string>();

        public int Count { get => data.Count; }
        public Row this[int index] { get => data[index]; set => data[index] = value; }
        public void Add(params object[] data)
        {
        }
    }
    public class Column
    {
        string name = "";
        List<string> data = new List<string>();

        public string Name { get => name; set => name = value; }
        public List<string> Rows { get => data; set => data = value; }

        public Column(string Name)
        {
            this.Name = Name;
        }
        public Column(string Name, params string[] data)
        {
            this.Name = Name;
            this.Rows.AddRange(data);
        }
        public static List<Column> SplitDataTable(DataTable table)
        {
            List<Column> data = new List<Column>();

            for (int i = 0; i < table.Columns.Count; i++)
            {
                data.Add(new Column(table.Columns[i].ColumnName));
            }
            for (int i = 0; i < table.Columns.Count; i++)
            {
                Column temp = data[i];
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    temp.Rows.Add(table.Rows[j][i].ToString());
                }
            }
            return data;
        }
        public static DataTable ToTable(List<Column> data)
        {
            DataTable table = new DataTable();
            table.BeginInit();
            table.BeginLoadData();
            for (int i = 0; i < data.Count; i++)
            {
                table.Columns.Add(data[i].Name);
            }
            for (int i = 0; i < data[0].Rows.Count; i++)
            {
                object[] paras = new object[data.Count];
                for (int j = 0; j < data.Count; j++)
                {
                    paras[j] = data[j].Rows[i];
                }
                table.Rows.Add(paras);
            }
            table.EndLoadData();
            table.EndInit();
            return table;
        }
    }
    
}
