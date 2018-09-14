using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokumenWebApps.DAL
{
    public class PenggunaDAL
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public PenggunaDAL(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<string>> GetAllUser()
        {
            var results = await _userManager.Users.Select(r => r.UserName).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<List<string>> GetAllRole()
        {
            var results = await _roleManager.Roles.Select(r => r.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task AddRoleToUser(string userid, string role)
        {
            var user = await _userManager.FindByNameAsync(userid);
            try
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }


    }
}
