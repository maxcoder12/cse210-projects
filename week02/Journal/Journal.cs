using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

public class Journal{
  public List <Entry> _entries = new List<Entry>();

  public void AddEntry(string date, string promptText, string entryText){
    Entry entry = new Entry();

    entry._date = date;
    entry._promptText = promptText;
    entry._entryText = entryText;
    

    _entries.Add(entry);
  }

  public void DisplayAll(){
    if (_entries.Count() > 0) {
      foreach (Entry entry in _entries){
        Console.WriteLine($"Date: {entry._date} - Prompt: {entry._promptText}");
        Console.WriteLine(entry._entryText);
        Console.WriteLine();
      }
    } else{
      Console.WriteLine("There are no entries saved...");
    }
  }

  public void LoadFromFile(string file){
    if (File.Exists(file) && new FileInfo(file).Length > 0) {
      string[] lines = System.IO.File.ReadAllLines(file);

      foreach (string line in lines){
        string[] parts = line.Split("|");

        string date = parts[0];
        string promptText = parts[1];
        string entryText = parts[2];

        AddEntry(date, promptText, entryText);

        Console.WriteLine("File loaded successfully!");
      }
    } else{
      Console.WriteLine("The file does not exist or is empty.");
    }
  }

  public void SaveToFile(string file){
    using (StreamWriter outputFile = new StreamWriter(file))
    {
      if (_entries.Count() > 0){
        foreach(Entry entry in _entries){
          outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
        }
        Console.WriteLine("File saved successfully!");
      }
      else{
        Console.WriteLine("There are no entries to save.");
      }
    }
  }

  public void ClearFile(string file){
    if (new FileInfo(file).Length > 0){
      File.WriteAllText(file, string.Empty);
      Console.WriteLine("The File has been cleared.");
    } else{
      Console.WriteLine("The file is already cleared.");
    }
  }
  
}