namespace Criminal_Web_Station.Services.Implementations
{
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Models;
    using Criminal_Web_Station.Services.Interfaces;
    using System.Threading.Tasks;
    public class CreditCardService : ICreditCardService
    {
        private readonly ApplicationDbContext context;

        public CreditCardService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(CreditCardFormModel creditCard)
        {
            var creditCardEntity = new CreditCard
            {
                AccountId = creditCard.AccountId,
            };

            await this.context.SaveChangesAsync();
        }
    }
}
