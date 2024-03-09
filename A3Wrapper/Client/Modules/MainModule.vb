Imports A3Wrapper.Client.My.ClientResources

Public Module MainModule

    Dim clientService As ClientService

    Public Sub Main()
        clientService = New ClientService(ClientResources.ProductName, ClientResources.KeySeed,
                    New FormKey(), New FormLicense(), New FormViewer())
        clientService.LaunchProgram()

    End Sub

End Module
