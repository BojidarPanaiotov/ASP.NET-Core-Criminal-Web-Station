namespace Criminal_Web_Station.Services.Interfaces
{
    using Criminal_Web_Station.Services.Models;
    using System.Collections.Generic;
    public interface IPurchaseService
    {
        IEnumerable<PurchaseServiceModel> GetAllPurchasesById(string accountId);
    }
}
