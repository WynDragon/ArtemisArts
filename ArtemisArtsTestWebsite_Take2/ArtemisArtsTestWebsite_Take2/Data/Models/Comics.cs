﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ArtemisArtsTestWebsite_Take2.Data.Models
{
    //webcomic pages
    public class Comics : BaseModel
    {
        [Key]
        [Required]
        public int ComicId { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public Guid ImageId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Url { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}