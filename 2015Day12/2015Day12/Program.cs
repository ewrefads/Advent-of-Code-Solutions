// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Unicode;

string[] file = File.ReadAllLines("input.json");

Console.WriteLine(CalculateSum(true));
Console.WriteLine(CalculateSum(false));
int CalculateSum(bool ignoreRedObjects)
{
    List<JSONObject> objects = new List<JSONObject>();
    int sum = 0;
    string number = "";
    JSONObject? currentObject = null;
    for(int i = 0; i < file[0].Length; i++)
    {
        if(file[0][i] == '{')
        {
            JSONObject tempObject = new JSONObject();
            objects.Add(tempObject);
            if(currentObject == null)
            {
                currentObject = tempObject;
            }
            else
            {
                currentObject.childObjects.Add(tempObject);
                tempObject.parent = currentObject;
                currentObject = tempObject;
            }
        }
        if(file[0][i] == 'r' && currentObject != null)
        {
            if(file[0].Substring(i, 3) == "red")
            {
                currentObject.isRed = true;
            }
        }
        if(Int32.TryParse(file[0][i].ToString(), out int num))
        {
            if(number.Length == 0 && i > 0 && file[0][i - 1] == '-')
            {
                number += '-';
            }
            number += file[0][i];
        }
        else if(number.Length > 0)
        {
            if(currentObject != null)
            {
                currentObject.numbers.Add(number);
            }
            else
            {
                sum += Int32.Parse(number);
            }
            number = "";
        }
        if(i == file[0].Length - 1 && number.Length > 0)
        {
            sum += Int32.Parse(number);
        }
        if(file[0][i] == '}')
        {
            if(currentObject.parent != null)
            {
                currentObject = currentObject.parent;
            }
            else
            {
                sum += currentObject.CalculateSum(true);
                currentObject = null;
            }
        }
    }
    return sum;
}

class JSONObject
{
    public JSONObject? parent;
    public List<string> numbers = new List<string>();
    public List<JSONObject> childObjects = new List<JSONObject>();
    public bool isRed = false;

    public int CalculateSum(bool ignoreRedObjects)
    {
        int sum = 0;
        if(ignoreRedObjects || !isRed)
        {
            foreach(string number in numbers)
            {
                sum += Int32.Parse(number);
            }
            foreach(JSONObject jSONObject in childObjects)
            {
                sum += jSONObject.CalculateSum(ignoreRedObjects);
            }
        }
        return sum;
    }
}