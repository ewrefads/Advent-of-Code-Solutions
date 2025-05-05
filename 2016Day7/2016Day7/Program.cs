// See https://aka.ms/new-console-template for more information
string[] input =
{
    "insert input here"
};
List<string> supportsTLS = new List<string>();
List<string> supportsSSL = new List<string>();
foreach(string IP in input)
{
    bool hasABBA = false;
    bool inBrackets = false;
    for(int i = 0; i < IP.Length - 3; i++)
    {
        if(IP[i] == '[')
        {
            inBrackets = true;
        }
        else if(IP[i] == ']')
        {
            inBrackets = false;
        }
        else
        {
            string subString = IP.Substring(i, 4);
            if(subString[0] == subString[3] && subString[1] == subString[2] && subString[0] != subString[1])
            {
                if(inBrackets)
                {
                    hasABBA = false;
                    break;
                }
                else
                {
                    hasABBA = true;
                }
            }
        }
    }
    if(hasABBA)
    {
        supportsTLS.Add(IP);
    }
}
foreach(string IP in input)
{
    List<string>ABAs = new List<string>();
    List<string>BABs = new List<string>();
    bool inBrackets = false;
    for(int i = 0; i < IP.Length - 2; i++)
    {
        if(IP[i] == '[')
        {
            inBrackets = true;
        }
        else if(IP[i] == ']')
        {
            inBrackets = false;
        }
        else
        {
            string subString = IP.Substring(i, 3);
            
            if(subString[0] == subString[2] && subString[0] != subString[1])
            {
                if(inBrackets)
                {
                    BABs.Add(subString);
                }
                else
                {
                    ABAs.Add(subString);
                }
            }
        }
    }
    bool SSLSupport = false;
    foreach(string ABA in ABAs)
    {
        foreach(string BAB in BABs)
        {
            if(ABA[0] == BAB[1] && ABA[1] == BAB[0])
            {
                SSLSupport = true;
                break;
            }
        }
        if(SSLSupport)
        {
            supportsSSL.Add(IP);
            break;
        }
    }
}
Console.WriteLine(supportsTLS.Count);
Console.WriteLine(supportsSSL.Count);
