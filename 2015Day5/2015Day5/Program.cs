// See https://aka.ms/new-console-template for more information
string input = "insert input here";
bool IsVowel(char letter)
{
    switch(letter)
    {
        case 'a':
        case 'e':
        case 'i':
        case 'o':
        case 'u':
            return true;
        default:
            return false;
    }
}
bool hasInvalidSubstring(char l1, char l2)
{
    char[] chars = {l1, l2};
    string substring = new string(chars);

    switch(substring)
    {
        case "ab":
        case "cd":
        case "pq":
        case "xy":
            return true;
        default:
            return false;
    }
}
bool hasRepeatingPair(List<char> previousletters, (char, char) pair)
{
    for(int i = 0; i < previousletters.Count; i++)
    {
        if(i < previousletters.Count - 1)
        {
            (char, char) compPair = (previousletters[i], previousletters[i + 1]);
            if(pair == compPair)
            {
                return true;
            }
        }
    }
    return false;
}
string[] strings = input.Split(',', StringSplitOptions.None);
int numNiceStrings = 0;
for(int i = 0; i < strings.Length; i++)
{
    string cString = strings[i];
    int numVowels = 0;
    bool hasLetterTwiceInRow = false;
    bool containInvalidSubstring = false;
    char cChar = ' ';
    char prevChar = ' ';
    for(int j = 0; j < cString.Length; j++)
    {
        prevChar = cChar;
        cChar = cString[j];
        if(IsVowel(cChar))
        {
            numVowels++;
        }
        if(cChar == prevChar && !hasLetterTwiceInRow)
        {
            hasLetterTwiceInRow = true;
        }
        if(prevChar != ' ' && hasInvalidSubstring(prevChar, cChar))
        {
            containInvalidSubstring = true;
            break;
        }
    }
    if(numVowels >= 3 && hasLetterTwiceInRow && !containInvalidSubstring)
    {
        numNiceStrings++;
    }
}
Console.WriteLine(numNiceStrings);
numNiceStrings = 0;
for(int i = 0; i < strings.Length; i++)
{
    string cString = strings[i];
    List<char> previousLetters = new List<char>();
    bool repeatingPair = false;
    bool repeatSurround = false;
    char cChar = ' ';
    char prevChar = ' ';
    for(int j = 0; j < cString.Length; j++)
    {
        if(prevChar != ' ')
        {
            previousLetters.Add(prevChar);
        }
        prevChar = cChar;
        cChar = cString[j];
        if(previousLetters.Count >= 2 && !repeatingPair)
        {
            repeatingPair = hasRepeatingPair(previousLetters, (prevChar, cChar));
        }
        if(previousLetters.Count > 0 && cChar == previousLetters[previousLetters.Count -1] && !repeatSurround)
        {
            repeatSurround = true;
        }
    }
    if(repeatingPair && repeatSurround)
    {
        numNiceStrings++;
    }
}
Console.WriteLine(numNiceStrings);