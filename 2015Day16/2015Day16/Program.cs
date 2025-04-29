// See https://aka.ms/new-console-template for more information", "
string[] input = {"insert input here"};
Aunt sampleResult = new Aunt();
sampleResult.children = 3;
sampleResult.cats = 7;
sampleResult.samoyeds = 2;
sampleResult.pomeranians = 3;
sampleResult.akitas = 0;
sampleResult.vizslas = 0;
sampleResult.goldfish = 5;
sampleResult.trees = 3;
sampleResult.cars = 2;
sampleResult.perfumes = 1;
int mostMatches = 0;
foreach(string aunt in input)
{
    string[] words = aunt.Split(' ');
    Aunt tempAunt = new Aunt();
    int matches = 0;
    bool incorrectInformation = false;
    for(int i = 0; i < words.Length; i++)
    {
        string word = words[i].Split(':')[0];
        switch(word)
        {
            case "Sue":
                tempAunt.auntNumber = int.Parse(words[i + 1].Split(':')[0]);
                break;
            case "children":
                tempAunt.children = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.children == sampleResult.children)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "cats":
                tempAunt.cats = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.cats == sampleResult.cats)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "samoyeds":
                tempAunt.samoyeds = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.samoyeds == sampleResult.samoyeds)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "pomeranians":
                tempAunt.pomeranians = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.pomeranians == sampleResult.pomeranians)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "akitas":
                tempAunt.akitas = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.akitas == sampleResult.akitas)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "vizslas":
                tempAunt.vizslas = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.vizslas == sampleResult.vizslas)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "goldfish":
                tempAunt.goldfish = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.goldfish == sampleResult.goldfish)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "trees":
                tempAunt.trees = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.trees == sampleResult.trees)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "cars":
                tempAunt.cars = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.cars == sampleResult.cars)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "perfumes":
                tempAunt.perfumes = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.perfumes == sampleResult.perfumes)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
        }
    }
    if(!incorrectInformation && matches > mostMatches)
    {
        sampleResult.auntNumber = tempAunt.auntNumber;
        mostMatches = matches;
    } 
}
Console.WriteLine(sampleResult.auntNumber);
sampleResult.auntNumber = int.MinValue; 
mostMatches = 0;
foreach(string aunt in input)
{
    string[] words = aunt.Split(' ');
    Aunt tempAunt = new Aunt();
    int matches = 0;
    bool incorrectInformation = false;
    for(int i = 0; i < words.Length; i++)
    {
        string word = words[i].Split(':')[0];
        switch(word)
        {
            case "Sue":
                tempAunt.auntNumber = int.Parse(words[i + 1].Split(':')[0]);
                break;
            case "children":
                tempAunt.children = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.children == sampleResult.children)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "cats":
                tempAunt.cats = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.cats > sampleResult.cats)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "samoyeds":
                tempAunt.samoyeds = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.samoyeds == sampleResult.samoyeds)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "pomeranians":
                tempAunt.pomeranians = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.pomeranians == sampleResult.pomeranians)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "akitas":
                tempAunt.akitas = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.akitas == sampleResult.akitas)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "vizslas":
                tempAunt.vizslas = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.vizslas == sampleResult.vizslas)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "goldfish":
                tempAunt.goldfish = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.goldfish < sampleResult.goldfish)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "trees":
                tempAunt.trees = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.trees == sampleResult.trees)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "cars":
                tempAunt.cars = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.cars == sampleResult.cars)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
            case "perfumes":
                tempAunt.perfumes = int.Parse(words[i + 1].Split(',')[0]);
                if(tempAunt.perfumes == sampleResult.perfumes)
                {
                    matches++;
                }
                else
                {
                    incorrectInformation = true;
                }
                break;
        }
    }
    if(!incorrectInformation && matches > mostMatches)
    {
        sampleResult.auntNumber = tempAunt.auntNumber;
        mostMatches = matches;
    } 
}
Console.WriteLine(sampleResult.auntNumber);
class Aunt
{
    public int auntNumber = int.MinValue;
    public int children = int.MinValue;
    public int cats = int.MinValue;
    public int samoyeds = int.MinValue;
    public int pomeranians = int.MinValue;
    public int akitas = int.MinValue;
    public int vizslas = int.MinValue;
    public int goldfish = int.MinValue;
    public int trees = int.MinValue;
    public int cars = int.MinValue;
    public int perfumes = int.MinValue;
}