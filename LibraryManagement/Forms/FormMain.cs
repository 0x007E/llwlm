using LibraryManagement.Core;
using LibraryManagement.DataAccess;
using LibraryManagement.DataAccess.Databases;
using LibraryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LibraryMangement.Forms
{
    public partial class FormMain : Form
    {
        //private IDataService<IBook> dataService = new ListDataService();
        private IDataService<IBook> dataService = new SQLiteDataService("Data Source=Library.db", @".\Databases\SQL\SQLite\");
        private IBook book;

        public FormMain()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledException_Handler;

            this.InitializeComponent();
            this.dataService.Refresh += Data_Reload;
        }

        private void FormMain_Load(object sender, EventArgs e) => this.Data_Reload(this, EventArgs.Empty);

        private void Data_Reload(object sender, EventArgs e)
        {
            this.dataGridViewBooks.DataSource = null;
            this.dataGridViewBooks.DataSource = this.dataService.Get();
            this.dataGridViewBooks.Invalidate();
        }

        private void dataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            book = null;

            try
            {
                book = dataGridViewBooks.CurrentRow.DataBoundItem as IBook;
            }
            catch { }

            ButtonStatus(!(this.book is null), new[] { this.buttonUpdate, this.buttonDelete });
        }

        private void buttonData_Click(object sender, EventArgs e)
        {
            IBook b;

            if (sender == buttonAdd)
                b = new Book();
            else if (sender == buttonUpdate)
                b = this.book;
            else
                throw new NullReferenceException(nameof(buttonData_Click));

            if (new FormData(b).ShowDialog() != DialogResult.OK)
                return;

            try
            {
                if (b.Id == 0)
                {
                    dataService.Insert(b);
                    return;
                }
                dataService.Update(b.Id, b);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.LibraryResource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.LibraryResource.DeleteBook, Resources.LibraryResource.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.dataService.Delete(book.Id);
        }

        private void ButtonStatus(bool status, IEnumerable<Button> buttons) => buttons.ToList().ForEach(b => b.Enabled = status);

        private void UnhandledException_Handler(object sender, UnhandledExceptionEventArgs e) => MessageBox.Show((e.ExceptionObject as Exception)?.Message, Resources.LibraryResource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
