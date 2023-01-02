using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mi_Granjita_Paraiso.Entities
{
    public class Category
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public int CategoryTypeId { get; set; }
        public DateTime DateSaved { get; set; } = DateTime.Now;
        [JsonIgnore]
        public virtual CategoryType CategoryType { get; set; }
    }
}
