using LibraryManagement.Core;
using LibraryManagement.Domain;
using LibraryManagement.Domain.Exeptions;
using LibraryManagement.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Forms
{
    public partial class FormData : Form
    {
        private IDataService<Book> service;
        private Book book;

        public FormData(IDataService<Book> service, Book book)
        {
            InitializeComponent();

            this.book = book;
            this.service = service;
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            if (this.book.Id == 0)
            {
                this.Text = "Hinzufügen";
                this.buttonDo.Text = "Hinzufügen";
            }
            else
            {
                this.Text = "Bearbeiten";
                this.buttonDo.Text = "Bearbeiten";

                this.textBoxISBN.ReadOnly = true;
                this.textBoxISBN.Text = this.book.ISBN;
                this.textBoxTitle.Text = this.book.Title;
                this.textBoxAutor.Text = this.book.Author;
            }
        }

        private void buttonDo_Click(object sender, EventArgs e)
        {
            this.TextBoxClearError(new[]
            {
                this.textBoxISBN,
                this.textBoxTitle,
                this.textBoxAutor
            });

            this.book.ISBN = this.textBoxISBN.Text;
            this.book.Title = this.textBoxTitle.Text;
            this.book.Author = this.textBoxAutor.Text;

            try
            {
                if (this.book.Id == 0)
                {
                    this.service.Insert(book);
                }
                else
                {
                    this.service.Update(book.Id, book);
                }
            }
            catch (BookException bookex)
            {
                switch (bookex.Accessor)
                {
                    case nameof(Book.ISBN):
                        this.TextBoxShowError(textBoxISBN, bookex.Message);
                        break;
                    case nameof(Book.Title):
                        this.TextBoxShowError(textBoxTitle, bookex.Message);
                        break;
                    case nameof(Book.Author):
                        this.TextBoxShowError(textBoxAutor, bookex.Message);
                        break;
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TextBoxShowError(TextBox textBox, string message)
        {
            this.errorProvider.SetError(textBox, message);

            textBox.BackColor = Color.Red;
            textBox.Focus();
            textBox.SelectAll();
        }

        private void TextBoxClearError(IEnumerable<TextBox> textBoxes)
        {
            textBoxes.ToList().ForEach(t =>
            {
                this.errorProvider.SetError(t, string.Empty);
                t.BackColor = Color.White;
            });
        }
    }
}
