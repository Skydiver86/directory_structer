

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to the Project Folder Configurator!\n");

        // Waiting for 2 seconds
        System.Threading.Thread.Sleep(2000);

        string folderPath = @"W:\SPS\PROG"; // Modify the path accordingly

        // Definieren der Liste von Zahlenbereichen
        List<Tuple<int, int>> numberRanges = new List<Tuple<int, int>>()
        {
            Tuple.Create(250, 499),
            Tuple.Create(500, 749),
            Tuple.Create(750, 999),
            Tuple.Create(1000, 1249),
            Tuple.Create(100000, 100499),
            Tuple.Create(100500, 100999),
            Tuple.Create(101000, 101499),
            Tuple.Create(101500, 101999),
            Tuple.Create(102000, 102499),
            Tuple.Create(102500, 102999),
            Tuple.Create(103000, 103499),
            Tuple.Create(103500, 103999),
            Tuple.Create(104000, 104499),
            Tuple.Create(104500, 104999),
            Tuple.Create(105000, 105499),
            Tuple.Create(105500, 105999),
            Tuple.Create(106000, 106499),
            Tuple.Create(108000, 108499),
            Tuple.Create(110000, 110499),
            Tuple.Create(110500, 110999),
            Tuple.Create(111000, 111499),
            Tuple.Create(111500, 111999),
            Tuple.Create(112000, 112499),
            Tuple.Create(112500, 112999),
            Tuple.Create(113000, 113499),
            Tuple.Create(113500, 113999),
            Tuple.Create(114000, 114499),
            Tuple.Create(114500, 114999),
            Tuple.Create(1250, 1499),
            Tuple.Create(1500, 1749),
            Tuple.Create(1750, 1999),
            Tuple.Create(2000, 2499),
            Tuple.Create(2500, 2749),
            Tuple.Create(2750, 2999),
            Tuple.Create(3000, 3249),
            Tuple.Create(3250, 3499),
            Tuple.Create(3500, 3749),
            Tuple.Create(3750, 3999),
            Tuple.Create(4000, 4249),
            Tuple.Create(4250, 4499),
            Tuple.Create(4500, 4749),
            Tuple.Create(4750, 4799),
            Tuple.Create(4800, 4849),
            Tuple.Create(4850, 4999),
            Tuple.Create(5000, 5249),
            Tuple.Create(5250, 5299),
            Tuple.Create(5300, 5399),
            Tuple.Create(5400, 5499),
            Tuple.Create(5500, 5749),
            Tuple.Create(5750, 5999),
            Tuple.Create(6000, 6249),
            Tuple.Create(6250, 6299),
            Tuple.Create(6300, 6499),
            Tuple.Create(6500, 6599),
            Tuple.Create(6600, 6699),
            Tuple.Create(6700, 6799),
            Tuple.Create(6800, 6899),
            Tuple.Create(6900, 6999),
            Tuple.Create(7000, 7249),
            Tuple.Create(7250, 7999),
            Tuple.Create(8000, 8249),
            Tuple.Create(8250, 8499),
            Tuple.Create(8500, 8749),
            Tuple.Create(8750, 8999),
            Tuple.Create(9000, 9249),
            Tuple.Create(9250, 9499)
        };

        Console.WriteLine("Enter a project number:");
        int projectNumber = int.Parse(Console.ReadLine());

        // Durchsuchen der Zahlenbereiche, um festzustellen, in welchem Bereich die Projektnummer liegt
        foreach (var range in numberRanges)
        {
            if (projectNumber >= range.Item1 && projectNumber <= range.Item2)
            {
                Console.WriteLine($"Project number {projectNumber} is in the range {range.Item1}-{range.Item2}");
                string openPath = $"{range.Item1}-{range.Item2}";
                string endPath = Path.Combine(folderPath, openPath);
                Console.WriteLine(endPath);

                string searchValue = projectNumber.ToString() ;
                string absolutePath = FindFolderByMatch(endPath, searchValue);
                string spsPath = Path.Combine(absolutePath);

                Console.WriteLine(spsPath);
               


                if (!string.IsNullOrEmpty(absolutePath))
                {
                    Console.WriteLine($"Found folder with match '{searchValue}' at: {absolutePath}");

                    Console.WriteLine(spsPath);


                    string folderSearchPath = spsPath;

                    // Array von Suchmustern für verschiedene Versionen
                    string[] searchPatterns = { "*.zap15_1", "*.zap16", "*.zap17", "*.zap18", "*.zap19" };

                    // Aufruf der Methode zum Durchsuchen des Verzeichnisses mit jedem Suchmuster
                    List<string> zapFiles = new List<string>();
                    foreach (string pattern in searchPatterns)
                    {
                        string[] files = SearchForZapFiles(folderSearchPath, pattern);
                        zapFiles.AddRange(files);
                    }

                    if (zapFiles.Count > 0)
                    {
                        Console.WriteLine("Gefundene .zap-Dateien:");
                        foreach (string zapFile in zapFiles)
                        {
                            Console.WriteLine(zapFile);

                            string sourceFilePath = zapFile;                                                ///////////Noch Anpasssen////////////////////////////////////
                            string destinationFilePath = @"C:\Users\smartin\Desktop\Projekte\Test_Copy";     ///////////Noch Anpasssen////////////////////////////////////

                            Console.WriteLine(destinationFilePath);

                            // Aufruf der Methode zum Kopieren der Datei
                            //CopyFile(sourceFilePath, destinationFilePath);

                        }
                    }
                    else
                    {
                        Console.WriteLine("Keine .zap-Dateien gefunden.");
                    }


                }
                else
                {
                    Console.WriteLine($"Folder with match '{searchValue}' not found in '{endPath}'.");
                }


                static void CopyFile(string sourceFilePath, string destinationDirectory)
                {
                    try
                    {
                        // Überprüfen, ob die Quelldatei existiert
                        if (File.Exists(sourceFilePath))
                        {
                            // Dateiname aus dem Quellpfad extrahieren
                            string fileName = Path.GetFileName(sourceFilePath);

                            // Zielpfad für die neue Datei erstellen
                            string destinationFilePath = Path.Combine(destinationDirectory, fileName);

                            // Kopiere die Datei zum Zielort
                            File.Copy(sourceFilePath, destinationFilePath, true);
                            Console.WriteLine("Die Datei wurde erfolgreich kopiert.");
                        }
                        else
                        {
                            Console.WriteLine("Die Quelldatei existiert nicht.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ein Fehler ist aufgetreten: " + ex.Message);
                    }
                }

                static string[] SearchForZapFiles(string directoryPath, string searchPattern)
                {
                    try
                    {
                        // Überprüfen, ob das Verzeichnis existiert
                        if (Directory.Exists(directoryPath))
                        {
                            // Durchsuche alle Dateien im Verzeichnis mit dem angegebenen Suchmuster
                            return Directory.GetFiles(directoryPath, searchPattern);
                        }
                        else
                        {
                            Console.WriteLine("Das angegebene Verzeichnis existiert nicht.");
                            return new string[0];
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ein Fehler ist aufgetreten: " + ex.Message);
                        return new string[0];
                    }
                }

                static string FindFolderByMatch(string parentFolderPath, string searchTerm)
                {
                    try
                    {
                        // Suche nach Unterordnern im übergeordneten Ordner
                        string[] subfolders = Directory.GetDirectories(parentFolderPath);

                        // Durchlaufe alle Unterordner und überprüfe, ob einer von ihnen den Suchbegriff im Namen enthält
                        foreach (string subfolder in subfolders)
                        {
                            string folderName = Path.GetFileName(subfolder);
                            if (folderName.Contains(searchTerm))
                            {                              


                               /* // Überprüfe, ob der Ordner existiert, bevor er geöffnet wird
                                if (System.IO.Directory.Exists(subfolder))
                                {
                                    // Öffne den Ordner im Datei-Explorer
                                     Process.Start("explorer.exe", subfolder);
                                }
                                else
                                {
                                    Console.WriteLine("Der angegebene Ordner existiert nicht.");
                                }
                               */
                                string parentDirectoryPath = @"C:\Users\smartin\Desktop\Projekte";
                                string selectedFolder = "";

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
                                              

                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Die Ordner '113' und '114' existieren nicht.");
                                           
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Das Verzeichnis existiert nicht: " + parentDirectoryPath);
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
                                        string[] subFolders = { "SPS", "EPLAN", "SEW", "EXCEL", "Dokumente" };
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
                                }


                                return subfolder; // Rückgabe des gefundenen Ordnerpfads

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error searching for folder: {ex.Message}");
                    }

                    return null; // Rückgabe null, wenn kein Ordner mit der angegebenen Übereinstimmung gefunden wurde
                }


            }
        }   
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void FilterFolderContent(string folderPath, string projectNumber)
    {
        try
        {
            // Display files in the folder
            Console.WriteLine("\nFiles:");
            foreach (string file in Directory.GetFiles(folderPath))
            {
                int matchCount = GetMatchingCharCount(Path.GetFileName(file), projectNumber);
                Console.WriteLine($"{Path.GetFileName(file)} - Matches: {matchCount}");
            }

            // Display subfolders
            Console.WriteLine("\nSubfolders:");
            foreach (string subfolder in Directory.GetDirectories(folderPath))
            {
                int matchCount = GetMatchingCharCount(Path.GetFileName(subfolder), projectNumber);
                Console.WriteLine($"{Path.GetFileName(subfolder)}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error filtering folder content: {e.Message}");
        }
    }

    static int GetMatchingCharCount(string input, string targetString)
    {
        // Number of matching characters
        int matchCount = 0;

        // Check if at least three characters match
        foreach (char c in targetString)
        {
            if (input.Contains(c))
            {
                matchCount++;
            }
        }
        return matchCount;
    }
}


