// See https://aka.ms/new-console-template for more information
string[] input = {"insert input here"};
Dictionary<string, Location> locations = new Dictionary<string, Location>();
foreach(string direction in input)
{
    string[] locationsAndDistance = direction.Split(" = ");
    string[] directionLocations = locationsAndDistance[0].Split(' ');
    Location location1 = CreateOrGetLocation(directionLocations[0]);
    Location location2 = CreateOrGetLocation(directionLocations[2]);
    int distance = Int32.Parse(locationsAndDistance[1]);
    location1.distances.Add(location2, distance);
    location2.distances.Add(location1, distance);
}
int shortestDistance = int.MaxValue;
foreach(Location location in locations.Values)
{
    int calculatedDistance = CalculateShortestDistance(location, locations.Values.ToList());
    if(calculatedDistance < shortestDistance)
    {
        shortestDistance = calculatedDistance;
    }
}
Console.WriteLine(shortestDistance);

int longestDistance = int.MinValue;
foreach(Location location in locations.Values)
{
    int calculatedDistance = CalculateLongestDistance(location, locations.Values.ToList());
    if(calculatedDistance > longestDistance)
    {
        longestDistance = calculatedDistance;
    }
}
Console.WriteLine(longestDistance);
int CalculateShortestDistance(Location location, List<Location> remainingLocations)
{
    if(remainingLocations.Count > 1)
    {
        remainingLocations.Remove(location);
        int shortestDistance = int.MaxValue;
        foreach(Location loc in remainingLocations)
        {
            Location[] locArray = remainingLocations.ToArray();
            int totalDistance = CalculateShortestDistance(loc, locArray.ToList());
            totalDistance += location.distances[loc];
            if(totalDistance < shortestDistance)
            {
                shortestDistance = totalDistance;
            }
        }
        
        return shortestDistance;
    }
    else
    {
        return 0;
    }
}
int CalculateLongestDistance(Location location, List<Location> remainingLocations)
{
    if(remainingLocations.Count > 1)
    {
        remainingLocations.Remove(location);
        int longestDistance = int.MinValue;
        foreach(Location loc in remainingLocations)
        {
            Location[] locArray = remainingLocations.ToArray();
            int totalDistance = CalculateLongestDistance(loc, locArray.ToList());
            totalDistance += location.distances[loc];
            if(totalDistance > longestDistance)
            {
                longestDistance = totalDistance;
            }
        }
        
        return longestDistance;
    }
    else
    {
        return 0;
    }
}

Location CreateOrGetLocation(string location)
{
    if(locations.ContainsKey(location))
    {
        return locations[location];
    }
    else 
    {
        Location newLoc = new Location();
        locations.Add(location, newLoc);
        return locations[location];
    }
}
class Location 
{
    public Dictionary<Location, int> distances = new Dictionary<Location, int>();
}