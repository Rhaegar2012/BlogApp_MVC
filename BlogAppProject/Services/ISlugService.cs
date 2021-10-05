using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppProject.Services
{
    public interface ISlugService
    {
        string urlfriendly(string title);
        bool IsUnique(string slug);

    }
}
