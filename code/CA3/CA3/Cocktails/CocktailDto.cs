namespace CA3.Cocktails
{
    public class CocktailDto
    {
        public Body[] body { get; set; }
    }

    public class Body
    {
        public string name { get; set; }
        public string[] ingredients { get; set; }
    }

}
