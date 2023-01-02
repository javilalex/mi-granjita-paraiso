using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Mi_Granjita_Paraiso.Entities
{
    public class ItemFile
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("File")]
        [NotNull]
        public int? FileId { get; set; }
        [ForeignKey("Item")]
        [NotNull]
        public long? ItemId { get; set; }
        [JsonIgnore]
        public virtual File File { get; set; }
        [JsonIgnore]
        public virtual Item Item { get; set; }
    }
}
