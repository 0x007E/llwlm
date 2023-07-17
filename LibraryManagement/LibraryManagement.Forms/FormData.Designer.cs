namespace LibraryManagement.Forms
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
            components = new System.ComponentModel.Container();
            groupBoxData = new GroupBox();
            buttonDo = new Button();
            textBoxAuthor = new TextBox();
            labelAuthor = new Label();
            textBoxTitle = new TextBox();
            labelTitle = new Label();
            textBoxISBN = new TextBox();
            labelISBN = new Label();
            errorProvider = new ErrorProvider(components);
            groupBoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // groupBoxData
            // 
            groupBoxData.Controls.Add(buttonDo);
            groupBoxData.Controls.Add(textBoxAuthor);
            groupBoxData.Controls.Add(labelAuthor);
            groupBoxData.Controls.Add(textBoxTitle);
            groupBoxData.Controls.Add(labelTitle);
            groupBoxData.Controls.Add(textBoxISBN);
            groupBoxData.Controls.Add(labelISBN);
            groupBoxData.Location = new Point(12, 12);
            groupBoxData.Name = "groupBoxData";
            groupBoxData.Size = new Size(260, 136);
            groupBoxData.TabIndex = 0;
            groupBoxData.TabStop = false;
            groupBoxData.Text = "Buch";
            // 
            // buttonDo
            // 
            buttonDo.Location = new Point(148, 103);
            buttonDo.Name = "buttonDo";
            buttonDo.Size = new Size(85, 23);
            buttonDo.TabIndex = 6;
            buttonDo.Text = "?";
            buttonDo.UseVisualStyleBackColor = true;
            buttonDo.Click += buttonDo_Click;
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.Location = new Point(63, 74);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new Size(170, 23);
            textBoxAuthor.TabIndex = 5;
            // 
            // labelAuthor
            // 
            labelAuthor.AutoSize = true;
            labelAuthor.Location = new Point(14, 77);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new Size(40, 15);
            labelAuthor.TabIndex = 4;
            labelAuthor.Text = "Autor:";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(63, 45);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(170, 23);
            textBoxTitle.TabIndex = 3;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(22, 48);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(32, 15);
            labelTitle.TabIndex = 2;
            labelTitle.Text = "Titel:";
            // 
            // textBoxISBN
            // 
            textBoxISBN.Location = new Point(63, 16);
            textBoxISBN.Name = "textBoxISBN";
            textBoxISBN.Size = new Size(170, 23);
            textBoxISBN.TabIndex = 1;
            // 
            // labelISBN
            // 
            labelISBN.AutoSize = true;
            labelISBN.Location = new Point(19, 19);
            labelISBN.Name = "labelISBN";
            labelISBN.Size = new Size(35, 15);
            labelISBN.TabIndex = 0;
            labelISBN.Text = "ISBN:";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // FormData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 160);
            Controls.Add(groupBoxData);
            Name = "FormData";
            Text = "?";
            Load += FormData_Load;
            groupBoxData.ResumeLayout(false);
            groupBoxData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxData;
        private TextBox textBoxISBN;
        private Label labelISBN;
        private TextBox textBoxAuthor;
        private Label labelAuthor;
        private TextBox textBoxTitle;
        private Label labelTitle;
        private Button buttonDo;
        private ErrorProvider errorProvider;
    }
}