namespace Mi_Granjita_Paraiso.DTOs
{
    public class MarketPlaceSearch
    {
        public long[] CategoriesId { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public int MyProperty { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long[] Ids { get; internal set; }
    }
}