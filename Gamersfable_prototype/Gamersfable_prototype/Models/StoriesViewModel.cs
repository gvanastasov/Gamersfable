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

    public class StoryEditViewModel
    {
        [Required]
        public int StoryID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public StoryEditViewModel()
        {

        }

        public StoryEditViewModel(Story story)
        {
            this.StoryID = story.Id;
            this.Title = story.Title;
            this.Body = story.Body;
        }
    }
}