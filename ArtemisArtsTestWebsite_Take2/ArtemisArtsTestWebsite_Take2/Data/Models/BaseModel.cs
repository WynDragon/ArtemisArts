using System;
using System.ComponentModel.DataAnnotations;

namespace ArtemisArtsTestWebsite_Take2.Data.Models
{
    /// <summary>
    /// All other Models will draw off this model
    /// </summary>
    public abstract class BaseModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeleteDate { get; set; }
    }
}
