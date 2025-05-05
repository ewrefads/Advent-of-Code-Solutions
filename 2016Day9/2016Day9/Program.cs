// See https://aka.ms/new-console-template for more information
string input = "insert input here";
Console.WriteLine(DecompressData(input).Length);
Console.WriteLine(DecompressDataWithSubCompression(input).GetLength());
string DecompressData(string compressedData)
{
    string decompressedString = "";
    int index = 0;
    string marker = "";
    string tempString = "";
    while(index < compressedData.Length)
    {
        if(compressedData[index] == '(' && marker.Length == 0 && int.TryParse(compressedData[index + 1].ToString(), out int res))
        {
            marker += '0';
            decompressedString += tempString;
            tempString = "";
        }
        else if(marker.Length > 0 && compressedData[index] != ')')
        {
            marker += compressedData[index];
        }
        else if(marker.Length > 0 && compressedData[index] == ')')
        {
            string[] numbers = marker.Split('x');
            tempString = compressedData.Substring(index + 1, int.Parse(numbers[0]));
            index += int.Parse(numbers[0]);
            for(int i = 0; i < int.Parse(numbers[1]); i++)
            {
                decompressedString += tempString;   
            }
            tempString = "";
            marker = "";
        }
        
        else
        {
            tempString += compressedData[index];
        }
        if(index == compressedData.Length - 1 && tempString.Length > 0)
        {
            decompressedString += tempString;
        }
        index++;
    }
    return decompressedString;
}
DecompressedPart DecompressDataWithSubCompression(string compressedData)
{
    DecompressedPart decompressedPart = new DecompressedPart();
    int index = 0;
    string marker = "";
    string tempString = "";
    while(index < compressedData.Length)
    {
        if(compressedData[index] == '(' && marker.Length == 0 && int.TryParse(compressedData[index + 1].ToString(), out int res))
        {
            marker += '0';
            decompressedPart.text += tempString;
            tempString = "";
        }
        else if(marker.Length > 0 && compressedData[index] != ')')
        {
            marker += compressedData[index];
        }
        else if(marker.Length > 0 && compressedData[index] == ')')
        {
            string[] numbers = marker.Split('x');
            tempString = compressedData.Substring(index + 1, int.Parse(numbers[0]));
            DecompressedPart childPart = DecompressDataWithSubCompression(tempString);
            childPart.amount = int.Parse(numbers[1]);
            decompressedPart.childParts.Add(childPart);
            index += int.Parse(numbers[0]);
            tempString = "";
            marker = "";
        }
        
        else
        {
            tempString += compressedData[index];
        }
        if(index == compressedData.Length - 1 && tempString.Length > 0)
        {
            decompressedPart.text += tempString;
        }
        index++;
    }
    return decompressedPart;    
}
class DecompressedPart
{
    public Int64 amount = 1;

    public string text;
    public List<DecompressedPart> childParts = new List<DecompressedPart>();

    public Int64 GetLength()
    {
        Int64 length = text.Length;
        foreach(DecompressedPart childPart in childParts)
        {
            length += childPart.GetLength();
        }
        length *= amount;
        return length;
    }
}