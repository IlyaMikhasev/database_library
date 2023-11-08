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
            _dt_Author.Columns[0].AutoIncrement= true;
            _dt_Author.Columns[0].AutoIncrementStep = 1;
            _dt_Author.Columns[0].AutoIncrementSeed = IncrementSeed("Authors");
        }
        private void fillbooks(string author_id = "") {
            /* string sqltextb = "select * from Books";*/
            string sqltext = "select Books.id, Books.id_author, Authors.name as author, Books.name as book," +
                " Books.description as book_description from Books join Authors on Authors.id = Books.id_author";
            if (!string.IsNullOrEmpty(author_id))
            {
                sqltext = sqltext + " where id_author=" + author_id;
            }
            _dt_Books = new DataTable();
            _adapter_books = new SQLiteDataAdapter(sqltext, _conn);

            //Вариант 1
            _adapter_books.SelectCommand = new SQLiteCommand(sqltext, _conn);
            sqltext = @"insert into Books values (@id, @id_author, @name, @description);";
            _adapter_books.InsertCommand = new SQLiteCommand(sqltext, _conn);
            _adapter_books.InsertCommand.Parameters.Add("id", DbType.Int32, 5, "id");
            _adapter_books.InsertCommand.Parameters.Add("id_author", DbType.Int32, 5, "id_author");
            _adapter_books.InsertCommand.Parameters.Add("name", DbType.String, 20, "name");
            _adapter_books.InsertCommand.Parameters.Add("description", DbType.String, 100, "description");

            sqltext = @"update Books set id_author=@id_author, name=@name, description=@description;";
            _adapter_books.UpdateCommand = new SQLiteCommand(sqltext, _conn);
            _adapter_books.UpdateCommand.Parameters.Add("id", DbType.Int32, 5, "id");
            _adapter_books.UpdateCommand.Parameters.Add("id_author", DbType.Int32, 5, "id_author");
            _adapter_books.UpdateCommand.Parameters.Add("name", DbType.String, 20, "name");
            _adapter_books.UpdateCommand.Parameters.Add("description", DbType.String, 100, "description");

            sqltext = @"delete from Books where id=@id;";
            _adapter_books.DeleteCommand = new SQLiteCommand(sqltext, _conn);
            _adapter_books.DeleteCommand.Parameters.Add("id", DbType.Int32, 5, "id");

            _adapter_books.Fill(_dt_Books);
            dGrid_books.DataSource = _dt_Books;
            _dt_Books.Columns[0].AutoIncrement = true;
            _dt_Books.Columns[0].AutoIncrementStep = 1;
            _dt_Books.Columns[0].AutoIncrementSeed = IncrementSeed("Books");

            (dGrid_books.Columns["famaly"] as DataGridViewComboBoxColumn).DataSource = _dt_Author;
            (dGrid_books.Columns["famaly"] as DataGridViewComboBoxColumn).DataPropertyName = "id_author";
            (dGrid_books.Columns["famaly"] as DataGridViewComboBoxColumn).ValueMember= "id";
            (dGrid_books.Columns["famaly"] as DataGridViewComboBoxColumn).DisplayMember= "name";
        }
        private int IncrementSeed(string tableName) {
            int seed = 0;
            string sqltext = " select max(id) from " + tableName;
            SQLiteCommand command = new SQLiteCommand(sqltext, _conn);
            _conn.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                seed = reader.GetInt32(0);
            }
            _conn.Close();
            return ++seed;
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

        private void dGrid_books_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
