using ShareMemoriesHub.Models.Memories;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShareMemoriesHub.Models.Images
{
    public class Image
    {
        public Image()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Type { get; set; }//1 profile pic, 2 other
        public string Description { get; set; }
        public string FileName { get; set; }
        public string Content { get; set; }//base64string
        [JsonIgnore]
        public string MemoryId { get; set; }


        [NotMapped]
        [JsonIgnore]
        public Memory Memory { get; set; }
    }
}
