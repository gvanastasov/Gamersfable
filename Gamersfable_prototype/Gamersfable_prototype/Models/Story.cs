﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gamersfable_prototype.Models
{
    public class Story
    {
        public Story()
        {
            this.Date = DateTime.Now;
            this.Score = 0;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int Score { get; set; }

        public string Author_Id { get; set; }
        [ForeignKey("Author_Id")]
        public ApplicationUser Author { get; set; }

        public string Game_Id { get; set; }
        [ForeignKey("Game_Id")]
        public Game Game { get; set; }
    }
}