Imports System.Data.Entity

Public Module EventSourceDal

    Public Function GetEventSourceCount(erContext As EventRecorderContext) As Integer
        Return Aggregate item In erContext.EventSources
               Into Count
    End Function

    Public Async Function GetEventSourceCountAsync(erContext As EventRecorderContext) As Task(Of Integer)
        'Find out, if there are action targets
        Return Await erContext.EventSources.CountAsync()
    End Function

    Public Function HasTableData(ercontext As EventRecorderContext) As Boolean
        Return (From item In ercontext.EventSources
                Take 1).FirstOrDefault IsNot Nothing
    End Function

    Public Async Function HasTableDataAsync(ercontext As EventRecorderContext) As Task(Of Boolean)
        Return Await (From item In ercontext.EventSources
                      Take 1).FirstOrDefaultAsync IsNot Nothing
    End Function

    Public Sub AddDemoData(erContext As EventRecorderContext)

        erContext.EventSources.Add(New EventSource With {.IdEventSource = Guid.NewGuid,
                                                         .Name = "Max Mustermann",
                                                         .DateCreated = DateTimeOffset.Now,
                                                         .DateLastEdited = DateTimeOffset.Now})

        erContext.EventSources.Add(New EventSource With {.IdEventSource = Guid.NewGuid,
                                                             .Name = "John Doe",
                                                             .DateCreated = DateTimeOffset.Now,
                                                             .DateLastEdited = DateTimeOffset.Now})

        erContext.EventSources.Add(New EventSource With {.IdEventSource = Guid.NewGuid,
                                                             .Name = "Jane Doe",
                                                             .DateCreated = DateTimeOffset.Now,
                                                             .DateLastEdited = DateTimeOffset.Now})

        erContext.EventSources.Add(New EventSource With {.IdEventSource = Guid.NewGuid,
                                                             .Name = "Michelle Mustermann",
                                                             .DateCreated = DateTimeOffset.Now,
                                                             .DateLastEdited = DateTimeOffset.Now})
    End Sub

    Public Async Function AddAndCommitDemoDataAsync(Of ContextType As {EventRecorderContext, New})() As Task

        Dim erContext As New ContextType

        If Not Await HasTableDataAsync(erContext) Then
            erContext.ActionTargets.Add(New ActionTarget With {.IdActionTarget = Guid.NewGuid,
                                                           .Name = "Kostenstelle 1",
                                                           .DateCreated = DateTimeOffset.Now,
                                                           .DateLastEdited = DateTimeOffset.Now})
            erContext.ActionTargets.Add(New ActionTarget With {.IdActionTarget = Guid.NewGuid,
                                                           .Name = "Kostenstelle 2",
                                                           .DateCreated = DateTimeOffset.Now,
                                                           .DateLastEdited = DateTimeOffset.Now})
            erContext.ActionTargets.Add(New ActionTarget With {.IdActionTarget = Guid.NewGuid,
                                                           .Name = "Kostenstelle 3",
                                                           .DateCreated = DateTimeOffset.Now,
                                                           .DateLastEdited = DateTimeOffset.Now})
        End If

        Await erContext.SaveChangesAsync()

    End Function

End Module
