namespace Criminal_Web_Station.Areas.Identity.Pages.Account
{
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using UserAccount = Data.Entities.Account;

    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<UserAccount> userManager;
        private readonly SignInManager<UserAccount> signInManager;
        private readonly IAdminService adminService;

        public LoginModel(
            SignInManager<UserAccount> signInManager,
            UserManager<UserAccount> userManager,
            IAdminService adminService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.adminService = adminService;
        }

        [BindProperty]
        public InputModel Input { get; set; }


        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (this.adminService.IsUserBanned(Input.Email))
                    {
                        var banInfo = this.adminService.GetBanInfo(Input.Email);
                        this.TempData[WebConstats.Warning] = string.Format(WebConstats.UserBanInformation,banInfo.Reason,banInfo.TotalBanSeconds);
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return Page();
                    }
                    this.TempData[WebConstats.Message] = this.User.Identity.Name + WebConstats.SuccessfulLogin;
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            return Page();
        }
    }
}
