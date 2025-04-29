// See https://aka.ms/new-console-template for more information
string[] input = {"insert input here"};
int longestDistance = int.MinValue;
int maxPoints = int.MinValue;
List<Reindeer> reindeers = new List<Reindeer>();
foreach(string reindeer in input)
{
    string[] words = reindeer.Split(' ');
    int speed = int.Parse(words[3]);
    int runTime = int.Parse(words[6]);
    int restTime = int.Parse(words[13]);
    Reindeer newReindeer = new Reindeer(speed, runTime, restTime);
    reindeers.Add(newReindeer);
}
for(int i = 0; i < 2503; i++)
{
    List<Reindeer> leadingReindeers = [new Reindeer(0, 0, 0)];
    foreach(Reindeer reindeer in reindeers)
    {
        reindeer.Travel();
        if(reindeer.distanceTraveled > leadingReindeers[0].distanceTraveled)
        {
            leadingReindeers.Clear();
            leadingReindeers.Add(reindeer);
        }
        else if(reindeer.distanceTraveled == leadingReindeers[0].distanceTraveled)
        {
            leadingReindeers.Add(reindeer);
        }
    }
    foreach(Reindeer reindeer in leadingReindeers)
    {
        reindeer.points++;
    }
}
foreach(Reindeer reindeer in reindeers)
{
    if(reindeer.distanceTraveled > longestDistance)
    {
        longestDistance = reindeer.distanceTraveled;
    }
    if(reindeer.points > maxPoints)
    {
        maxPoints = reindeer.points;
    }
}
Console.WriteLine(longestDistance);
Console.WriteLine(maxPoints);
class Reindeer
{
    public int speed;
    public int runTime;
    public int remainingRunTime = 0;
    public int restTime;
    public int remainingRestTime = 0;
    public int points = 0;
    
    public int distanceTraveled = 0;

    public Reindeer(int speed, int runTime, int restTime)
    {
        this.speed = speed;
        this.runTime = runTime;
        remainingRunTime = this.runTime;
        this.restTime = restTime;
    }

    public int Travel()
    {
        if(remainingRunTime > 0)
        {
            distanceTraveled += speed;
            remainingRunTime--;
            if(remainingRunTime == 0)
            {
                remainingRestTime = restTime;
            }
        }
        else if(remainingRestTime > 0)
        {
            remainingRestTime--;
            if(remainingRestTime == 0)
            {
                remainingRunTime = runTime;
            }
        }
        return distanceTraveled;
    }

}