// See https://aka.ms/new-console-template for more information
string input = "insert input here"
int , int)CalculateCoords(int x, int y, char direction)
{
    if(direction == '^')
    {
        y++;
    }
    else if(direction == 'v')
    {
        y--;
    }
    else if(direction == '<')
    {
        x--;
    }
    else if(direction == '>')
    {
        x++;
    }
    return (x, y);
}
List<(int, int)> visitedLocations = new List<(int, int)>()
{
    (0, 0)
};
int numVisitedLocations = 1;
(int, int) coords = (0, 0);
for(int i = 0; i < input.Length; i++)
{
    coords = CalculateCoords(coords.Item1, coords.Item2, input[i]);
    if(!visitedLocations.Contains(coords))
    {
        visitedLocations.Add(coords);
        numVisitedLocations++;
    }
}
visitedLocations.Clear();
visitedLocations.Add((0, 0));
int numVisitedLocationsYear2 = 1;
(int, int)santaCoords = (0, 0);
(int, int)roboSantaCoords = (0, 0);

for(int i = 0; i < input.Length; i++)
{
    if((i % 2) == 0)
    {
        santaCoords = CalculateCoords(santaCoords.Item1, santaCoords.Item2, input[i]);
        if(!visitedLocations.Contains(santaCoords))
        {
            visitedLocations.Add(santaCoords);
            numVisitedLocationsYear2++;
        }
    }
    else
    {
        roboSantaCoords = CalculateCoords(roboSantaCoords.Item1, roboSantaCoords.Item2, input[i]);
        if(!visitedLocations.Contains(roboSantaCoords))
        {
            visitedLocations.Add(roboSantaCoords);
            numVisitedLocationsYear2++;
        }
    }
}
Console.WriteLine(numVisitedLocations);
Console.WriteLine(numVisitedLocationsYear2);