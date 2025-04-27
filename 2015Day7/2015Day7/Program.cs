// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Reflection.Metadata.Ecma335;

string input = "insert input here";
string[] instructions = input.Split(',');
Dictionary<string, Instruction> instructionList = new Dictionary<string, Instruction>();
foreach(string instruction in instructions)
{
    string[] inOut = instruction.Split(" -> ");
    Instruction inst = new Instruction();
    inst.output = inOut[1];
    string[] inParts = inOut[0].Split(' ');
    if(inParts.Length == 1)
    {
        inst.input.Add(inParts[0]);
        inst.op = "ASSIGN";
    }
    else if(inParts.Length == 2)
    {
        inst.input.Add(inParts[1]);
        inst.op = inParts[0];
    }
    else
    {
        inst.input.Add(inParts[0]);
        inst.op = inParts[1];
        inst.input.Add(inParts[2]);
    }
    instructionList.Add(inst.output, inst);
} 
ushort aValue = CalculateWire("a");
Console.WriteLine(aValue);
Instruction newBInstruction = new Instruction();
foreach(Instruction inst in instructionList.Values)
{
    if(inst.output != "b")
    {
        inst.calculatedOutput = false;
    }
    else{
        inst.value = aValue;
    }
}
Console.WriteLine(CalculateWire("a"));
ushort CalculateWire(string wire)
{
    Instruction instruction = instructionList[wire];
    if(instruction.calculatedOutput)
    {
        return instruction.value;
    }
    else
    {
        switch(instruction.op)
        {
            case "ASSIGN":
                instruction.value = ParseOrReturn(instruction.input[0]);
                instruction.calculatedOutput = true;
                break;
            case "AND":
                instruction.value = (ushort)(ParseOrReturn(instruction.input[0]) & ParseOrReturn(instruction.input[1]));
                instruction.calculatedOutput = true;
                break;
            case "OR":
                instruction.value = (ushort)(ParseOrReturn(instruction.input[0]) | ParseOrReturn(instruction.input[1]));
                instruction.calculatedOutput = true;
                break;
            case "LSHIFT":
                instruction.value = (ushort)(ParseOrReturn(instruction.input[0]) << ParseOrReturn(instruction.input[1]));
                instruction.calculatedOutput = true;
                break;
            case "RSHIFT":
                instruction.value = (ushort)(ParseOrReturn(instruction.input[0]) >> ParseOrReturn(instruction.input[1]));
                instruction.calculatedOutput = true;
                break;
            case "NOT":
                instruction.value = (ushort)~ParseOrReturn(instruction.input[0]);
                instruction.calculatedOutput = true;
                break;
            default:
                throw new Exception("unknown operator: " + instruction.op);
        }
        return instruction.value;
    }
}

ushort ParseOrReturn(string wire)
{
    if(ushort.TryParse(wire, out ushort value))
    {
        return value;
    }
    else
    {
        return CalculateWire(wire);
    }
}
class Instruction
{
    public List<string> input = new List<string>();
    public string op;
    public string output;

    public bool calculatedOutput = false;
    public ushort value;
}
