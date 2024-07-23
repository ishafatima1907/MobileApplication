namespace MobileApplication.Manager.DTOs
{
    public class MobileInfoDto
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int YearOfMake { get; set; }
        public decimal Price { get; set; }
        public ICollection<MobileSpecsDto> MobileSpecs { get; set; }
    }
}
