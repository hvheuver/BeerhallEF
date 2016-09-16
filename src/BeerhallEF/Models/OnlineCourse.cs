namespace BeerhallEF.Models
{
    public class OnlineCourse : Course
    {
        public string Url { get; set; }

        protected OnlineCourse()
        {
        }

        public OnlineCourse( string title, Language language, Brewer brewer, string url) : this()
        {
            Title = title;
            Language = language;
            Brewer = brewer;
            Url = url;
        }
    }
}

