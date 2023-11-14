namespace DataBaseKursRabota.Views.Tables
{
    partial class ServiceView
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
            this.amountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fertilizedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.detailTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.employeeComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.careProductComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.plantComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.listTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cancelGenButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.amountNumericUpDown)).BeginInit();
            this.detailTabPage.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.listTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // amountNumericUpDown
            // 
            this.amountNumericUpDown.Location = new System.Drawing.Point(17, 246);
            this.amountNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.amountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amountNumericUpDown.Name = "amountNumericUpDown";
            this.amountNumericUpDown.Size = new System.Drawing.Size(174, 23);
            this.amountNumericUpDown.TabIndex = 18;
            this.amountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Количество";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Дата Удобрения";
            // 
            // fertilizedDateTimePicker
            // 
            this.fertilizedDateTimePicker.Location = new System.Drawing.Point(17, 73);
            this.fertilizedDateTimePicker.MaxDate = new System.DateTime(2023, 11, 13, 0, 0, 0, 0);
            this.fertilizedDateTimePicker.Name = "fertilizedDateTimePicker";
            this.fertilizedDateTimePicker.Size = new System.Drawing.Size(174, 23);
            this.fertilizedDateTimePicker.TabIndex = 15;
            this.fertilizedDateTimePicker.Value = new System.DateTime(2023, 11, 13, 0, 0, 0, 0);
            // 
            // detailTabPage
            // 
            this.detailTabPage.Controls.Add(this.label1);
            this.detailTabPage.Controls.Add(this.idTextBox);
            this.detailTabPage.Controls.Add(this.label11);
            this.detailTabPage.Controls.Add(this.employeeComboBox);
            this.detailTabPage.Controls.Add(this.label10);
            this.detailTabPage.Controls.Add(this.careProductComboBox);
            this.detailTabPage.Controls.Add(this.amountNumericUpDown);
            this.detailTabPage.Controls.Add(this.label9);
            this.detailTabPage.Controls.Add(this.label8);
            this.detailTabPage.Controls.Add(this.fertilizedDateTimePicker);
            this.detailTabPage.Controls.Add(this.label5);
            this.detailTabPage.Controls.Add(this.plantComboBox);
            this.detailTabPage.Controls.Add(this.cancelButton);
            this.detailTabPage.Controls.Add(this.saveButton);
            this.detailTabPage.Location = new System.Drawing.Point(4, 24);
            this.detailTabPage.Name = "detailTabPage";
            this.detailTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.detailTabPage.Size = new System.Drawing.Size(792, 422);
            this.detailTabPage.TabIndex = 1;
            this.detailTabPage.Text = "Обслуживание подробно";
            this.detailTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "ID";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(17, 32);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(174, 23);
            this.idTextBox.TabIndex = 23;
            this.idTextBox.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "Работник";
            // 
            // employeeComboBox
            // 
            this.employeeComboBox.FormattingEnabled = true;
            this.employeeComboBox.Location = new System.Drawing.Point(17, 158);
            this.employeeComboBox.Name = "employeeComboBox";
            this.employeeComboBox.Size = new System.Drawing.Size(174, 23);
            this.employeeComboBox.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Средство ухода";
            // 
            // careProductComboBox
            // 
            this.careProductComboBox.FormattingEnabled = true;
            this.careProductComboBox.Location = new System.Drawing.Point(17, 202);
            this.careProductComboBox.Name = "careProductComboBox";
            this.careProductComboBox.Size = new System.Drawing.Size(174, 23);
            this.careProductComboBox.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Растение";
            // 
            // plantComboBox
            // 
            this.plantComboBox.FormattingEnabled = true;
            this.plantComboBox.Location = new System.Drawing.Point(17, 114);
            this.plantComboBox.Name = "plantComboBox";
            this.plantComboBox.Size = new System.Drawing.Size(174, 23);
            this.plantComboBox.TabIndex = 6;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(116, 275);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(17, 275);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
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
            this.tabControl.TabIndex = 4;
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
            this.listTabPage.Text = "Список обслуживаний";
            this.listTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cancelGenButton);
            this.groupBox2.Controls.Add(this.generateButton);
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
            // cancelGenButton
            // 
            this.cancelGenButton.Location = new System.Drawing.Point(340, 15);
            this.cancelGenButton.Name = "cancelGenButton";
            this.cancelGenButton.Size = new System.Drawing.Size(109, 23);
            this.cancelGenButton.TabIndex = 8;
            this.cancelGenButton.Text = "Отменить";
            this.cancelGenButton.UseVisualStyleBackColor = true;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(221, 15);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(113, 23);
            this.generateButton.TabIndex = 7;
            this.generateButton.Text = "Сгенерировать";
            this.generateButton.UseVisualStyleBackColor = true;
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
            this.dataGridView.Size = new System.Drawing.Size(786, 323);
            this.dataGridView.TabIndex = 5;
            // 
            // ServiceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "ServiceView";
            this.Text = "ServiceView";
            ((System.ComponentModel.ISupportInitialize)(this.amountNumericUpDown)).EndInit();
            this.detailTabPage.ResumeLayout(false);
            this.detailTabPage.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.listTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NumericUpDown amountNumericUpDown;
        private Label label9;
        private Label label8;
        private DateTimePicker fertilizedDateTimePicker;
        private TabPage detailTabPage;
        private Label label5;
        private ComboBox plantComboBox;
        private Button cancelButton;
        private Button saveButton;
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
        private Label label11;
        private ComboBox employeeComboBox;
        private Label label10;
        private ComboBox careProductComboBox;
        private Label label1;
        private TextBox idTextBox;
        private Button cancelGenButton;
        private Button generateButton;
    }
}