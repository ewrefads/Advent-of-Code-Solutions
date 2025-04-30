// See https://aka.ms/new-console-template for more information
string molecule = "Insert molecule here";
string[] input = {"insert input here"};
List<Replacement> replacements = new List<Replacement>();
List<string> possibleMolecules = new List<string>();
foreach(string replacement in input)
{
    string[] words = replacement.Split(" => ");
    Replacement newReplacement = new Replacement();
    newReplacement.input = words[0];
    newReplacement.output = words[1];
    replacements.Add(newReplacement);
}
foreach(Replacement replacement in replacements)
{
    for(int i = 0; i < molecule.Length; i++)
    {
        if(i + replacement.input.Length < molecule.Length && molecule.Substring(i, replacement.input.Length) == replacement.input)
        {
            string newMolecule = molecule.Substring(0, i) + replacement.output + molecule.Substring(i + replacement.input.Length, molecule.Length - i - replacement.input.Length);
            if(!possibleMolecules.Contains(newMolecule))
            {
                possibleMolecules.Add(newMolecule);
            }
        }
    }
}
Console.WriteLine(possibleMolecules.Count);
Dictionary<string, int> possiblePath = new Dictionary<string, int>();
int shortestPath = int.MaxValue;
List<string> noPaths = new List<string>();
int maxAttempts = 4000;
long remainingAttempts = 100000;
//Console.WriteLine(CalculateSteps(molecule));
int CalculateSteps(string input)
{
    int steps = 0;
    Dictionary<string, int> previousMolecules = new Dictionary<string, int>();
    Random rnd = new Random();
    int passes = 0;
    while(input != "e")
    {
        string tempMolecule = input;
        List<Replacement> attemptedReplacements = new List<Replacement>();
        List<Replacement> usedReplacements = new List<Replacement>();
        int index = 0;
        while(index < input.Length)
        {
            if(attemptedReplacements.Count == replacements.Count)
            {
                index++;
                attemptedReplacements.Clear();
            }
            Replacement replacement = replacements[rnd.Next(0, replacements.Count)];
            while(attemptedReplacements.Contains(replacement))
            {
                replacement = replacements[rnd.Next(0, replacements.Count)];
            }
            attemptedReplacements.Add(replacement);
            if(tempMolecule.Length - index - replacement.output.Length > 0 && tempMolecule.Substring(index, replacement.output.Length) == replacement.output)
            {
                tempMolecule = tempMolecule.Substring(0, index) + replacement.input + tempMolecule.Substring(index + replacement.output.Length, tempMolecule.Length - index - replacement.output.Length);
                index += replacement.output.Length;
                usedReplacements.Add(replacement);
            }
        }
        if(tempMolecule != input)
        {
            previousMolecules.Add(tempMolecule, steps + usedReplacements.Count);
        }
        else if(previousMolecules.Count > 0)
        {
        }
        steps += usedReplacements.Count;
        usedReplacements.Clear();
        Console.WriteLine(tempMolecule);
        input = tempMolecule;
        
    }
    return steps;
}
class Replacement
{
    public string input = "";
    public string output = "";
}
