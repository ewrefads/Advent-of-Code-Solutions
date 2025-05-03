// See https://aka.ms/new-console-template for more information
string input = "1321131112";
string inputWord = input;
File.WriteAllText("test.txt", inputWord.Length.ToString());
for(int i = 0; i < 50; i++)
{
    string tempWord = "";
    string substring = "";
    for(int j = 0; j < inputWord.Length; j++)
    {
        float percentage = (1.0f - ((float)j / (float)inputWord.Length)) * 100;
        Console.WriteLine("iteration " + i + " remaining numbers: " + (inputWord.Length - j) + " " + percentage);
        if(substring == "" || substring[0] == inputWord[j])
        {
            substring += inputWord[j];
        }
        else
        {
            tempWord += substring.Length;
            tempWord += substring[0];
            substring = "";
            substring += inputWord[j];
        }
        if(j == inputWord.Length - 1)
        {
            tempWord += substring.Length;
            tempWord += substring[0];
        }
    }
    
    inputWord = tempWord;
}

string LookAndSay(string input, int remainingIterations)
{
    Console.WriteLine("remaining iterations: " + remainingIterations);
    if(remainingIterations > 0)
    {
        string tempWord = "";
        string substring = "";
        for(int j = 0; j < input.Length; j++)
        {
            if(substring == "" || substring[0] == input[j])
            {
                substring += input[j];
            }
            else
            {
                string recursionResult = LookAndSay(substring.Length.ToString() + substring[0], remainingIterations--);
                tempWord += recursionResult;
                substring = "";
                substring += input[j];
            }
            if(j == input.Length - 1)
            {
                string recursionResult = LookAndSay(substring.Length.ToString() + substring[0], remainingIterations--);
                tempWord += recursionResult;
            }
        }
        
        return tempWord;
    }
    else
    {
        return input;
    }
}
Console.WriteLine(inputWord.Length);
File.WriteAllText("result.txt", inputWord.Length.ToString());
//Console.WriteLine(LookAndSay(input, 40).Length);
