using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using ProofOfConceptBLZ.Data;
using Microsoft.Identity.Client;
using DataAccessLibrary;
using System.Data;
using DataAccessLibrary.Models;
using System.ComponentModel.Design;

namespace ProofOfConceptBLZ.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {

        private readonly SignInManager<ProofOfConceptBLZ.Data.ApplicationUser> _signInManager;
        private readonly UserManager<ProofOfConceptBLZ.Data.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ISQLDataAccess _db;

        public RegisterModel(SignInManager<ProofOfConceptBLZ.Data.ApplicationUser> signInManager,
                           UserManager<ProofOfConceptBLZ.Data.ApplicationUser> userManager,
                           RoleManager<IdentityRole> roleManager,
                           ISQLDataAccess db
                           ) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
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
                //create company, get ID
                int companyId = await CreateCompany(Input.CompanyName);
                var identity = new ProofOfConceptBLZ.Data.ApplicationUser { UserName = Input.AdminEmail, Email = Input.AdminEmail, CompanyID = companyId };
                var result = await _userManager.CreateAsync(identity, Input.AdminPassword);
                if(!result.Succeeded) 
                { 
                    
                }
                //Role admin
                string adminRole = "Company Administrator";
                var roleResult = IdentityResult.Success;
                
                if(!await _roleManager.RoleExistsAsync(adminRole))
                {
                    var role = new IdentityRole(adminRole);
                    roleResult = await _roleManager.CreateAsync(role);
                }

                var addUserRoleResult = await _userManager.AddToRoleAsync(identity, adminRole);

                if(result.Succeeded && roleResult.Succeeded && addUserRoleResult.Succeeded)
                {
                    await _signInManager.SignInAsync(identity, isPersistent: false);
                    return LocalRedirect(ReturnUrl);
                }

            }

            return Page();

        }

        private async Task<int> CreateCompany(string name)
        {
            int companyId = await _db.SaveDataReturn<int>("dbo.spCompany_Insert", CreateCompanyModel(name));
            return companyId;
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress]
            public string AdminEmail { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [MinLength(8)]
            [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$")]
            [DataType(DataType.Password)]
            public string AdminPassword { get; set; }

            [Required(ErrorMessage = "Company is required.")]
            public string CompanyName { get; set; }
        }

        private CompanyModel CreateCompanyModel(string name)
        {
            CompanyModel m = new();

            m.CompanyName = name;
            m.IsDeleted = false;
            m.HasActivePlan = true;
            m.CreatedDateTime = DateTime.Now;

            return m;
        }

    }
}
