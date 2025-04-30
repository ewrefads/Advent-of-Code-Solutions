// See https://aka.ms/new-console-template for more information
int input = int.MinValue;

int giftsDelivered = 0;
List<int> houseNumbers = new List<int>();

for(int i = 1; i <= input / 10; i++)
{
    int gifts = i * 10;
    for(int j = i; j <= input / 10; j += i)
    {
        if(houseNumbers.Count < j)
        {
            houseNumbers.Add(gifts);
        }
        else
        {
            houseNumbers[j - 1] += gifts;
        }
    }
}
for(int i = 0; i < houseNumbers.Count; i++)
{
    if(houseNumbers[i] >= input)
    {
        Console.WriteLine(i + 1);
        break;
    }
}
Dictionary<int, int> houses = new Dictionary<int, int>();
for(int i = 1; i <= input / 11; i++)
{
    int gifts = i * 11;
    int max = i * 50;
    if(max > input / 11)
    {
        max = input / 11;
    }
    for(int j = i; j <= max; j += i)
    {
        if(!houses.ContainsKey(j))
        {
            houses.Add(j, 0);
        }
        houses[j] += gifts;
    }
    Console.WriteLine(input / 11 - i);
}
int lowestHouseNumber = int.MaxValue;
foreach(int houseNumber in houses.Keys)
{
    if(houses[houseNumber] >= input && houseNumber < lowestHouseNumber)
    {
        lowestHouseNumber = houseNumber;
    }
}
Console.WriteLine(lowestHouseNumber);
