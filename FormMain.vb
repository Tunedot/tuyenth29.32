Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class FormMain
    Private ReadOnly cs As String = ConfigurationManager.ConnectionStrings("StudentDb").ConnectionString
    Private dt As DataTable
    Private view As DataView
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler btnAdd.Click, AddressOf btnAdd_Click
        AddHandler btnUpdate.Click, AddressOf btnUpdate_Click
        AddHandler btnDelete.Click, AddressOf btnDelete_Click
        AddHandler btnClear.Click, AddressOf btnClear_Click
        AddHandler btnSave.Click, AddressOf btnSave_Click
        AddHandler btnLoad.Click, AddressOf btnLoad_Click
        AddHandler txtSearch.TextChanged, AddressOf txtSearch_TextChanged
        AddHandler dgv.SelectionChanged, AddressOf dgv_SelectionChanged

        cboGender.Items.Clear()
        cboGender.Items.AddRange(New String() {"Nam", "Nữ", "Khác"})

        LoadStudents()
    End Sub
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtId.Text) Then MessageBox.Show("Vui lòng nhập Mã sinh viên.") : Return False
        If String.IsNullOrWhiteSpace(txtName.Text) Then MessageBox.Show("Vui lòng nhập Họ tên.") : Return False
        If cboGender.SelectedIndex < 0 Then MessageBox.Show("Vui lòng chọn Giới tính.") : Return False
        If String.IsNullOrWhiteSpace(txtClass.Text) Then MessageBox.Show("Vui lòng nhập Lớp.") : Return False
        If dtpBirth.Value.Date < #1/1/1900# OrElse dtpBirth.Value.Date > Date.Today Then
            MessageBox.Show("Ngày sinh không hợp lệ.") : Return False
        End If
        Return True
    End Function
    Private Sub ClearInputs()
        txtId.Clear()
        txtName.Clear()
        cboGender.SelectedIndex = -1
        txtClass.Clear()
        dtpBirth.Value = Date.Today
        txtId.Focus()
    End Sub
    Private Sub FormatGrid()
        dgv.AutoGenerateColumns = True
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.ReadOnly = False
        If dgv.Columns.Contains("Age") Then dgv.Columns("Age").ReadOnly = True
    End Sub
    Private Sub LoadStudents(Optional q As String = "")
        Try
            dt = New DataTable()
            Using cn As New SqlConnection(cs)
                If String.IsNullOrWhiteSpace(q) Then
                    Dim sql As String =
"SELECT StudentId, FullName, Gender, Class, BirthDate,
        DATEDIFF(YEAR, BirthDate, GETDATE()) -
        CASE WHEN (MONTH(BirthDate) > MONTH(GETDATE())) OR
                  (MONTH(BirthDate) = MONTH(GETDATE()) AND DAY(BirthDate) > DAY(GETDATE()))
             THEN 1 ELSE 0 END AS Age
 FROM dbo.Students
 ORDER BY FullName;"
                    Using da As New SqlDataAdapter(sql, cn)
                        da.Fill(dt)
                    End Using
                Else
                    Using da As New SqlDataAdapter("dbo.sp_Student_Search", cn)
                        da.SelectCommand.CommandType = CommandType.StoredProcedure
                        da.SelectCommand.Parameters.Add("@q", SqlDbType.NVarChar, 200).Value = q
                        da.Fill(dt)
                    End Using
                    If Not dt.Columns.Contains("Age") Then dt.Columns.Add("Age", GetType(Integer))
                    For Each r As DataRow In dt.Rows
                        If Not IsDBNull(r("BirthDate")) Then
                            Dim b As Date = CDate(r("BirthDate"))
                            Dim age = Date.Now.Year - b.Year
                            If (Date.Now.Month < b.Month) OrElse (Date.Now.Month = b.Month AndAlso Date.Now.Day < b.Day) Then age -= 1
                            r("Age") = age
                        End If
                    Next
                End If
            End Using

            view = New DataView(dt)
            dgv.DataSource = view
            FormatGrid()
        Catch ex As Exception
            MessageBox.Show("Lỗi nạp dữ liệu: " & ex.Message)
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        If Not ValidateInputs() Then Return
        Try
            Using cn As New SqlConnection(cs)
                Using cmd As New SqlCommand("dbo.sp_Student_Create", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@StudentId", SqlDbType.NVarChar, 20).Value = txtId.Text.Trim()
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 120).Value = txtName.Text.Trim()
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 10).Value = cboGender.SelectedItem?.ToString()
                    cmd.Parameters.Add("@Class", SqlDbType.NVarChar, 50).Value = txtClass.Text.Trim()
                    cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = dtpBirth.Value.Date
                    cn.Open() : cmd.ExecuteNonQuery()
                End Using
            End Using
            LoadStudents() : ClearInputs()
        Catch ex As SqlException
            MessageBox.Show("Không thêm được: " & ex.Message)
        End Try
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
        If Not ValidateInputs() Then Return
        Try
            Using cn As New SqlConnection(cs)
                Using cmd As New SqlCommand("dbo.sp_Student_Update", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@StudentId", SqlDbType.NVarChar, 20).Value = txtId.Text.Trim()
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 120).Value = txtName.Text.Trim()
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 10).Value = cboGender.SelectedItem?.ToString()
                    cmd.Parameters.Add("@Class", SqlDbType.NVarChar, 50).Value = txtClass.Text.Trim()
                    cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = dtpBirth.Value.Date
                    cn.Open() : cmd.ExecuteNonQuery()
                End Using
            End Using
            LoadStudents()
        Catch ex As SqlException
            MessageBox.Show("Không sửa được: " & ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtId.Text) Then
            MessageBox.Show("Chọn 1 dòng hoặc nhập Mã sinh viên để xoá.") : Return
        End If
        If MessageBox.Show("Xoá bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo) = DialogResult.No Then Return
        Try
            Using cn As New SqlConnection(cs)
                Using cmd As New SqlCommand("dbo.sp_Student_Delete", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@StudentId", SqlDbType.NVarChar, 20).Value = txtId.Text.Trim()
                    cn.Open() : cmd.ExecuteNonQuery()
                End Using
            End Using
            LoadStudents() : ClearInputs()
        Catch ex As SqlException
            MessageBox.Show("Không xoá được: " & ex.Message)
        End Try
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        ClearInputs()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs)
        LoadStudents()
        MessageBox.Show("Đã tải dữ liệu từ SQL.")
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)
        LoadStudents(txtSearch.Text.Trim())
    End Sub
    Private Sub dgv_SelectionChanged(sender As Object, e As EventArgs)
        If dgv.CurrentRow Is Nothing OrElse dgv.CurrentRow.Index < 0 Then Return
        Dim r = dgv.CurrentRow
        txtId.Text = r.Cells("StudentId").Value?.ToString()
        txtName.Text = r.Cells("FullName").Value?.ToString()
        cboGender.SelectedItem = r.Cells("Gender").Value?.ToString()
        txtClass.Text = r.Cells("Class").Value?.ToString()
        If r.Cells("BirthDate").Value IsNot Nothing AndAlso r.Cells("BirthDate").Value IsNot DBNull.Value Then
            dtpBirth.Value = CDate(r.Cells("BirthDate").Value)
        End If
    End Sub
End Class
