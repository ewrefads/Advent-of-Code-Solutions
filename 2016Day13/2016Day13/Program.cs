// See https://aka.ms/new-console-template for more information
int input = 0;

Dictionary<(int, int), int> distances = new Dictionary<(int, int), int>();
List<(int, int)> walls = new List<(int, int)>();
distances.Add((1,1), 0);
Queue<(int, int)> positions = new Queue<(int, int)>();
positions.Enqueue((1,1));
int locationsReached = 0;
while(!distances.ContainsKey((31, 39)))
{

    (int, int) position = positions.Dequeue();
    Dictionary<(int, int), int> potentialPositions = new Dictionary<(int, int), int>
    {
        { (position.Item1 + 1, position.Item2), int.MaxValue },
        { (position.Item1, position.Item2 + 1), int.MaxValue }
    };
    if(position.Item1 >= 1)
    {
        potentialPositions.Add((position.Item1 - 1, position.Item2), int.MaxValue);
    }
    if(position.Item2 >= 1)
    {
        potentialPositions.Add((position.Item1, position.Item2 - 1), int.MaxValue);
    }
    int distance = distances[position] + 1;
    foreach((int, int) pos in potentialPositions.Keys)
    {
        if(!IsWall(pos) && !distances.ContainsKey(pos))
        {
            distances.Add(pos, distance);
            positions.Enqueue(pos);
        }
    }
    if(distances[position] < 51)
    {
        locationsReached++;
    }
}
Console.WriteLine(distances[(31, 39)]);
Console.WriteLine(locationsReached);
bool IsWall((int, int) position)
{
    if(walls.Contains(position))
    {
        return true;
    }
    int value = position.Item1 * position.Item1 + 3 * position.Item1 + 2 * position.Item1 * position.Item2 + position.Item2 + position.Item2 * position.Item2 + input;
    string binaryValue = Convert.ToString(value, 2);
    int bits1 = 0;
    foreach(char bit in binaryValue)
    {
        if(bit == '1')
        {
            bits1++;
        }
    }
    if(bits1 % 2 != 0)
    {
        walls.Add(position);
        return true;
    }
    return false;
}