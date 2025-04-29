// See https://aka.ms/new-console-template for more information
int[] input = {0};
int minCombination = int.MaxValue;
int numMinCombinations = 0;
int NumberOfCombinations(int index, int remainingEggnog, int usedContainers)
{
    if(remainingEggnog == input[index])
    {
        usedContainers++;
        if(usedContainers < minCombination)
        {
            minCombination = usedContainers;
            numMinCombinations = 1;
        }
        else if(usedContainers == minCombination)
        {
            numMinCombinations++;
        }
        return 1;
    }
    else if(remainingEggnog < input[index])
    {
        return 0;
    }
    else
    {
        int possibleCombinations = 0;
        remainingEggnog -= input[index];
        usedContainers++;
        for(int i = index + 1; i < input.Length; i++)
        {
            possibleCombinations += NumberOfCombinations(i, remainingEggnog, usedContainers);
        }
        return possibleCombinations;
    }
}
int totalCombinations = 0;
for(int i = 0; i < input.Length; i++)
{
    totalCombinations += NumberOfCombinations(i, 150, 0);
}
Console.WriteLine(totalCombinations);
Console.WriteLine(numMinCombinations);
