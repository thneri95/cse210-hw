public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        CommenterName = name;
        Text = text;
    }
}
