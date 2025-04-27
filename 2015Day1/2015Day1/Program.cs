// See https://aka.ms/new-console-template for more information
string input = "insert input here"
int currentFloor = 0;
int entersBasement = -1;
bool hasEnteredBasement = false;
for(int i = 0; i < input.Length; i++)
{
    if(input[i] == '(')
    {
        currentFloor++;
    }
    else
    {
        currentFloor--;
    }
    if(currentFloor == -1 && !hasEnteredBasement)
    {
        entersBasement = i + 1;
        hasEnteredBasement = true;
    }
}
Console.WriteLine(currentFloor);
Console.WriteLine(entersBasement);