using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace CA3.Cocktails
{
    public class CocktailService : ICocktailService
    {
        public readonly HttpClient _httpClient;
        const string _baseURL = "https://cocktails3.p.rapidapi.com/random";
        const string _cocktailEndpoint = "https://cocktails3.p.rapidapi.com/random";
        const string _host = "cocktails3.p.rapidapi.com";
        const string _key = "8d979503c9msh74b4763f3240ec0p179098jsn4386c9b93bdb";

        public CocktailService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<CocktailsItem>> GetCocktails()
        {
            ConfigureHttpClient();

            var response = await _httpClient.GetAsync(_cocktailEndpoint);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            var dto = await JsonSerializer.DeserializeAsync<CocktailDto>(stream);
            Console.WriteLine(dto);
            return dto.body.Select(n => new CocktailsItem
            {
                strDrink =(MarkupString)n.name
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
