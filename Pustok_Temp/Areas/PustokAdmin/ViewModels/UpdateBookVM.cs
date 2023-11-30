namespace Pustok_Temp.Areas.PustokAdmin.ViewModels
{
    public class UpdateBookVM
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImgUrl { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }

    }
}
