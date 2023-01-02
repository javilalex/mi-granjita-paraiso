using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Mi_Granjita_Paraiso.Entities
{
    public class MetaTag
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(70)]
        public string Value { get; set; }
        [NotNull]
        [ForeignKey("Item")]
        public long ItemId { get; set; }
        [JsonIgnore]
        public virtual Item Item { get; set; }
    }
}
