using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Web.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Blog.Logic.Entities;

namespace Blog.Web.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<User> userManager;
        public RoleController(RoleManager<IdentityRole> role, UserManager<User> user)
        {
            roleManager = role;
            userManager = user;
        }
        public IActionResult Create() => View();
        public IActionResult Index() => View(roleManager.Roles.ToList());
        [HttpPost]
        public async Task<IActionResult> CreateRole(string Name)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                IdentityResult Result = await roleManager.CreateAsync(new IdentityRole(Name));
                if (Result.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (var errors in Result.Errors)
                        ModelState.AddModelError(string.Empty, errors.Description);
            }
            return View(Name);
        } 
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string Id)
        {
            IdentityRole Role = await roleManager.FindByIdAsync(Id);
            if (Role != null)
            {
                IdentityResult del = await roleManager.DeleteAsync(Role);
            }
            return RedirectToAction("Index");
        }
        //////
        public IActionResult UList() => View(userManager.Users.ToList());
        //////
        [HttpPost]
        public async Task<IActionResult> GetUsersAndRoles(string Id)
        {
            User user = await userManager.FindByIdAsync(Id);
            if (user != null)
            {
                var UserRole = await userManager.GetRolesAsync(user);
                var AllRole = roleManager.Roles.ToList();
                ChangeRoleView changeRole = new ChangeRoleView
                {
                    AllRoles = AllRole,
                    UserRoles = UserRole,
                    UserId = user.Id,
                    UserMail = user.Mail
                };
                return View(changeRole);
            }
            return NotFound();
        }
        ///////
        public async Task<IActionResult> GetUsersAndRoles(string Id, List<string> role)
        {
            User user = await userManager.FindByIdAsync(Id);
            if(user!=null)
            {
                var UserRole = await userManager.GetRolesAsync(user);
                var AllRole = roleManager.Roles.ToList();
                var AddRoles = role.Except(UserRole);
                var DeleteRoles = UserRole.Except(role);
                await userManager.AddToRolesAsync(user,AddRoles);
                await userManager.RemoveFromRolesAsync(user, DeleteRoles);
                return View("UList");
            }
            return NotFound();
        }
    }
}
