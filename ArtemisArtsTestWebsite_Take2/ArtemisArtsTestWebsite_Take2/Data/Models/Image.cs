using System;
using System.ComponentModel.DataAnnotations;

namespace ArtemisArtsTestWebsite_Take2.Data.Models
{
    public class Image : BaseModel
    {
        [Key]
        public Guid ImageId { get; set; } //id for each complete image file

        [Required]
        public int AccountId { get; set; } //sees who it is that did the update

        [Required]
        [DataType(DataType.Text)]
        public string Url { get; set; } //url for each page

        [Required]
        public int DraftId { get; set; } //id for saved project, or "draft", or queued up page set to publish later
    }
}
