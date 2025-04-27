// See https://aka.ms/new-console-template for more information
string input = "insert input here"
int surfaceArea(int l, int w, int h)
{
    int sides1 = l * w;
    int sides2 = w * h;
    int sides3 = h * l;
    int smallestSide;
    int[] sides = {sides1, sides2, sides3};
    smallestSide = sides.Min();
    return  2 * sides1 + 2 * sides2 + 2 * sides3 + smallestSide;
}
int ribbonLength(int l, int w, int h)
{
    List<int> dimensions = new List<int>(){
        l,
        w,
        h
    };
    
    dimensions = dimensions.Order().ToList();
    int side1 = dimensions[0];
    int side2 = dimensions[1];
    int bowLength = l * w * h;
    return side1 * 2 + side2 * 2 + bowLength;
}
int l = 0;
int w = 0;
int h = 0;
string cNumber = "";
int totalArea = 0;
int ribLength = 0;
for(int i = 0; i < input.Length; i++)
{
    int num;
    if(input[i] == 'x' && l == 0)
    {
        l = Int32.Parse(cNumber);
        cNumber = "";
    }
    else if(input[i] == 'x')
    {
        w = Int32.Parse(cNumber);
        cNumber = "";
    }
    else if(input[i] == ',')
    {
        h = Int32.Parse(cNumber);
        totalArea += surfaceArea(l, w, h);
        ribLength += ribbonLength(l, w, h);
        l = 0;
        w = 0;
        h = 0;
        cNumber = "";
    }
    else if(Int32.TryParse(input[i].ToString(), out num))
    {
        cNumber += input[i];
    }
    else
    {
        throw new Exception("Unknown char: " + input[i]);
    }
}
Console.WriteLine(totalArea);
Console.WriteLine(ribLength);
