// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;

string input = "insert input here";
int index = 0;
MD5 mD5 = MD5.Create();
string hash = Convert.ToHexString(mD5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input + index)));
string password = "";
string secondPassword = "--------";
int positionsFilled = 0;
while(password.Length < 8 || positionsFilled < 8)
{
    index++;
    hash = Convert.ToHexString(mD5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input + index)));
    if(hash.Substring(0, 5) == "00000")
    {
        if(password.Length < 8)
        {
            password += hash[5];
        }
        if(int.TryParse(hash[5].ToString(), out int num) && num < 8 && secondPassword[num] == '-')
        {
            StringBuilder sb = new StringBuilder(secondPassword);
            sb[num] = hash[6];
            secondPassword = sb.ToString();
            positionsFilled++;
        }
    }
}
Console.WriteLine(password);
Console.WriteLine(secondPassword);