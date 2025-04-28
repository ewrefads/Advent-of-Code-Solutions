// See https://aka.ms/new-console-template for more information
using System.Text;
string input = "insert input here";

while(true)
{
    if(VerifyPassWord(input))
    {
        break;
    }
    else
    {
        input = Increment(input);
    }
}
Console.WriteLine(input);
input = Increment(input);
while(true)
{
    if(VerifyPassWord(input))
    {
        break;
    }
    else
    {
        input = Increment(input);
    }
}
Console.WriteLine(input);
bool VerifyPassWord(string word)
{
    List<int> pairEnds = new List<int>();
    string testString = "";
    bool foundIncreasingLetters = false;
    for(int i = 0; i < word.Length; i++)
    {
        if(!foundIncreasingLetters && testString.Length < 3)
        {
            testString += word[i];
        }
        else if(!foundIncreasingLetters)
        {
            foundIncreasingLetters = VerifyIncreasingLetters(testString, 1);
            testString = "";
        }
        if(i > 0 && word[i] == word[i - 1] && !pairEnds.Contains(i - 1))
        {
            pairEnds.Add(i);
        }
    }
    if(pairEnds.Count >= 2 && foundIncreasingLetters)
    {
        return true;
    }
    else
    {
        return false;
    }
}
bool VerifyIncreasingLetters(string letters, int testIndex)
{
    switch(letters[testIndex])
    {
        case 'a':
            return false;
        case 'b':
            if(letters[testIndex - 1] == 'a')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'c':
            if(letters[testIndex - 1] == 'b')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'd':
            if(letters[testIndex - 1] == 'c')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'e':
            if(letters[testIndex - 1] == 'd')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'f':
            if(letters[testIndex - 1] == 'e')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'g':
            if(letters[testIndex - 1] == 'f')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'h':
            if(letters[testIndex - 1] == 'g')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'j':
            if(letters[testIndex - 1] == 'h')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'k':
            if(letters[testIndex - 1] == 'j')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'm':
            if(letters[testIndex - 1] == 'k')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'n':
            if(letters[testIndex - 1] == 'm')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'p':
            if(letters[testIndex - 1] == 'n')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'q':
            if(letters[testIndex - 1] == 'p')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'r':
            if(letters[testIndex - 1] == 'q')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 's':
            if(letters[testIndex - 1] == 'r')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 't':
            if(letters[testIndex - 1] == 's')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'u':
            if(letters[testIndex - 1] == 't')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'v':
            if(letters[testIndex - 1] == 'u')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'w':
            if(letters[testIndex - 1] == 'v')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'x':
            if(letters[testIndex - 1] == 'w')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'y':
            if(letters[testIndex - 1] == 'x')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        case 'z':
            if(letters[testIndex - 1] == 'y')
            {
                if(testIndex == 1)
                {
                    return VerifyIncreasingLetters(letters, 2);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        default:
            return false;
    }
}
string Increment(string word)
{
    char lastChar = word[word.Length - 1];
    StringBuilder sb = new StringBuilder(word);
    switch(lastChar)
    {
        case 'a':
            sb[word.Length - 1] = 'b';
            break;
        case 'b':
            sb[word.Length - 1] = 'c';
            break;
        case 'c':
            sb[word.Length - 1] = 'd';
            break;
        case 'd':
            sb[word.Length - 1] = 'e';
            break;
        case 'e':
            sb[word.Length - 1] = 'f';
            break;
        case 'f':
            sb[word.Length - 1] = 'g';
            break;
        case 'g':
            sb[word.Length - 1] = 'h';
            break;
        case 'h':
            sb[word.Length - 1] = 'j';
            break;
        case 'j':
            sb[word.Length - 1] = 'k';
            break;
        case 'k':
            sb[word.Length - 1] = 'm';
            break;
        case 'm':
            sb[word.Length - 1] = 'n';
            break;
        case 'n':
            sb[word.Length - 1] = 'p';
            break;
        case 'p':
            sb[word.Length - 1] = 'q';
            break;
        case 'q':
            sb[word.Length - 1] = 'r';
            break;
        case 'r':
            sb[word.Length - 1] = 's';
            break;
        case 's':
            sb[word.Length - 1] = 't';
            break;
        case 't':
            sb[word.Length - 1] = 'u';
            break;
        case 'u':
            sb[word.Length - 1] = 'v';
            break;
        case 'v':
            sb[word.Length - 1] = 'w';
            break;
        case 'w':
            sb[word.Length - 1] = 'x';
            break;
        case 'x':
            sb[word.Length - 1] = 'y';
            break;
        case 'y':
            sb[word.Length - 1] = 'z';
            break;
        case 'z':
            sb = new StringBuilder(Increment(word.Remove(word.Length - 1))+ 'a' );
            break;
    }
    return sb.ToString();
}