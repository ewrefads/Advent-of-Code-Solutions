// See https://aka.ms/new-console-template for more information
string[] input = {"Insert input here"};

Dictionary<string, Person> persons = new Dictionary<string, Person>();
foreach(string instruction in input)
{
    string[] words = instruction.Split(' ');
    Person person1 = GetOrCreatePerson(words[0]);
    Person person2 = GetOrCreatePerson(words[words.Length - 1]);
    string opinion = "";
    if(words[2] == "lose")
    {
        opinion += '-';
    }
    opinion += words[3];
    person1.opinions.Add(person2, Int32.Parse(opinion));
}
Console.WriteLine(CalculateMaximumHappiness(persons["Alice"], persons.Values.ToList(), persons["Alice"]));
Person ewrefads = new Person();
ewrefads.name = "ewrefads";
foreach(Person person3 in persons.Values)
{
    ewrefads.opinions.Add(person3, 0);
    person3.opinions.Add(ewrefads, 0);
}
persons.Add("ewrefads", ewrefads);
Console.WriteLine(CalculateMaximumHappiness(persons["Alice"], persons.Values.ToList(), persons["Alice"]));
Person GetOrCreatePerson(string person)
{
    if(!persons.ContainsKey(person))
    {
        Person newPerson = new Person();
        newPerson.name = person;
        persons.Add(person, newPerson);
    }
    return persons[person];
}
int CalculateMaximumHappiness(Person person, List<Person> remainingPeople, Person originalPerson)
{
    if(remainingPeople.Count > 1)
    {
        remainingPeople.Remove(person);
        int maximumHappiness = int.MinValue;
        foreach(Person pers in remainingPeople)
        {
            Person[] peopleArray = remainingPeople.ToArray();
            int totalHappiness = CalculateMaximumHappiness(pers, peopleArray.ToList(), originalPerson);
            totalHappiness += person.opinions[pers];
            totalHappiness += pers.opinions[person];
            if(totalHappiness > maximumHappiness)
            {
                maximumHappiness = totalHappiness;
            }
        }
        
        return maximumHappiness;
    }
    else
    {
        return person.opinions[originalPerson] + originalPerson.opinions[person];
    }
}
class Person 
{
    public string name;
    public Dictionary<Person, int> opinions = new Dictionary<Person, int>();

    public (int, Person) CalculateMaxHappiness(List<Person> checkedPeople)
    {
        checkedPeople.Add(this);
        if(checkedPeople.Count > opinions.Count)
        {
            return (opinions[checkedPeople[0]] + opinions[checkedPeople[checkedPeople.Count - 2]], this);
        }
        else
        {
            Person lastPerson = new Person();
            int maxHappiness = int.MinValue;
            foreach(Person person in opinions.Keys)
            {
                if(!checkedPeople.Contains(person))
                {
                    int happiness = opinions[person];
                    if(checkedPeople.Count > 1)
                    {
                        happiness += opinions[checkedPeople[checkedPeople.Count - 2]];
                    }
                    (int, Person) calculatedHappiness = person.CalculateMaxHappiness(checkedPeople);
                    happiness += calculatedHappiness.Item1;
                    if(checkedPeople.Count == 1)
                    {
                        happiness += opinions[calculatedHappiness.Item2];
                    }
                    if(happiness > maxHappiness)
                    {
                        maxHappiness = happiness;
                        lastPerson = calculatedHappiness.Item2;
                    }
                }
            }
            return (maxHappiness, lastPerson);
        }
    }
}

