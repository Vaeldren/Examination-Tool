using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FinalYearProject.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace FinalYearProject.Server.Areas.Identity.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        // *************************************************
        // This is the user that will be automatically 
        // made an Administrator
        // *************************************************
        const string ADMINISTRATOR_USERNAME = "Admin@email";
        const string ADMINISTRATION_ROLE = "Administrators";
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegisterModel(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public class InputModel
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Surname")]
            public string SecondName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage =
                "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage =
                "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins =
                (await _signInManager.GetExternalAuthenticationSchemesAsync())
                .ToList();
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins =
                (await _signInManager.GetExternalAuthenticationSchemesAsync())
                .ToList();
            if (ModelState.IsValid)
            {
                var user =
                    new ApplicationUser
                    {
                        UserName = Input.Email,
                        Email = Input.Email,
                        FirstName = Input.FirstName,
                        SecondName = Input.SecondName
                    };
                var result =
                    await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    // Set confirm Email for user
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                    // ensure there is a ADMINISTRATION_ROLE
                    var RoleResult =
                        await _roleManager.FindByNameAsync(ADMINISTRATION_ROLE);
                    if (RoleResult == null)
                    {
                        // Create ADMINISTRATION_ROLE Role
                        await _roleManager.CreateAsync(new IdentityRole(ADMINISTRATION_ROLE));
                    }

                    var RoleResult2 = await _roleManager.FindByNameAsync("Users");
                    if (RoleResult2 == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Users"));
                    }

                    var RoleResult3 = await _roleManager.FindByNameAsync("Teachers");
                    if (RoleResult3 == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Teachers"));
                    }

                    if (user.UserName.ToLower() == ADMINISTRATOR_USERNAME.ToLower())
                        //if name matches admin@email
                    {
                        // Put admin in Administrator role
                        await _userManager.AddToRoleAsync(user, ADMINISTRATION_ROLE);
                    }

                    else if (user.UserName.ToLower() == "teacher@email")
                    //if name matches teacher@email
                    {
                        // Put admin in Administrator role
                        await _userManager.AddToRoleAsync(user, "Teachers");
                    }

                    else
                    {
                        // Put admin in Administrator role
                        await _userManager.AddToRoleAsync(user, "Users");
                    }


                    // Log user in
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}