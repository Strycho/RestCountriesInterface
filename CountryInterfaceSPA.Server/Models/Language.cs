using System.Text.Json.Serialization;

namespace CountryInterfaceSPA.Server.Models
{
    public class Language
    {
        // <summary>
        /// Languages 
        /// The key of the dictionary is the language code, the value is a
        /// the language name in english.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
