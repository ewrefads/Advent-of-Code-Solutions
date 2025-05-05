// See https://aka.ms/new-console-template for more information
string[] input = 
{
    "insert input here"
};
bool [,] screen = new bool[50,6];
for(int x = 0; x < 50; x++)
{
    for(int y = 0; y < 6; y++)
    {
        screen[x, y] = false;
    }
}
for(int i = 0; i < input.Length; i++)
{
    string instruction = input[i];
    string[] words = instruction.Split(' ');
    switch(words[0])
    {
        case "rect":
            string[] numbers = words[1].Split('x');
            screen = Rect(screen, int.Parse(numbers[0]), int.Parse(numbers[1]));
            break;
        case "rotate":
            if(words[1] == "row")
            {
                int row = int.Parse(words[2].Split('=')[1]);
                int modifier = int.Parse(words[4]);
                screen = RotateRow(screen, row, modifier);
            }
            else
            {
                int column = int.Parse(words[2].Split('=')[1]);
                int modifier = int.Parse(words[4]);
                screen = RotateColumn(screen, column, modifier);
            }
            break;
    }
}
int litPixels = 0;
foreach(bool pixel in screen)
{
    if(pixel)
    {
        litPixels++;
    }
}
Console.WriteLine(litPixels);
for(int y = 0; y < 6; y++)
{
    for(int x = 0; x < 50; x++)
    {
        if(screen[x,y])
        {
            Console.Write('#');
        }
        else
        {
            Console.Write('.');
        }
    }
    Console.WriteLine();
}
bool[,] Rect(bool[,] screen, int width, int height)
{
    for(int x = 0; x < width; x++)
    {
        for(int y = 0; y < height; y++)
        {
            screen[x, y] = true;
        }
    }
    return screen;
}
bool[,] RotateRow(bool[,] screen, int row, int modifier)
{
    bool[] tempRow = new bool[50];
    for(int i = 0; i < 50; i++)
    {
        int index = i + modifier;
        while(index >= 50)
        {
            index -= 50;
        }
        tempRow[index] = screen[i, row];
    }
    for(int i = 0; i < 50; i++)
    {
        screen[i, row] = tempRow[i];
    }
    return screen;
}
bool[,] RotateColumn(bool[,] screen, int column, int modifier)
{
    bool[] tempColumn = new bool[6];
    for(int i = 0; i < 6; i++)
    {
        int index = i + modifier;
        while(index >= 6)
        {
            index -= 6;
        }
        tempColumn[index] = screen[column, i];
    }
    for(int i = 0; i < 6; i++)
    {
        screen[column, i] = tempColumn[i];
    }
    return screen;
}

