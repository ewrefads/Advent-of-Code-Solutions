// See https://aka.ms/new-console-template for more information
using System.Text;

string[] input =
{"insert input here"};
int sectorIdSum = 0;
Dictionary<string, int>validRooms = new Dictionary<string, int>();
for(int i = 0; i < input.Length; i++)
{
    string room = input[i];
    Dictionary<char, int> letters = new Dictionary<char, int>();
    string checksum = "";
    string sectorId = "";
    bool endOfLetters = false;
    
    for(int j = 0; j < room.Length; j++)
    {
        char letter = room[j];
        
        if(int.TryParse(letter.ToString(), out int res))
        {
            sectorId = sectorId + letter;
        }
        else if(letter == '[')
        {
            Console.WriteLine("beginning checksum");
            endOfLetters = true;
        }
        else if(endOfLetters && letter != ']')
        {
            checksum += letter;
        }
        else if(!endOfLetters && letter != '-' && letter != ']')
        {
            if(letters.ContainsKey(letter))
            {
                letters[letter]++;
            }
            else
            {
                letters.Add(letter, 1);
            }
        }
    }
    List<char>mostUsedLetters = new List<char>();
    while(mostUsedLetters.Count < 5)
    {
        int max = 0;
        List<char>lettersToBeAdded = new List<char>();
        foreach(char letter in letters.Keys)
        {
            if(!mostUsedLetters.Contains(letter) && letters[letter] > max)
            {
                max = letters[letter];
                lettersToBeAdded.Clear();
                lettersToBeAdded.Add(letter);
            }
            else if(!mostUsedLetters.Contains(letter) && letters[letter] == max)
            {
                lettersToBeAdded.Add(letter);
            }
        }
        if(lettersToBeAdded.Count == 1)
        {
            mostUsedLetters.Add(lettersToBeAdded[0]);
        }
        else
        {
            lettersToBeAdded.Sort();
            int x = lettersToBeAdded.Count;
            if(mostUsedLetters.Count + x > 5)
            {
                x = 5 - mostUsedLetters.Count;
            }
            for(int y = 0; y < x; y++)
            {
                mostUsedLetters.Add(lettersToBeAdded[y]);
            }
        }
    }
    bool isValidRoom = true;
    if(checksum.Length == 5)
    {
        for(int h = 0; h < 5; h++)
        {
            if(mostUsedLetters[h] != checksum[h])
            {
                isValidRoom = false;
                break;
            }
        }
        if(isValidRoom)
        {
            sectorIdSum += int.Parse(sectorId);
            validRooms.Add(room, int.Parse(sectorId));
        }
    }
    else
    {
        Console.WriteLine(checksum);
    }
    
}
Console.WriteLine(sectorIdSum);
List<char>decryptLetter = new List<char>()
{
    'a',
    'b',
    'c',
    'd',
    'e',
    'f',
    'g',
    'h',
    'i',
    'j',
    'k',
    'l',
    'm',
    'n',
    'o',
    'p',
    'q',
    'r',
    's',
    't',
    'u',
    'v',
    'w',
    'x',
    'y',
    'z'
};
foreach(string room in validRooms.Keys)
{
    string[] encryptedWords = room.Split('-');
    List<string> decryptedWords = new List<string>();
    for(int i = 0; i < encryptedWords.Length; i++)
    {
        if(!int.TryParse(encryptedWords[i][0].ToString(), out int res))
        {
            string word = "";
            int modifier = validRooms[room];
            while(modifier > decryptLetter.Count)
            {
                modifier -= decryptLetter.Count;
            }
            for(int j = 0; j < encryptedWords[i].Length; j++)
            {
                char encryptedLetter = encryptedWords[i][j];
                int tempModifier = modifier;
                switch(encryptedLetter)
                {
                    case 'a':
                        break;
                    case 'b':
                        tempModifier += 1;
                        break;
                    case 'c':
                        tempModifier += 2;
                        break;
                    case 'd':
                        tempModifier += 3;
                        break;
                    case 'e':
                        tempModifier += 4;
                        break;
                    case 'f':
                        tempModifier += 5;
                        break;
                    case 'g':
                        tempModifier += 6;
                        break;
                    case 'h':
                        tempModifier += 7;
                        break;
                    case 'i':
                        tempModifier += 8;
                        break;
                    case 'j':
                        tempModifier += 9;
                        break;
                    case 'k':
                        tempModifier += 10;
                        break;
                    case 'l':
                        tempModifier += 11;
                        break;
                    case 'm':
                        tempModifier += 12;
                        break;
                    case 'n':
                        tempModifier += 13;
                        break;
                    case 'o':
                        tempModifier += 14;
                        break;
                    case 'p':
                        tempModifier += 15;
                        break;
                    case 'q':   
                        tempModifier += 16;
                        break;
                    case 'r':
                        tempModifier += 17;
                        break;
                    case 's':
                        tempModifier += 18;
                        break;
                    case 't':
                        tempModifier += 19;
                        break;
                    case 'u':
                        tempModifier += 20;
                        break;
                    case 'v':
                        tempModifier += 21;
                        break;
                    case 'w':
                        tempModifier += 22;
                        break;
                    case 'x':
                        tempModifier += 23;
                        break;
                    case 'y':
                        tempModifier += 24;
                        break;
                    case 'z':
                        tempModifier += 25;
                        break;
                }
                if(tempModifier >= decryptLetter.Count)
                {
                    tempModifier -= decryptLetter.Count;
                }
                word += decryptLetter[tempModifier];
            }
            decryptedWords.Add(word);
        }
    }
    for(int j = 0; j < decryptedWords.Count; j++)
    {
        Console.Write(decryptedWords[j] + " ");
    }
    Console.WriteLine();
}