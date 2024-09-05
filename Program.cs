using System.Diagnostics;
Console.WriteLine("Enter a message:");
string message = Console.ReadLine();

if (!IsLowercaseString(message))
{
    Console.WriteLine("Sorry, we only support lower-case letters.");
    return;
}
Console.WriteLine("Enter an encryption key:");
string key = Console.ReadLine();
if (!IsLowercaseString(key))
{
    Console.WriteLine("We only support lowercase  letters.");
    return;
}
string encryptedMessage = EncryptMessage(message, key);
Console.WriteLine("Encrypted Message is:");
Console.WriteLine(encryptedMessage);



static string EncryptMessage(string message, string key)
{
    string result = "";
    int keyLength = key.Length;
    for (int i = 0; i < message.Length; i++ )
    {
        int messageCharPos = message[i] - 'a';
        int keyCharPos = key[i % keyLength] - 'a';
        int encryptedCharPos = (messageCharPos + keyCharPos) % 26;
        result += (char)('a' + encryptedCharPos);
    }
    return result;
}
 static bool IsLowercaseString(string input)
 {
    foreach (char c in input)
    {
        if (!IsLowercaseLetter(c))
        {
            return false;
        }
    }
    return true;
 }
 static bool IsLowercaseLetter(char c)
 {
    return c >= 'a' && c <= 'z';
 }

 
 static void TestIsLowercaseLetter() 
 {
    Debug.Assert(IsLowercaseLetter('a'));
    Debug.Assert(IsLowercaseLetter('b'));
    Debug.Assert(IsLowercaseLetter('z'));
    Debug.Assert(!IsLowercaseLetter('A'));
    Debug.Assert(!IsLowercaseLetter('`'));
    Debug.Assert(!IsLowercaseLetter('{'));
}