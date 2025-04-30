// See https://aka.ms/new-console-template for more information
string[] input = {"Insert boss input here"};
CombatEntity boss = new CombatEntity();
CombatEntity player = new CombatEntity();
List<Item> weapons = new List<Item>()
{
    new Item("Insert weapons here", 0, 0, 0)

};
List<Item>armor = new List<Item>
{
    new Item("Insert armor here", 0, 0, 0)
};
List<Item>rings = new List<Item>
{
    new Item("Insert rings here", 0, 0, 0)
};
player.hitpoints = 100;
player.damage = 0;
player.armor = 0;
boss.hitpoints = Int32.Parse(input[0].Split(' ')[2]);
boss.damage = Int32.Parse(input[1].Split(' ')[1]);
boss.armor = Int32.Parse(input[2].Split(' ')[1]);
Console.WriteLine(DecideWeapon());
Console.WriteLine(DecideLosingWeapon());
int DecideWeapon()
{
    int lowestCost = int.MaxValue;
    foreach(Item weapon in weapons)
    {
        if(weapon.cost < lowestCost)
        {
            int cost = DecideArmor(weapon);
            if(cost < lowestCost)
            {
                lowestCost = cost;
            }
        }
    }
    return lowestCost;
}

int DecideLosingWeapon()
{
    int highestCost = int.MinValue;
    foreach(Item weapon in weapons)
    {
        int cost = DecideLosingArmor(weapon);
        if(cost > highestCost)
        {
            highestCost = cost;
        }
    }
    return highestCost;
}

int DecideArmor(Item weapon)
{
    int lowestCost = DecideRings(weapon, new Item("unarmored", 0, 0, 0));
    foreach(Item armor in armor)
    {
        if(weapon.cost + armor.cost < lowestCost)
        {
            int cost = DecideRings(weapon, armor);
            if(cost < lowestCost)
            {
                lowestCost = cost;
            }
        }
    }

    return lowestCost;
}
int DecideLosingArmor(Item weapon)
{
    int highestCost = DecideLosingRings(weapon, new Item("unarmored", 0, 0, 0));
    foreach(Item armor in armor)
    {
        int cost = DecideLosingRings(weapon, armor);
        if(cost > highestCost)
        {
            highestCost = cost;
        }
    }

    return highestCost;
}
int DecideRings(Item weapon, Item armor)
{
    if(CanDefeatBoss(weapon, armor, new Item("no ring", 0, 0, 0), new Item("no ring", 0, 0, 0)))
    {
        return weapon.cost + armor.cost;
    }
    else
    {
        int lowestCost = int.MaxValue;
        foreach(Item ring1 in rings)
        {
            int totalCost = weapon.cost + armor.cost + ring1.cost;
            if(totalCost < lowestCost)
            {
                if(CanDefeatBoss(weapon, armor, ring1, new Item("no ring", 0, 0, 0)))
                {
                    lowestCost = totalCost;
                }
                else
                {
                    foreach(Item ring2 in rings)
                    {
                        if(ring2 != ring1 && totalCost + ring2.cost < lowestCost)
                        {
                            if(CanDefeatBoss(weapon, armor, ring1, ring2))
                            {
                                lowestCost = totalCost + ring2.cost;
                            }
                        }
                    }
                }
            }
        }
        return lowestCost;
    }
}

int DecideLosingRings(Item weapon, Item armor)
{
    int highestCost = int.MinValue;
    if(!CanDefeatBoss(weapon, armor, new Item("no ring", 0, 0, 0), new Item("no ring", 0, 0, 0)))
    {
        highestCost = weapon.cost + armor.cost;
    }
    foreach(Item ring1 in rings)
    {
        int totalCost = weapon.cost + armor.cost + ring1.cost;
        if(!CanDefeatBoss(weapon, armor, ring1, new Item("no ring", 0, 0, 0)) && totalCost > highestCost)
        {
            highestCost = totalCost;
        }
        foreach(Item ring2 in rings)
        {
            if(ring2 != ring1 && totalCost + ring2.cost > highestCost)
            {
                if(!CanDefeatBoss(weapon, armor, ring1, ring2))
                {
                    highestCost = totalCost + ring2.cost;
                }
            }
        }
    }
    return highestCost;
}

bool CanDefeatBoss(Item weapon, Item armor, Item ring1, Item ring2)
{
    int playerDamage = weapon.damage + ring1.damage + ring2.damage - boss.armor;
    if(playerDamage < 1)
    {
        playerDamage = 1;
    }
    int roundsToDefeatBoss = boss.hitpoints / playerDamage;
    int bossDamage = boss.damage - armor.armor - ring1.armor - ring2.armor;
    if(bossDamage < 1)
    {
        bossDamage = 1;
    }
    int roundsToDefeatPlayer = player.hitpoints / bossDamage;
    if(roundsToDefeatBoss <= roundsToDefeatPlayer)
    {
        return true;
    }
    else
    {
        return false;
    } 
}
class CombatEntity
{
    public int hitpoints;
    public int damage;
    public int armor;
}

class Item
{
    public string name; 
    public int cost;
    public int damage;
    public int armor;

    public Item(string name, int cost, int damage, int armor)
    {
        this.name = name;
        this.cost = cost;
        this.damage = damage;
        this.armor = armor;
    }
}