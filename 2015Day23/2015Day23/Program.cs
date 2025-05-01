// See https://aka.ms/new-console-template for more information
String[] instructions = {"Insert input here"};
int a = 0;
int b = 0;
int i = 0;
RunInstructions();
Console.WriteLine(b);
a = 1;
b = 0;
i = 0;
RunInstructions();
Console.WriteLine(b);
void RunInstructions()
{
    while(i < instructions.Length)
    {
        string[] words = instructions[i].Split(' ');
        int deltaI = 1;
        switch(words[0])
        {
            case "hlf":
                if(words[1] == "a")
                {
                    a /= 2;
                }
                else
                {
                    b /= 2;
                }
                break;
            case "tpl":
                if(words[1] == "a")
                {
                    a *= 3;
                }
                else
                {
                    b *= 3;
                }
                break;
            case "inc":
                if(words[1] == "a")
                {
                    a += 1;
                }
                else
                {
                    b += 1;
                }
                break;
            case "jmp":
                deltaI = int.Parse(words[1]);
                break;
            case "jie":
                if(words[1] == "a,")
                {
                    if(a % 2 == 0)
                    {
                        deltaI = int.Parse(words[2]);
                    }
                }
                else
                {
                    if(b % 2 == 0)
                    {
                        deltaI = int.Parse(words[2]);
                    }
                }
                break;
            case "jio":
                if(words[1] == "a,")
                {
                    if(a == 1)
                    {
                        deltaI = int.Parse(words[2]);
                    }
                }
                else
                {
                    if(b == 1)
                    {
                        deltaI = int.Parse(words[2]);
                    }
                }
                break;
            default:
                throw new Exception("unknown instruction: " + words[0]);
        }
        i += deltaI;
    }
}

