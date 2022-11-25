namespace Human.Resources.API.Domain.Entities
{
    public class WorkTitleInfoEntity
    {
        public int Id { get; set; }
        public string? WorkTitle { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public string? Reason { get; set; }
    }
}
