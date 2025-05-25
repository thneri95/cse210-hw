using System;

class Program
{
    static void Main(string[] args)

    {

        List<Video> videos = new List<Video>();

        Video video1 = new Video("The Restoration of the Gospel", "The Church of Jesus Christ of Latter-day Saints", 420);
        video1.AddComment(new Comment("Emma", "This video brings peace to my heart"));
        video1.AddComment(new Comment("Joseph", "So inspiring! I felt the Spirit"));
        video1.AddComment(new Comment("Lucy", "I'm grateful for the Prophet Joseph Smith"));

        Video video2 = new Video("Jesus Christ: Our Savior", "The Church of Jesus Christ of Latter-day Saints", 360);
        video2.AddComment(new Comment("John", "He truly is the Light of the World"));
        video2.AddComment(new Comment("Mary", "This strengthened my testimony"));
        video2.AddComment(new Comment("Nephi", "Powerful message about the Atonement"));

        Video video3 = new Video("Temples: Houses of the Lord", "The Church of Jesus Christ of Latter-day Saints", 510);
        video3.AddComment(new Comment("Sarah", "I feel peace every time I go to the temple"));
        video3.AddComment(new Comment("Alma", "I can't wait for my endowment"));
        video3.AddComment(new Comment("Helaman", "The temple is truly the Lord's house"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
