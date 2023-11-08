namespace database_library
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menustrip_chooseBD = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menustrip_CreateTable = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dGrid_author = new System.Windows.Forms.DataGridView();
            this.b_update = new System.Windows.Forms.Button();
            this.dGrid_books = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.famaly = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_author)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_books)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1004, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menustrip_chooseBD});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // menustrip_chooseBD
            // 
            this.menustrip_chooseBD.Name = "menustrip_chooseBD";
            this.menustrip_chooseBD.Size = new System.Drawing.Size(192, 22);
            this.menustrip_chooseBD.Text = "Выбрать базу данных";
            this.menustrip_chooseBD.Click += new System.EventHandler(this.menustrip_chooseBD_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menustrip_CreateTable});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // menustrip_CreateTable
            // 
            this.menustrip_CreateTable.Name = "menustrip_CreateTable";
            this.menustrip_CreateTable.Size = new System.Drawing.Size(168, 22);
            this.menustrip_CreateTable.Text = "Создать таблицы";
            this.menustrip_CreateTable.Click += new System.EventHandler(this.menustrip_CreateTable_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dGrid_author
            // 
            this.dGrid_author.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGrid_author.Location = new System.Drawing.Point(13, 27);
            this.dGrid_author.Name = "dGrid_author";
            this.dGrid_author.Size = new System.Drawing.Size(376, 563);
            this.dGrid_author.TabIndex = 1;
            this.dGrid_author.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dGrid_author_CellMouseDoubleClick);
            // 
            // b_update
            // 
            this.b_update.Location = new System.Drawing.Point(890, 27);
            this.b_update.Name = "b_update";
            this.b_update.Size = new System.Drawing.Size(105, 23);
            this.b_update.TabIndex = 2;
            this.b_update.Text = "update";
            this.b_update.UseVisualStyleBackColor = true;
            this.b_update.Click += new System.EventHandler(this.b_update_Click);
            // 
            // dGrid_books
            // 
            this.dGrid_books.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGrid_books.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.famaly,
            this.name,
            this.desc});
            this.dGrid_books.Location = new System.Drawing.Point(395, 27);
            this.dGrid_books.Name = "dGrid_books";
            this.dGrid_books.Size = new System.Drawing.Size(489, 563);
            this.dGrid_books.TabIndex = 3;
            this.dGrid_books.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGrid_books_CellContentClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // famaly
            // 
            this.famaly.DataPropertyName = "id_author";
            this.famaly.HeaderText = "Фио";
            this.famaly.Name = "famaly";
            this.famaly.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.famaly.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // name
            // 
            this.name.HeaderText = "Название";
            this.name.Name = "name";
            // 
            // desc
            // 
            this.desc.HeaderText = "примечание";
            this.desc.Name = "desc";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 675);
            this.Controls.Add(this.dGrid_books);
            this.Controls.Add(this.b_update);
            this.Controls.Add(this.dGrid_author);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_author)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_books)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menustrip_chooseBD;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menustrip_CreateTable;
        private System.Windows.Forms.DataGridView dGrid_author;
        private System.Windows.Forms.Button b_update;
        private System.Windows.Forms.DataGridView dGrid_books;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewComboBoxColumn famaly;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
    }
}

