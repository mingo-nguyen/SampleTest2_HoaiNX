using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantBusiness.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace RestaurantWebapp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public LoginInput LoginData { get; set; } = new LoginInput();

        public string? ErrorMessage { get; set; }

        public void OnGet(string? returnUrl = null)
        {
            // Store the return URL in ViewData to maintain it during postback
            ViewData["ReturnUrl"] = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid)
                return Page();

            // TODO: Replace with actual user authentication from your database
            // This is a mock implementation for demonstration
            var user = AuthenticateUser(LoginData.Username, LoginData.Password);

            if (user == null)
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = LoginData.RememberMe,
                RedirectUri = returnUrl
            };

            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity), authProperties);

            _logger.LogInformation("User {Username} logged in at {Time}", user.Username, DateTime.UtcNow);

            // Redirect based on role
            if (user.Role == "Admin")
                return LocalRedirect("/Admin/Dashboard");
            else
                return LocalRedirect("/Customer/Dashboard");
        }

        // Mock authentication - replace with actual database authentication
        private User? AuthenticateUser(string username, string password)
        {
            // In a real app, you would verify against your database
            var mockUsers = new List<User>
            {
                new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin" },
                new User { Id = 2, Username = "customer", Password = "customer123", Role = "Customer" }
            };

            return mockUsers.FirstOrDefault(u =>
                u.Username == username &&
                u.Password == password);
        }
    }

    public class LoginInput
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
