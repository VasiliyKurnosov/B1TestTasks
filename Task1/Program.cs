﻿using Task1;

string filesDirectoryPath = "files";
string filesNamePattern = "file";
int filesNumber = 100;
int rowsInFileNumber = 100000;
RowsFilesManager.CreateRowsFiles(filesDirectoryPath, filesNamePattern, filesNumber, rowsInFileNumber);

while (true)
{
    Console.WriteLine("Enter character sequence. Rows that contain this sequence won't be included in the result file:");
    string pattern = Console.ReadLine() ?? String.Empty;
    Console.WriteLine("Enter result file name:");
    string unitedFilePath = Console.ReadLine() ?? "united_file.txt";
    int removedRowsNumber = RowsFilesManager.UniteFilesFromDirectory(filesDirectoryPath, unitedFilePath, pattern);
    Console.WriteLine($"Rows removed: {removedRowsNumber}");

    string connectionString = "Data Source=..\\..\\..\\Database\\task1.db";
    var database = new Database(connectionString);

    var rows = File.ReadAllLines(unitedFilePath);
    var importProgress = new Progress<int>(importedRowsNumber =>
    {
        Console.Write($"\rImporting rows...[{importedRowsNumber}/{rows.Length}]");
    });
    database.ImportRows(rows, importProgress);
    Console.WriteLine();
    Console.WriteLine("Sum of integer numbers: " + database.CalculateIntegerNumbersSum());
    Console.WriteLine("Average of real numbers: " + database.CalculateRealNumbersAverage());

    Console.WriteLine("Do you want to continue?[y/n]");
    string? userAnswer = Console.ReadLine();
    if (userAnswer == "n")
    {
        break;
    }
}
