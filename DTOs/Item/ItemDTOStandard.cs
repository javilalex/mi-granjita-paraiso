using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mi_Granjita_Paraiso.DTOs.Item
{
    public class ItemDTOStandard : ItemDTOLite, Interfaces.IItem
    {
        [NotNull]
        [Required]
        [MaxLength(100)]
        public string SummaryContent { get; set; }
        [NotNull]
        [Required]
        public string Content { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public short StatusId { get; set; }
        public string Status { get; set; }
#nullable enable
        public long? ParentItemId { get; set; }
    }
}
