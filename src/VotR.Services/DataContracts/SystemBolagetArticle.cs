namespace VotR.Services.DataContracts
{
    public class SystemBolagetArticle
    {
        public string ArticleId { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Description { get; set; }
        public string PriceWithVat { get; set; }
        public string VolumeInLiters { get; set; }
        public string PricePerLiter { get; set; }
        public string SaleStart { get; set; }
        public string SaleStop { get; set; }
        public string ArticleGroup { get; set; }
        public string PackageType { get; set; }
        public string Origin { get; set; }
        public string OriginCountry { get; set; }
        public string Producer { get; set; }
        public string Supplier { get; set; }
        public string Vintage { get; set; }
        public string TestedVintage { get; set; }
        public string Alcohol { get; set; }
        public string Range { get; set; }
        public string Ecologic { get; set; }
        public string Koscher { get; set; }
        public string DescriptionRaw { get; set; }
    }
}
