using System;
using System.Linq;

public class Word{
  private string _text;
  private string _hiddenText;
  private bool _isHidden;
  

  public Word(string text)
  {
    _text = text; 
    _hiddenText = text;
    _isHidden = false;
  }

  public void Hide()
  {
    if (!_isHidden) 
    {
      _hiddenText = new string('_', _text.Length);
      _isHidden = true;
    }
  }
  
  public bool IsHidden(){
    return _text.All(c => c == '_');
  }

  public string GetDisplayText()
  {
    if (_isHidden)
    {
      return _hiddenText;
    }
    else
    {
      return _text;
    }
  }
}