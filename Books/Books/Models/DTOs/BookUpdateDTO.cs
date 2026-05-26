namespace Books.Models.DTOs
{
    public class BookUpdateDTO
    {
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int Pages { get; set; }
        public string ImgUrl { get; set; }
    }
}
