// See https://aka.ms/new-console-template for more information
string input = "insert input here";
string[] instructions = input.Split('.');
bool[,] grid = new bool[1000, 1000];
for(int x = 0; x < 1000; x++)
{
    for(int y = 0; y < 1000; y++)
    {
        grid[x, y] = false;
    }
}
for(int i = 0; i < instructions.Length; i++)
{
    string[]words = instructions[i].Split(' ');
    (int, int) firstCoordinate;
    (int, int) secondCoordinate;
    if(words[0] == "toggle")
    {
        string[] coord1 = words[1].Split(',');
        firstCoordinate = (Int32.Parse(coord1[0]), Int32.Parse(coord1[1]));
        string[] coord2 = words[3].Split(',');
        secondCoordinate = (Int32.Parse(coord2[0]), Int32.Parse(coord2[1]));
        for(int x = firstCoordinate.Item1; x <= secondCoordinate.Item1; x++)
        {
            for(int y = firstCoordinate.Item2; y <= secondCoordinate.Item2; y++)
            {
                grid[x, y] = !grid[x, y];
            }
        }
    }
    if(words[0] == "turn")
    {
        string[] coord1 = words[2].Split(',');
        firstCoordinate = (Int32.Parse(coord1[0]), Int32.Parse(coord1[1]));
        string[] coord2 = words[4].Split(',');
        secondCoordinate = (Int32.Parse(coord2[0]), Int32.Parse(coord2[1]));
        bool turnOn = false;
        if(words[1] == "on")
        {
            turnOn = true;
        }
        for(int x = firstCoordinate.Item1; x <= secondCoordinate.Item1; x++)
        {
            for(int y = firstCoordinate.Item2; y <= secondCoordinate.Item2; y++)
            {
                grid[x, y] = turnOn;
            }
        }
    }
}

int numTurnedOnLights = 0;
foreach(bool light in grid)
{
    if(light)
    {
        numTurnedOnLights++;
    }
}
Console.WriteLine(numTurnedOnLights);
int[,] brightnessGrid = new int[1000, 1000];
for(int x = 0; x < 1000; x++)
{
    for(int y = 0; y < 1000; y++)
    {
        brightnessGrid[x, y] = 0;
    }
}
for(int i = 0; i < instructions.Length; i++)
{
    string[]words = instructions[i].Split(' ');
    (int, int) firstCoordinate;
    (int, int) secondCoordinate;
    if(words[0] == "toggle")
    {
        string[] coord1 = words[1].Split(',');
        firstCoordinate = (Int32.Parse(coord1[0]), Int32.Parse(coord1[1]));
        string[] coord2 = words[3].Split(',');
        secondCoordinate = (Int32.Parse(coord2[0]), Int32.Parse(coord2[1]));
        for(int x = firstCoordinate.Item1; x <= secondCoordinate.Item1; x++)
        {
            for(int y = firstCoordinate.Item2; y <= secondCoordinate.Item2; y++)
            {
                brightnessGrid[x, y] += 2;
            }
        }
    }
    if(words[0] == "turn")
    {
        string[] coord1 = words[2].Split(',');
        firstCoordinate = (Int32.Parse(coord1[0]), Int32.Parse(coord1[1]));
        string[] coord2 = words[4].Split(',');
        secondCoordinate = (Int32.Parse(coord2[0]), Int32.Parse(coord2[1]));
        int change = -1;
        if(words[1] == "on")
        {
            change = 1;
        }
        for(int x = firstCoordinate.Item1; x <= secondCoordinate.Item1; x++)
        {
            for(int y = firstCoordinate.Item2; y <= secondCoordinate.Item2; y++)
            {
                brightnessGrid[x, y] += change;
                if(brightnessGrid[x,y] < 0)
                {
                    brightnessGrid[x,y] = 0;
                }
            }
        }
    }
}
int totalBrightness = 0;
foreach(int light in brightnessGrid)
{
    totalBrightness += light;
}
Console.WriteLine(totalBrightness);