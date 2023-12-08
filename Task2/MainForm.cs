using Task2.Models;

namespace Task2
{
    public partial class MainForm : Form
    {
        private readonly Database _database;
        private readonly string[] _classDescriptions;

        private List<Turnover> _turnovers = new List<Turnover>();
        private List<Turnover> _turnoversGroupedByBalanceAccount = new List<Turnover>();
        private List<Turnover> _turnoversGroupedByClass = new List<Turnover>();
        private Turnover _totalTurnover;

        public MainForm()
        {
            _database = new Database("Data Source=..\\..\\..\\Database\\task2.db");
            InitializeComponent();
            _fileNamesListBox.Items.AddRange(new string[] { });
            LoadTurnovers();
            _classDescriptions = _database.GetClassDescriptions().ToArray();
            ShowTable();
        }

        private void LoadTurnovers()
        {
            _turnovers = _database.GetAllTurnovers().ToList();
            _turnoversGroupedByBalanceAccount = _database.GetTurnoversGroupedByBalanceAccount().ToList();
            _turnoversGroupedByClass = _database.GetTurnoversGroupedByClass().ToList();
            _totalTurnover = _database.GetTotalTurnover();
        }

        private void ShowTable()
        {
            _turnoversGrid.Rows.Clear();

            _turnoversGrid.Rows.Add("", "Входящее сальдо", "Входящее сальдо", "Обороты", "Обороты",
                "Исходящее сальдо", "Исходящее сальдо");
            _turnoversGrid.Rows.Add("Б/сч", "Актив", "Пассив", "Дебет", "Кредит", "Актив", "Пассив");
            if (!_turnovers.Any())
            {
                return;
            }

            _turnoversGrid.Rows.Add($"Класс {_turnoversGroupedByClass[0].BalanceAccount} {_classDescriptions[0]}");
            int currentClassIndex = 0;
            int currentTwoDigitBalanceAccountIndex = 0;
            foreach (var turnover in _turnovers)
            {
                if (turnover.BalanceAccount / 100 !=
                    _turnoversGroupedByBalanceAccount[currentTwoDigitBalanceAccountIndex].BalanceAccount)
                {
                    AddTurnoverToGrid(_turnoversGroupedByBalanceAccount[currentTwoDigitBalanceAccountIndex]);
                    currentTwoDigitBalanceAccountIndex++;

                    if (turnover.BalanceAccount / 1000 != _turnoversGroupedByClass[currentClassIndex].BalanceAccount)
                    {
                        int rowIndex = AddTurnoverToGrid(_turnoversGroupedByClass[currentClassIndex]);
                        _turnoversGrid.Rows[rowIndex].Cells[0].Value = "По классу";
                        currentClassIndex++;
                        if (currentClassIndex < _turnoversGroupedByClass.Count)
                        {
                            int classNumber = _turnoversGroupedByClass[currentClassIndex].BalanceAccount;
                            _turnoversGrid.Rows.Add($"Класс {classNumber} {_classDescriptions[classNumber - 1]}");
                        }
                    }
                }

                AddTurnoverToGrid(turnover);
            }

            AddTurnoverToGrid(_turnoversGroupedByBalanceAccount[currentTwoDigitBalanceAccountIndex]);
            int lastClassRowIndex = AddTurnoverToGrid(_turnoversGroupedByClass[currentClassIndex]);
            _turnoversGrid.Rows[lastClassRowIndex].Cells[0].Value = "По классу";
            int lastRowIndex = AddTurnoverToGrid(_totalTurnover);
            _turnoversGrid.Rows[lastRowIndex].Cells[0].Value = "БАЛАНС";
        }

        private int AddTurnoverToGrid(Turnover turnover)
        {
            return _turnoversGrid.Rows.Add(turnover.BalanceAccount, turnover.IncomingBalanceActive,
                turnover.IncomingBalancePassive, turnover.Debit, turnover.Credit,
                turnover.OutgoingBalanceActive, turnover.OutgoingBalancePassive);
        }

        private void AddTableButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filePath = openFileDialog.FileName;
            var turnovers = ExcelFileReader.ReadFile(filePath);
            _database.InsertTurnovers(turnovers);
            LoadTurnovers();
            ShowTable();
            _fileNamesListBox.Items.Add(filePath.Split('\\')[^1]);
        }
    }
}
