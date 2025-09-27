using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Console.WriteLine();

        List<Video> videos = new List<Video>();

        Video videoA = new Video("The Road to Damascus.", "Paul the Apostle", 900);
        videoA.AddComment(new Comment("Precious", "Wow! A very powerful moment of transformation."));
        videoA.AddComment(new Comment("Charity", "Awesome! The Faith restored through divine call."));
        videoA.AddComment(new Comment("Christoff", "Great! This is the real missionary service."));
        videoA.AddComment(new Comment("Mercy", "Amazing! very wonderful movie."));
        videos.Add(videoA);

        Video videoB = new Video("The Turning of Water into Wine.", "Jesus of Nazareth", 550);
        videoB.AddComment(new Comment("Precious", "This is the real power of God."));
        videoB.AddComment(new Comment("Charity", "A mother's faith and trust."));
        videoB.AddComment(new Comment("Christoff", "A miracle that change everything."));
        videos.Add(videoB);

        Video videoC = new Video("Peter: The Fisherman's Journey.", "Peter the Apostle", 1500);
        videoC.AddComment(new Comment("Precious", "What a miracle!"));
        videoC.AddComment(new Comment("Charity", "His courage inspired me."));
        videoC.AddComment(new Comment("Christofferson", "I like the movie so much."));
        videoC.AddComment(new Comment("Ismael", "Full of fishes, they became rich spiritually."));
        videoC.AddComment(new Comment("Barok", "Very interesting!"));
        videos.Add(videoC);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} (seconds)");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("COMMENTS:");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($" {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
            Console.WriteLine("*******************************************************************");

        }
        


    }
}