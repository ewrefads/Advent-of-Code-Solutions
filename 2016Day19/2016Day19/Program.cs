// See https://aka.ms/new-console-template for more information
int input = 0;
string binary = Convert.ToString(input, 2);
char leadingBit = binary[0];
string safePosition = binary.Substring(1, binary.Length - 1) + leadingBit;
Console.WriteLine(Convert.ToInt32(safePosition, 2));
List<int> remainingElfs = new List<int>();
for(int i = 1; i <= input; i++)
{
    remainingElfs.Add(i);
}
Console.WriteLine(GetLastRemaing(input));
int GetLastRemaing(int elfs)
{
    List<int> firstHalf = new List<int>();
    List<int> secondHalf = new List<int>();
    for(int i = 1; i <= elfs; i++)
    {
        if(i <= elfs / 2)
        {
            firstHalf.Add(i);
        }
        else
        {
            secondHalf.Add(i);
        }
    }
    while(firstHalf.Count + secondHalf.Count > 1)
    {
        int x = firstHalf[0];
        firstHalf.RemoveAt(0);
        if(firstHalf.Count == secondHalf.Count)
        {
            firstHalf.Remove(firstHalf.Last());
        }
        else
        {
            secondHalf.RemoveAt(0);
        }
        secondHalf.Add(x);
        firstHalf.Add(secondHalf[0]);
        secondHalf.RemoveAt(0);
        Console.WriteLine(firstHalf.Count + secondHalf.Count + " elfs remaining");
    }
    int remainingElf;
    if(firstHalf.Count == 1)
    {
        remainingElf = firstHalf[0];
    }
    else
    {
        remainingElf = secondHalf[0];
    }
    return remainingElf;
}