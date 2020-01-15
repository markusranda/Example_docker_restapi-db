using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Resources
{
    public class SaveCategoryResource
    {
        [Required] [MaxLength] public string Name { get; set; }
    }
}