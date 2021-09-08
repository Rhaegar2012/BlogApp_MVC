using BlogAppProject.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        //Foreing Keys
        public int PostId { get; set; }
        public string BlogUserId { get; set; }
        public string ModeratorId { get; set; }
        //Content properties
        [Required]
        [StringLength(500,ErrorMessage ="The {0) must be at least {2} and no more than {1} characters long",MinimumLength =2)]
        [Display(Name ="Comment")]
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Moderated { get; set; }
        public DateTime? Deleted { get; set; }
        [StringLength(500, ErrorMessage = "The {0) must be at least {2} and no more than {1} characters long", MinimumLength = 2)]
        [Display(Name = "Moderated Comment")]
        public string ModeratedBody { get; set; }
        public ModerationType ModerationType { get; set; }
        //Navigation properties 
        //Holds the entire record represented by PostId
        //Navigational Properties
        //IdentityUser is a generic user , the type is called from ASP.NET core
        //Parent properties
        public virtual BlogUser BlogUser { get; set; }
        public virtual BlogUser Moderator { get; set; }
        public virtual Post Post { get; set; }


    }
}
