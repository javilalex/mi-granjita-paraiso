using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Mi_Granjita_Paraiso.Entities
{
    public class CategoryType
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Category> Categories { get; set; }
    }
}