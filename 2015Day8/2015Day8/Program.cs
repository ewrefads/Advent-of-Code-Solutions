// See https://aka.ms/new-console-template for more information
using System.Text;

var input = File.ReadLines("input.txt");

int stringLiteralLength = 0;
int memoryStringLength = input.Sum(l => l.Length);
foreach(string word in input){
    int wordLength = word.Length - 2;
    int i = 0;
    while(i < word.Length)
    {
        if(word[i] == '\\')
        {
            if(word[i + 1] == '\\' || word[i + 1] == '\"')
            {
                wordLength -= 1;
                i += 2;
            }
            else if(word[i + 1] == 'x')
            {
                wordLength -= 3;
                i += 4;
            }
        }
        else
        {
            i++;
        }
    }
    stringLiteralLength += wordLength;
}
Console.WriteLine(memoryStringLength - stringLiteralLength);
int encodedStringLength = 0;
foreach(string word in input){
    int wordLength = word.Length + 2;
    int i = 0;
    while(i < word.Length)
    {
        if(word[i] == '\\' || word[i] == '\"')
        {
            wordLength++;
        }
        i++;
    }
    encodedStringLength += wordLength;
}
Console.WriteLine(encodedStringLength - memoryStringLength);
