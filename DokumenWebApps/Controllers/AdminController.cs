using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DokumenWebApps.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DokumenWebApps.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private PenggunaDAL penggunaDAL;
        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            penggunaDAL = new PenggunaDAL(_userManager,_roleManager);
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                await penggunaDAL.CreateRole("admin");
                return Content("Berhasil menambahkan role");
            }
            catch(Exception ex)
            {
                return Content($"Error:{ex.Message}");
            }
        }
    }
}