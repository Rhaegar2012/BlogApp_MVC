using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlogAppProject.Models;

namespace BlogAppProject.Data
{
    //Inherits from IdentityDbContext with a BlogUser type to create the customized table 
    public class ApplicationDbContext:IdentityDbContext<BlogUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):
            base(options)
        {

        }
        //Property related to the Blogs table using the data models
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }


    }
}
