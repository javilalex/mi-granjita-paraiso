using Swashbuckle.AspNetCore.Annotations;

namespace Mi_Granjita_Paraiso.Interfaces
{
    [SwaggerSubType(typeof(DTOs.Item.ItemDTOFull))]
    [SwaggerSubType(typeof(DTOs.Item.ItemDTOStandard))]
    [SwaggerSubType(typeof(DTOs.Item.ItemDTOLite))]
    public interface IItem
    {
        string PicturePath { get; set; }
        long Id { get; set; }
        string Title { get; set; }
    }
}
