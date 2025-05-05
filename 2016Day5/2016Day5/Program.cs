// See https://aka.ms/new-console-template for more information
string[] input = 
{
    "insert input here"
};
List<Dictionary<char, int>> chars = new List<Dictionary<char, int>>();
for (int i = 0; i < input.Length; i++)
{
    string message = input[i];
    for (int j = 0; j < message.Length; j++)
    {
        if(chars.Count == j)
        {
            chars.Add(new Dictionary<char, int>());
        }
        if(chars[j].Keys.Contains(message[j]))
        {
            chars[j][message[j]]++;
        }
        else
        {
            chars[j].Add(message[j], 1);
        }
    }
}
string errorCorrected = "";
string modifiedErrorCorrected = "";
for(int i = 0; i < chars.Count; i++)
{
    int max = 0;
    char maxCharacter = ' ';
    int min = int.MaxValue;
    char minCharacter = ' ';
    foreach(char letter in chars[i].Keys)
    {
        if(chars[i][letter] > max)
        {
            max = chars[i][letter];
            maxCharacter = letter;
        }
        if(chars[i][letter] < min)
        {
            min = chars[i][letter];
            minCharacter = letter;
        }
    }
    errorCorrected += maxCharacter;
    modifiedErrorCorrected += minCharacter;
}
Console.WriteLine(errorCorrected);
Console.WriteLine(modifiedErrorCorrected);
