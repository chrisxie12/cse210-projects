Video video1 = new Video("C# Fundamentals", "CodeAcademy", 720);
video1.AddComment(new Comment("Alice", "Great tutorial!"));
video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
video1.AddComment(new Comment("Charlie", "I finally understand classes."));

Video video2 = new Video("Abstract Art Explained", "ArtWithMia", 480);
video2.AddComment(new Comment("Diana", "Beautiful explanation."));
video2.AddComment(new Comment("Eve", "I love the examples!"));
video2.AddComment(new Comment("Frank", "Subscribed!"));

Video video3 = new Video("Guitar Basics", "MusicPro", 900);
video3.AddComment(new Comment("Grace", "Perfect for beginners."));
video3.AddComment(new Comment("Hank", "My fingers hurt but worth it!"));
video3.AddComment(new Comment("Ivy", "Can you do a part 2?"));
video3.AddComment(new Comment("Jack", "Awesome lesson."));

Video video4 = new Video("World Travel Vlog", "NomadLife", 600);
video4.AddComment(new Comment("Kate", "This place looks amazing!"));
video4.AddComment(new Comment("Leo", "Adding this to my bucket list."));
video4.AddComment(new Comment("Mia", "What camera do you use?"));

List<Video> videos = new List<Video> { video1, video2, video3, video4 };

foreach (Video video in videos)
{
    Console.WriteLine($"Title: {video.GetTitle()}");
    Console.WriteLine($"Author: {video.GetAuthor()}");
    Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
    Console.WriteLine($"Comments ({video.GetCommentCount()}):");
    foreach (Comment comment in video.GetComments())
    {
        Console.WriteLine($"  {comment.GetCommenterName()}: {comment.GetText()}");
    }
    Console.WriteLine();
}
