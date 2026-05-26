namespace Books.Models.DTOs
{
    public class BookReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int Pages { get; set; }
        public string ImgUrl { get; set; }
    }
}
