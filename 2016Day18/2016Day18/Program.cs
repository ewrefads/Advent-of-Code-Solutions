// See https://aka.ms/new-console-template for more information
string input = "insert input here";
Console.WriteLine(GetTotalForTiles(input, 40));
Console.WriteLine(GetTotalForTiles(input, 400000));
int GetTotalForTiles(string currentRow, int rows)
{
    int totalSafeTiles = CountSafeTiles(currentRow);
    for(int i = 0; i < rows - 1; i++)
    {
        currentRow = GenerateRow(currentRow);
        totalSafeTiles += CountSafeTiles(currentRow);
        Console.WriteLine(i);
    }
    return totalSafeTiles;
}
string GenerateRow(string previousRow)
{
    string row = "";
    for(int i = 0; i < previousRow.Length; i++)
    {
        string determiners = "";
        if(i == 0)
        {
            determiners += '.' + previousRow.Substring(0, 2);
        }
        else if(i == previousRow.Length - 1)
        {
            determiners += previousRow.Substring(i - 1, 2) + '.';
        }
        else
        {
            determiners += previousRow.Substring(i - 1, 3);
        }
        if(determiners[0] == '^' && determiners[1] == '^' && determiners[2] == '.')
        {
            row += '^';
        }
        else if(determiners[0] == '.' && determiners[1] == '^' && determiners[2] == '^')
        {
            row += '^';
        }
        else if(determiners[0] == '^' && determiners[1] == '.' && determiners[2] == '.')
        {
            row += '^';
        }
        else if(determiners[0] == '.' && determiners[1] == '.' && determiners[2] == '^')
        {
            row += '^';
        }
        else
        {
            row += '.';
        }
    }
    return row;
}
int CountSafeTiles(string row)
{
    int safeTiles = 0;
    foreach(char tile in row)
    {
        if(tile == '.')
        {
            safeTiles += 1;
        }
    }
    return safeTiles;
}