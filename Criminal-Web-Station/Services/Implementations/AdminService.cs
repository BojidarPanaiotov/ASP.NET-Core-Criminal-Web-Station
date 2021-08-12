namespace Criminal_Web_Station.Services.Implementations
{
    using Criminal_Web_Station.Areas.Admin.Models;
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Services.Interfaces;
    using global::AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminService : IAdminService
    {
        private readonly UserManager<Account> userManager;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public AdminService(
            UserManager<Account> userManager,
            IMapper mapper,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.context = context;
        }

        public IEnumerable<UserServiceModel> GetAllUsers()
        {
            return this.userManager
                      .Users
                      .Include(u => u.CreditCard)
                      .Include(u => u.Items)
                      .Select(x => new UserServiceModel
                      {
                          AccountId = x.Id,
                          Username = x.UserName,
                          CreadtedOn = x.CreatedOn,
                          CreditCard = this.mapper.Map<CreditCardServiceModel>(x.CreditCard),
                          ItemsCount = x.Items.Count(),
                          PurchasesCount = x.Purchases.Count()
                      })
                      .OrderByDescending(x => x.ItemsCount)
                      .ToList();
        }

        public string GetUsernameById(string accountId)
            => this.context
                .Accounts
                .FirstOrDefault(x => x.Id == accountId)
                .UserName;

        public bool MarkUserAsBanned(AdminBanInfoFormModel banInformation)
        {
            var user = this.context
                           .Accounts
                           .Find(banInformation.AccountId);
            if(user == null)
            {
                return false;
            }

            user.IsBanned = true;

            var ban = new Ban
            {
                AccoundId = banInformation.AccountId,
                BannedForSeconds = banInformation.TotalBanSeconds,
                ReasonDescription = banInformation.Reason
            };

            this.context
                .Bans
                .Add(ban);

            this.context.SaveChanges();

            return true;
        }
        public bool IsUserBanned(string email)
        {
            var user = this.context
                .Accounts
                .FirstOrDefault(u => u.Email == email);

            return user.IsBanned;
        }

        public AdminBanInfoFormModel GetBanInfo(string userEmail)
        {
            var user = this.context
                 .Accounts
                 .FirstOrDefault(u => u.Email == userEmail);

            var ban = this.context
                .Bans
                .FirstOrDefault(b => b.AccoundId == user.Id);

            return new AdminBanInfoFormModel
            {
                Reason = ban.ReasonDescription,
                TotalBanSeconds = ban.BannedForSeconds
            };
        }
    }
}
