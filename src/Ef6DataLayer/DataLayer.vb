Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity

Public Class EventRecorderContext
    Inherits DbContext

    Sub New()
        MyBase.New("Server=(localdb)\mssqllocaldb;Database=EventRecorder;Trusted_Connection=True;")
    End Sub

    Public Property EventSources As DbSet(Of EventSource)
    Public Property ActionTargets As DbSet(Of ActionTarget)
    Public Property Events As DbSet(Of [Event])
End Class

Public Class ActionTarget

    <Key>
    Public Property IdActionTarget As Guid

    <Column(TypeName:="nvarchar"), StringLength(200)>
    Public Property Name As String

    Public Property DateCreated As DateTimeOffset
    Public Property DateLastEdited As DateTimeOffset

End Class

Public Class EventSource

    <Key>
    Public Property IdEventSource As Guid

    <Column(TypeName:="nvarchar"), StringLength(200)>
    Public Property Name As String
    Public Property Description As String

    Public Property DateCreated As DateTimeOffset
    Public Property DateLastEdited As DateTimeOffset

End Class

Public Class [Event]

    <Key>
    Public Property IdEvent As Guid
    Public Property ActionTarget As ActionTarget
    Public Property EventSource As EventSource
    Public Property StartTime As TimeSpan?
    Public Property EndTime As TimeSpan?
    Public Property BookingDate As DateTimeOffset?
    Public Property Duration As Long?

    <Column(TypeName:="nvarchar"), StringLength(200)>
    Public Property Description As String

    Public Property DateCreated As DateTimeOffset
    Public Property DateLastEdited As DateTimeOffset

    Public Sub SetTimeSpan(startTime As TimeSpan, endTime As TimeSpan)
        Me.StartTime = startTime
        Me.EndTime = endTime
        CalculateDuration()
    End Sub

    Public Sub SetTimeSpan(startTime As TimeSpan, durationTicks As Long)
        SetTimeSpan(startTime, New TimeSpan(durationTicks))
    End Sub

    Private Sub CalculateDuration()
        If Not StartTime.HasValue OrElse Not EndTime.HasValue Then
            Duration = (EndTime - StartTime).Value.Ticks
        Else
            Duration = Nothing
        End If
    End Sub
End Class