namespace DataBaseKursRabota.Views.Tables
{
    partial class GardenView
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.listTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.pageLabel = new System.Windows.Forms.Label();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.detailTabPage = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.openingDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.phoneNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.financingCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.propertyComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.employeeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.gardenTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.listTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.detailTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phoneNumericUpDown)).BeginInit();
            this.SuspendLayout();
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
            this.tabControl.TabIndex = 2;
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
            this.listTabPage.Text = "Список садов";
            this.listTabPage.UseVisualStyleBackColor = true;
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
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(705, 15);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = "След.";
            this.nextButton.UseVisualStyleBackColor = true;
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
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 57);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(786, 308);
            this.dataGridView.TabIndex = 5;
            // 
            // detailTabPage
            // 
            this.detailTabPage.Controls.Add(this.label8);
            this.detailTabPage.Controls.Add(this.label7);
            this.detailTabPage.Controls.Add(this.openingDateTimePicker);
            this.detailTabPage.Controls.Add(this.phoneNumericUpDown);
            this.detailTabPage.Controls.Add(this.financingCheckBox);
            this.detailTabPage.Controls.Add(this.label6);
            this.detailTabPage.Controls.Add(this.propertyComboBox);
            this.detailTabPage.Controls.Add(this.label5);
            this.detailTabPage.Controls.Add(this.employeeComboBox);
            this.detailTabPage.Controls.Add(this.label4);
            this.detailTabPage.Controls.Add(this.cityComboBox);
            this.detailTabPage.Controls.Add(this.cancelButton);
            this.detailTabPage.Controls.Add(this.saveButton);
            this.detailTabPage.Controls.Add(this.gardenTextBox);
            this.detailTabPage.Controls.Add(this.label2);
            this.detailTabPage.Controls.Add(this.idTextBox);
            this.detailTabPage.Controls.Add(this.label1);
            this.detailTabPage.Location = new System.Drawing.Point(4, 24);
            this.detailTabPage.Name = "detailTabPage";
            this.detailTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.detailTabPage.Size = new System.Drawing.Size(792, 422);
            this.detailTabPage.TabIndex = 1;
            this.detailTabPage.Text = "Сад подробно";
            this.detailTabPage.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(213, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Год открытия";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Телефон";
            // 
            // openingDateTimePicker
            // 
            this.openingDateTimePicker.Location = new System.Drawing.Point(213, 123);
            this.openingDateTimePicker.MaxDate = new System.DateTime(2023, 11, 13, 0, 0, 0, 0);
            this.openingDateTimePicker.Name = "openingDateTimePicker";
            this.openingDateTimePicker.Size = new System.Drawing.Size(174, 23);
            this.openingDateTimePicker.TabIndex = 15;
            this.openingDateTimePicker.Value = new System.DateTime(2023, 11, 13, 0, 0, 0, 0);
            // 
            // phoneNumericUpDown
            // 
            this.phoneNumericUpDown.Location = new System.Drawing.Point(19, 123);
            this.phoneNumericUpDown.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.phoneNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.phoneNumericUpDown.Name = "phoneNumericUpDown";
            this.phoneNumericUpDown.Size = new System.Drawing.Size(175, 23);
            this.phoneNumericUpDown.TabIndex = 14;
            this.phoneNumericUpDown.Value = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            // 
            // financingCheckBox
            // 
            this.financingCheckBox.AutoSize = true;
            this.financingCheckBox.Location = new System.Drawing.Point(238, 169);
            this.financingCheckBox.Name = "financingCheckBox";
            this.financingCheckBox.Size = new System.Drawing.Size(121, 19);
            this.financingCheckBox.TabIndex = 12;
            this.financingCheckBox.Text = "Финансирование";
            this.financingCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Тип собственности";
            // 
            // propertyComboBox
            // 
            this.propertyComboBox.FormattingEnabled = true;
            this.propertyComboBox.Location = new System.Drawing.Point(213, 75);
            this.propertyComboBox.Name = "propertyComboBox";
            this.propertyComboBox.Size = new System.Drawing.Size(174, 23);
            this.propertyComboBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Работник";
            // 
            // employeeComboBox
            // 
            this.employeeComboBox.FormattingEnabled = true;
            this.employeeComboBox.Location = new System.Drawing.Point(19, 167);
            this.employeeComboBox.Name = "employeeComboBox";
            this.employeeComboBox.Size = new System.Drawing.Size(175, 23);
            this.employeeComboBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Город";
            // 
            // cityComboBox
            // 
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(213, 31);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(174, 23);
            this.cityComboBox.TabIndex = 6;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(312, 194);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(19, 196);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // gardenTextBox
            // 
            this.gardenTextBox.Location = new System.Drawing.Point(19, 75);
            this.gardenTextBox.Name = "gardenTextBox";
            this.gardenTextBox.Size = new System.Drawing.Size(175, 23);
            this.gardenTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Название сада";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // GardenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "GardenView";
            this.Text = "GardenView";
            this.tabControl.ResumeLayout(false);
            this.listTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.detailTabPage.ResumeLayout(false);
            this.detailTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phoneNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl;
        private TabPage listTabPage;
        private GroupBox groupBox2;
        private Label label3;
        private Label totalLabel;
        private Label pageLabel;
        private Button prevButton;
        private Button nextButton;
        private GroupBox groupBox1;
        private TextBox searchTextBox;
        private Button searchButton;
        private Button deleteButton;
        private Button addButton;
        private Button editButton;
        private DataGridView dataGridView;
        private TabPage detailTabPage;
        private Label label4;
        private ComboBox cityComboBox;
        private Button cancelButton;
        private Button saveButton;
        private TextBox gardenTextBox;
        private Label label2;
        private TextBox idTextBox;
        private Label label1;
        private Label label6;
        private ComboBox propertyComboBox;
        private Label label5;
        private ComboBox employeeComboBox;
        private Label label8;
        private Label label7;
        private DateTimePicker openingDateTimePicker;
        private NumericUpDown phoneNumericUpDown;
        private CheckBox financingCheckBox;
    }
}