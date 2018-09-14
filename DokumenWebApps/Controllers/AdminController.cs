using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DokumenWebApps.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string userid, string role)
        {
            var pengguna = await _userManager.FindByNameAsync(userid);
            try
            {
                await _userManager.AddToRoleAsync(pengguna, role);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            return View();
        }
    }
}