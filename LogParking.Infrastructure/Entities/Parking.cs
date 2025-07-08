namespace LogParking.Infrastructure.Entities
{
    public class Parking
    {
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public string VehicleNumber { get; set; } = string.Empty;
        public DateTime ParkedAt { get; set; }
        public DateTime? ExitedAt { get; set; }
    }
}
