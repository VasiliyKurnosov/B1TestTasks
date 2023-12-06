using Microsoft.Data.Sqlite;
using Task2.Models;

namespace Task2
{
    public class Database
    {
        private readonly string _connectionString;

        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertTurnovers(IEnumerable<Turnover> turnovers)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                foreach (var turnover in turnovers)
                {
                    var formatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-US");
                    string incomingBalanceActiveString = turnover.IncomingBalanceActive.ToString(formatProvider);
                    string incomingBalancePassiveString = turnover.IncomingBalancePassive.ToString(formatProvider);
                    string debitString = turnover.Debit.ToString(formatProvider);
                    string creditString = turnover.Credit.ToString(formatProvider);
                    string sqlExpression = @$"INSERT INTO turnovers
(balance_account, incoming_balance_active, incoming_balance_passive, debit, credit)
VALUES({turnover.BalanceAccount}, {incomingBalanceActiveString}, {incomingBalancePassiveString},
{debitString}, {creditString})
ON CONFLICT DO UPDATE SET incoming_balance_active = incoming_balance_active + {incomingBalanceActiveString},
incoming_balance_passive = incoming_balance_passive + {incomingBalancePassiveString},
debit = debit + {debitString}, credit = credit + {creditString};";

                    var insertRowCommand = new SqliteCommand(sqlExpression, connection);
                    insertRowCommand.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Turnover> GetAllTurnovers()
        {
            return GetTurnoversFromTable("full_turnovers");
        }

        public IEnumerable<Turnover> GetTurnoversGroupedByBalanceAccount()
        {
            return GetTurnoversFromTable("full_turnovers_grouped_by_balance_account");
        }

        public IEnumerable<Turnover> GetTurnoversGroupedByClass()
        {
            return GetTurnoversFromTable("full_turnovers_grouped_by_class");
        }

        public Turnover GetTotalTurnover()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sqlExpression = @"SELECT ifnull(SUM(incoming_balance_active), 0),
ifnull(SUM(incoming_balance_passive), 0), ifnull(SUM(debit), 0), ifnull(SUM(credit), 0),
ifnull(SUM(outgoing_balance_active), 0), ifnull(SUM(outgoing_balance_passive), 0) FROM full_turnovers";

                var selectCommand = new SqliteCommand(sqlExpression, connection);
                using (var reader = selectCommand.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        var turnover = new Turnover
                        {
                            BalanceAccount = 0,
                            IncomingBalanceActive = reader.GetDecimal(0),
                            IncomingBalancePassive = reader.GetDecimal(1),
                            Debit = reader.GetDecimal(2),
                            Credit = reader.GetDecimal(3),
                            OutgoingBalanceActive = reader.GetDecimal(4),
                            OutgoingBalancePassive = reader.GetDecimal(5)
                        };
                        return turnover;
                    }
                }
            }
            return new Turnover();
        }

        public IEnumerable<string> GetClassDescriptions()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sqlExpression = "SELECT description FROM classes";

                var selectCommand = new SqliteCommand(sqlExpression, connection);
                using (var reader = selectCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string className = reader.GetString(0);
                            yield return className;
                        }
                    }
                }
            }
        }

        private IEnumerable<Turnover> GetTurnoversFromTable(string tableName)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sqlExpression = $"SELECT * FROM {tableName}";

                var selectCommand = new SqliteCommand(sqlExpression, connection);
                using (var reader = selectCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var turnover = new Turnover
                            {
                                BalanceAccount = reader.GetInt32(0),
                                IncomingBalanceActive = reader.GetDecimal(1),
                                IncomingBalancePassive = reader.GetDecimal(2),
                                Debit = reader.GetDecimal(3),
                                Credit = reader.GetDecimal(4),
                                OutgoingBalanceActive = reader.GetDecimal(5),
                                OutgoingBalancePassive = reader.GetDecimal(6)
                            };
                            yield return turnover;
                        }
                    }
                }
            }
        }
    }
}
