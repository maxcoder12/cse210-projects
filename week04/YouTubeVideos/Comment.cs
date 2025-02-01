using System;

public class Comment{
    private string _username;
    private string _textComment;

    public Comment(string username, string textComment){
        _username = username;
        _textComment = textComment;
    }

    public string GetUsername(){
        return _username;
    }

    public string GetTextComment(){
        return _textComment;
    }
}