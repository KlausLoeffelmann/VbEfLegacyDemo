<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnPatchData = New System.Windows.Forms.Button()
        Me.btnAddDemoBaseData = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPatchData
        '
        Me.btnPatchData.Location = New System.Drawing.Point(282, 95)
        Me.btnPatchData.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPatchData.Name = "btnPatchData"
        Me.btnPatchData.Size = New System.Drawing.Size(221, 49)
        Me.btnPatchData.TabIndex = 3
        Me.btnPatchData.Text = "Patch Data (Disconnected)"
        Me.btnPatchData.UseVisualStyleBackColor = True
        '
        'btnAddDemoBaseData
        '
        Me.btnAddDemoBaseData.Location = New System.Drawing.Point(282, 28)
        Me.btnAddDemoBaseData.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAddDemoBaseData.Name = "btnAddDemoBaseData"
        Me.btnAddDemoBaseData.Size = New System.Drawing.Size(221, 49)
        Me.btnAddDemoBaseData.TabIndex = 2
        Me.btnAddDemoBaseData.Text = "Add Demo Base Data"
        Me.btnAddDemoBaseData.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnPatchData)
        Me.Controls.Add(Me.btnAddDemoBaseData)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPatchData As Button
    Friend WithEvents btnAddDemoBaseData As Button
End Class
