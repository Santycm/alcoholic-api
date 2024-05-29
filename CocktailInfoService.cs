using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;

public class CocktailInfoService
{
    private readonly HttpClient _httpClient;

    public CocktailInfoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Ingredient>> GetIngredientAsync()
    {
        string url = "https://thecocktaildb.com/api/json/v1/1/list.php?i=list";
        var response = await this._httpClient.GetFromJsonAsync<DrinksListIngredient>(url);
        return response.Drinks;
    }

    public async Task<List<Category>> GetCategoryAsync()
    {
        string url = "https://thecocktaildb.com/api/json/v1/1/list.php?c=list";
        var response = await this._httpClient.GetFromJsonAsync<DrinksListCategory>(url);
        return response.Drinks;
    }

    public async Task<List<Glass>> GetGlassAsync()
    {
        string url = "https://thecocktaildb.com/api/json/v1/1/list.php?g=list";
        var response = await this._httpClient.GetFromJsonAsync<DrinksListGlass>(url);
        return response.Drinks;
    }

    public async Task<List<Cocktail>> GetCocktailByNameAsync(string param)
    {
        string url = $"https://thecocktaildb.com/api/json/v1/1/search.php?s={param}";
        var response = await this._httpClient.GetFromJsonAsync<DrinksList>(url);
        return response.Drinks;
    }

    public async Task<List<Cocktail>> GetCocktailByIDAsync(int id)
    {
        string url = $"https://thecocktaildb.com/api/json/v1/1/lookup.php?i={id}";
        var response = await this._httpClient.GetFromJsonAsync<DrinksList>(url);
        return response.Drinks;
    }

    //Lists

    public class DrinksListIngredient
    {
        public List<Ingredient>? Drinks { get; set; }
    }

    public class DrinksListCategory
    {
        public List<Category>? Drinks { get; set; }
    }

    public class DrinksListGlass
    {
        public List<Glass>? Drinks { get; set; }
    }

    public class DrinksList
    {
        public List<Cocktail>? Drinks { get; set; }
    }

    //Objects

    public class Ingredient
    {
        public string? strIngredient1 { get; set; }
    }

    public class Category
    {
        public string? strCategory { get; set; }
    }

    public class Glass
    {
        public string? strGlass { get; set; }
    }

    public class Cocktail
    {
        public string? idDrink { get; set; }
        public string? strDrink { get; set; }
        public string? strCategory { get; set; }
        public string? strAlcoholic { get; set; }
        public string? strGlass { get; set; }
        public string? strInstructions { get; set; }
        public string? strDrinkThumb { get; set; }
    }
}