namespace Pustok_Temp.Areas.PustokAdmin.ViewModels
{
    public class CreateBookVM
    {
        public string? Title { get; set; }
        public string? ImgUrl { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public string Tag { get; set; }
        List<int> TagIds { get; set; }


    }
}
