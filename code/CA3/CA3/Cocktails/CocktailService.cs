using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text.Json;

namespace CA3.Cocktails
{
    public class CocktailService : ICocktailService
    {
        public readonly HttpClient _httpClient;
        const string _baseURL = "https://the-cocktail-db.p.rapidapi.com/random.php";
        const string _cocktailEndpoint = "/random";
        const string _host = "the-cocktail-db.p.rapidapi.com";
        const string _key = "8d979503c9msh74b4763f3240ec0p179098jsn4386c9b93bdb";

        public CocktailService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<CocktailsItem>> GetCocktails()
        {

            var response = await _httpClient.GetAsync(_baseURL + _cocktailEndpoint);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStringAsync();

            var dto = System.Text.Json.JsonSerializer.Deserialize<List<CocktailDto>>(stream);
            return dto.Select(n => new CocktailsItem
            {
                id = n.idDrink,
                name = n.strDrink
            }).ToList();
        }
        public void ConfigureHttpClient()
        {
            _httpClient.BaseAddress = new Uri(_baseURL);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _host);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _key);
        }
    }
}