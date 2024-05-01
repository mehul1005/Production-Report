using System.Drawing;
using System.Windows.Forms;

namespace Production_Report
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCsvFolder = new MetroFramework.Controls.MetroTextBox();
            this.btnBrowseFldr = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnGetReport = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtExcelFilePath = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.txtExcelFilePath01 = new MetroFramework.Controls.MetroTextBox();
            this.btnViewReport = new MetroFramework.Controls.MetroButton();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.comboBoxSheets = new System.Windows.Forms.ComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.lblTotal = new MetroFramework.Controls.MetroLabel();
            this.chkMoveFiles = new MetroFramework.Controls.MetroCheckBox();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCsvFolder
            // 
            // 
            // 
            // 
            this.txtCsvFolder.CustomButton.Image = null;
            this.txtCsvFolder.CustomButton.Location = new System.Drawing.Point(743, 1);
            this.txtCsvFolder.CustomButton.Name = "";
            this.txtCsvFolder.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCsvFolder.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCsvFolder.CustomButton.TabIndex = 1;
            this.txtCsvFolder.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCsvFolder.CustomButton.UseSelectable = true;
            this.txtCsvFolder.CustomButton.Visible = false;
            this.txtCsvFolder.Lines = new string[0];
            this.txtCsvFolder.Location = new System.Drawing.Point(103, 23);
            this.txtCsvFolder.MaxLength = 32767;
            this.txtCsvFolder.Name = "txtCsvFolder";
            this.txtCsvFolder.PasswordChar = '\0';
            this.txtCsvFolder.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCsvFolder.SelectedText = "";
            this.txtCsvFolder.SelectionLength = 0;
            this.txtCsvFolder.SelectionStart = 0;
            this.txtCsvFolder.ShortcutsEnabled = true;
            this.txtCsvFolder.Size = new System.Drawing.Size(765, 23);
            this.txtCsvFolder.TabIndex = 0;
            this.txtCsvFolder.UseSelectable = true;
            this.txtCsvFolder.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCsvFolder.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtCsvFolder.TextChanged += new System.EventHandler(this.txtCsvFolder_TextChanged);
            // 
            // btnBrowseFldr
            // 
            this.btnBrowseFldr.Location = new System.Drawing.Point(874, 23);
            this.btnBrowseFldr.Name = "btnBrowseFldr";
            this.btnBrowseFldr.Size = new System.Drawing.Size(94, 23);
            this.btnBrowseFldr.TabIndex = 1;
            this.btnBrowseFldr.Text = "Browse";
            this.btnBrowseFldr.UseSelectable = true;
            this.btnBrowseFldr.Click += new System.EventHandler(this.btnBrowseFldr_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(8, 25);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(75, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "CSV Folder";
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(874, 63);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(94, 23);
            this.btnGetReport.TabIndex = 3;
            this.btnGetReport.Text = "Get Report";
            this.btnGetReport.UseSelectable = true;
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(8, 65);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(67, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Excel Path";
            // 
            // txtExcelFilePath
            // 
            // 
            // 
            // 
            this.txtExcelFilePath.CustomButton.Image = null;
            this.txtExcelFilePath.CustomButton.Location = new System.Drawing.Point(743, 1);
            this.txtExcelFilePath.CustomButton.Name = "";
            this.txtExcelFilePath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtExcelFilePath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtExcelFilePath.CustomButton.TabIndex = 1;
            this.txtExcelFilePath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtExcelFilePath.CustomButton.UseSelectable = true;
            this.txtExcelFilePath.CustomButton.Visible = false;
            this.txtExcelFilePath.Lines = new string[0];
            this.txtExcelFilePath.Location = new System.Drawing.Point(103, 63);
            this.txtExcelFilePath.MaxLength = 32767;
            this.txtExcelFilePath.Name = "txtExcelFilePath";
            this.txtExcelFilePath.PasswordChar = '\0';
            this.txtExcelFilePath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtExcelFilePath.SelectedText = "";
            this.txtExcelFilePath.SelectionLength = 0;
            this.txtExcelFilePath.SelectionStart = 0;
            this.txtExcelFilePath.ShortcutsEnabled = true;
            this.txtExcelFilePath.Size = new System.Drawing.Size(765, 23);
            this.txtExcelFilePath.TabIndex = 4;
            this.txtExcelFilePath.UseSelectable = true;
            this.txtExcelFilePath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtExcelFilePath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.Controls.Add(this.txtExcelFilePath01);
            this.metroPanel1.Controls.Add(this.btnViewReport);
            this.metroPanel1.Controls.Add(this.txtExcelFilePath);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.txtCsvFolder);
            this.metroPanel1.Controls.Add(this.btnGetReport);
            this.metroPanel1.Controls.Add(this.btnBrowseFldr);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 821);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(980, 139);
            this.metroPanel1.TabIndex = 6;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(8, 103);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(89, 23);
            this.metroButton1.TabIndex = 9;
            this.metroButton1.Text = "Excel Browse";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.btnExcelBrowse);
            // 
            // txtExcelFilePath01
            // 
            // 
            // 
            // 
            this.txtExcelFilePath01.CustomButton.Image = null;
            this.txtExcelFilePath01.CustomButton.Location = new System.Drawing.Point(743, 1);
            this.txtExcelFilePath01.CustomButton.Name = "";
            this.txtExcelFilePath01.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtExcelFilePath01.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtExcelFilePath01.CustomButton.TabIndex = 1;
            this.txtExcelFilePath01.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtExcelFilePath01.CustomButton.UseSelectable = true;
            this.txtExcelFilePath01.CustomButton.Visible = false;
            this.txtExcelFilePath01.Lines = new string[0];
            this.txtExcelFilePath01.Location = new System.Drawing.Point(103, 103);
            this.txtExcelFilePath01.MaxLength = 32767;
            this.txtExcelFilePath01.Name = "txtExcelFilePath01";
            this.txtExcelFilePath01.PasswordChar = '\0';
            this.txtExcelFilePath01.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtExcelFilePath01.SelectedText = "";
            this.txtExcelFilePath01.SelectionLength = 0;
            this.txtExcelFilePath01.SelectionStart = 0;
            this.txtExcelFilePath01.ShortcutsEnabled = true;
            this.txtExcelFilePath01.Size = new System.Drawing.Size(765, 23);
            this.txtExcelFilePath01.TabIndex = 7;
            this.txtExcelFilePath01.UseSelectable = true;
            this.txtExcelFilePath01.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtExcelFilePath01.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(874, 103);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(94, 23);
            this.btnViewReport.TabIndex = 6;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseSelectable = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle32;
            this.metroGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.metroGrid1.Location = new System.Drawing.Point(20, 60);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle33;
            this.metroGrid1.RowHeadersWidth = 45;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.metroGrid1.Size = new System.Drawing.Size(980, 651);
            this.metroGrid1.TabIndex = 7;
            this.metroGrid1.SelectionChanged += new System.EventHandler(this.metroGrid1_SelectionChanged);
            // 
            // comboBoxSheets
            // 
            this.comboBoxSheets.FormattingEnabled = true;
            this.comboBoxSheets.Location = new System.Drawing.Point(123, 733);
            this.comboBoxSheets.Name = "comboBoxSheets";
            this.comboBoxSheets.Size = new System.Drawing.Size(133, 21);
            this.comboBoxSheets.TabIndex = 8;
            this.comboBoxSheets.SelectedIndexChanged += new System.EventHandler(this.comboBoxSheets_SelectedIndexChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(28, 733);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(75, 19);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "User Name";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(355, 737);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 0);
            this.lblTotal.TabIndex = 11;
            // 
            // chkMoveFiles
            // 
            this.chkMoveFiles.AutoSize = true;
            this.chkMoveFiles.Location = new System.Drawing.Point(23, 791);
            this.chkMoveFiles.Name = "chkMoveFiles";
            this.chkMoveFiles.Size = new System.Drawing.Size(101, 15);
            this.chkMoveFiles.TabIndex = 12;
            this.chkMoveFiles.Text = "Move Csv Files";
            this.chkMoveFiles.UseSelectable = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 980);
            this.Controls.Add(this.chkMoveFiles);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.comboBoxSheets);
            this.Controls.Add(this.metroGrid1);
            this.Controls.Add(this.metroPanel1);
            this.Name = "Form1";
            this.Text = "Production Report";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtCsvFolder;
        private MetroFramework.Controls.MetroButton btnBrowseFldr;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnGetReport;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtExcelFilePath;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox txtExcelFilePath01;
        private MetroFramework.Controls.MetroButton btnViewReport;
        private System.Windows.Forms.ComboBox comboBoxSheets;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lblTotal;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private MetroFramework.Controls.MetroCheckBox chkMoveFiles;
    }
}

