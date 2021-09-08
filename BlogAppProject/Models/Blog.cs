using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppProject.Models
{
    public class Blog
    {
        //Primary key 
        public int Id { get; set; }
        //Foreign Key
        public string BlogUserId { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="The {0} must be at least {2} and at most {1} characters.",MinimumLength =2)]
        public string Name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="Created Date")]
        public DateTime Created { get; set; }
        //Updated declared as nullable with the ?
        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }
        [Display(Name="Blog Image")]
        public byte[] ImageData { get; set; }
        //Image data
        [Display(Name = "Image Type")]
        public string ContentType { get; set; }
        //Image selected file by the user feeds ImageData and Content Type, Not mapped to not store in database
        [NotMapped]
        public IFormFile Image { get; set; }
        //Navigation property 
        //Parent property
        public virtual BlogUser BlogUser { get; set; }
        //Children properties
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();


    }
}
