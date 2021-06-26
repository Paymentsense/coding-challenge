using System.Text.Json.Serialization;

public class Language
{
    [JsonPropertyName("iso639_1")] public string Iso6391 { get; set; }
    [JsonPropertyName("iso639_2")] public string Iso6392 { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("nativeName")] public string NativeName { get; set; }
}