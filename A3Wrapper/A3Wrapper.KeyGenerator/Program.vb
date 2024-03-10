Imports System
Imports A3Wrapper.Services
Imports A3Wrapper.SharedResources.My
Imports A3Wrapper.SharedResources.My.Resources

Module Program
    Sub Main(args As String())
        Dim keyService As New KeyService(A3Resources.KeySeed)

        'could programatically iterate through all letter combinations from AAAAA - ZZZZZ
        'must be same length as keyseedcount
        Console.WriteLine(keyService.GenerateKey("ABCDE"))
        Console.WriteLine(keyService.GenerateKey("EFGHI"))
        Console.WriteLine(keyService.GenerateKey("IJKLM"))
        Console.WriteLine(keyService.GenerateKey("MNOPQ"))

        Console.WriteLine("Press any key to quit.")
        Console.ReadKey()
    End Sub
End Module
