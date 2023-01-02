using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mi_Granjita_Paraiso.DTOs.Item
{
    public class ItemDTOLite : Interfaces.IItem
    {
        public long Id { get; set; }
        [NotNull]
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public string PicturePath { get; set; }
    }
}
