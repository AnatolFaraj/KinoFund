Imports System.IO
Imports System


Public Class FileManager

    Public Async Function SaveFileAsync(incomingFile As Byte(), fileName As String) As Task(Of String)

        Dim newFileName As String

        Try

            newFileName = Guid.NewGuid().ToString() + fileName
            Dim solutionDirectory As String = Directory.GetParent(Environment.CurrentDirectory).FullName
            Dim savePath As String = Path.Combine(solutionDirectory, "FileServices\images", newFileName)

            Using str As New FileStream(savePath, FileMode.Create)

                Await str.WriteAsync(incomingFile, 0, incomingFile.Length)

            End Using

        Catch ex As Exception

            Throw New Exception(ex.InnerException.Message)

        End Try

        Return newFileName

    End Function

    Public Async Function GetFileAsync(fileName As String) As Task(Of Byte())

        Dim fileInBytes As Byte()

        Try

            Dim solutionDirectory As String = Directory.GetParent(Environment.CurrentDirectory).FullName

            Dim filePath As String = Path.Combine(solutionDirectory, "FileServices\images", fileName)

            fileInBytes = Await File.ReadAllBytesAsync(filePath)

        Catch ex As Exception

            Throw New Exception(ex.InnerException.Message)

        End Try

        Return fileInBytes


    End Function




End Class
