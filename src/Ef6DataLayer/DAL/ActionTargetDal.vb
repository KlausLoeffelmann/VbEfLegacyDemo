Imports System.Data.Entity

Public Module ActionTargetDal

    Public Function GetActionTargetCount(erContext As EventRecorderContext) As Integer
        Return Aggregate item In erContext.ActionTargets
               Into Count
    End Function

    Public Async Function GetActionTargetCountAsync(erContext As EventRecorderContext) As Task(Of Integer)
        'Find out, if there are action targets
        Return Await erContext.ActionTargets.CountAsync()
    End Function

    Public Function HasTableData(ercontext As EventRecorderContext) As Boolean
        Return (From item In ercontext.ActionTargets
                Take 1).FirstOrDefault IsNot Nothing
    End Function

    Public Async Function HasTableDataAsync(ercontext As EventRecorderContext) As Task(Of Boolean)
        Dim retVal = Await (From item In ercontext.ActionTargets
                            Take 1).FirstOrDefaultAsync
        Return retVal IsNot Nothing
    End Function

    Public Sub AddDemoData(erContext As EventRecorderContext)

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
    End Sub

    Public Sub PatchActionTargetName(erContext As EventRecorderContext,
                                      actionTarget As ActionTarget)

        Dim entry = erContext.Entry(actionTarget)
        If entry.State = EntityState.Detached Then
            erContext.Set(Of ActionTarget).Attach(actionTarget)
            entry.State = EntityState.Modified
        End If
        erContext.SaveChanges()

    End Sub

    Public Async Function GetAllActionTargetsAsync(erContext As EventRecorderContext) As Task(Of List(Of ActionTarget))

        Return Await erContext.ActionTargets.ToListAsync

    End Function

    Public Async Function GetByIdAsync(erContext As EventRecorderContext, id As Guid) As Task(Of ActionTarget)
        Return Await erContext.ActionTargets.Where(
            Function(item) item.IdActionTarget = id).FirstOrDefaultAsync
    End Function
End Module
