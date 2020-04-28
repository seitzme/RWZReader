<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetails
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
        Me.dgDetails = New System.Windows.Forms.DataGridView()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPosition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgDetails
        '
        Me.dgDetails.AllowUserToAddRows = False
        Me.dgDetails.AllowUserToDeleteRows = False
        Me.dgDetails.AllowUserToResizeRows = False
        Me.dgDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDescription, Me.colPosition, Me.colData})
        Me.dgDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgDetails.Name = "dgDetails"
        Me.dgDetails.ReadOnly = True
        Me.dgDetails.RowHeadersVisible = False
        Me.dgDetails.Size = New System.Drawing.Size(284, 262)
        Me.dgDetails.TabIndex = 0
        '
        'colDescription
        '
        Me.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        Me.colDescription.Width = 85
        '
        'colPosition
        '
        Me.colPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colPosition.HeaderText = "Position"
        Me.colPosition.Name = "colPosition"
        Me.colPosition.ReadOnly = True
        Me.colPosition.Width = 69
        '
        'colData
        '
        Me.colData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colData.HeaderText = "Data"
        Me.colData.Name = "colData"
        Me.colData.ReadOnly = True
        Me.colData.Width = 55
        '
        'frmDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.dgDetails)
        Me.Name = "frmDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rule Details"
        CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgDetails As System.Windows.Forms.DataGridView
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPosition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colData As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
