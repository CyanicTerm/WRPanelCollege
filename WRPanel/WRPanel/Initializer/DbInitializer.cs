using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WRPanel.Data;
using WRPanel.Models;
using WRPanel.Utility;

namespace WRPanel.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                
            }

            _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Manager)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Owner)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Name = "Admin",

            },"Admin123*").GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "manager@gmail.com",
                Email = "manager@gmail.com",
                Name = "Manager",

            }, "Admin123*").GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "owner@gmail.com",
                Email = "owner@gmail.com",
                Name = "Owner",

            }, "Admin123*").GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "employee@gmail.com",
                Email = "employee@gmail.com",
                Name = "Employee",

            }, "Admin123*").GetAwaiter().GetResult();

            ApplicationUser userAdmin = _db.ApplicationUsers.Where(x => x.Email == "admin@gmail.com").FirstOrDefault();
            ApplicationUser userManager = _db.ApplicationUsers.Where(x => x.Email == "manager@gmail.com").FirstOrDefault();
            ApplicationUser userOwner = _db.ApplicationUsers.Where(x => x.Email == "owner@gmail.com").FirstOrDefault();
            ApplicationUser userEmployee = _db.ApplicationUsers.Where(x => x.Email == "employee@gmail.com").FirstOrDefault();

            _userManager.AddToRoleAsync(userAdmin, SD.Role_Admin).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(userManager, SD.Role_Manager).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(userOwner, SD.Role_Owner).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(userEmployee, SD.Role_Employee).GetAwaiter().GetResult();
        }
    }
}
