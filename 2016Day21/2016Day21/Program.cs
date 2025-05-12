// See https://aka.ms/new-console-template for more information
using System.Text;

string[] input =
{
    "Insert input here"
};
List<char> password = new List<char>()
{
    '0'
};
Console.WriteLine(ScramblePassword(password));
List<char> scrambledPassword = new List<char>()
{
    '0'
};
Console.WriteLine(UnscramblePassword(scrambledPassword));
string ScramblePassword(List<char> password)
{
    for(int i = 0; i < input.Length; i++)
    {
        string[] words = input[i].Split(' ');
        if(words[0] == "swap" && words[1] == "position")
        {
            password = SwapPosition(password, int.Parse(words[2]), int.Parse(words[5]));
        }
        else if(words[0] == "swap" && words[1] == "letter")
        {
            password = SwapLetters(password, words[2][0], words[5][0]);
        }
        else if(words[0] == "rotate")
        {
            if(words[1] == "left")
            {
                password = Rotate(password, -int.Parse(words[2]));
            }
            else if(words[1] == "right")
            {
                password = Rotate(password, int.Parse(words[2]));
            }
            else
            {
                password = RotateBasedOnLetter(password, password.IndexOf(words[6][0]));
            }
        }
        else if(words[0] == "reverse")
        {
            password = Reverse(password, int.Parse(words[2]), int.Parse(words[4]));
        }
        else if(words[0] == "move")
        {
            password = Move(password, int.Parse(words[2]), int.Parse(words[5]));
        }
    }
    string finalPassword = "";
    for(int i = 0; i < password.Count; i++)
    {
        finalPassword += password[i];
    }
    return finalPassword;
}

List<char> SwapPosition(List<char> password, int pos1, int pos2)
{
    char char1 = password[pos1];
    char char2 = password[pos2];
    password[pos1] = char2;
    password[pos2] = char1;
    return password;
}

List<char> SwapLetters(List<char> password, char letter1, char letter2)
{
    int index1 = password.IndexOf(letter1);
    int index2 = password.IndexOf(letter2);
    password[index1] = letter2;
    password[index2] = letter1;
    return password;
}
List<char> ReverseRotateBasedOnLetter(List<char> password, char index)
{
    List<char> tempPassword = new List<char>();
    int i = 0;
    while(i < password.Count)
    {
        int offSet = -1 - i;
        if(i >= 4)
        {
            offSet -= 1;
        }
        tempPassword = Rotate(password, offSet);
        if(tempPassword.IndexOf(index) == i)
        {
            break;
        }
        else
        {
            i++;
        }
    }
    
    return tempPassword;
}
List<char> RotateBasedOnLetter(List<char> password, int index)
{
    int offSet = 1 + index;
    if(index >= 4)
    {
        offSet += 1;
    }
    return Rotate(password, offSet);
}
List<char> Rotate(List<char> password, int offSet)
{
    List<char> tempPassword = new List<char>();
    for(int i = 0; i < password.Count; i++)
    {
        int index = i - offSet;
        while(index < 0)
        {
            index += password.Count;
        }
        while(index >= password.Count)
        {
            index -= password.Count;
        }
        tempPassword.Add(password[index]);
    }
    return tempPassword;
}

List<char> Reverse(List<char> password, int start, int end)
{
    string tempPassword = ConvertToString(password);
    string firstPart = "";
    if(start > 0)
    {
        firstPart = tempPassword.Substring(0, start);
    }
    
    List<char> reversedPart = tempPassword.Substring(start, end - start + 1).ToList();
    reversedPart.Reverse();
    string lastPart = "";
    if(end < tempPassword.Length - 1)
    {
        lastPart = tempPassword.Substring(end + 1, tempPassword.Length - end - 1);
    }
    tempPassword = firstPart + ConvertToString(reversedPart) + lastPart;
    return tempPassword.ToList();
}

List<char> Move(List<char> password, int pos1, int pos2)
{
    char movedCharacter = password[pos1];
    password.Remove(movedCharacter);
    password.Insert(pos2, movedCharacter);
    return password;
}

string ConvertToString(List<char> list)
{
    string listString = "";
    for(int i = 0; i < list.Count; i++)
    {
        listString += list[i];
    }
    return listString;
}

string UnscramblePassword(List<char> password)
{
    for(int i = input.Length - 1; i >= 0; i--)
    {
        string[] words = input[i].Split(' ');
        if(words[0] == "swap" && words[1] == "position")
        {
            password = SwapPosition(password, int.Parse(words[2]), int.Parse(words[5]));
        }
        else if(words[0] == "swap" && words[1] == "letter")
        {
            password = SwapLetters(password, words[2][0], words[5][0]);
        }
        else if(words[0] == "rotate")
        {
            if(words[1] == "left")
            {
                password = Rotate(password, int.Parse(words[2]));
            }
            else if(words[1] == "right")
            {
                password = Rotate(password, -int.Parse(words[2]));
            }
            else
            {
                password = ReverseRotateBasedOnLetter(password, words[6][0]);
            }
        }
        else if(words[0] == "reverse")
        {
            password = Reverse(password, int.Parse(words[2]), int.Parse(words[4]));
        }
        else if(words[0] == "move")
        {
            password = Move(password, int.Parse(words[5]), int.Parse(words[2]));
        }
    }
    return ConvertToString(password);
}