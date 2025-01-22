namespace Domain.Entities
{
    public class Tag:Entity
    {
        public required string NameEn {  get; set; }
        public required string NameAr {  get; set; }
        public required string PropertyEn {  get; set; }
        public required string PropertyAr {  get; set; }
        public required string ContentEn {  get; set; }
        public required string ContentAr {  get; set; }
    }
}
