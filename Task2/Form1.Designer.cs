namespace Task2
{
    partial class Form1
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
            this._turnoversGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._addTableButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._fileNamesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._turnoversGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // _turnoversGrid
            // 
            this._turnoversGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this._turnoversGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._turnoversGrid.ColumnHeadersVisible = false;
            this._turnoversGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this._turnoversGrid.Location = new System.Drawing.Point(37, 74);
            this._turnoversGrid.Name = "_turnoversGrid";
            this._turnoversGrid.RowHeadersVisible = false;
            this._turnoversGrid.RowHeadersWidth = 51;
            this._turnoversGrid.Size = new System.Drawing.Size(1085, 613);
            this._turnoversGrid.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // _addTableButton
            // 
            this._addTableButton.Location = new System.Drawing.Point(1158, 87);
            this._addTableButton.Name = "_addTableButton";
            this._addTableButton.Size = new System.Drawing.Size(210, 29);
            this._addTableButton.TabIndex = 1;
            this._addTableButton.Text = "Добавить таблицу";
            this._addTableButton.UseVisualStyleBackColor = true;
            this._addTableButton.Click += new System.EventHandler(this.AddTableButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "file.xls";
            this.openFileDialog.Filter = "Office Files|*.xls;*.xlsx;*.xlsb";
            // 
            // _fileNamesListBox
            // 
            this._fileNamesListBox.FormattingEnabled = true;
            this._fileNamesListBox.ItemHeight = 20;
            this._fileNamesListBox.Location = new System.Drawing.Point(1158, 164);
            this._fileNamesListBox.Name = "_fileNamesListBox";
            this._fileNamesListBox.Size = new System.Drawing.Size(210, 524);
            this._fileNamesListBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(107, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(879, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Оборотная ведомость по балансовым счетам за период с 01.01.2016 по 31.12.2016";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1162, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Загруженные файлы:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 762);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._fileNamesListBox);
            this.Controls.Add(this._addTableButton);
            this.Controls.Add(this._turnoversGrid);
            this.Name = "Form1";
            this.Text = "ОВС";
            ((System.ComponentModel.ISupportInitialize)(this._turnoversGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView _turnoversGrid;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private Button _addTableButton;
        private OpenFileDialog openFileDialog;
        private ListBox _fileNamesListBox;
        private Label label1;
        private Label label2;
    }
}