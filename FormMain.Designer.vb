<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblClass = New System.Windows.Forms.Label()
        Me.lblDob = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cboGender = New System.Windows.Forms.ComboBox()
        Me.txtClass = New System.Windows.Forms.TextBox()
        Me.dtpBirth = New System.Windows.Forms.DateTimePicker()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(27, 27)
        Me.lblId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(81, 16)
        Me.lblId.TabIndex = 18
        Me.lblId.Text = "Mã sinh viên"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(27, 64)
        Me.lblName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(64, 16)
        Me.lblName.TabIndex = 17
        Me.lblName.Text = "Họ và tên"
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Location = New System.Drawing.Point(27, 101)
        Me.lblGender.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(54, 16)
        Me.lblGender.TabIndex = 16
        Me.lblGender.Text = "Giới tính"
        '
        'lblClass
        '
        Me.lblClass.AutoSize = True
        Me.lblClass.Location = New System.Drawing.Point(27, 138)
        Me.lblClass.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClass.Name = "lblClass"
        Me.lblClass.Size = New System.Drawing.Size(30, 16)
        Me.lblClass.TabIndex = 15
        Me.lblClass.Text = "Lớp"
        '
        'lblDob
        '
        Me.lblDob.AutoSize = True
        Me.lblDob.Location = New System.Drawing.Point(27, 175)
        Me.lblDob.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDob.Name = "lblDob"
        Me.lblDob.Size = New System.Drawing.Size(67, 16)
        Me.lblDob.TabIndex = 14
        Me.lblDob.Text = "Ngày sinh"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(147, 23)
        Me.txtId.Margin = New System.Windows.Forms.Padding(4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(292, 22)
        Me.txtId.TabIndex = 13
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(147, 60)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(292, 22)
        Me.txtName.TabIndex = 12
        '
        'cboGender
        '
        Me.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGender.Items.AddRange(New Object() {"Nam", "Nữ", "Khác"})
        Me.cboGender.Location = New System.Drawing.Point(147, 97)
        Me.cboGender.Margin = New System.Windows.Forms.Padding(4)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(292, 24)
        Me.cboGender.TabIndex = 11
        '
        'txtClass
        '
        Me.txtClass.Location = New System.Drawing.Point(147, 134)
        Me.txtClass.Margin = New System.Windows.Forms.Padding(4)
        Me.txtClass.Name = "txtClass"
        Me.txtClass.Size = New System.Drawing.Size(292, 22)
        Me.txtClass.TabIndex = 10
        '
        'dtpBirth
        '
        Me.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBirth.Location = New System.Drawing.Point(147, 171)
        Me.dtpBirth.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpBirth.Name = "dtpBirth"
        Me.dtpBirth.Size = New System.Drawing.Size(292, 22)
        Me.dtpBirth.TabIndex = 9
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(480, 22)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 31)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Thêm"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(480, 59)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(120, 31)
        Me.btnUpdate.TabIndex = 7
        Me.btnUpdate.Text = "Sửa"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(480, 96)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(120, 31)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "Xóa"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(480, 133)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(120, 31)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Làm mới"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(627, 22)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 31)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Lưu"
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(627, 59)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(120, 31)
        Me.btnLoad.TabIndex = 3
        Me.btnLoad.Text = "Mở"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(560, 171)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(185, 22)
        Me.txtSearch.TabIndex = 2
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(480, 175)
        Me.lblSearch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(62, 16)
        Me.lblSearch.TabIndex = 1
        Me.lblSearch.Text = "Tìm kiếm"
        '
        'dgv
        '
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(31, 222)
        Me.dgv.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersWidth = 51
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(716, 320)
        Me.dgv.TabIndex = 0
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 566)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dtpBirth)
        Me.Controls.Add(Me.txtClass)
        Me.Controls.Add(Me.cboGender)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.lblDob)
        Me.Controls.Add(Me.lblClass)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblId)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormMain"
        Me.Text = "Quản lý Sinh viên (VB.NET, WinForms)"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblId As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lblGender As Label
    Friend WithEvents lblClass As Label
    Friend WithEvents lblDob As Label

    Friend WithEvents txtId As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents cboGender As ComboBox
    Friend WithEvents txtClass As TextBox
    Friend WithEvents dtpBirth As DateTimePicker

    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnLoad As Button

    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearch As Label

    Friend WithEvents dgv As DataGridView
End Class