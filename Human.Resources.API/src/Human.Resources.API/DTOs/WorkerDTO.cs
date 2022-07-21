namespace Human.Resources.API.DTOs
{
    public class WorkerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkerStatus { get; set; }
        public string WorkTitle { get; set; }        
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public string? ReasonOut { get; set; }
    }
}
