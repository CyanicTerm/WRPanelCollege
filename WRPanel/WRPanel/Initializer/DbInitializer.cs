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
                    _db.Database.Migrate();

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
                UserName = "admin@test.com",
                Email = "admin@test.com",
                Name = "Admin",

            },"Admin123*").GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "manager@test.com",
                Email = "manager@test.com",
                Name = "Manager",

            }, "Admin123*").GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "owner@test.com",
                Email = "owner@test.com",
                Name = "Owner",

            }, "Admin123*").GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "employee@test.com",
                Email = "employee@test.com",
                Name = "Employee",

            }, "Admin123*").GetAwaiter().GetResult();

            ApplicationUser userAdmin = _db.ApplicationUsers.Where(x => x.Email == "admin@test.com").FirstOrDefault();
            ApplicationUser userManager = _db.ApplicationUsers.Where(x => x.Email == "manager@test.com").FirstOrDefault();
            ApplicationUser userOwner = _db.ApplicationUsers.Where(x => x.Email == "owner@test.com").FirstOrDefault();
            ApplicationUser userEmployee = _db.ApplicationUsers.Where(x => x.Email == "employee@test.com").FirstOrDefault();

            _userManager.AddToRoleAsync(userAdmin, SD.Role_Admin).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(userManager, SD.Role_Manager).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(userOwner, SD.Role_Owner).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(userEmployee, SD.Role_Employee).GetAwaiter().GetResult();

            //Seed Clients to database
            if (_db.Clients.Count() == 0)
            {
                _db.Clients.Add(new Client
                {
                    FirstName = "Andrzej",
                    LastName = "Rakowski",
                    Email = "andrzej.rakowski@test.com",
                    Phone = "666024312"
                });

                _db.Clients.Add(new Client
                {
                    FirstName = "Marek",
                    LastName = "Kowalski",
                    Email = "marek.kowalski@test.com",
                    Phone = "501423956"
                });

                _db.Clients.Add(new Client
                {
                    FirstName = "Sylwester",
                    LastName = "Stanowski",
                    Email = "sylwester.stanowski@test.com",
                    Phone = "888354092"
                });

                _db.Clients.Add(new Client
                {
                    FirstName = "Mariusz",
                    LastName = "Tracz",
                    Email = "mariusz.tracz@test.com",
                    Phone = "476555222"
                });
                _db.SaveChanges();
            }
            
            //SeedToDos to database

            if (_db.ToDos.Count() == 0)
            {
                _db.ToDos.Add(new ToDo
                {
                    TaskName = "Zamówić opony",
                    IsImportant = true,
                    IsDone = false,
                    Description = "Opony Toyo z OtoMoto"
                });
                _db.ToDos.Add(new ToDo
                {
                    TaskName = "Zakupić kompresor",
                    IsImportant = true,
                    IsDone = false,
                    Description = "Kompresor W40B50"
                });
                _db.ToDos.Add(new ToDo
                {
                    TaskName = "Zakupić wyważarkę",
                    IsImportant = true,
                    IsDone = false,
                    Description = "Wyważarka Hoffmann"
                });
                _db.ToDos.Add(new ToDo
                {
                    TaskName = "Zadzwonić do klienta",
                    IsImportant = true,
                    IsDone = false,
                    Description = "Andrzej Bawara - 666432678"
                });
                _db.ToDos.Add(new ToDo
                {
                    TaskName = "Dodać samochód do przechowalni",
                    IsImportant = true,
                    IsDone = false,
                    Description = "Klient z BMW Runflat"
                });
                _db.SaveChanges();
            }
            
            if (_db.Storages.Count() == 0)
            {
                _db.Storages.Add(new Storage
                {
                    StorageNum = 1,
                    PlateNum = "KR666PL",
                    Tire = "BridgeStone",
                    TireNum = 4,
                    Rim = "Silver",
                    RimNum = 4,
                    Description = "Rok 2012, 215/55 R16",
                    ClientId = _db.Clients.FirstOrDefault(a => a.Phone == "476555222").Id
                });
                _db.Storages.Add(new Storage
                {
                    StorageNum = 2,
                    PlateNum = "KR666PL",
                    Tire = "Toyo",
                    TireNum = 2,
                    Rim = "Black",
                    RimNum = 2,
                    Description = "Rok 2008, 225/40 R16",
                    ClientId = _db.Clients.FirstOrDefault(a => a.Phone == "888354092").Id
                });
                _db.Storages.Add(new Storage
                {
                    StorageNum = 3,
                    PlateNum = "KR666PL",
                    Tire = "Dębica",
                    TireNum = 4,
                    Rim = null,
                    RimNum = null,
                    Description = "Rok 2022, 185/45 R16",
                    ClientId = _db.Clients.FirstOrDefault(a => a.Phone == "501423956").Id
                });
                _db.Storages.Add(new Storage
                {
                    StorageNum = 4,
                    PlateNum = "KR666PL",
                    Tire = "Pirelli",
                    TireNum = 4,
                    Rim = "Silver",
                    RimNum = 4,
                    Description = "Rok 2018, 195/50 R16",
                    ClientId = _db.Clients.FirstOrDefault(a => a.Phone == "666024312").Id
                });
                _db.Storages.Add(new Storage
                {
                    StorageNum = 5,
                    PlateNum = "KR666PL",
                    Tire = "Michelin",
                    TireNum = 2,
                    Rim = "Silver",
                    RimNum = 2,
                    Description = "Rok 2019, 205/60 R16",
                    ClientId = _db.Clients.FirstOrDefault(a => a.Phone == "476555222").Id
                });
                _db.SaveChanges();
            }                        
        }
    }
}
