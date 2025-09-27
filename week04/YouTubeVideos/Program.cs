using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Learn C# in 10 Minutes", "CodeAcademy", 600);
        Video video2 = new Video("Top 10 Design Patterns", "DevTutorials", 900);
        Video video3 = new Video("Funny Cat Compilation", "PetWorld", 300);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great tutorial, very clear!"));
        video1.AddComment(new Comment("Bob", "Helped me understand OOP."));
        video1.AddComment(new Comment("Charlie", "More videos like this please!"));

        // Add comments to video2
        video2.AddComment(new Comment("Diana", "Love the examples, thanks."));
        video2.AddComment(new Comment("Ethan", "Could you do one on Singleton?"));
        video2.AddComment(new Comment("Fiona", "This was so useful for my project."));

        // Add comments to video3
        video3.AddComment(new Comment("George", "These cats are hilarious 😂"));
        video3.AddComment(new Comment("Hannah", "My kids loved this!"));
        video3.AddComment(new Comment("Ian", "Perfect stress relief."));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display videos with comments
        foreach (Video video in videos)
        {
            Console.WriteLine(video.GetDisplayText());

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetDisplayText()}");
            }

            Console.WriteLine();
        }
    }
}
