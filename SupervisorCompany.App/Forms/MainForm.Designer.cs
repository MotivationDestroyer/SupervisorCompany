namespace SupervisorCompany.App
{
    partial class MainForm
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
            if (disposing)
            {
                _dbContext.Dispose();
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
            components = new System.ComponentModel.Container();
            supervisorCompanyDbContextBindingSource = new BindingSource(components);
            tabControlMain = new TabControl();
            tabPageContracts = new TabPage();
            buttonContractsRefresh = new Button();
            labelServices = new Label();
            dataGridViewServices = new DataGridView();
            labelContracts = new Label();
            dataGridViewContracts = new DataGridView();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)supervisorCompanyDbContextBindingSource).BeginInit();
            tabControlMain.SuspendLayout();
            tabPageContracts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContracts).BeginInit();
            SuspendLayout();
            // 
            // supervisorCompanyDbContextBindingSource
            // 
            supervisorCompanyDbContextBindingSource.DataSource = typeof(Context.SupervisorCompanyDbContext);
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageContracts);
            tabControlMain.Controls.Add(tabPage2);
            tabControlMain.Location = new Point(12, 12);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1381, 525);
            tabControlMain.TabIndex = 0;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            // 
            // tabPageContracts
            // 
            tabPageContracts.Controls.Add(buttonContractsRefresh);
            tabPageContracts.Controls.Add(labelServices);
            tabPageContracts.Controls.Add(dataGridViewServices);
            tabPageContracts.Controls.Add(labelContracts);
            tabPageContracts.Controls.Add(dataGridViewContracts);
            tabPageContracts.Location = new Point(4, 24);
            tabPageContracts.Name = "tabPageContracts";
            tabPageContracts.Padding = new Padding(3);
            tabPageContracts.Size = new Size(1373, 497);
            tabPageContracts.TabIndex = 0;
            tabPageContracts.Text = "Договоры";
            tabPageContracts.UseVisualStyleBackColor = true;
            // 
            // buttonContractsRefresh
            // 
            buttonContractsRefresh.Font = new Font("Segoe UI", 12F);
            buttonContractsRefresh.Location = new Point(704, 3);
            buttonContractsRefresh.Name = "buttonContractsRefresh";
            buttonContractsRefresh.Size = new Size(135, 29);
            buttonContractsRefresh.TabIndex = 6;
            buttonContractsRefresh.Text = "Обновить";
            buttonContractsRefresh.UseVisualStyleBackColor = true;
            buttonContractsRefresh.Click += buttonContractsRefresh_Click;
            // 
            // labelServices
            // 
            labelServices.AutoSize = true;
            labelServices.Font = new Font("Segoe UI", 12F);
            labelServices.Location = new Point(845, 11);
            labelServices.Name = "labelServices";
            labelServices.Size = new Size(60, 21);
            labelServices.TabIndex = 5;
            labelServices.Text = "Заявки";
            // 
            // dataGridViewServices
            // 
            dataGridViewServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewServices.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewServices.Location = new Point(845, 35);
            dataGridViewServices.MultiSelect = false;
            dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewServices.Size = new Size(477, 413);
            dataGridViewServices.TabIndex = 4;
            // 
            // labelContracts
            // 
            labelContracts.AutoSize = true;
            labelContracts.Font = new Font("Segoe UI", 12F);
            labelContracts.Location = new Point(6, 7);
            labelContracts.Name = "labelContracts";
            labelContracts.Size = new Size(82, 21);
            labelContracts.TabIndex = 3;
            labelContracts.Text = "Договоры";
            // 
            // dataGridViewContracts
            // 
            dataGridViewContracts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewContracts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewContracts.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewContracts.Location = new Point(6, 35);
            dataGridViewContracts.MultiSelect = false;
            dataGridViewContracts.Name = "dataGridViewContracts";
            dataGridViewContracts.ReadOnly = true;
            dataGridViewContracts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewContracts.Size = new Size(833, 413);
            dataGridViewContracts.TabIndex = 1;
            dataGridViewContracts.SelectionChanged += dataGridViewContracts_SelectionChanged;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1373, 497);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1419, 705);
            Controls.Add(tabControlMain);
            Name = "MainForm";
            Text = "Main form";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)supervisorCompanyDbContextBindingSource).EndInit();
            tabControlMain.ResumeLayout(false);
            tabPageContracts.ResumeLayout(false);
            tabPageContracts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContracts).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource supervisorCompanyDbContextBindingSource;
        private TabControl tabControlMain;
        private TabPage tabPageContracts;
        private TabPage tabPage2;
        private DataGridView dataGridViewContracts;
        private Label labelServices;
        private DataGridView dataGridViewServices;
        private Label labelContracts;
        private Button buttonContractsRefresh;
    }
}
