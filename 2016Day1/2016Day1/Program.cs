// See https://aka.ms/new-console-template for more information
string[] input = {"L2", "L5", "L5", "R5", "L2", "L4", "R1", "R1", "L4", "R2", "R1", "L1", "L4", "R1", "L4", "L4", "R5", "R3", "R1", "L1", "R1", "L5", "L1", "R5", "L4", "R2", "L5", "L3", "L3", "R3", "L3", "R4", "R4", "L2", "L5", "R1", "R2", "L2", "L1", "R3", "R4", "L193", "R3", "L5", "R45", "L1", "R4", "R79", "L5", "L5", "R5", "R1", "L4", "R3", "R3", "L4", "R185", "L5", "L3", "L1", "R5", "L2", "R1", "R3", "R2", "L3", "L4", "L2", "R2", "L3", "L2", "L2", "L3", "L5", "R3", "R4", "L5", "R1", "R2", "L2", "R4", "R3", "L4", "L3", "L1", "R3", "R2", "R1", "R1", "L3", "R4", "L5", "R2", "R1", "R3", "L3", "L2", "L2", "R2", "R1", "R2", "R3", "L3", "L3", "R4", "L4", "R4", "R4", "R4", "L3", "L1", "L2", "R5", "R2", "R2", "R2", "L4", "L3", "L4", "R4", "L5", "L4", "R2", "L4", "L4", "R4", "R1", "R5", "L2", "L4", "L5", "L3", "L2", "L4", "L4", "R3", "L3", "L4", "R1", "L2", "R3", "L2", "R1", "R2", "R5", "L4", "L2", "L1", "L3", "R2", "R3", "L2", "L1", "L5", "L2", "L1", "R4"};
//string[] input = {"R8", "R4", "R4", "R8"};
int x = 0;
int y = 0;
int deltaX = 0;
int deltaY = 1;
int twiceX = int.MaxValue;
int twiceY = int.MaxValue;
List<(int, int)> visitedLocations = new List<(int, int)>()
{
    (0,0)
};
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
    if(twiceX == int.MaxValue && twiceY == int.MaxValue)
    {
        for(int j = 0; j < change; j++)
        {
            int xPoint = x - j * deltaX;
            int yPoint = y - j * deltaY;
            if(visitedLocations.Contains((xPoint, yPoint)))
            {
                twiceX = xPoint;
                twiceY = yPoint;
            }
            else
            {
                visitedLocations.Add((xPoint, yPoint));
            }
        }
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
int distance = Math.Abs(x) + Math.Abs(y);
int twiceDistance = Math.Abs(twiceX) + Math.Abs(twiceY);
Console.WriteLine(distance);
Console.WriteLine(twiceDistance);
Console.WriteLine("(" + twiceX + ", " + twiceY + ")");