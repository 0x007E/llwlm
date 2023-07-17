namespace LibraryManagement.Forms
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxData = new GroupBox();
            dataGridViewBooks = new DataGridView();
            buttonInsert = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            groupBoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            SuspendLayout();
            // 
            // groupBoxData
            // 
            groupBoxData.Controls.Add(dataGridViewBooks);
            groupBoxData.Location = new Point(12, 12);
            groupBoxData.Name = "groupBoxData";
            groupBoxData.Size = new Size(460, 308);
            groupBoxData.TabIndex = 0;
            groupBoxData.TabStop = false;
            groupBoxData.Text = "Bücher";
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(6, 22);
            dataGridViewBooks.MultiSelect = false;
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.ReadOnly = true;
            dataGridViewBooks.RowTemplate.Height = 25;
            dataGridViewBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBooks.Size = new Size(448, 280);
            dataGridViewBooks.TabIndex = 0;
            dataGridViewBooks.SelectionChanged += dataGridViewBooks_SelectionChanged;
            // 
            // buttonInsert
            // 
            buttonInsert.Enabled = false;
            buttonInsert.Location = new Point(310, 326);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(50, 23);
            buttonInsert.TabIndex = 1;
            buttonInsert.Text = "+";
            buttonInsert.UseVisualStyleBackColor = true;
            buttonInsert.Click += buttonAddorUpdate_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Enabled = false;
            buttonUpdate.Location = new Point(366, 326);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(50, 23);
            buttonUpdate.TabIndex = 2;
            buttonUpdate.Text = "U";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonAddorUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Enabled = false;
            buttonDelete.Location = new Point(422, 326);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(50, 23);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "-";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonInsert);
            Controls.Add(groupBoxData);
            Name = "FormMain";
            Text = "Bücherei";
            Load += FormMain_Load;
            groupBoxData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxData;
        private Button buttonInsert;
        private Button buttonUpdate;
        private Button buttonDelete;
        private DataGridView dataGridViewBooks;
    }
}