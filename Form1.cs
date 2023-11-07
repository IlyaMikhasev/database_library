using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_library
{
    public partial class Form1 : Form
    {
        private SQLiteConnection _conn;
        private DataTable _dt_Author;
        private DataTable _dt_Books;
        private SQLiteDataAdapter _adapter_author;
        private SQLiteDataAdapter _adapter_books;
        public Form1()
        {
            InitializeComponent();
        }

        private void menustrip_chooseBD_Click(object sender, EventArgs e)
        {
            string filename;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) { 
                filename = openFileDialog1.FileName;
                _conn = new SQLiteConnection("Data Source="+filename);
                _conn.Open();
                string isTable = " select name from sqlite_master where type='table'";
                SQLiteCommand cmd= new SQLiteCommand(isTable,_conn);
                SQLiteDataReader reader= cmd.ExecuteReader();
                menustrip_CreateTable.Enabled = !reader.HasRows;
                _conn.Close();
                DataGridFill();
            }
        }

        private void menustrip_CreateTable_Click(object sender, EventArgs e)
        {
            string sqltext = "create table Authors (id int primary key, name varchar(20), description varchar(100)); " +
                "create table Books (id int primary key, id_author int, name varchar(20), description varchar(100));";
            SQLiteCommand command = new SQLiteCommand(sqltext, _conn);
            _conn.Open();
            command.ExecuteNonQuery();
            _conn.Close();
            menustrip_CreateTable.Enabled = false;
        }
        private void DataGridFill() {
            fillAuthor();
            fillbooks();
        }
        private void fillAuthor() {
            string sqltext = "select * from Authors; ";
            _adapter_author = new SQLiteDataAdapter(sqltext, _conn);
            _dt_Author = new DataTable();
            SQLiteCommandBuilder _author = new SQLiteCommandBuilder(_adapter_author);
            _adapter_author.Fill(_dt_Author);
            dGrid_author.DataSource = _dt_Author;
        }
        private void fillbooks(string author_id = "") {
            string sqltextb = "select * from Books";
            if (!string.IsNullOrEmpty(author_id))
                sqltextb += " where id_author = " + author_id;
            _adapter_books = new SQLiteDataAdapter(sqltextb, _conn);
            _dt_Books = new DataTable();
            SQLiteCommandBuilder _books = new SQLiteCommandBuilder(_adapter_books);
            _adapter_books.Fill(_dt_Books);
            dGrid_books.DataSource = _dt_Books;
        }
        private void b_update_Click(object sender, EventArgs e)
        {
            _adapter_author.Update(_dt_Author);
            Thread.Sleep(100);
            _adapter_books.Update(_dt_Books);
        }

        private void dGrid_author_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            fillbooks(dGrid_author[0, dGrid_author.CurrentRow.Index].Value.ToString());
        }
    }
}
