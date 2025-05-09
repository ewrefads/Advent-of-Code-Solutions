// See https://aka.ms/new-console-template for more information
string[] input = 
{
    "insert input here"
};
int[] registers = {0, 0, 0, 0};
ExecuteInstructions();
Console.WriteLine(registers[0]);
registers = [0, 0, 1, 0];
ExecuteInstructions();
Console.WriteLine(registers[0]);
int Copy(string[] instruction)
{
    if(int.TryParse(instruction[1], out int num))
    {
        registers[GetRegisterIndex(instruction[2])] = num;
    }
    else
    {
        registers[GetRegisterIndex(instruction[2])] = registers[GetRegisterIndex(instruction[1])];
    }
    return 1;
}
int Increase(string[] instruction)
{
    registers[GetRegisterIndex(instruction[1])] += 1;
    return 1;
}
int Decrease(string[] instruction)
{
    registers[GetRegisterIndex(instruction[1])] -= 1;
    return 1;
}
int Jump(string[] instruction)
{
    int jumpBool = 0;
    int jump = 1;
    if(int.TryParse(instruction[1], out int num))
    {
        jumpBool = num;
    }
    else
    {
        jumpBool = registers[GetRegisterIndex(instruction[1])];
    }
    if(jumpBool != 0)
    {
        jump = int.Parse(instruction[2]);
    }
    return jump;
}

int GetRegisterIndex(string register)
{
    switch(register)
    {
        case "a":
            return 0;
        case "b":
            return 1;
        case "c":
            return 2;
        case "d":
            return 3;
        default:
            throw new Exception("unknown register: " + register);
    }
}

void ExecuteInstructions()
{
    int i = 0;
    while(i < input.Length)
    {
        string[] instruction = input[i].Split(' ');
        switch(instruction[0])
        {
            case "cpy":
                i += Copy(instruction);
                break;
            case "inc":
                i += Increase(instruction);
                break;
            case "dec":
                i += Decrease(instruction);
                break;
            case "jnz":
                i += Jump(instruction);
                break;
        }
    }
}
