// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;
int FindMD5HashAdditionWithLeadingZeroes(string input, int numLeadingZeroes)
{
    MD5 md5 = MD5.Create();
    int num = 0;
    while(true)
    {
        string attempt = input + num;
        byte[] byteInput = Encoding.ASCII.GetBytes(attempt);
        byte[] hash = md5.ComputeHash(byteInput);
        string hexHash = Convert.ToHexString(hash);
        int numZeroes = 0;
        while(hexHash[numZeroes].ToString()[0] == '0' && numZeroes < numLeadingZeroes)
        {
            numZeroes++;
        }
        if(numZeroes == numLeadingZeroes)
        {
            break;
        }
        else
        {
            num++;
        }
    }
    return num;
}
string input = "insert input here";

Console.WriteLine(FindMD5HashAdditionWithLeadingZeroes(input, 5));
Console.WriteLine(FindMD5HashAdditionWithLeadingZeroes(input, 6));