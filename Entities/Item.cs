using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Mi_Granjita_Paraiso.Entities
{
    public class Item
    {
        [Key]
        public long Id { get; set; }
        [NotNull]
        [Required]
        public string Title { get; set; }
        [NotNull]
        [Required]
        [MaxLength(100)]
        public string SummaryContent { get; set; }
        [NotNull]
        [Required]
        public string Content  { get; set; }
        [NotNull]
        [Required]
        [ForeignKey("User")]
        public string SavedUserId { get; set; }
        [NotNull]
        public DateTime DateSaved { get; set; } = DateTime.Now;
        [NotNull]
        public DateTime PublishDate { get; set; } = DateTime.Now;
        [NotNull]
        [Required]
        public long CategoryId { get; set; }
#nullable enable
        public long? ParentItemId { get; set; }
        public short StatusId { get; set; }
        [JsonIgnore]
        public virtual Item ParentItem { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual IdentityUser User { get; set; }
        [JsonIgnore]
        public virtual List<ItemFile> ItemFiles { get; set; }
    }
}