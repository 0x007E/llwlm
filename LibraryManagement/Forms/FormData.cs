using LibraryManagement.Core.Extensions;
using LibraryManagement.Domain;
using LibraryManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibraryMangement.Forms
{
    public partial class FormData : Form
    {
        private IBook book;

        public FormData(IBook book)
        {
            this.book = book;
            this.InitializeComponent();
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            if (this.book.Id == 0)
            {
                this.Text = Resources.LibraryResource.Create;
                this.buttonSend.Text = this.Text;
            }
            else
            {
                this.Text = Resources.LibraryResource.Update;
                this.buttonSend.Text = this.Text;

                this.textBoxISBN.ReadOnly = true;
                this.textBoxISBN.Text = this.book.ISBN;
                this.textBoxAuthor.Text = this.book.Author;
                this.textBoxTitle.Text = this.book.Title;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            this.TextBoxClearError(new[] { this.textBoxISBN, this.textBoxAuthor, this.textBoxTitle });

            this.book.ISBN = this.textBoxISBN.Text;
            this.book.Author = this.textBoxAuthor.Text;
            this.book.Title = this.textBoxTitle.Text;

            if (!this.ValidateTextBox())
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateTextBox()
        {
            try
            {
                this.book.ValidateBook();
            }
            catch (BookException bookex)
            {
                switch (bookex.Accessor)
                {
                    case nameof(IBook.ISBN):
                        this.TextBoxShowError(textBoxISBN, bookex.Message);
                        break;
                    case nameof(IBook.Title):
                        this.TextBoxShowError(textBoxTitle, bookex.Message);
                        break;
                    case nameof(IBook.Author):
                        this.TextBoxShowError(textBoxAuthor, bookex.Message);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.LibraryResource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void TextBoxShowError(TextBox textBox, string message)
        {
            this.errorProvider.SetError(textBox, message);
            textBox.BackColor = Color.Red;
            textBox.Focus();
            textBox.SelectAll();
        }

        private void TextBoxClearError(IEnumerable<TextBox> textBoxes) =>
            textBoxes.ToList().ForEach(t =>
            {
                this.errorProvider.SetError(t, string.Empty);
                t.BackColor = Color.White;
            });
    }
}
