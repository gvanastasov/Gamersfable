using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamersfable_prototype.Models
{
    public class StoriesViewModel
    {
        public List<Story> top3 = new List<Story>();
        public List<Story> last10 = new List<Story>();
    }

    public class StoryCreateViewModel
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [DisplayName("Game Title")]
        public string GameID { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public IEnumerable<SelectListItem> Games { get; set; }
    }
}