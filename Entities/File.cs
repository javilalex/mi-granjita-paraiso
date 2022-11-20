using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Mi_Granjita_Paraiso.Entities
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        [NotNull]
        public DateTime DateSaved { get; set; } = DateTime.Now;
        [ForeignKey("User")]
        public string SavedByUserId { get; set; }
        public long? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual List<ItemFile> ItemFiles { get; set; }
    }
}