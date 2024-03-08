

Console.WriteLine("Wilkommen beim Projektordern Konfigurator!");
Thread.Sleep(2000);


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
        Console.WriteLine("Das Elternverzeichnis existiert nicht: " + parentDirectoryPath);
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
        string[] subFolders = { "SPS", "EPLAN", "SEW" };
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
}
catch (Exception ex)
{
    Console.WriteLine("Fehler beim Erstellen des Ordners: " + ex.Message);
}