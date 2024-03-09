Public Class KeyService
    Private Const ASCII_CHAR_OFFSET As Integer = 65
    Private Const KEYLENGTH As Integer = 20 'total length of key 
    Private Const KEYSEEDINTERVAL As Integer = 5 'when to put a seed into the key
    Private Const KEYSEEDCOUNT As Integer = 4 'how many seeds to insert

    Dim letterValues As IDictionary(Of String, Integer)
    Dim seed As Integer

    Public Sub New(initSeed As Integer)
        'set our seed value
        seed = initSeed

        'set iterator variable
        Dim i As Integer

        'set up letters
        '65 is the start of the capital letters in the ASCII character set
        Dim letters = New List(Of String)
        For i = 0 To 25
            letters.Add(Convert.ToChar(i + ASCII_CHAR_OFFSET).ToString())
        Next

        'create letter values, based off the power of 2
        'we use this for generating seed values to base RNG off of
        Dim values As IList(Of Integer) = New List(Of Integer)
        For i = 0 To 25
            values.Add(Math.Pow(2, i))
        Next

        'randomize values
        letters = Shuffle(Of String)(letters)
        values = Shuffle(Of Integer)(values)

        'set a random letter 
        letterValues = New Dictionary(Of String, Integer)
        For i = 0 To 25
            letterValues.Add(letters(i), values(i))
        Next

    End Sub

    Public Function GenerateKey(ByVal passedString As String) As String
        'Parameter checks
        If (String.IsNullOrEmpty(passedString)) Then Throw New ArgumentException(NameOf(passedString))
        If Not (passedString.Length = 4) Then Throw New ArgumentException(NameOf(passedString))
        If Not (passedString.All(Function(x) Char.IsLetter(x) And Char.IsUpper(x))) Then Throw New ArgumentException(NameOf(passedString))

        'Declare variables
        Dim i As Single
        Dim newKey As String = String.Empty

        'Create random seed based off of input value (for consistency)
        Dim r As New Random(GetHashValue(passedString))

        'Generate a key based off the seed value
        For i = 0 To KEYLENGTH - KEYSEEDCOUNT - 1
            newKey = newKey & Convert.ToChar(r.Next(0 + ASCII_CHAR_OFFSET, 25 + ASCII_CHAR_OFFSET)).ToString()
        Next

        'insert characters into string at specific locations
        For i = 0 To KEYSEEDCOUNT - 1
            newKey = newKey.Insert(i * KEYSEEDINTERVAL, passedString.Chars(i))
        Next

        'return new key
        Return newKey
    End Function
    Public Function VerifyKey(ByVal passedString As String) As Boolean
        'parameter checks
        If (String.IsNullOrEmpty(passedString)) Then Throw New ArgumentException(NameOf(passedString))
        If Not (passedString.Length = KEYLENGTH) Then Throw New ArgumentException(NameOf(passedString))
        If Not (passedString.All(Function(x) Char.IsLetter(x) And Char.IsUpper(x))) Then Throw New ArgumentException(NameOf(passedString))

        Dim mySeed As String = ""
        Dim i As Integer

        'grab the four original seeds
        For i = KEYSEEDCOUNT - 1 To 0 Step -1
            mySeed = (passedString.Chars(i * KEYSEEDINTERVAL) & mySeed)
        Next i

        'test
        Return GenerateKey(mySeed).Equals(passedString, StringComparison.InvariantCultureIgnoreCase)
    End Function

    Public Function GetHashValue(ByVal passedString As String) As Integer
        Dim myReturn As Integer

        'loop through each letter in the passed string
        'and add the associated value in the letterValue lookup
        For i = 0 To passedString.Length - 1
            Dim tempChar As String = passedString.Chars(i)
            myReturn = myReturn + letterValues(tempChar)
        Next

        Return myReturn
    End Function


    Private Function Shuffle(Of T)(list As IList(Of T)) As IList(Of T)
        'Fisher-Yates Shuffle Algorithm from https://stackoverflow.com/a/1262619
        Dim random As New Random(seed)
        Dim i As Integer = list.Count, j As Integer = 0
        Dim value As T

        While i > 1
            i = i - 1
            j = random.Next(i + 1)
            value = list(j)
            list(j) = list(i)
            list(i) = value
        End While

        Return list
    End Function

End Class
