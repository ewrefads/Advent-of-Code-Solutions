// See https://aka.ms/new-console-template for more information
(int, int, int)[] input = 
{
    (0, 0, 0)
};
List<(int, int, int)> possibleTriangles = new List<(int, int, int)>();
List<(int, int, int)> impossibleTriangles = new List<(int, int, int)>();
for(int i = 0; i < input.Length; i++)
{
    (int, int, int) triangle = input[i];
    if(triangle.Item1 + triangle.Item2 > triangle.Item3 && triangle.Item1 + triangle.Item3 > triangle.Item2 && triangle.Item2 + triangle.Item3 > triangle.Item1)
    {
        possibleTriangles.Add(triangle);
    }
    else
    {
        impossibleTriangles.Add(triangle);
    }
}
Console.WriteLine(possibleTriangles.Count);
int possibleVerticalTriangles = 0;
for(int i = 0; i < input.Length; i += 3)
{
    (int, int, int)[] triangles = 
    {
        (input[i].Item1, input[i + 1].Item1, input[i + 2].Item1),
        (input[i].Item2, input[i + 1].Item2, input[i + 2].Item2),
        (input[i].Item3, input[i + 1].Item3, input[i + 2].Item3)
    };
    foreach((int, int, int) triangle in triangles)
    {
        if(triangle.Item1 + triangle.Item2 > triangle.Item3 && triangle.Item1 + triangle.Item3 > triangle.Item2 && triangle.Item2 + triangle.Item3 > triangle.Item1)
        {
            possibleVerticalTriangles++;
        }
    }
}
Console.WriteLine(possibleVerticalTriangles);