using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Mi_Granjita_Paraiso.Entities
{
    public class ItemFile
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("File")]
        [NotNull]
        public int FileId { get; set; }
        [ForeignKey("Item")]
        [NotNull]
        public long ItemId { get; set; }
        public virtual File File { get; set; }
        public virtual Item Item { get; set; }
    }
}
