
namespace LibraryMangement.Forms
{
    partial class FormData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxBook = new System.Windows.Forms.GroupBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelISBN = new System.Windows.Forms.Label();
            this.textBoxISBN = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxBook
            // 
            this.groupBoxBook.Controls.Add(this.buttonSend);
            this.groupBoxBook.Controls.Add(this.labelAuthor);
            this.groupBoxBook.Controls.Add(this.textBoxAuthor);
            this.groupBoxBook.Controls.Add(this.labelTitle);
            this.groupBoxBook.Controls.Add(this.textBoxTitle);
            this.groupBoxBook.Controls.Add(this.labelISBN);
            this.groupBoxBook.Controls.Add(this.textBoxISBN);
            this.groupBoxBook.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBook.Name = "groupBoxBook";
            this.groupBoxBook.Size = new System.Drawing.Size(359, 141);
            this.groupBoxBook.TabIndex = 3;
            this.groupBoxBook.TabStop = false;
            this.groupBoxBook.Tag = "";
            this.groupBoxBook.Text = "Buch";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(167, 109);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(146, 23);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "?";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(6, 83);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(40, 15);
            this.labelAuthor.TabIndex = 5;
            this.labelAuthor.Tag = "";
            this.labelAuthor.Text = "Autor:";
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(55, 80);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(258, 23);
            this.textBoxAuthor.TabIndex = 4;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(14, 54);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(32, 15);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Tag = "";
            this.labelTitle.Text = "Titel:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(55, 51);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(258, 23);
            this.textBoxTitle.TabIndex = 2;
            // 
            // labelISBN
            // 
            this.labelISBN.AutoSize = true;
            this.labelISBN.Location = new System.Drawing.Point(11, 25);
            this.labelISBN.Name = "labelISBN";
            this.labelISBN.Size = new System.Drawing.Size(35, 15);
            this.labelISBN.TabIndex = 1;
            this.labelISBN.Tag = "";
            this.labelISBN.Text = "ISBN:";
            // 
            // textBoxISBN
            // 
            this.textBoxISBN.Location = new System.Drawing.Point(55, 22);
            this.textBoxISBN.Name = "textBoxISBN";
            this.textBoxISBN.Size = new System.Drawing.Size(258, 23);
            this.textBoxISBN.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 165);
            this.Controls.Add(this.groupBoxBook);
            this.Name = "FormData";
            this.Text = "?";
            this.Load += new System.EventHandler(this.FormData_Load);
            this.groupBoxBook.ResumeLayout(false);
            this.groupBoxBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBook;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelISBN;
        private System.Windows.Forms.TextBox textBoxISBN;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}