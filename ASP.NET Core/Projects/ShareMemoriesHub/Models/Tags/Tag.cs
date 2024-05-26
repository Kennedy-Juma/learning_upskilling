using Microsoft.AspNetCore.Identity;
using ShareMemoriesHub.Models.Memories;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShareMemoriesHub.Models.Tags
{
    public class Tag
    {
        public Tag()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public string MemoryId { get; set; }


        [NotMapped]
        [JsonIgnore]
        public Memory Memory { get; set; }
    }
}
