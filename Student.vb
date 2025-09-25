Imports System
Imports System.Xml.Serialization

<Serializable()>
Public Class Student
    Public Property StudentId As String
    Public Property FullName As String
    Public Property Gender As String
    Public Property [Class] As String
    Public Property BirthDate As Date

    <XmlIgnore>
    Public ReadOnly Property Age As Integer
        Get
            Dim today = Date.Today
            Dim yrs = today.Year - BirthDate.Year
            If BirthDate > today.AddYears(-yrs) Then yrs -= 1
            Return yrs
        End Get
    End Property
End Class