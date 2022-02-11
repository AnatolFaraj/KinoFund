Imports System.Runtime.CompilerServices

Public Class FileUploadObject

    Public Property FileKey As String
    Public Property IsValid As Boolean
    Public Property ErrorMessage As String


End Class



Public Module FileUploadObjExtensions

    <Extension()>
    Public Function IsValid(incomingFile As Byte()) As Boolean

        Dim maxFileSize As Integer = 10485760

        If incomingFile.Length > maxFileSize Then
            Return False
        End If

        Return True

    End Function
End Module