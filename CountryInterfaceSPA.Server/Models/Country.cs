using System.Text.Json.Serialization;

namespace CountryInterfaceSPA.Server.Models
{
    // Class Structure to store the data from https://restcountries.com/v3.1/all
    public class Country
    {
        // <summary>
        /// Country name
        /// </summary>
        [JsonPropertyName("name")]
        public CountryName Name { get; set; }

        // <summary>
        /// capital city of Country
        /// </summary>
        [JsonPropertyName("capital")]
        public string[] Capital { get; set; }

        /// <summary>
        /// Currencies used in the country.
        /// The dictionary is the currency code, the value is a Currency
        /// object: {name: string, symbol: string}.
        /// </summary>
        [JsonPropertyName("currencies")]
        public Dictionary<string, Currency>? Currencies { get; set; }

        /// <summary>
        /// Population of the country.
        /// </summary>
        [JsonPropertyName("population")]
        public int Population { get; set; }

        /// <summary>
        /// cca3 Three digit iso code that denotes the country eg GBR.
        /// </summary>
        [JsonPropertyName("cca3")]
        public string cca3 { get; set; }

        // <summary>
        /// Languages spoken in the country.
        /// The key of the dictionary is the language code, the value is a
        /// the language name in english.
        /// </summary>
        [JsonPropertyName("languages")]
        public Dictionary<string, string>? Languages { get; set; }

        /// <summary>
        /// Flag(Url) of the country in png and svg format.
        /// </summary>
        [JsonPropertyName("flags")]
        public Flag Flag { get; set; }
    }
}