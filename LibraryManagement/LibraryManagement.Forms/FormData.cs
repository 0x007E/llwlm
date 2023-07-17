using LibraryManagement.Domain;
using LibraryManagement.Domain.Exceptions;
using LibraryManagement.Domain.Extensions;
using System.Windows.Forms;

namespace LibraryManagement.Forms
{
    public partial class FormData : Form
    {
        private Book _book;

        public FormData(Book book)
        {
            _book = book;
            InitializeComponent();
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            if (_book.Id == 0)
            {
                Text = "Hinzufügen";
                buttonDo.Text = "+";
            }
            else
            {
                Text = "Bearbeiten";
                buttonDo.Text = "U";

                textBoxISBN.ReadOnly = true;
                textBoxISBN.Text = _book.ISBN;
                textBoxTitle.Text = _book.Title;
                textBoxAuthor.Text = _book.Author;
            }
        }

        private void buttonDo_Click(object sender, EventArgs e)
        {
            _book.ISBN = textBoxISBN.Text;
            _book.Title = textBoxTitle.Text;
            _book.Author = textBoxAuthor.Text;

            TextBox_ClearError(textBoxISBN);
            TextBox_ClearError(textBoxTitle);
            TextBox_ClearError(textBoxAuthor);

            try
            {
                _book
                    .IsNotNull()
                    .RemoveCharsFromISBN()
                    .Validate();

                // Ohne Service nicht möglich, in FormMain verschoben
                //if (_book.Id == 0)
                //    _book.Duplicate();
            }
            catch (BookException ex)
            {
                switch (ex.Accessor)
                {
                    case nameof(Book.ISBN):
                        TextBox_SetError(textBoxISBN, ex.Message);
                        break;
                    case nameof(Book.Title):
                        TextBox_SetError(textBoxTitle, ex.Message);
                        break;
                    case nameof(Book.Author):
                        TextBox_SetError(textBoxAuthor, ex.Message);
                        break;
                    default:
                        throw new ArgumentException(ex.Message);
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Wenn alles i.O. ist
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TextBox_ClearError(TextBox textBox)
        {
            textBox.BackColor = Color.White;
            errorProvider.SetError(textBox, string.Empty);
        }

        private void TextBox_SetError(TextBox textBox, string message)
        {
            textBox.BackColor = Color.Red;
            textBox.Focus();
            textBox.SelectAll();
            errorProvider.SetError(textBox, message);
        }
    }
}
