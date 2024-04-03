using System.Text.Json.Serialization;
using System.Transactions;

namespace CountryInterfaceSPA.Server.Models
{
    public class CountryName
    {
        /// <summary>
        /// Official name.
        /// </summary>
        [JsonPropertyName("official")]
        public string Official { get; set; }

        /// <summary>
        /// Common used name.
        /// </summary>
        [JsonPropertyName("common")]
        public string Common { get; set; }
        /// <summary>
        /// Native name of the country.
        /// The key of the dictionary is the language code, value is the native name
        /// object: {Official: string, Common: string}.
        /// The number of native names is the same as the number of languages.
        /// </summary>
        [JsonPropertyName("nativeName")]
        public Dictionary<string, Translation>? NativeName { get; set; }
    }
}
