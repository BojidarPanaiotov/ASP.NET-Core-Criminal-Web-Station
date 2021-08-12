namespace Criminal_Web_Station.Areas.Admin.Models
{
    public class AdminBanInfoFormModel
    {
        public string AccountId { get; set; }
        public string Reason { get; set; }
        public int TotalBanSeconds { get; set; }
    }
}
