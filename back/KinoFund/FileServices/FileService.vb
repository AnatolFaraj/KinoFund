Imports System.IO
Imports System
Imports System.Linq


Public Class FileService


    Public Async Function UploadAsync(incomingFile As Byte(), fileName As String) As Task(Of FileUploadObject)

        Dim newFileName As String = String.Empty

        Dim key As String = String.Empty
        Try
            If IsValid(incomingFile) = False Then

                Return New FileUploadObject With
                {
                    .IsValid = False,
                    .ErrorMessage = "File is too big. Size limit - 10MB"
                }

            End If

            key = Guid.NewGuid().ToString()
            Dim extension As String = Path.GetExtension(fileName)
            newFileName = key + extension

            Dim solutionDirectory As String = Directory.GetParent(Environment.CurrentDirectory).FullName
            Dim savePath As String = Path.Combine(solutionDirectory, "FileServices\images", newFileName)

            Using str As New FileStream(savePath, FileMode.Create)

                Await str.WriteAsync(incomingFile, 0, incomingFile.Length)

            End Using


        Catch ex As Exception

            Throw New Exception(ex.InnerException.Message)


        End Try

        Return New FileUploadObject With
        {
           .FileKey = key,
           .IsValid = True
        }




    End Function

    Public Async Function DownloadAsync(fileKey As String) As Task(Of FileDownloadObject)

        Dim fileInBytes As Byte()
        Dim fileName As String

        Try

            Dim solutionDirectory As String = Directory.GetParent(Environment.CurrentDirectory).FullName
            Dim filesFolderPath As String = Path.Combine(solutionDirectory, "FileServices\images")
            Dim returnFilePath As String = Directory.GetFiles(filesFolderPath).Where(Function(f) Path.GetFileName(f).StartsWith(fileKey)).First()

            fileName = Path.GetFileName(returnFilePath)

            If File.Exists(returnFilePath) = False Then


                Return New FileDownloadObject With
                {
                    .IsValid = False,
                    .ErrorMessage = "File not found."
                }


            End If

            fileInBytes = Await File.ReadAllBytesAsync(returnFilePath)


        Catch ex As Exception

            Throw New Exception(ex.InnerException.Message)

        End Try

        Return New FileDownloadObject With
        {
            .FileArray = fileInBytes,
            .FileName = fileName,
            .IsValid = True
        }


    End Function


End Class
