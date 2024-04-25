namespace ReactApp1.Server.Model
{
    public class ThemeUpdate
    {
        public int UserId { get; set; }
        public string Theme { get; set; }
        public string ImagePath { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
