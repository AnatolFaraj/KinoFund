Imports System.IO
Imports System


Public Class FileManager

    Shared Async Function SaveFileAsync(incomingFile As Byte(), fileName As String) As Task(Of String)

        Dim newFileName As String

        Try

            newFileName = Guid.NewGuid().ToString() + fileName

            Dim savePath As String = Path.Combine(Directory.GetCurrentDirectory(), "images", newFileName)

            Using str As New FileStream(savePath, FileMode.Create)

                Await str.WriteAsync(incomingFile, 0, incomingFile.Length)

            End Using

        Catch ex As Exception

            Return ex.InnerException.Message



        End Try

        Return newFileName

    End Function

    Shared Async Function GetFileAsync(fileName As String) As Task(Of Byte())


        Dim filePath As String = Path.Combine(Directory.GetCurrentDirectory(), "images", fileName)

        Dim fileInBytes As Byte() = Await File.ReadAllBytesAsync(filePath)



        Return fileInBytes


    End Function




End Class
