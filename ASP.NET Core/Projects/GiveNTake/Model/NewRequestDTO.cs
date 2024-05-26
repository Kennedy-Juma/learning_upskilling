using System.ComponentModel.DataAnnotations;

namespace GiveNTake.Model
{
    public class NewRequestDTO
    {
        [MaxLength(1)]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
    }
}
