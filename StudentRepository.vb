Imports System.IO
Imports System.Xml.Serialization
Imports System.ComponentModel

Public Class StudentRepository
    Private ReadOnly _filePath As String
    Private ReadOnly _serializer As XmlSerializer

    Public Sub New(filePath As String)
        _filePath = filePath
        _serializer = New XmlSerializer(GetType(BindingList(Of Student)))
    End Sub

    Public Function LoadAll() As BindingList(Of Student)
        If Not File.Exists(_filePath) Then
            Return New BindingList(Of Student)()
        End If
        Using fs = File.OpenRead(_filePath)
            Return CType(_serializer.Deserialize(fs), BindingList(Of Student))
        End Using
    End Function

    Public Sub SaveAll(students As BindingList(Of Student))
        Dim dir = Path.GetDirectoryName(_filePath)
        If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)
        Using fs = File.Create(_filePath)
            _serializer.Serialize(fs, students)
        End Using
    End Sub
End Class