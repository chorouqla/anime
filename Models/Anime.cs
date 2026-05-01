using Newtonsoft.Json;

namespace AnimeProject.Models
{
    public class Anime
    {
        [JsonProperty("mal_id")] //coge la data json
        public int Id { get; set; } // y le convierte a c# 

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("score")]
        public double? Rating { get; set; } //?: puede ser numero o nulo=vacio

        [JsonProperty("synopsis")]
        public string Description { get; set; }

        [JsonProperty("episodes")]
        public int? Episodes { get; set; } // ?: puede ser numero o nulo

        [JsonProperty("images")]
        public ImageData Images { get; set; }
    }

    public class ImageData
    {
        [JsonProperty("jpg")]
        public JpgImage Jpg { get; set; }
    }

    public class JpgImage
    {
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }
}