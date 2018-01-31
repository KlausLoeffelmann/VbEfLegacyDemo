Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialDbSchema
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ActionTargets",
                Function(c) New With
                    {
                        .IdActionTarget = c.Guid(nullable := False),
                        .Name = c.String(maxLength := 200),
                        .DateCreated = c.DateTimeOffset(nullable := False, precision := 7),
                        .DateLastEdited = c.DateTimeOffset(nullable := False, precision := 7)
                    }) _
                .PrimaryKey(Function(t) t.IdActionTarget)
            
            CreateTable(
                "dbo.Events",
                Function(c) New With
                    {
                        .IdEvent = c.Guid(nullable := False),
                        .StartTime = c.Time(precision := 7),
                        .EndTime = c.Time(precision := 7),
                        .BookingDate = c.DateTimeOffset(precision := 7),
                        .Duration = c.Long(),
                        .Description = c.String(maxLength := 200),
                        .DateCreated = c.DateTimeOffset(nullable := False, precision := 7),
                        .DateLastEdited = c.DateTimeOffset(nullable := False, precision := 7),
                        .ActionTarget_IdActionTarget = c.Guid(),
                        .EventSource_IdEventSource = c.Guid()
                    }) _
                .PrimaryKey(Function(t) t.IdEvent) _
                .ForeignKey("dbo.ActionTargets", Function(t) t.ActionTarget_IdActionTarget) _
                .ForeignKey("dbo.EventSources", Function(t) t.EventSource_IdEventSource) _
                .Index(Function(t) t.ActionTarget_IdActionTarget) _
                .Index(Function(t) t.EventSource_IdEventSource)
            
            CreateTable(
                "dbo.EventSources",
                Function(c) New With
                    {
                        .IdEventSource = c.Guid(nullable := False),
                        .Name = c.String(maxLength := 200),
                        .Description = c.String(),
                        .DateCreated = c.DateTimeOffset(nullable := False, precision := 7),
                        .DateLastEdited = c.DateTimeOffset(nullable := False, precision := 7)
                    }) _
                .PrimaryKey(Function(t) t.IdEventSource)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Events", "EventSource_IdEventSource", "dbo.EventSources")
            DropForeignKey("dbo.Events", "ActionTarget_IdActionTarget", "dbo.ActionTargets")
            DropIndex("dbo.Events", New String() { "EventSource_IdEventSource" })
            DropIndex("dbo.Events", New String() { "ActionTarget_IdActionTarget" })
            DropTable("dbo.EventSources")
            DropTable("dbo.Events")
            DropTable("dbo.ActionTargets")
        End Sub
    End Class
End Namespace
