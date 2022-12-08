namespace CA3.Cocktails
{
    public interface ICocktailService
    {
        Task<List<CocktailsItem>> GetCocktails();
    }
}