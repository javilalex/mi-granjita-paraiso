using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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
        public virtual List<Category> Categories { get; set; }
    }
}