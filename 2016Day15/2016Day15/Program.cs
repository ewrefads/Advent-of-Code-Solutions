// See https://aka.ms/new-console-template for more information
string[] input = 
{
    "insert input here"
}; 
Disc disc1 = new Disc();
disc1.positions = 1;
disc1.currentPosition = 0;
List<Disc> discs = new List<Disc>()
{
    disc1
};
for(int i = 0; i < input.Length; i++)
{
    string[] words = input[i].Split(' ');
    Disc disc = new Disc();
    disc.positions = int.Parse(words[3]);
    disc.currentPosition = int.Parse(words[11].Split('.')[0]);
    discs.Add(disc);
}

Console.WriteLine(FindStartTime());
Disc newDisc = new Disc();
newDisc.positions = 11;
newDisc.currentPosition = 0;
discs.Add(newDisc);
Console.WriteLine(FindStartTime());
int FindStartTime()
{
    int time = 0;
    int longest = 0;
    while(true)
    {
        bool canPassThrough = true;
        for(int i = 0; i < discs.Count; i++)
        {
            if(discs[i].GetMovedPosition(time + i) != 0)
            {
                if(i > longest)
                {
                    longest = i;
                    Console.WriteLine(i);
                }
                canPassThrough = false;
                break;
            }
        }
        if(canPassThrough)
        {
            break;
        }
        else
        {
            time++;
        }
    }
    return time;
}
class Disc 
{
    public int positions;
    public int currentPosition;
    public int GetMovedPosition(int move)
    {
        int newPosition = currentPosition;
        newPosition += move;
        while(newPosition >= positions)
        {
            newPosition -= positions;
        }
        return newPosition;
    }
}