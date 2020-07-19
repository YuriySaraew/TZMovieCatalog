namespace MovCat.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedYear { get; set; }
        public string Director { get; set; }
        public string FilePath { get; set; }

        public int? userID { get; set; }
    }
}
