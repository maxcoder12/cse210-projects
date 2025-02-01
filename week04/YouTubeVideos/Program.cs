using System;
using System.Collections.Generic;

public class Program
{
  public static void Main(string[] args)
  {
    
    List<Comment> firstVideoComments = new List<Comment>();
    Comment firstVideoComment1 = new Comment("FirstUser", "Life is like a list, sometimes you need to add new experiences and remove old ones!" );
    firstVideoComments.Add(firstVideoComment1);

    Comment firstVideoComment2 = new Comment("SecondUser", "Life is like a list, sometimes you need to add new experiences and remove old ones!" );
    firstVideoComments.Add(firstVideoComment2);

    Comment firstVideoComment3 = new Comment("ThirdUser", "Life is like a list, sometimes you need to add new experiences and remove old ones!" );
    firstVideoComments.Add(firstVideoComment3);

    Comment firstVideoComment4 = new Comment("FourthUser", "Life is like a list, sometimes you need to add new experiences and remove old ones!" );
    firstVideoComments.Add(firstVideoComment4);

    // First

    List<Comment> secondVideoComments = new List<Comment>();
    Comment secondVideoComment1 = new Comment("FirstUser", "Coding is like magic—turning logic into reality, one line at a time!" );
    secondVideoComments.Add(secondVideoComment1);

    Comment secondVideoComment2 = new Comment("SecondUser", "Coding is like magic—turning logic into reality, one line at a time!" );
    secondVideoComments.Add(secondVideoComment2);

    Comment secondVideoComment3 = new Comment("ThirdUser", "Coding is like magic—turning logic into reality, one line at a time!" );
    secondVideoComments.Add(secondVideoComment3);

    Comment secondVideoComment4 = new Comment("FourthUser", "Coding is like magic—turning logic into reality, one line at a time!" );
    secondVideoComments.Add(secondVideoComment4);

    // Second

    List<Comment> thirdVideoComments = new List<Comment>();
    Comment thirdVideoComment1 = new Comment("FirstUser", "A bug in the code is just a hidden feature waiting to be understood!" );
    thirdVideoComments.Add(thirdVideoComment1);

    Comment thirdVideoComment2 = new Comment("SecondUser", "A bug in the code is just a hidden feature waiting to be understood!" );
    thirdVideoComments.Add(thirdVideoComment2);

    Comment thirdVideoComment3 = new Comment("ThirdUser", "A bug in the code is just a hidden feature waiting to be understood!" );
    thirdVideoComments.Add(thirdVideoComment3);

    Comment thirdVideoComment4 = new Comment("FourthUser", "A bug in the code is just a hidden feature waiting to be understood!" );
    thirdVideoComments.Add(thirdVideoComment4);

    // Third

    List<Comment> fourthVideoComments = new List<Comment>();
    Comment fourthVideoComment1 = new Comment("FirstUser", "Lists are like friendships—they grow, change, and sometimes need a little sorting!" );
    fourthVideoComments.Add(fourthVideoComment1);

    Comment fourthVideoComment2 = new Comment("SecondUser", "Lists are like friendships—they grow, change, and sometimes need a little sorting!" );
    fourthVideoComments.Add(fourthVideoComment2);

    Comment fourthVideoComment3 = new Comment("ThirdUser", "Lists are like friendships—they grow, change, and sometimes need a little sorting!" );
    fourthVideoComments.Add(fourthVideoComment3);

    Comment fourthVideoComment4 = new Comment("FourthUser", "Lists are like friendships—they grow, change, and sometimes need a little sorting!" );
    fourthVideoComments.Add(fourthVideoComment4);

    // Fourth


    Video firstVideo = new Video(firstVideoComments, "Life Like", "Benito Martinez", 98);
    Video secondVideo = new Video(secondVideoComments, "Coding like", "Maximo Gomez", 79);
    Video thirdVideo = new Video(thirdVideoComments, "Bug Code", "Lorenzo Perez", 45);
    Video fourthVideo = new Video(fourthVideoComments, "List Friedship", "Julya Machado", 120);

    List<Video> videos = new List<Video> {firstVideo, secondVideo, thirdVideo, fourthVideo};

    foreach (Video video in videos){
        Console.WriteLine(video.DisplayVideoInfo());
    }
  }      
}
