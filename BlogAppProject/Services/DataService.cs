using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppProject.Data;
using BlogAppProject.Enums;
using Microsoft.AspNetCore.Identity;

namespace BlogAppProject.Services
{
    public class DataService
    {
        //Properties
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;

        //Constructor with an injected instance of a database registered service 
        public DataService(ApplicationDbContext dbContext , RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
        }
        //Methods 
        //Callback to class methods 
        public async Task ManageDataAsync()
        {
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
                await _roleManager.CreateAsync(new IdentityRole(role))
            }
        }

        private async Task SeedUsersAsync()
        {

        }






     

    }
}
