namespace API.Data.Entities
{
    public enum StatusDestination{
        waitApprove = 0,
        enable = 1,
        disenable = 2
    }
    public enum ProvinceOrAreaOrPrArea{
        province = 0,
        desSpecial = 1,
        desNormal = 2
    }
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgAvatar { get; set; }
        public string ShortDecription { get; set; }
        public ProvinceOrAreaOrPrArea ProvinceOrAreaOrPrArea { get; set; }
        public int View { get; set; }
        public string Content { get; set; }
        public StatusDestination Status { get; set; }
        public decimal? NumberStar { get; set; }
        public string? Tips { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        // public string? UrlWebsite { get; set; }
        // public string? WhoGoTogether { get; set; }
        // public string? TimeRecomment { get; set; }
        // public string? TimeVisit { get; set; }
        // public int? PriceAdv { get; set; }
        public string? Address { get; set; }
        public string? Logitude { get; set; }
        public string? Latitude { get; set; }
        public int ProvinceId { get; set; }
        public Province? Province { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        // public int? ImageShareId { get; set; }
        // public ImageShare? ImageShare { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int? TypeDestinationId { get; set; }
        public TypeDestination? TypeDestination { get; set; }
        public List<ImageDestination>? ImageDestinations { get; set; }
        public List<ImageShareDestination>? ImageShareDestinations { get; set; }
        public List<ReviewDestination>? ReviewDestinations { get; set; }
        public List<QuestionDestination>? QuestionDestinations { get; set; }
        public List<BlogDestination>? BlogDestinations { get; set; }
        public List<PlanDestination>? PlanDestinations { get; set; }
        // public List<PlanDate>? PlanDates { get; set; }
    }
}