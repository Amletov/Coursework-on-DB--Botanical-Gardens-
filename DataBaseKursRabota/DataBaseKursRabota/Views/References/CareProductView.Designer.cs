﻿namespace DataBaseKursRabota.Views
{
    partial class CareProductView
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.careProductTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.detailTabPage = new System.Windows.Forms.TabPage();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.pageLabel = new System.Windows.Forms.Label();
            this.prevButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.detailTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.listTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(119, 174);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(19, 174);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // careProductTextBox
            // 
            this.careProductTextBox.Location = new System.Drawing.Point(19, 75);
            this.careProductTextBox.Name = "careProductTextBox";
            this.careProductTextBox.Size = new System.Drawing.Size(175, 23);
            this.careProductTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Средство";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // detailTabPage
            // 
            this.detailTabPage.Controls.Add(this.unitTextBox);
            this.detailTabPage.Controls.Add(this.label4);
            this.detailTabPage.Controls.Add(this.cancelButton);
            this.detailTabPage.Controls.Add(this.saveButton);
            this.detailTabPage.Controls.Add(this.careProductTextBox);
            this.detailTabPage.Controls.Add(this.label2);
            this.detailTabPage.Controls.Add(this.idTextBox);
            this.detailTabPage.Controls.Add(this.label1);
            this.detailTabPage.Location = new System.Drawing.Point(4, 24);
            this.detailTabPage.Name = "detailTabPage";
            this.detailTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.detailTabPage.Size = new System.Drawing.Size(792, 422);
            this.detailTabPage.TabIndex = 1;
            this.detailTabPage.Text = "Средство подробно";
            this.detailTabPage.UseVisualStyleBackColor = true;
            // 
            // idTextBox
            // 
            this.idTextBox.Enabled = false;
            this.idTextBox.Location = new System.Drawing.Point(19, 31);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(175, 23);
            this.idTextBox.TabIndex = 1;
            this.idTextBox.Text = "0";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 53);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(786, 327);
            this.dataGridView.TabIndex = 5;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(6, 19);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(309, 23);
            this.searchTextBox.TabIndex = 4;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(321, 18);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(705, 15);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = "След.";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(705, 19);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(543, 19);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(624, 19);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Изменить";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Всего записей:";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(96, 19);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(13, 15);
            this.totalLabel.TabIndex = 3;
            this.totalLabel.Text = "1";
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Location = new System.Drawing.Point(674, 19);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(13, 15);
            this.pageLabel.TabIndex = 2;
            this.pageLabel.Text = "1";
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(583, 15);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(75, 23);
            this.prevButton.TabIndex = 1;
            this.prevButton.Text = "Пред.";
            this.prevButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.totalLabel);
            this.groupBox2.Controls.Add(this.pageLabel);
            this.groupBox2.Controls.Add(this.prevButton);
            this.groupBox2.Controls.Add(this.nextButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 371);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(786, 48);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // listTabPage
            // 
            this.listTabPage.Controls.Add(this.groupBox2);
            this.listTabPage.Controls.Add(this.groupBox1);
            this.listTabPage.Controls.Add(this.dataGridView);
            this.listTabPage.Location = new System.Drawing.Point(4, 24);
            this.listTabPage.Name = "listTabPage";
            this.listTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.listTabPage.Size = new System.Drawing.Size(792, 422);
            this.listTabPage.TabIndex = 0;
            this.listTabPage.Text = "Список средств";
            this.listTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchTextBox);
            this.groupBox1.Controls.Add(this.searchButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.editButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(786, 48);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.listTabPage);
            this.tabControl.Controls.Add(this.detailTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 1;
            // 
            // unitTextBox
            // 
            this.unitTextBox.Location = new System.Drawing.Point(19, 116);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.Size = new System.Drawing.Size(175, 23);
            this.unitTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ед. измерения";
            // 
            // CareProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "CareProductView";
            this.Text = "CareProductView";
            this.detailTabPage.ResumeLayout(false);
            this.detailTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.listTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button cancelButton;
        private Button saveButton;
        private TextBox careProductTextBox;
        private Label label2;
        private Label label1;
        private TabPage detailTabPage;
        private TextBox unitTextBox;
        private Label label4;
        private TextBox idTextBox;
        private DataGridView dataGridView;
        private TextBox searchTextBox;
        private Button searchButton;
        private Button nextButton;
        private Button deleteButton;
        private Button addButton;
        private Button editButton;
        private Label label3;
        private Label totalLabel;
        private Label pageLabel;
        private Button prevButton;
        private GroupBox groupBox2;
        private TabPage listTabPage;
        private GroupBox groupBox1;
        private TabControl tabControl;
    }
}