using Microsoft.AspNetCore.Identity;
using ShareMemoriesHub.Models.Images;
using ShareMemoriesHub.Models.Tags;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShareMemoriesHub.Models.Memories
{
    public class Memory
    {
        public Memory()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        [NotMapped]
        public Tag Tag { get; set; }
        [NotMapped]
        public Image Image { get; set; }
        [NotMapped]
        [JsonIgnore]
        public IdentityUser IdentityUser { get; set; }
    }
}
