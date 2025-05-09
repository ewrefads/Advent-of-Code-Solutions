// See https://aka.ms/new-console-template for more information
string[] input = 
{
    "Insert input here"
};
List<AssemblyPart> floor1 = new List<AssemblyPart>();
List<AssemblyPart> floor2 = new List<AssemblyPart>();
List<AssemblyPart> floor3 = new List<AssemblyPart>();
List<AssemblyPart> floor4 = new List<AssemblyPart>();
List<List<AssemblyPart>> floors = new List<List<AssemblyPart>>()
{
    floor1,
    floor2,
    floor3,
    floor4
};
List<State> previousStates = new List<State>();
foreach(string floor in input)
{
    string[] words = floor.Split(' ');
    int floorNumber = 0;
    switch(words[1])
    {
        case "second":
            floorNumber = 1;
            break;
        case "third":
            floorNumber = 2;
            break;
        case "fourth":
            floorNumber = 3;
            break;
    }
    for(int i = 0; i < words.Length; i++)
    {
        string compWord = words[i].Split(',')[0];
        compWord = compWord.Split('.')[0];
        switch(compWord)
        {
            case "generator":
                Generator generator = new Generator();
                generator.fuel = words[i - 1];
                floors[floorNumber].Add(generator);
                break;
            case "microchip":
                Microchip microchip = new Microchip();
                microchip.fuel = words[i -1].Split('-')[0];
                floors[floorNumber].Add(microchip);
                break;
        }
    }
}
int totalItems = floors[0].Count + floors[1].Count + floors[2].Count;
Int64 possibleFloorCombinations = 1;
for(int i = 1; i <= totalItems + 1; i++)
{
    possibleFloorCombinations *= i;
}
Int64 possibleElevatorCombinations = 4;
for(int i = 1; i <= totalItems + 1; i++)
{
    possibleElevatorCombinations *= i;
}
Int64 totalPossibleCombinations = possibleFloorCombinations * possibleElevatorCombinations - 1;
State startState = new State();
startState.currentFloor = 0;
startState.elevator = new List<AssemblyPart>();
startState.floors = floors;
previousStates.Add(startState);
Queue<State> statesToCheck = new Queue<State>();
statesToCheck.Enqueue(startState);
int shortestRoute = 0;
while(statesToCheck.Count > 0 && shortestRoute == 0)
{
    CalculateShortestRoute(statesToCheck.Dequeue());
    Console.WriteLine(totalPossibleCombinations + " possible combinations remaining");
}
Console.WriteLine(shortestRoute);
void CalculateShortestRoute(State state)
{
    if(state.elevator.Count + floors[3].Count == totalItems && state.currentFloor == 3)
    {
        Console.WriteLine("found valid route");
        shortestRoute = state.stepsAttempted;
    }
    else if(state.elevator.Count + floors[3].Count == totalItems && state.currentFloor != 3)
    {
        State newState = state.GetCopy();
        newState.currentFloor = state.currentFloor + 1;
        newState.stepsAttempted++;
        statesToCheck.Enqueue(newState.GetCopy());
    }
    else if(state.elevator.Count + floors[3].Count != totalItems)
    {
        if(state.elevator.Count == 2)
        {
            State newState = state.GetCopy();
            newState.stepsAttempted++;
            if(state.currentFloor < 3)
            {
                newState.currentFloor++;
                if(ValidState(newState))
                {
                    previousStates.Add(newState.GetCopy());
                    totalPossibleCombinations--;
                    statesToCheck.Enqueue(newState.GetCopy());
                }
                newState.currentFloor--;
            }
            if(state.currentFloor > 0)
            {
                newState.currentFloor--;
                if(ValidState(newState))
                {
                    previousStates.Add(newState.GetCopy());
                    totalPossibleCombinations--;
                    statesToCheck.Enqueue(newState.GetCopy());
                }
                newState.currentFloor++;
            }
            foreach(AssemblyPart assemblyPart in newState.elevator)
            {
                state.floors[state.currentFloor].Add(assemblyPart);
            }
            newState.elevator.Clear();
            if(ValidState(newState))
            {
                previousStates.Add(newState.GetCopy());
                totalPossibleCombinations--;
                statesToCheck.Enqueue(newState.GetCopy());
            }
            newState.elevator.Add(state.elevator[0]);
            newState.floors[newState.currentFloor].Remove(state.elevator[0]);
            if(ValidState(newState))
            {
                previousStates.Add(newState.GetCopy());
                totalPossibleCombinations--;
                statesToCheck.Enqueue(newState.GetCopy());
            }
            newState.floors[newState.currentFloor].Add(state.elevator[0]);
            newState.elevator.Clear();
            newState.elevator.Add(state.elevator[1]);
            newState.floors[newState.currentFloor].Remove(state.elevator[1]);
            if(ValidState(newState))
            {
                previousStates.Add(newState.GetCopy());
                totalPossibleCombinations--;
                statesToCheck.Enqueue(newState.GetCopy());
            }
        }
        else if(state.elevator.Count == 1)
        {
            State newState = state.GetCopy();
            if(state.currentFloor < 3)
            {
                newState.currentFloor++;
                if(ValidState(newState))
                {
                    previousStates.Add(newState.GetCopy());
                    totalPossibleCombinations--;
                    statesToCheck.Enqueue(newState.GetCopy());
                }
                newState.currentFloor--;
            }
            if(state.currentFloor > 0)
            {
                newState.currentFloor--;
                if(ValidState(newState))
                {
                    previousStates.Add(newState.GetCopy());
                    totalPossibleCombinations--;
                    statesToCheck.Enqueue(newState.GetCopy());
                }
                newState.currentFloor++;
            }
            List<(AssemblyPart, AssemblyPart)> validElevatorInput = validElevatorContents(newState.elevator, newState.floors[newState.currentFloor]);
            foreach((AssemblyPart, AssemblyPart) elevatorInput in validElevatorInput)
            {
                newState.elevator.Add(elevatorInput.Item1);
                newState.floors[newState.currentFloor].Remove(elevatorInput.Item1);
                if(ValidState(newState))
                {
                    previousStates.Add(newState.GetCopy());
                    totalPossibleCombinations--;
                    statesToCheck.Enqueue(newState.GetCopy());
                }
                newState.elevator.Remove(elevatorInput.Item1);
                newState.floors[newState.currentFloor].Add(elevatorInput.Item1);
            }
            foreach(AssemblyPart assemblyPart in newState.elevator)
            {
                state.floors[state.currentFloor].Add(assemblyPart);
            }
            newState.elevator.Clear();
            if(ValidState(newState))
            {
                previousStates.Add(newState.GetCopy());
                totalPossibleCombinations--;
                statesToCheck.Enqueue(newState.GetCopy());
            }
            newState.elevator.Add(state.elevator[0]);
            newState.floors[newState.currentFloor].Remove(state.elevator[0]);
            if(ValidState(newState))
            {
                previousStates.Add(newState.GetCopy());
                totalPossibleCombinations--;
                statesToCheck.Enqueue(newState.GetCopy());
            }
        }
        else
        {
            State newState = state.GetCopy();
            List<(AssemblyPart, AssemblyPart)> possibleElevatorContents = validElevatorContents(newState.elevator, newState.floors[newState.currentFloor]);
            foreach((AssemblyPart, AssemblyPart) elevatorContents in possibleElevatorContents)
            {
                newState.elevator.Add(elevatorContents.Item1);
                newState.floors[newState.currentFloor].Remove(elevatorContents.Item1);
                
                if(elevatorContents.Item2 != null)
                {
                    newState.elevator.Add(elevatorContents.Item2);
                    newState.floors[newState.currentFloor].Remove(elevatorContents.Item2);
                }
                if(ValidState(newState))
                {
                    previousStates.Add(newState.GetCopy());
                    totalPossibleCombinations--;
                    statesToCheck.Enqueue(newState.GetCopy());
                }
                foreach(AssemblyPart assemblyPart in newState.elevator)
                {
                    newState.floors[newState.currentFloor].Add(assemblyPart);
                }
                newState.elevator.Clear();
            }
        }
    }
}

