using System.Text.Json.Serialization;

namespace CountryInterfaceSPA.Server.Models
{
    public class Currency
    {
        /// <summary>
        /// Currency Name name of the currency in english.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Currency Symbol Symbol that represents the currency.
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }
}
