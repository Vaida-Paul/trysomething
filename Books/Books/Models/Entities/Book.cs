namespace Books.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        
        public string ImgUrl { get; set; }
        public int Pages { get; set; }

        public DateTime CreatedAT = DateTime.Now;

        public DateTime UpdatedAT = DateTime.Now;

        public int UserId { get; set; }
        
        public User User { get; set; } = null!; 

    }
}