List<(AssemblyPart, AssemblyPart)> validElevatorContents(List<AssemblyPart> elevatorContents, List<AssemblyPart> floorContents)
{
    List<(AssemblyPart, AssemblyPart)> validElevatorContents = new List<(AssemblyPart, AssemblyPart)>();
    List<AssemblyPart> checkedAsSecondary = new List<AssemblyPart>();
    if(elevatorContents.Count == 0)
    {
        foreach(AssemblyPart assemblyPart1 in floorContents)
        {
            validElevatorContents.Add((assemblyPart1, null));
            foreach(AssemblyPart assemblyPart2 in floorContents)
            {
                if(assemblyPart2 != assemblyPart1 && !validElevatorContents.Contains((assemblyPart2, assemblyPart1)))
                {
                    validElevatorContents.Add((assemblyPart1, assemblyPart2));
                }
            }
        }
    }
    else if(elevatorContents.Count == 1)
    {
        foreach(AssemblyPart assemblyPart1 in floorContents)
        {
            validElevatorContents.Add((elevatorContents[0], assemblyPart1));
        }
    }
    return validElevatorContents;
}
bool ValidState(State state)
{
    foreach(State state1 in previousStates)
    {
        if(state.SameState(state1))
        {
            return false;
        }
    }
    bool validState = true;
    for(int i = 0; i < state.floors.Count; i++)
    {
        List<Microchip> unshieldedMicrochips = new List<Microchip>();
        List<Generator> generators = new List<Generator>();
        if(i == state.currentFloor)
        {
            foreach(AssemblyPart assemblyPart in state.elevator)
            {
                if(assemblyPart.GetType() == typeof(Generator))
                {
                    generators.Add((Generator)assemblyPart);
                }    
                else
                {
                    unshieldedMicrochips.Add((Microchip)assemblyPart);
                }
            }
        }
        if(unshieldedMicrochips.Count == 1 && generators.Count == 1)
        {
            if(unshieldedMicrochips[0].fuel == generators[0].fuel)
            {
                unshieldedMicrochips.RemoveAt(0);
            }
        }
        foreach(AssemblyPart assemblyPart in state.floors[i])
        {
            if(assemblyPart.GetType() == typeof(Microchip))
            {
                if(generators.Count > 0)
                {
                    bool unshielded = true;
                    foreach(Generator generator in generators)
                    {
                        if(generator.fuel == assemblyPart.fuel)
                        {
                            unshielded = false;
                            break;
                        }
                    }
                    if(unshielded)
                    {
                        unshieldedMicrochips.Add((Microchip) assemblyPart);
                    }
                }  
                else
                {
                    unshieldedMicrochips.Add((Microchip) assemblyPart);
                }
            }
            else
            {
                generators.Add((Generator)assemblyPart);
                if(unshieldedMicrochips.Count > 0)
                {
                    Microchip microchipToBeRemoved = null;
                    foreach(Microchip microchip in unshieldedMicrochips)
                    {
                        if(microchip.fuel == assemblyPart.fuel)
                        {
                            microchipToBeRemoved = microchip;
                            break;
                        }
                    }
                    if(microchipToBeRemoved != null)
                    {
                        unshieldedMicrochips.Remove(microchipToBeRemoved);
                    }
                }
            }
        }
        if(generators.Count > 0 && unshieldedMicrochips.Count > 0)
        {
            validState = false;
            break;
        }
    }
    if(!validState)
    {
        totalPossibleCombinations--;
    }
    return validState;
}
class AssemblyPart
{
    public string fuel;
}

