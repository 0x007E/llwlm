using LibraryManagement.Core;
using LibraryManagement.Core.Services.BookDataServices;
using LibraryManagement.Domain;

namespace LibraryManagement.Forms
{
    public partial class FormMain : Form
    {
        private IDataService<Book> _dataService;
        private Book _book;

        public FormMain() => InitializeComponent();

        private void FormMain_Load(object sender, EventArgs e)
        {
            //_dataService = new BookListDataService();
            //_dataService = new BookSQLiteDataService(new SqliteConnection("Data Source=Books.db"));
            _dataService = new BookFileDataService("Book.dat");

            DataGrid_Update();

            buttonInsert.Enabled = true;
        }

        private void buttonAddorUpdate_Click(object sender, EventArgs e)
        {
            Book b = sender == buttonInsert ? new() : _book;

            if (new FormData(b).ShowDialog() == DialogResult.OK)
            {
                if (sender == buttonInsert)
                {
                    try
                    {
                        _dataService.Insert(b);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    _dataService.Update(b.Id, b);
                }
            }
            DataGrid_Update();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;

            try
            {
                _dataService.Delete(_book.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataGrid_Update();
        }

        private void dataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            _book = null;

            try
            {
                _book = dataGridViewBooks?.CurrentRow?.DataBoundItem as Book;
            }
            catch { }
        }

        private void DataGrid_Update()
        {
            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.DataSource = _dataService.GetAll();

            buttonUpdate.Enabled = !(dataGridViewBooks.Rows.Count == 0);
            buttonDelete.Enabled = !(dataGridViewBooks.Rows.Count == 0);
        }

        //private async void FormMain_Load(object sender, EventArgs e)
        //{
        //    await Task.Delay(5000);
        //    await Task.Run(() =>
        //    {
        //        _dataService = new BookSQLiteDataService(new SqliteConnection("Data Source=Books.db"));

        //    });
        //    await DataGrid_Update();

        //    buttonInsert.Enabled = true;
        //}

        //private async void buttonAddorUpdate_Click(object sender, EventArgs e)
        //{
        //    Book b = sender == buttonInsert ? new() : _book;

        //    if (new FormData(b).ShowDialog() == DialogResult.OK)
        //    {
        //        await Task.Run(() =>
        //        {
        //            if (sender == buttonInsert)
        //            {
        //                _dataService.Insert(b);
        //            }
        //            else
        //            {
        //                _dataService.Update(b.Id, b);
        //            }
        //        });
        //    }
        //    await DataGrid_Update();
        //}

        //private async void buttonDelete_Click(object sender, EventArgs e)
        //{
        //    buttonUpdate.Enabled = false;
        //    buttonDelete.Enabled = false;

        //    await Task.Delay(4000);
        //    await Task.Run(() =>
        //    {
        //        _dataService.Delete(_book.Id);

        //        DataGrid_Update();
        //    });
        //}

        //private Task DataGrid_Update()
        //{
        //    Task task = Task.Run(() =>
        //    {
        //        dataGridViewBooks.Invoke(() =>
        //        {
        //            dataGridViewBooks.DataSource = _dataService.GetAll();
        //        });

        //        buttonUpdate.Invoke(() =>
        //        {
        //            buttonUpdate.Enabled = !(dataGridViewBooks.Rows.Count == 0);
        //        });
        //        buttonDelete.Invoke(() =>
        //        {
        //            buttonDelete.Enabled = !(dataGridViewBooks.Rows.Count == 0);
        //        });
        //    });

        //    return task;
        //}
    }
}