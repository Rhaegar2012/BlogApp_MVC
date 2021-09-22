using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppProject.Data;
using BlogAppProject.Enums;
using BlogAppProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogAppProject.Services
{
    public class DataService
    {
        //Properties
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        //Constructor with an injected instance of a database registered service 
        public DataService(ApplicationDbContext dbContext , 
                           RoleManager<IdentityRole> roleManager,
                           UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        //Methods 
        //Callback to class methods 
        public async Task ManageDataAsync()
        {
            // Create database from existing migrations 
            await _dbContext.Database.MigrateAsync();
            //Task 1: Seed a few roles into the system
            await SeedRolesAsync();
            //Task 2: Seed a few users into the system
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //If there are already Roles in the system, do nothing
            if (_dbContext.Roles.Any())
            {
                return;
            }
            //Otherwise we create a few roles
            foreach (var role in Enum.GetNames(typeof(BlogRole)))
            {
                //Use the Role Manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task SeedUsersAsync()
        {
            if (_dbContext.Users.Any())
            {
                return;
            }
            //Step 1: Local variable for admin user, creates a new instance of Blog User
            var adminUser = new BlogUser()
            {
                Email = "josebsg75@hotmail.com",
                UserName = "JoseT",
                FirstName = "Jose",
                LastName = "Tellez",
                PhoneNumber = "(604) 319-2926",
                EmailConfirmed = true
            };
            //Step 2: Use the UserManager to create a new user that is defined by adminuser
            //This step adds it to the database
            await _userManager.CreateAsync(adminUser, "Alphasierra117+");
            //Step 3: Add the new user to the Administrator role 
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            //Add moderator user
            var modUser = new BlogUser()
            {
                Email = "email@email.com",
                UserName = "Mod",
                FirstName = "Rhaegar",
                LastName = "Targaryen",
                PhoneNumber = "(800) 555-1212",
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(modUser, "Alphasierra117+");
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
        }






     

    }
}