class Generator: AssemblyPart
{

}

class Microchip: AssemblyPart
{

}

class State
{
    public List<List<AssemblyPart>> floors;
    public List<AssemblyPart> elevator;
    public int currentFloor;
    public int stepsAttempted = 0;

    public bool SameState(State compState)
    {
        bool equalFloors = true;
        for(int i = 0; i < floors.Count; i++)
        {
            if(floors[i].Count == compState.floors[i].Count)
            {
                for(int j = 0; j < floors[i].Count; j++)
                {
                    if(floors[i][j].fuel != compState.floors[i][j].fuel || floors[i][j].GetType() != compState.floors[i][j].GetType())
                    {
                        equalFloors = false;
                        break;
                    }
                }
                if(!equalFloors)
                {
                    break;
                }
            }
            else
            {
                equalFloors = false;
                break;
            }
        }
        if(equalFloors && currentFloor == compState.currentFloor)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public State GetCopy()
    {
        State state = new State();
        state.currentFloor = currentFloor;
        state.elevator = [.. elevator];
        state.floors = new List<List<AssemblyPart>>();
        state.stepsAttempted = stepsAttempted;
        for(int i = 0; i < floors.Count; i++)
        {
            state.floors.Add([.. floors[i]]);
        }
        return state;
    }
}