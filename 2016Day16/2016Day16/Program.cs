// See https://aka.ms/new-console-template for more information
string input = "insert input here";
Console.WriteLine(GetChecksum(input, 272));
Console.WriteLine(GetChecksum(input, 35651584));
string GetChecksum(string input, int length)
{
    string extendedData = input;
    while(extendedData.Length < length)
    {
        string temp = ReverseString(extendedData);
        string toBeAdded = "0";
        for(int i = 0; i < temp.Length; i++)
        {
            Console.WriteLine(temp.Length - i + " word length remaining " + (length - extendedData.Length) + " data length remaining");
            if(temp[i] == '0')
            {
                toBeAdded += '1';
            }
            else
            {
                toBeAdded += '0';
            }
            
        }
        extendedData += toBeAdded;
        Console.WriteLine();
    }
    extendedData = extendedData.Substring(0, length);
    string checkSum = "";
    for(int i = 0; i < extendedData.Length - 1; i += 2)
    {
        if(extendedData[i] == extendedData[i + 1])
        {
            checkSum += '1';
        }
        else
        {
            checkSum += '0';
        }
    }
    while(checkSum.Length % 2 == 0)
    {
        string tempCheckSum = "";
        for(int i = 0; i < checkSum.Length - 1; i += 2)
        {
            if(checkSum[i] == checkSum[i + 1])
            {
                tempCheckSum += '1';
            }
            else
            {
                tempCheckSum += '0';
            }
        }
        checkSum = tempCheckSum;

    }
    return checkSum;
}
string ReverseString(string input)
{
    char[] letters = input.ToCharArray();
    Array.Reverse(letters);
    return new string(letters);
}
