using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using MTLcourts.Data;
using MTLcourts.Models;
using Microsoft.AspNetCore.Authorization;
namespace MTLcourts.Pages
{

    [Authorize(Roles = "Admin, Moderator")]
    public class AdminManagementModel : PageModel
    {
        private RoleManager<IdentityRole> roleManager;

        private UserManager<IdentityUser> userManager;

        // private CourtsDbContext db;

        // [BindProperty]
        // public InputModel Input { get; set; }
        public AdminManagementModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager){
            this.userManager = userManager;
            this.roleManager = roleManager;
         
        }
        // public class InputModel
        // {
        
        // [Required]
      
        // public string RoleName { get; set;}
        // }
        
        public List<IdentityRole> LRoles = new List<IdentityRole>();
        public List<IdentityUser> LUsers = new List<IdentityUser>();

        // public List<List<IdentityUser>> myList = new List<List<IdentityUser>>();
        public async Task OnGetAsync()
        {
          LRoles =roleManager.Roles.ToList();
        //   for (int i = 0; i < LRoles.Count; i++)
        //   {
        //         var xquery = from user in LUsers
        //                         where userManager.IsInRoleAsync(user, LRoles[i].Name)
        //                         select
                             
        //         myList[i]= userManager.Users.Where().ToList();
        //   }
            
          LUsers = userManager.Users.ToList();
        }

    public async Task<IActionResult> OnPostAsync(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id); 
            
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToPage("AdminManagement");
                
            }
            else
                ModelState.AddModelError("", "No role found");


            
            return RedirectToPage("AdminManagement");
        }

    

    
    }
}
