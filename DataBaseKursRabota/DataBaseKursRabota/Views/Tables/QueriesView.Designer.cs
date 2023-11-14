namespace DataBaseKursRabota.Views.Tables
{
    partial class QueryView
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.queriesComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chartButton = new System.Windows.Forms.Button();
            this.excelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 51);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(800, 362);
            this.dataGridView.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.queriesComboBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // queriesComboBox
            // 
            this.queriesComboBox.FormattingEnabled = true;
            this.queriesComboBox.Items.AddRange(new object[] {
            "Выберите запрос",
            "1. симметричное внутреннее соединение с условием с условием отбора по внешнему кл" +
                "ючу",
            "2. симметричное внутреннее соединение с условием с условием отбора по внешнему кл" +
                "ючу 2",
            "3. симметричное внутреннее соединение с условием с условием отбора по датам",
            "4. симметричное внутреннее соединение с условием с условием отбора по датам 2",
            "5. симметричное внутреннее соединение без условия",
            "6. симметричное внутреннее соединение без условия 2",
            "7. симметричное внутреннее соединение без условия 3",
            "8. симметричное внутреннее соединение без условия 4",
            "9. левое внешнее соединение",
            "10. правое внешнее соединение",
            "11. запрос на запросе по принципу левого соединения",
            "12. итоговый запрос без условия",
            "13. итоговый запрос без условия c итоговыми данными вида: «всего», «в том числе»",
            "14. итоговые запросы с условием на данные (по значению, по маске, с использование" +
                "м индекса, без использования индекса)",
            "15. итоговый запрос с условием на группы по значению",
            "16. итоговый запрос с условием на группы по маске",
            "17. итоговый запрос с условием на группы",
            "18. итоговый запрос с условием на данные и на группы",
            "19. запрос на запросе по принципу итогового запроса",
            "20. запрос с использованием объединения:",
            "21. запросы с подзапросами с использованием in",
            "22. запросы с подзапросами с использованием not in",
            "23. запросы с подзапросами с использованием case",
            "24. Определить процент растений, посаженных до 2020 года по каждому ботаническому" +
                " саду и в целом по всем садам.",
            "25. Определить средний возраст и стаж работников по каждому ботаническому саду и " +
                "по всем садам в целом.",
            "26. Определить среднее количество изданий каждого издательства и по всем издатель" +
                "ствам в целом.",
            "27. Определить суммарные расходы по уходу за растениями и количество растений по " +
                "каждому саду."});
            this.queriesComboBox.Location = new System.Drawing.Point(6, 16);
            this.queriesComboBox.Name = "queriesComboBox";
            this.queriesComboBox.Size = new System.Drawing.Size(788, 23);
            this.queriesComboBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chartButton);
            this.groupBox2.Controls.Add(this.excelButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 411);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 39);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // chartButton
            // 
            this.chartButton.Enabled = false;
            this.chartButton.Location = new System.Drawing.Point(87, 10);
            this.chartButton.Name = "chartButton";
            this.chartButton.Size = new System.Drawing.Size(75, 23);
            this.chartButton.TabIndex = 1;
            this.chartButton.Text = "Диаграмма";
            this.chartButton.UseVisualStyleBackColor = true;
            // 
            // excelButton
            // 
            this.excelButton.Enabled = false;
            this.excelButton.Location = new System.Drawing.Point(6, 10);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(75, 23);
            this.excelButton.TabIndex = 0;
            this.excelButton.Text = "В Excel";
            this.excelButton.UseVisualStyleBackColor = true;
            // 
            // QueryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView);
            this.Name = "QueryView";
            this.Text = "QueriesView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView;
        private GroupBox groupBox1;
        private ComboBox queriesComboBox;
        private GroupBox groupBox2;
        private Button chartButton;
        private Button excelButton;
    }
}