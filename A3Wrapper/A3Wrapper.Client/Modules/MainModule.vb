Imports A3Wrapper.Client.My.ClientResources
Imports A3Wrapper.SharedResources.My.Resources

Public Module MainModule
    Dim clientService As ClientService

    Public Sub Main()
        clientService = New ClientService(A3Resources.ProductName, A3Resources.KeySeed,
                    New FormKey(), New FormLicense(), New FormViewer())

        clientService.LaunchProgram()
    End Sub
End Module
