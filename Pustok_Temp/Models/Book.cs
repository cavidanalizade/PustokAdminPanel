namespace Pustok_Temp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImgUrl { get; set; }
        public double? Price { get; set; }
        public int? AuthorId { get; set; }
        public Author? Authors { get; set; }
        public List<Book_Img>? Bookimages { get; set; }
        public int? CategoryId { get; set; }
        public Category? Categories { get; set; }


    }
}
