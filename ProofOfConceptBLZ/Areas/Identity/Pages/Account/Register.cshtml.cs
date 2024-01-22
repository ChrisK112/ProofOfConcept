using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using ProofOfConceptBLZ.Data;
using Microsoft.Identity.Client;

namespace ProofOfConceptBLZ.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {

        private readonly SignInManager<ProofOfConceptBLZ.Data.ApplicationUser> _signInManager;
        private readonly UserManager<ProofOfConceptBLZ.Data.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(SignInManager<ProofOfConceptBLZ.Data.ApplicationUser> signInManager,
                           UserManager<ProofOfConceptBLZ.Data.ApplicationUser> userManager,
                           RoleManager<IdentityRole> roleManager 
                           ) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input {  get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");
            if(ModelState.IsValid)
            {
                var identity = new ProofOfConceptBLZ.Data.ApplicationUser { UserName = Input.Email, Email = Input.Email, CompanyID = Input.CompanyID };
                var result = await _userManager.CreateAsync(identity, Input.Password);

                var role = new IdentityRole(Input.Role);
                var roleResult = await _roleManager.CreateAsync(role);

                var addUserRoleResult = await _userManager.AddToRoleAsync(identity, Input.Role);

                if(result.Succeeded && roleResult.Succeeded && addUserRoleResult.Succeeded)
                {
                    await _signInManager.SignInAsync(identity, isPersistent: false);
                    return LocalRedirect(ReturnUrl);
                }

            }

            return Page();

        }

        public class InputModel
        {
            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Company is required.")]
            public string CompanyID { get; set; }

            [Required(ErrorMessage = "Role is required.")]
            public string Role { get; set; }
        }

    }
}
