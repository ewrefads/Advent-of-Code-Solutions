// See https://aka.ms/new-console-template for more information
string[] input = 
{
    "Insert input here"
};
List<Ingredient> ingredients = new List<Ingredient>();
foreach(string ingredient in input)
{
    string[] words = ingredient.Split(' ');
    int capacity = int.Parse(words[2].Split(',')[0]);
    int durability = int.Parse(words[4].Split(',')[0]);
    int flavor = int.Parse(words[6].Split(',')[0]);
    int texture = int.Parse(words[8].Split(',')[0]);
    int calories = int.Parse(words[10].Split(',')[0]);
    Ingredient newIngredient = new Ingredient(capacity, durability, flavor, texture, calories);
    ingredients.Add(newIngredient);
}
Console.WriteLine(BestCookie(false));
Console.WriteLine(BestCookie(true));
int BestCookie(bool calorieRestricted)
{
    int totalValue = int.MinValue;
    for(int i = 1; i <= 100 - 3; i++)
    {
        for(int j = 1; j <= 100 - 2 - i; j++)
        {
            for(int x = 1; x <= 100 - 1 - i - j; x++)
            {
                int y = 100 - i - j - x;
                int capacity = CalculateValue(ingredients[0].capacity * i, ingredients[1].capacity * j, ingredients[2].capacity * x, ingredients[3].capacity * y);
                int durability = CalculateValue(ingredients[0].durability * i, ingredients[1].durability * j, ingredients[2].durability * x, ingredients[3].durability * y);
                int flavor = CalculateValue(ingredients[0].flavor * i, ingredients[1].flavor * j, ingredients[2].flavor * x, ingredients[3].flavor * y);
                int texture = CalculateValue(ingredients[0].texture * i, ingredients[1].texture * j, ingredients[2].texture * x, ingredients[3].texture * y);
                int tempValue = capacity * durability * flavor * texture;
                int calories = ingredients[0].calories * i + ingredients[1].calories * j + ingredients[2].calories * x + ingredients[3].calories * y;
                if(tempValue > totalValue && (!calorieRestricted || calories == 500))
                {
                    totalValue = tempValue;
                }
            }
        }
    }
    
    return totalValue;
}

int CalculateValue(int val1, int val2, int val3, int val4)
{
    int value = val1 + val2 + val3 + val4;
    if(value < 0)
    {
        value = 0;
    }
    return value;
}
class Ingredient
{
    public int capacity;
    public int durability;
    public int flavor;
    public int texture;
    public int calories;

    public Ingredient(int capacity, int durability, int flavor, int texture, int calories)
    {
        this.capacity = capacity;
        this.durability = durability;
        this.flavor = flavor;
        this.texture = texture;
        this.calories = calories;
    }

    
}

