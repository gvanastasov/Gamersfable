using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamersfable_prototype.Models
{
    public class StoriesViewModel
    {
        public List<Story> top3 = new List<Story>();
        public List<Story> last10 = new List<Story>();
    }
}