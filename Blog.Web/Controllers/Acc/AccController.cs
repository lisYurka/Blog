using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Blog.Web.ViewModel;
using Blog.Logic.Context;
using Blog.Logic.Entities;
using Microsoft.EntityFrameworkCore;
using Blog.Logic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Blog.Web.Controllers
{
    public class AccController: Controller
    {
        public DataContext dataContext;
        public AccController(DataContext data)
        {
            dataContext = data;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        private async Task Authenticate(User user)
        {
            var Claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role?.Name)
            };
            ClaimsIdentity identity = new ClaimsIdentity(Claims,
                "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(identity));
        }
        //добавление в БД
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel register)
        {
            if(ModelState.IsValid)
            {
                User user = await dataContext.Users.FirstOrDefaultAsync(q=>q.Login==register.Login);
                if(user==null)
                {
                    user = new User
                    {
                        Mail=user.Mail,
                        Login=user.Login,
                        Password=user.Password
                    };
                    Role UserRole = await dataContext.Roles.FirstOrDefaultAsync(w=>w.Name=="User");
                    if(UserRole!=null)
                    {
                        user.Role = UserRole;
                    }
                    dataContext.Users.Add(user);
                    await dataContext.SaveChangesAsync();
                    await Authenticate(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("","Неверный логин-пароль");
                }
            }
            return View(register);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if(ModelState.IsValid)
            {
                User user = await dataContext.Users.Include(q => q.Role).FirstOrDefaultAsync
                    (w => w.Login == login.Login && w.Password == login.Password);
                if(user!=null)
                {
                    await Authenticate(user);
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("","Неверный логин-пароль");
            }
            return View(login);
        }
        /*
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        //....
        public AccController(UserManager<User> user, SignInManager<User> signIn)
        {
            userManager = user;
            signInManager = signIn;
        }
        ////////
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string retURL = null)
        {
            return View(new LoginModel{ returnURL = retURL });
        }
        ////////
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel register)
        {
            if(ModelState.IsValid)
            {
                User user = new User
                {
                    Mail = register.Mail,
                    Login = register.Login
                    //.......
                };
                var Result = await userManager.CreateAsync(user,register.Password);//добавление в БД
                if(Result.Succeeded)
                {
                    await signInManager.SignInAsync(user,false);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    foreach (var errors in Result.Errors)
                        ModelState.AddModelError(string.Empty,errors.Description);
                }
            }
            return View(register);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var Result = await signInManager.PasswordSignInAsync(viewModel.Login, viewModel.Password, viewModel.SaveLoginPassword, false);
                if (Result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(viewModel.returnURL) && Url.IsLocalUrl(viewModel.returnURL))
                        return RedirectToAction(viewModel.returnURL);
                    else
                        return RedirectToAction("Index", "Home");
                }
            }
            else
                ModelState.AddModelError("","Incorrect login-password");
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logoff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }*/
    }
}
