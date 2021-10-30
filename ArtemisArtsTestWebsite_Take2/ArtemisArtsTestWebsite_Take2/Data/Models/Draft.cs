using System.ComponentModel.DataAnnotations;

namespace ArtemisArtsTestWebsite_Take2.Data.Models
{
    public class Draft : BaseModel
    {
        [Key]
        public int DraftId { get; set; } //id of draft to be published

        [Required]
        public int AccountId { get; set; } //who added the draft

        [DataType(DataType.Text)]
        public string Name { get; set; } //draft name

        [Required]
        [DataType(DataType.Text)]
        public string DisplayTitle { get; set; } //name given to the page

        [DataType(DataType.MultilineText)]
        public string Description { get; set; } //author note, side story, etc

        [DataType(DataType.MultilineText)]
        public string? Data { get; set; } //what it contains
    }
}
