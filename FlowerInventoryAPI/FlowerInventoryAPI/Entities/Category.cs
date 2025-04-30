using System.Text.Json.Serialization;

namespace FlowerInventoryAPI.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        [JsonIgnore]
        public List<Flower>? Flowers { get; set; }
    }
}
