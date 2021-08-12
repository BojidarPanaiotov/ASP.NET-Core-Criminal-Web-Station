namespace Criminal_Web_Station.Data.Entities
{
    using System;

    public class Ban
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public Account Account { get; set; }
        public string AccoundId { get; init; }
        public string ReasonDescription { get; set; }
        public int BannedForSeconds { get; set; }
    }
}
