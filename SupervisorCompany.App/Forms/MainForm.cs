using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SupervisorCompany.App.Context;
using SupervisorCompany.App.Context.Models;
using SupervisorCompany.App.Helpers;
using SupervisorCompany.App.Models;

namespace SupervisorCompany.App
{
    public partial class MainForm : Form
    {
        private readonly SupervisorCompanyDbContext _dbContext;
        private readonly bool _isDevelopment;
        private List<Contract>? _contracts;

        public MainForm(IDbContextFactory<SupervisorCompanyDbContext> dbContext, IHostEnvironment hostEnvironment)
        {
            InitializeComponent();

            _dbContext = dbContext.CreateDbContext();
            _isDevelopment = hostEnvironment.IsDevelopment();

            DatabaseInitializationHelper.InitializeDatabase(_dbContext, hostEnvironment.IsDevelopment());

            //var persons = _dbContext.Persons.Include(p => p.Addresses).ToArray();
        }

        protected void RefreshContracts()
        {
            var selectedContractIndex = dataGridViewContracts.SelectedRows.Count is 0
                ? (int?)null
                : dataGridViewContracts.SelectedRows[0].Index;

            var selectedContractId = selectedContractIndex is null
                ? (long?)null
                : _contracts![selectedContractIndex.Value].Id;

            _contracts = _dbContext.Contracts.Include(c => c.Services).OrderBy(c => c.Id).ToList();

            dataGridViewContracts.DataSource = _contracts;

            dataGridViewContracts.Columns[nameof(Contract.Services)]!.Visible = false;
            dataGridViewContracts.Columns[nameof(Contract.Person)]!.Visible = false;

            dataGridViewContracts.Columns[nameof(Contract.Id)]!.DisplayIndex = 0;
            dataGridViewContracts.Columns[nameof(Contract.StartDate)]!.DisplayIndex = 1;
            dataGridViewContracts.Columns[nameof(Contract.EndDate)]!.DisplayIndex = 2;
            dataGridViewContracts.Columns[nameof(Contract.Description)]!.DisplayIndex = 3;
            dataGridViewContracts.Columns[nameof(Contract.TotalCost)]!.DisplayIndex = 4;

            dataGridViewContracts.ClearSelection();

            if (selectedContractId is null)
            {
                return;
            }

            var selectedContractIdx = _contracts.FindIndex(c => c.Id == selectedContractId.Value);

            if (selectedContractIdx > -1)
            {
                dataGridViewContracts.Rows[selectedContractIdx].Selected = true;
            }
        }

        protected void DisplayRelatedServices()
        {
            var selectedContractIndex = dataGridViewContracts.SelectedRows.Count is 0
                ? (int?)null
                : dataGridViewContracts.SelectedRows[0].Index;

            var selectedContractId = selectedContractIndex is null
                ? (long?)null
                : _contracts![selectedContractIndex.Value].Id;

            if (selectedContractId is null)
            {
                dataGridViewServices.DataSource = null;
                return;
            }

            var selectedContract = _contracts!.FirstOrDefault(c => c.Id == selectedContractId.Value);

            if (selectedContract is not null)
            {
                dataGridViewServices.DataSource = selectedContract.Services
                    .OrderBy(s => s.Id)
                    .Select(s => new ServiceDisplayModel(s))
                    .ToArray();
                dataGridViewServices.Columns[nameof(ServiceDisplayModel.Id)]!.DisplayIndex = 0;
                dataGridViewServices.Columns[nameof(ServiceDisplayModel.ServiceName)]!.DisplayIndex = 1;
                dataGridViewServices.Columns[nameof(ServiceDisplayModel.TotalCost)]!.DisplayIndex = 2;
            }
        }

        private void buttonContractsRefresh_Click(object sender, EventArgs e)
        {
            RefreshContracts();
        }

        private void ExecuteFuncWithExceptionHandling(Action executeAction)
        {
            try
            {
                executeAction();
            }
            catch (Exception e)
            {
                MessageBox.Show(_isDevelopment
                    ? e.ToString()
                    : e.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlMain.SelectedIndex)
            {
                // Contracts
                case 0:
                    RefreshContracts();
                    break;
                default:
                    throw new NotImplementedException(
                        $"Refresh of tab with index {tabControlMain.SelectedIndex} is not implemented.");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshContracts();
        }

        private void dataGridViewContracts_SelectionChanged(object sender, EventArgs e)
        {
            DisplayRelatedServices();
        }
    }
}