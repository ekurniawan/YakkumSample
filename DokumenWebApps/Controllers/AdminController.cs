﻿using System;
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

        public IActionResult Index()
        {
            
            return Content($"User is in role admin {User.IsInRole("admin")}");
        }

        public async Task<IActionResult> CreateRole(string role)
        {
            try
            {
                await penggunaDAL.CreateRole(role);
                return Content("Berhasil menambahkan role");
            }
            catch (Exception ex)
            {
                return Content($"Error:{ex.Message}");
            }
        }

        //Admin/RegisterUserToRole?username=erick.kurniawan@gmail.com&role=admin
        public async Task<IActionResult> RegisterUserToRole(string username,string role)
        {
            try
            {
                await penggunaDAL.AddUserToRole(username, role);
                return Content($"Berhasil mendaftakan user {username} ke role {role}");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }
    }
}