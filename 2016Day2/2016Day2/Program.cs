// See https://aka.ms/new-console-template for more information
string[] input = {"insert input here"};
/*string[] input = 
{
    "ULL",
    "RRDDD",
    "LURDL",
    "UUUUD"
};*/
int x = 1;
int y = 1;
string code = "";
for(int i = 0; i < input.Length; i++)
{
    for(int j = 0; j < input[i].Length; j++)
    {
        char instruction = input[i][j];
        switch(instruction)
        {
            case 'L':
                x--;
                break;
            case 'R':
                x++;
                break;
            case 'U':
                y--;
                break;
            case 'D':
                y++;
                break;
        }
        if(x < 0)
        {
            x = 0;
        }
        if(x > 2)
        {
            x = 2;
        }
        if(y < 0)
        {
            y = 0;
        }
        if(y > 2)
        {
            y = 2;
        }
    }
    switch (y)
    {
        case 0:
            switch(x)
            {
                case 0:
                    code += "1";
                    break;
                case 1:
                    code += "2";
                    break;
                case 2:
                    code += "3";
                    break;
            }
            break;
        case 1:
            switch(x)
            {
                case 0:
                    code += "4";
                    break;
                case 1:
                    code += "5";
                    break;
                case 2:
                    code += "6";
                    break;
            }
            break;
        case 2:
            switch(x)
            {
                case 0:
                    code += "7";
                    break;
                case 1:
                    code += "8";
                    break;
                case 2:
                    code += "9";
                    break;
            }
            break;
    }
}
Console.WriteLine(code);
x = -2;
y = 0;
code = "";
bool[,] legalCoordinates = new bool[5, 5];
for(int i = 0; i < 5; i++)
{
    for(int j = 0; j < 5; j++)
    {
        switch(i)
        {
            case 0:
                switch(j)
                {
                    case 0:
                        legalCoordinates[i, j] = false;
                        break;
                    case 1:
                        legalCoordinates[i, j] = false;
                        break;
                    case 3:
                        legalCoordinates[i, j] = false;
                        break;
                    case 4:
                        legalCoordinates[i, j] = false;
                        break;
                    default:
                        legalCoordinates[i, j] = true;
                        break;
                }
                break;
            case 1:
                switch(j)
                {
                    case 0:
                        legalCoordinates[i, j] = false;
                        break;
                    case 4:
                        legalCoordinates[i, j] = false;
                        break;
                    default:
                        legalCoordinates[i, j] = true;
                        break;
                }
                break;
            case 3:
                switch(j)
                {
                    case 0:
                        legalCoordinates[i, j] = false;
                        break;
                    case 4:
                        legalCoordinates[i, j] = false;
                        break;
                    default:
                        legalCoordinates[i, j] = true;
                        break;
                }
                break;
            case 4:
                switch(j)
                {
                    case 0:
                        legalCoordinates[i, j] = false;
                        break;
                    case 1:
                        legalCoordinates[i, j] = false;
                        break;
                    case 3:
                        legalCoordinates[i, j] = false;
                        break;
                    case 4:
                        legalCoordinates[i, j] = false;
                        break;
                    default:
                        legalCoordinates[i, j] = true;
                        break;
                }
                break;
        }
    }
}
for(int i = 0; i < input.Length; i++)
{
    for(int j = 0; j < input[i].Length; j++)
    {
        char instruction = input[i][j];
        switch(instruction)
        {
            case 'L':
                if(Math.Abs(x - 1) + Math.Abs(y) <= 2)
                {
                    x--;
                }
                
                break;
            case 'R':
                if(Math.Abs(x + 1) + Math.Abs(y) <= 2)
                {
                    x++;
                }
                break;
            case 'U':
                if(Math.Abs(x) + Math.Abs(y - 1) <= 2)
                {
                    y--;
                }
                break;
            case 'D':
                if(Math.Abs(x) + Math.Abs(y + 1) <= 2)
                {
                    y++;
                }
                break;
        }
        Console.WriteLine("instruction: "+ instruction + " x: " + x + " y:" + y);
    }
    Console.WriteLine();
    switch (y)
    {
        case -2:
            switch(x)
            {
                case 0:
                    code += '1';
                    break;
                default:
                    throw new Exception("no key with coordinates: (" + x + ", " + y + ")");
            }
            break;
        case -1:
            switch(x)
            {
                case -1:
                    code += '2';
                    break;
                case 0:
                    code += '3';
                    break;
                case 1:
                    code += '4';
                    break;
                default:
                    throw new Exception("no key with coordinates: (" + x + ", " + y + ")");
            }
            break;
        case 0:
            switch(x)
            {
                case -2:
                    code += '5';
                    break;
                case -1:
                    code += '6';
                    break;
                case 0:
                    code += '7';
                    break;
                case 1:
                    code += '8';
                    break;
                case 2:
                    code += '9';
                    break;
                default:
                    throw new Exception("no key with coordinates: (" + x + ", " + y + ")");
            }
            break;
        case 1:
            switch(x)
            {
                case -1:
                    code += 'A';
                    break;
                case 0:
                    code += 'B';
                    break;
                case 1:
                    code += 'C';
                    break;
                default:
                    throw new Exception("no key with coordinates: (" + x + ", " + y + ")");
            }
            break;
        case 2:
            switch(x)
            {
                case 0:
                    code += 'D';
                    break;
                default:
                    throw new Exception("no key with coordinates: (" + x + ", " + y + ")");
            }
            break;
    }
}
Console.WriteLine(code);