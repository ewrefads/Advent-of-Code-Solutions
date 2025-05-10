// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;

string input = "insert input here";
MD5 mD5 = MD5.Create();
int shortestPathSoFar = int.MaxValue;
Console.WriteLine(ShortestPath((0, 0), ""));
Console.WriteLine(LongestPath((0,0), "").Length);
string ShortestPath((int, int) position, string pathSoFar)
{
    if(position == (3, 3))
    {
        if(pathSoFar.Length < shortestPathSoFar)
        {
            shortestPathSoFar = pathSoFar.Length;
        }
        return pathSoFar;
    }
    else if(pathSoFar.Length <= shortestPathSoFar - 1)
    {
        string doors = Convert.ToHexString(mD5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input + pathSoFar))).ToLower().Substring(0, 4);
        string ShortPath = "no path";
        for(int i = 0; i < doors.Length; i++)
        {
            switch(doors[i])
            {
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                    string temp = "no path";
                    if(i == 0 && position.Item2 > 0)
                    {
                        (int, int) newPosition = (position.Item1, position.Item2);
                        newPosition.Item2 -= 1;
                        temp = ShortestPath(newPosition, pathSoFar + 'U');
                    }
                    else if(i == 1 && position.Item2 < 3)
                    {
                        (int, int) newPosition = (position.Item1, position.Item2);
                        newPosition.Item2 += 1;
                        temp = ShortestPath(newPosition, pathSoFar + 'D');
                    }
                    else if(i == 2 && position.Item1 > 0)
                    {
                        (int, int) newPosition = (position.Item1, position.Item2);
                        newPosition.Item1 -= 1;
                        temp = ShortestPath(newPosition, pathSoFar + 'L');
                    }
                    else if(i == 3 && position.Item1 < 3)
                    {
                        (int, int) newPosition = (position.Item1, position.Item2);
                        newPosition.Item1 += 1;
                        temp = ShortestPath(newPosition, pathSoFar + 'R');
                    }
                    if(temp != "no path" && (ShortPath == "no path"))
                    {
                        ShortPath = temp;
                    }
                    else if(temp != "no path" && ShortPath.Length > temp.Length)
                    {
                        ShortPath = temp;
                    }
                    break;
            }
        }
        if(ShortPath == "")
        {
            ShortPath = "no path";
        }
        return ShortPath;
    }
    else
    {
        return "no path";
    }
}
string LongestPath((int, int) position, string pathSoFar)
{
    if(position == (3, 3))
    {
        return pathSoFar;
    }
    else
    {
        string doors = Convert.ToHexString(mD5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input + pathSoFar))).ToLower().Substring(0, 4);
        string longPath = "no path";
        for(int i = 0; i < doors.Length; i++)
        {
            switch(doors[i])
            {
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                    string temp = "no path";
                    if(i == 0 && position.Item2 > 0)
                    {
                        (int, int) newPosition = (position.Item1, position.Item2);
                        newPosition.Item2 -= 1;
                        temp = LongestPath(newPosition, pathSoFar + 'U');
                    }
                    else if(i == 1 && position.Item2 < 3)
                    {
                        (int, int) newPosition = (position.Item1, position.Item2);
                        newPosition.Item2 += 1;
                        temp = LongestPath(newPosition, pathSoFar + 'D');
                    }
                    else if(i == 2 && position.Item1 > 0)
                    {
                        (int, int) newPosition = (position.Item1, position.Item2);
                        newPosition.Item1 -= 1;
                        temp = LongestPath(newPosition, pathSoFar + 'L');
                    }
                    else if(i == 3 && position.Item1 < 3)
                    {
                        (int, int) newPosition = (position.Item1, position.Item2);
                        newPosition.Item1 += 1;
                        temp = LongestPath(newPosition, pathSoFar + 'R');
                    }
                    if(temp != "no path" && (longPath == "no path"))
                    {
                        longPath = temp;
                    }
                    else if(temp != "no path" && longPath.Length < temp.Length)
                    {
                        longPath = temp;
                    }
                    break;
            }
        }
        if(longPath == "")
        {
            longPath = "no path";
        }
        return longPath;
    }
}