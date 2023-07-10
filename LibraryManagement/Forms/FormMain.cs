using LibraryManagement.Core;
using LibraryManagement.DataAccess;
using LibraryManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Forms
{
    public partial class FormMain : Form
    {
        //private IDataService<Book> dataService = new ListDataService();
        //private IDataService<Book> dataService = new DbDataService(new("Data Source=Library.db"));

        private IDataService<Book> dataService = 
            new Db2DataService(
                new SQLiteConnection("Data Source=Library.db"),
                new DirectoryInfo(@".\Databases\SQL\SQLite\"));
        private Book book;

        List<Book> books = new();

        public FormMain()
        {
            this.InitializeComponent();
            this.Data_Reload();
        }

        private void Data_Reload()
        {
            this.dataGridViewData.DataSource = null;
            this.dataGridViewData.DataSource = this.dataService.Get();

            this.Button_Status();
        }

        private void Button_Status()
        {
            if (this.dataGridViewData.RowCount == 0)
            {
                this.buttonUpdate.Enabled = false;
                this.buttonDelete.Enabled = false;
            }
            else
            {
                this.buttonUpdate.Enabled = true;
                this.buttonDelete.Enabled = true;
            }
        }

        private void buttonCreateOrUpdate_Click(object sender, EventArgs e)
        {
            Book b = this.book;

            if (sender == buttonCreate)
            {
                b = new Book();
            }

            if (new FormData(this.dataService, b).ShowDialog() != DialogResult.OK)
                return;

            this.Data_Reload();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Wirklich löschen", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.dataService.Delete(book.Id);
                this.Data_Reload();
            }
        }

        private void dataGridViewData_SelectionChanged(object sender, EventArgs e)
        {
            book = null;

            try
            {
                book = dataGridViewData.CurrentRow.DataBoundItem as Book;
            }
            catch { }
        }
    }
}
