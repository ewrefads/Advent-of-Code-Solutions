// See https://aka.ms/new-console-template for more information",
string[] input =
{
    "Insert input here"
};
Dictionary<Int64, Int64> ranges = new Dictionary<Int64, Int64>();
Int64 lowestPossibleIP = Int64.MaxValue;
for (Int64 i1 = 0; i1 < input.Length; i1++)
{
    string bound = input[i1];
    Int64 parsedLowerBound = Int64.Parse(bound.Split('-')[0]);
    Int64 parsedUpperBound = Int64.Parse(bound.Split('-')[1]);
    ranges.Add(parsedLowerBound, parsedUpperBound);
}
Int64 i = 0;
Int64 validIPs = 0;
while(i < 4294967295)
{
    bool validIP = true;
    foreach(Int64 lower in ranges.Keys)
    {

        if(i >= lower &&  i <= ranges[lower])
        {
            validIP = false;
            i = ranges[lower];
            break;
        }
    }
    if(validIP)
    {
        validIPs++;
        if(lowestPossibleIP == Int64.MaxValue)
        {
            lowestPossibleIP = i;
        }
    }
    i++;
}
Console.WriteLine(lowestPossibleIP);
Console.WriteLine(validIPs);