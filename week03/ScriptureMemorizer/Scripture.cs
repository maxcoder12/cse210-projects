using System.Collections.Generic;
using System;

public class Scripture{
  private Reference _reference = new Reference("",0,0);
  private List<Word> _words = new List<Word>();


  public Scripture(Reference reference, string text)
  {
    _reference = reference;

    string[] textSeparated = text.Split(' ');
    for (int i = 0; i < textSeparated.Length; i++)
    {
      _words.Add(new Word($"{textSeparated[i]}"));
    }
  }

  public void HideRandomWords(int numberToHide)
  {
    Random random = new Random();
    int hiddenCount = 0;
    
    while (hiddenCount < numberToHide && !IsCompletelyHidden())
    {
      int randomIndex = random.Next(_words.Count);

      if (!_words[randomIndex].IsHidden())
      {
        _words[randomIndex].Hide();
        hiddenCount++;
      }
    }
  }

  public string GetDisplayText()
  {
    string textReference = _reference.GetDisplayText();
    string text = "";

    for (int i = 0; i < _words.Count; i++){
      text += _words[i].GetDisplayText() + " ";
      text.Trim();
    }
    
    return $"{textReference} {text}";
  }

  public bool IsCompletelyHidden()
  {
    int allWordsHidden = 0;
    foreach(Word word in _words){
      Word _word = new Word($"{word}");
      string text = word.GetDisplayText();
      if (text == new string('_', text.Length))
      {
        allWordsHidden++;
      }
    }
    if (allWordsHidden == _words.Count){
      return true;
    }
    else{
      return false;
    }
  }
}