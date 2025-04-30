// See https://aka.ms/new-console-template for more information
string[] input = {"insert input here"};
int dimensions = input.Length;
bool[,] grid = new bool[dimensions, dimensions];
bool[,] cornersAlwaysOnGrid = new bool[dimensions, dimensions];
for(int x = 0; x < input.Length; x++)
{
    for(int y = 0; y < input[x].Length; y++)
    {
        if(input[y][x] == '#')
        {
            grid[x, y] = true;
            cornersAlwaysOnGrid[x, y] = true;
        }
        else if(input[y][x] == '.')
        {
            grid[x, y] = false;
            cornersAlwaysOnGrid[x, y] = false;
        }
        else
        {
            throw new Exception("unknown character: "  + input[x][y]);
        }
        if((x == 0 || x == dimensions - 1) && (y == 0 || y == dimensions - 1))
        {
            cornersAlwaysOnGrid[x, y] = true;
        }
    }
}
for(int i = 0; i < 100; i++)
{
    grid = AnimateGrid(grid, false);
    cornersAlwaysOnGrid = AnimateGrid(cornersAlwaysOnGrid, true);
}
int onLights = 0;
for(int y = 0; y < dimensions; y++)
{
    for(int x = 0; x < dimensions; x++)
    {

        if(grid[x, y])
        {
            onLights++;
        }
    }
}
Console.WriteLine(onLights);
onLights = 0;
for(int y = 0; y < dimensions; y++)
{
    for(int x = 0; x < dimensions; x++)
    {

        if(cornersAlwaysOnGrid[x, y])
        {
            onLights++;
        }
    }
}
Console.WriteLine(onLights);
bool[,] AnimateGrid(bool[,] grid, bool cornersAlwaysOn)
{
    bool[,] tempGrid = new bool[dimensions, dimensions];
    for(int x = 0; x < dimensions; x++)
    {
        for(int y = 0; y < dimensions; y++)
        {
            int neighbourLights = CountLights(grid, x, y);
            if(grid[x, y] && (neighbourLights == 2 || neighbourLights == 3))
            {
                tempGrid[x, y] = true;
            }
            else if(!grid[x, y] && neighbourLights == 3)
            {
                tempGrid[x, y] = true;
            }
            else if(cornersAlwaysOn && (x == 0 || x == dimensions - 1) && (y == 0 || y == dimensions - 1))
            {
                tempGrid[x, y] = true;
            }
            else
            {
                tempGrid[x, y] = false;
            }
        }
    }
    return tempGrid;
}

int CountLights(bool[,] grid, int x, int y)
{
    int onLights = 0;
    for(int i = 0; i < 8; i++)
    {
        switch(i)
            {
                case 0:
                    if(x > 0 && y > 0 && grid[x - 1, y - 1])
                    {
                        onLights++;
                    }
                    break;
                case 1:
                    if(y > 0 && grid[x, y - 1])
                    {
                        onLights++;
                    }
                    break;
                case 2:
                    if(x < dimensions - 1 && y > 0 && grid[x + 1, y - 1])
                    {
                        onLights++;
                    }
                    break;
                case 3:
                    if(x > 0 && grid[x - 1, y])
                    {
                        onLights++;
                    }
                    break;
                case 4:
                    if(x < dimensions - 1 && grid[x + 1, y])
                    {
                        onLights++;
                    }
                    break;
                case 5:
                    if(x > 0 && y < dimensions - 1 && grid[x - 1, y + 1])
                    {
                        onLights++;
                    }
                    break;
                case 6:
                    if(y < dimensions - 1 && grid[x, y + 1])
                    {
                        onLights++;
                    }
                    break;
                case 7:
                    if(x < dimensions - 1 && y < dimensions - 1 && grid[x + 1, y + 1])
                    {
                        onLights++;
                    }
                    break;
            }
    }
    return onLights;
}

