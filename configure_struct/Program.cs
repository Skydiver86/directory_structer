

using System.Diagnostics;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

Console.WriteLine("Wilkommen beim Projektordner Konfigurator!\n");
Thread.Sleep(2000);


string parentDirectoryPath = @"C:\Users\smartin\Desktop\Projekte";
string selectedFolder = "";


    string folderPath = @"C:\Users\smartin\Desktop\Projekte\test"; // Passe den Pfad entsprechend an

    // Zeige den Inhalt des Ordners an
    FilterFolderContent(folderPath);

    Console.WriteLine("Drücke eine beliebige Taste, um fortzufahren...");
    Console.ReadKey();


static void FilterFolderContent(string folderPath)
{
    try
    {
        // Zeige Dateien im Ordner an
        Console.WriteLine("Dateien:");
        foreach (string file in Directory.GetFiles(folderPath))
        {
            int matchCount = GetMatchingCharCount(Path.GetFileName(file));
            Console.WriteLine($"{Path.GetFileName(file)} - Übereinstimmungen: {matchCount}");
        }

        // Zeige Unterordner an
        Console.WriteLine("\nUnterordner:");
        foreach (string subfolder in Directory.GetDirectories(folderPath))
        {
            int matchCount = GetMatchingCharCount(Path.GetFileName(subfolder));
            Console.WriteLine($"{Path.GetFileName(subfolder)} - Übereinstimmungen: {matchCount}");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Fehler beim Filtern des Ordnerinhalts: {e.Message}");
    }
}

static int GetMatchingCharCount(string input)
{
    // Anzahl der übereinstimmenden Zeichen
    int matchCount = 0;

    // Vergleichszeichenfolge
    string targetString = "1149"; // Passe die Vergleichszeichenfolge entsprechend an

    // Überprüfe, ob mindestens drei Zeichen übereinstimmen
    foreach (char c in targetString)
    {
        if (input.Contains(c))
        {
            matchCount++;
        }
    }

    return matchCount;
}
/*
try
{
    // Überprüfen, ob die Elternordner existieren
    if (Directory.Exists(parentDirectoryPath))
    {
        // Prüfen, ob die Ordner "113" oder "114" existieren
        string directory113Path = Path.Combine(parentDirectoryPath, "113");
        string directory114Path = Path.Combine(parentDirectoryPath, "114");

        if (Directory.Exists(directory113Path) || Directory.Exists(directory114Path))
        {
            // Fragen Sie den Benutzer nach dem zu erstellenden Ordner
            Console.WriteLine("In welchem Ordner soll der neue Ordner erstellt werden? (113 oder 114)");
            string userInput = Console.ReadLine();

            // Überprüfen, ob der Benutzer eine gültige Eingabe gemacht hat
            if (userInput == "113" || userInput == "114")
            {
                // Den ausgewählten Ordner festlegen
                selectedFolder = userInput;

            }
            else
            {
                Console.WriteLine("Ungültige Eingabe.");
                return;

            }
        }
        else
        {
            Console.WriteLine("Die Ordner '113' und '114' existieren nicht.");
            return;
        }
    }
    else
    {
        Console.WriteLine("Das Verzeichnis existiert nicht: " + parentDirectoryPath);
        return;
    }

    Console.WriteLine("Nummer des neuen Projekts eingeben!");
    string projektnummer = Console.ReadLine();

    // Vollständigen Pfad des neuen Ordners erstellen
    string newFolderPath = Path.Combine(parentDirectoryPath, selectedFolder, projektnummer);

    // Überprüfen, ob der neue Ordner bereits existiert
    if (!Directory.Exists(newFolderPath))
    {
        // Versuchen, den Ordner zu erstellen
        Directory.CreateDirectory(newFolderPath);
        Console.WriteLine("Ordner erfolgreich erstellt: " + newFolderPath);

        // Erstellen Sie die Unterordner
        string[] subFolders = { "SPS", "EPLAN", "SEW" , "EXCEL" , "Dokumente" };
        foreach (string subFolderName in subFolders)
        {
            string subFolderPath = Path.Combine(newFolderPath, subFolderName);
            Directory.CreateDirectory(subFolderPath);
            Console.WriteLine($"Unterordner '{subFolderName}' erfolgreich erstellt: {subFolderPath}");

            // Im Unterordner "SPS" einen Unterordner "ALT" erstellen
            if (subFolderName == "SPS")
            {
                string altFolderPath = Path.Combine(subFolderPath, "ALT");
                Directory.CreateDirectory(altFolderPath);
                Console.WriteLine($"Unterordner 'ALT' erfolgreich erstellt: {altFolderPath}");
            }
        }
    }
    else
    {
        Console.WriteLine("Der Ordner '" + newFolderPath + "' existiert bereits.");
    }

    // Passe den Pfad zum zu öffnenden Ordner entsprechend an
   

    // Überprüfe, ob der Ordner existiert, bevor er geöffnet wird
    if (System.IO.Directory.Exists(parentDirectoryPath))
    {
        // Öffne den Ordner im Datei-Explorer
        Process.Start("explorer.exe", parentDirectoryPath);
    }
    else
    {
        Console.WriteLine("Der angegebene Ordner existiert nicht.");
    }

}
catch (Exception ex)
{
    Console.WriteLine("Fehler beim Erstellen des Ordners: " + ex.Message);
}*/