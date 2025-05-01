// See https://aka.ms/new-console-template for more information
string[] input = {"insert input here"};
int x = 0;
int y = 0;
int deltaX = 0;
int deltaY = 1;
int twiceX = 0;
int twiceY = 0;
List<(int, int)> visitedLocations = new List<(int, int)>();
for(int i = 0; i < input.Length; i++)
{
    string instruction = input[i];
    string number = "0";
    
    if(instruction[0] == 'L')
    {
        number = instruction.Split('L')[1];
        if(deltaX == -1 && deltaY == 0)
        {
            deltaX = 0;
            deltaY = -1;
        }
        else if(deltaX == 0 && deltaY == 1)
        {
            deltaX = -1;
            deltaY = 0;
        }
        else if(deltaX == 0 && deltaY == -1)
        {
            deltaX = 1;
            deltaY = 0;
        }
        else if(deltaX == 1 && deltaY == 0)
        {
            deltaX = 0;
            deltaY = 1;
        }
    }
    else
    {
        
        number = instruction.Split('R')[1];
        if(deltaX == -1 && deltaY == 0)
        {
            deltaX = 0;
            deltaY = 1;
        }
        else if(deltaX == 0 && deltaY == 1)
        {
            deltaX = 1;
            deltaY = 0;
        }
        else if(deltaX == 0 && deltaY == -1)
        {
            deltaX = -1;
            deltaY = 0;
        }
        else if(deltaX == 1 && deltaY == 0)
        {
            deltaX = 0;
            deltaY = -1;
        }

    }
    int change = int.Parse(number);
    x += change * deltaX;
    y += change * deltaY;
    bool allreadyVisited = false;
    foreach((int, int) coord in visitedLocations)
    {
        if(coord.Item1 == x && coord.Item2 == y)
        {
            allreadyVisited = true;
            break;
        }
    }
    if(allreadyVisited)
    {
        twiceX = x;
        twiceY = y;
    }
    else
    {
        Console.WriteLine("Adding new location (" + x + ", " + y + ")");
        visitedLocations.Add((x,y));
    }
}
if(x < 0)
{
    x = -x;
}
if(y < 0)
{
    y = -y;
}
if(twiceX < 0)
{
    twiceX = -twiceX;
}
if(y < 0)
{
    twiceY = -twiceY;
}
int distance = x + y;
int twiceDistance = twiceX + twiceY;
Console.WriteLine(distance);
Console.WriteLine(twiceDistance);