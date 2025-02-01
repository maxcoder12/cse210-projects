using System.Collections.Generic;
using System;

public class Video{
    private List<Comment> _comments;
    private string _title;
    private string _author;
    private int _length;

    public Video(List<Comment> comments, string title, string author, int length){
        _comments = comments;
        _title = title;
        _author = author;
        _length = length;
    }

    public int GetNumberOfComments(){
        return _comments.Count;
    }

    public string DisplayVideoInfo(){
        string videoInfo = $"The Video called '{_title}' of '{_author}' lasts '{_length}' seconds, and has '{GetNumberOfComments()}' comments, whose are:\n";
        string commentsText = "";

        foreach (Comment comment in _comments){
            commentsText += comment.GetUsername() + "\n" + comment.GetTextComment() + "\n";
        }

        return videoInfo + commentsText;

    }
}