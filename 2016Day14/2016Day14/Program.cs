// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;

string input = "insert input here";
Dictionary<int, string> keys = new Dictionary<int, string>();
List<int> checkedKeys = new List<int>();
Dictionary<int, string> hashes = new Dictionary<int, string>();
int i = 0;
MD5 md5 = MD5.Create();
while(keys.Count < 64)
{
    string hexNumber = "";
    if(!hashes.Keys.Contains(i))
    {
        string hashInput = input + i.ToString();
        hexNumber = Convert.ToHexString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(hashInput)));
        hashes.Add(i, hexNumber);
    }
    else 
    {
        hexNumber = hashes[i];
    }
    for(int j = 0; j < hexNumber.Length - 2; j++)
    {
        if(!checkedKeys.Contains(i) && hexNumber[j + 1] == hexNumber[j] && hexNumber[j + 2] == hexNumber[j])
        {
            for(int x = i + 1; x <= i + 1000; x++)
            {
                string hex = "";
                if(!hashes.Keys.Contains(x))
                {
                    string hashInput = input + x.ToString();
                    hex = Convert.ToHexString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(hashInput)));
                    hashes.Add(x, hex);
                }
                else 
                {
                    hex = hashes[x];
                }
                bool foundFive = false;
                for(int y = 0; y < hex.Length - 4; y++)
                {
                    if(hex[y] == hexNumber[j] && hex[y] == hex[y + 1] && hex[y] == hex[y + 2] && hex[y] == hex[y + 3]  && hex[y] == hex[y + 4])
                    {
                        foundFive = true;
                        keys.Add(i, hexNumber);
                        Console.WriteLine(64 - keys.Count);
                        break;
                    }
                }
                if(foundFive)
                {
                    break;
                }
            }
            checkedKeys.Add(i);
        }
        else if(checkedKeys.Contains(i))
        {
            break;
        }
    }
    i++;
}

string stretchedHash(string input, int stretches)
{
    if(stretches > 0)
    {
        string hex = Convert.ToHexString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(stretchedHash(input, stretches - 1)))).ToLower();
        return hex;
    }
    else
    {
        return input;
    }
}
Console.WriteLine(keys.Last());
keys = new Dictionary<int, string>();
checkedKeys = new List<int>();
hashes = new Dictionary<int, string>();
i = 0;
md5 = MD5.Create();
while(keys.Count < 64)
{
    string hexNumber = "";
    if(!hashes.Keys.Contains(i))
    {
        string hashInput = input + i.ToString();
        hexNumber = stretchedHash(hashInput, 2017);
        hashes.Add(i, hexNumber);
    }
    else 
    {
        hexNumber = hashes[i];
    }
    for(int j = 0; j < hexNumber.Length - 2; j++)
    {
        if(!checkedKeys.Contains(i) && hexNumber[j + 1] == hexNumber[j] && hexNumber[j + 2] == hexNumber[j])
        {
            for(int x = i + 1; x <= i + 1000; x++)
            {
                string hex = "";
                if(!hashes.Keys.Contains(x))
                {
                    string hashInput = input + x.ToString();
                    hex = stretchedHash(hashInput, 2017);
                    hashes.Add(x, hex);
                }
                else 
                {
                    hex = hashes[x];
                }
                bool foundFive = false;
                for(int y = 0; y < hex.Length - 4; y++)
                {
                    if(hex[y] == hexNumber[j] && hex[y] == hex[y + 1] && hex[y] == hex[y + 2] && hex[y] == hex[y + 3]  && hex[y] == hex[y + 4])
                    {
                        Console.WriteLine(i);
                        foundFive = true;
                        keys.Add(i, hexNumber);
                        break;
                    }
                }
                if(foundFive)
                {
                    break;
                }
            }
            checkedKeys.Add(i);
        }
        else if(checkedKeys.Contains(i))
        {
            break;
        }
    }
    i++;
}