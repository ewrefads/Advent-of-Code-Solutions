// See https://aka.ms/new-console-template for more information",
string[] input =
{
    "insert input here"
};
Dictionary<int, List<int>> bots = new Dictionary<int, List<int>>();
Dictionary<int, List<int>> outputs = new Dictionary<int, List<int>>();
List<string> valueInputs = new List<string>();
Queue<Instruction> instructions = new Queue<Instruction>();
int chipCounter = 0;
for(int i = 0; i < input.Length; i++)
{
    string[] words = input[i].Split(' ');
    if(words[0] == "bot")
    {
        Instruction comparison = new Instruction();
        comparison.botNumber = int.Parse(words[1]);
        CreateBot(comparison.botNumber);
        comparison.highInputDirection = int.Parse(words[11]);
        comparison.operation = "compare";
        if(words[10] == "bot")
        {
            CreateBot(comparison.highInputDirection);
        }
        else
        {
            CreateOutput(comparison.highInputDirection);
            comparison.highBot = false;
        }
        comparison.lowInputDirection = int.Parse(words[6]);
        if(words[5] == "bot")
        {
            CreateBot(comparison.lowInputDirection);
        }
        else
        {
            CreateOutput(comparison.lowInputDirection);
            comparison.lowBot = false;
        }
        instructions.Enqueue(comparison);
    }
    else if(words[0] == "value")
    {
        chipCounter++;
        Instruction assignChip = new Instruction();
        assignChip.botNumber = int.Parse(words[5]);
        CreateBot(int.Parse(words[5]));
        assignChip.chip = int.Parse(words[1]);
        assignChip.operation = "assign";
        instructions.Enqueue(assignChip);
    }
    else
    {
        throw new Exception("unknown instruction: " + input[i]);
    }
    
}
int sizeAtLastRepeat = instructions.Count;
Instruction firstSkippedInstruction = new Instruction();
firstSkippedInstruction.botNumber = int.MinValue;
while(instructions.Count > 0)
{
    Instruction instruction = instructions.Dequeue();
    if(instruction.operation == "assign")
    {
        bots[instruction.botNumber].Add(instruction.chip);
    }
    else if(instruction.operation == "compare")
    {
        if(bots[instruction.botNumber].Count < 2)
        {
            instructions.Enqueue(instruction);
        }
        else
        {
            if(bots[instruction.botNumber].Contains(61) && bots[instruction.botNumber].Contains(17))
            {
                Console.WriteLine(instruction.botNumber);
            }
            if(instruction.highBot)
            {
                bots[instruction.highInputDirection].Add(bots[instruction.botNumber].Max());
            }
            else
            {
                outputs[instruction.highInputDirection].Add(bots[instruction.botNumber].Max());
            }
            if(instruction.lowBot)
            {
                bots[instruction.lowInputDirection].Add(bots[instruction.botNumber].Min());
            }
            else
            {
                outputs[instruction.lowInputDirection].Add(bots[instruction.botNumber].Min());
            }
        }
    }
}
Console.WriteLine(outputs[0][0] * outputs[1][0] * outputs[2][0]);

void CreateBot(int botNumber)
{
    if(!bots.Keys.Contains(botNumber))
    {
        bots.Add(botNumber, new List<int>());
    }
}
void CreateOutput(int outputNumber)
{
    if(!outputs.Keys.Contains(outputNumber))
    {
        outputs.Add(outputNumber, new List<int>());
    }
}
class Instruction
{
    public string operation;
    public int botNumber;
    public int chip;
    public bool calculatedOutput = false;
    public int lowInputDirection = int.MinValue;
    public bool lowBot = true;
    public int highInputDirection = int.MinValue;
    public bool highBot = true;
}