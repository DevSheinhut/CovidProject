﻿Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub btnViewListPeople_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        GridPeople.Visible = True
        Dim strConnString As String = WebConfigurationManager.ConnectionStrings("COVID").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand("GetAllManList", con)
        Dim da As New SqlDataAdapter()

        Dim dt, tbl, tbl1 As New DataTable


        con.Open()
        cmd.CommandType = CommandType.StoredProcedure
        da.SelectCommand = cmd
        dt.Clear()
        da.Fill(dt)
        Dim grid_people As DataTable = New DataTable()
        Dim NEW_ROW As DataRow
        Dim NEW_col As DataColumn

        'For index As Integer = 0 To 0
        '    NEW_ROW = grid_people.NewRow
        '    grid_people.Rows.Add(NEW_ROW)
        'Next

        For index As Integer = 0 To 3
            NEW_col = New DataColumn
            grid_people.Columns.Add(NEW_col)
        Next
        grid_people.Columns(0).ColumnName = "ID"
        grid_people.Columns(1).ColumnName = "שם"
        grid_people.Columns(2).ColumnName = "משפחה"
        grid_people.Columns(3).ColumnName = "ת.ז."



        tbl = dt
        If tbl.Rows.Count > 0 Then

            For index = 0 To tbl.Rows.Count - 1
                NEW_ROW = grid_people.NewRow()
                grid_people.Rows.Add(NEW_ROW)
                grid_people.Rows(index)(0) = tbl.Rows(index)("id")
                grid_people.Rows(index)(1) = tbl.Rows(index)("first_name")
                grid_people.Rows(index)(2) = tbl.Rows(index)("last_name")
                grid_people.Rows(index)(3) = tbl.Rows(index)("identification")


            Next
        End If
        grid_people.Columns.Add("הצג")
        ViewState("CurrentTable") = grid_people
        GridPeople.DataSource = grid_people
        GridPeople.DataBind()
        GridPeople.HeaderRow.Cells(2).Visible = False
        Dim Row As Integer
        For i As Integer = 0 To GridPeople.Rows.Count - 1
            Row = grid_people.Rows(i)("id")
            GridPeople.Rows(i).Cells(2).Visible = False

            Dim f As New System.Web.UI.WebControls.ImageButton
            f.ImageUrl = "~/Images/ViewPerson.PNG"
            f.Attributes.Add("title", "פרטים נוספים")
            f.Attributes.Add("id", Row)
            f.Attributes.Add("onclick", "detail_onclick(this)")
            GridPeople.Rows(i).Cells(6).Controls.Add(f)
        Next
    End Sub
    Private Sub InitGridPersonDetails()
        ' GridPeople.Visible = True
        Dim strConnString As String = WebConfigurationManager.ConnectionStrings("COVID").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand("Get_Man_Detail_By_Id", con)
        Dim da As New SqlDataAdapter()

        Dim dt, tbl, tbl1 As New DataTable



        con.Open()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@id", GridPeople.EditIndex)
        da.SelectCommand = cmd
        dt.Clear()
        da.Fill(dt)

        Dim grid_people As DataTable = New DataTable()
        Dim NEW_ROW As DataRow
        Dim NEW_col As DataColumn


        'For index As Integer = 0 To 0
        '    NEW_ROW = grid_people.NewRow
        '    grid_people.Rows.Add(NEW_ROW)
        'Next

        For index As Integer = 0 To 13
            NEW_col = New DataColumn
            grid_people.Columns.Add(NEW_col)
        Next

        grid_people.Columns(0).ColumnName = "id"
        grid_people.Columns(1).ColumnName = "person_id"
        grid_people.Columns(2).ColumnName = "שם"
        grid_people.Columns(3).ColumnName = "משפחה"
        grid_people.Columns(4).ColumnName = "ת.ז."
        grid_people.Columns(5).ColumnName = "כתובת"
        grid_people.Columns(6).ColumnName = "ת.לידה"
        grid_people.Columns(7).ColumnName = "טלפון"
        grid_people.Columns(8).ColumnName = "פלאפון"
        grid_people.Columns(9).ColumnName = "חיסון"
        grid_people.Columns(10).ColumnName = "תאריך"
        grid_people.Columns(11).ColumnName = "יצרן"
        grid_people.Columns(12).ColumnName = "ת.חיובי"
        grid_people.Columns(13).ColumnName = "ת.החלמה"


        tbl = dt
        If tbl.Rows.Count > 0 Then

            For index = 0 To tbl.Rows.Count - 1
                NEW_ROW = grid_people.NewRow()
                grid_people.Rows.Add(NEW_ROW)
                grid_people.Rows(index)(0) = tbl.Rows(index)("id")
                grid_people.Rows(index)(1) = tbl.Rows(index)("person_id")
                grid_people.Rows(index)(2) = tbl.Rows(index)("first_name")
                grid_people.Rows(index)(3) = tbl.Rows(index)("last_name")
                grid_people.Rows(index)(4) = tbl.Rows(index)("identification")
                grid_people.Rows(index)(5) = tbl.Rows(index)("address")
                grid_people.Rows(index)(6) = tbl.Rows(index)("birth_date")
                grid_people.Rows(index)(7) = tbl.Rows(index)("telephone")
                grid_people.Rows(index)(8) = tbl.Rows(index)("phone")
                grid_people.Rows(index)(9) = tbl.Rows(index)("חיסון")
                grid_people.Rows(index)(10) = tbl.Rows(index)("תאריך")
                grid_people.Rows(index)(11) = tbl.Rows(index)("יצרן")
                grid_people.Rows(index)(12) = tbl.Rows(index)("date_positive")
                grid_people.Rows(index)(13) = tbl.Rows(index)("date_recovery")

            Next
        End If

        GridPersonDetails.DataSource = grid_people

        GridPersonDetails.DataBind()
        GridPersonDetails.HeaderRow.Cells(1).Visible = False
        GridPersonDetails.HeaderRow.Cells(2).Visible = False

        For i As Integer = 0 To GridPersonDetails.Rows.Count - 1

            GridPersonDetails.Rows(i).Cells(1).Visible = False
            GridPersonDetails.Rows(i).Cells(2).Visible = False

        Next
        GridPersonDetails.Visible = True

    End Sub

    'בלחיצה על ערוך בטבלת חברים יפתח לנו טבלה עם פרטים אישיים של אותו שורה
    Protected Sub GridPeople_RowEditing(sender As Object, e As GridViewEditEventArgs)
        Dim dtCurrentTable As DataTable = ViewState("CurrentTable")
        GridPeople.EditIndex = dtCurrentTable.Rows(e.NewEditIndex)("ID")


        InitGridPersonDetails()
        'לרשום פה פרוצדורה שיכניס את הערכים המעודכנים למסד נתונים
    End Sub
    'מחיקת חבר
    Protected Sub GridPeople_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim strConnString As String = WebConfigurationManager.ConnectionStrings("COVID").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand("Delete_Person", con)
        Dim dtCurrentTable As DataTable = ViewState("CurrentTable")
        Dim id, active As Integer
        Dim da As New SqlDataAdapter()
        Dim dt As New DataTable
        con.Open()
        cmd.CommandType = CommandType.StoredProcedure
        id = dtCurrentTable.Rows(e.RowIndex)("id")
        active = 0
        cmd.Parameters.AddWithValue("@id", id)
        cmd.Parameters.AddWithValue("@active", active)
        da.SelectCommand = cmd
        dt.Clear()
        da.Fill(dt)
        btnViewListPeople_Click(sender, e)

    End Sub
    ' עריכת פרטים אישיים
    Protected Sub GridPersonDetails_RowEditing(sender As Object, e As GridViewEditEventArgs)
        GridPersonDetails.EditIndex = e.NewEditIndex


    End Sub
    'ביטול עריכת פרטים אישיים
    Protected Sub GridPersonDetails_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        GridPersonDetails.EditIndex = -1
        InitGridPersonDetails()
    End Sub
    'עדכון עריכת פרטים אישיים
    Protected Sub GridPersonDetails_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim strConnString As String = WebConfigurationManager.ConnectionStrings("COVID").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand("Update_Person")
        Dim row As GridViewRow = GridPersonDetails.Rows(e.RowIndex)


        Dim newFname_txt As System.Web.UI.WebControls.TextBox = CType(row.FindControl("FnameC"), System.Web.UI.WebControls.TextBox)
        Dim newLname_txt As System.Web.UI.WebControls.TextBox = CType(row.FindControl("LnameC"), System.Web.UI.WebControls.TextBox)
        Dim person_id As System.Web.UI.WebControls.TextBox = CType(row.FindControl("IDC"), System.Web.UI.WebControls.TextBox)
        If newFname_txt.Text = "" Or newLname_txt.Text = "" Then
            msg.Visible = True
            Exit Sub
        End If
        msg.Visible = False
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@id", row)
        GridPersonDetails.EditIndex = -1
        InitGridPersonDetails()


    End Sub
    'בלחיצה על הצג יופיע טבלה עם פרטים אישיים
    Public Sub detail_onclick()
        'GridPeople.EditIndex = e.Row.RowIndex

        InitGridPersonDetails()
    End Sub

    Protected Sub GridPeople_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        'If e.Row.RowType = DataControlRowType.DataRow AndAlso GridPeople.EditIndex = e.Row.RowIndex Then
        '    Dim btnddl As HtmlInputButton = CType(e.Row.FindControl("selectWeight"), HtmlInputButton)

        'End If

        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    e.Row.Cells(0).Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridPeople, "Select$" & e.Row.RowIndex)
        '    e.Row.Cells(0).ToolTip = "Click to select this row."
        '    e.Row.Cells(0).CssClass = "pointer"
        '    ' e.Row.Cells(1).Text = "<a style=""cursor:pointer"" >" + "מחק" + "</a>"
        '    ' e.Row.Cells(2).Text = "<a style=""cursor:pointer"" >" + "הצג" + "</a>"
        '    ' e.Row.Cells(6).Text = "<a style=""cursor:pointer"" onclick=""showConfirm1(" + e.Row.RowIndex.ToString + ")"">" + "מחק" + "</a>"

        'End If
    End Sub
    'הוספת חבר חדש
    Public Sub btnAddPerson_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DivAddPerson.Visible = True
        btnAdd.Visible = False
    End Sub
    Public Sub updatePerson_Click(sender As Object, e As EventArgs)
        Dim strConnString As String = WebConfigurationManager.ConnectionStrings("COVID").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand("GetAllManIDList", con)
        Dim da As New SqlDataAdapter()
        Dim dt, tbl, tbl1 As New DataTable
        Dim person_id As Integer


        con.Open()
        cmd.CommandType = CommandType.StoredProcedure
        da.SelectCommand = cmd
        dt.Clear()
        da.Fill(dt)
        tbl = dt
        If txtFname.Value = "" Or txtLname.Value = "" Or txtId.Value = "" Then
            msg.Visible = True
            Exit Sub
        Else
            'להכניס את הID האחרון
            person_id = tbl.Rows(tbl.Rows.Count - 1)("id") + 1
            Dim cmd1 As New SqlCommand("Insert_New_Person", con)
            cmd1.CommandType = CommandType.StoredProcedure
            cmd1.Parameters.AddWithValue("@person_id", person_id)
            cmd1.Parameters.AddWithValue("@fName", txtFname.Value)
            cmd1.Parameters.AddWithValue("@lName", txtLname.Value)
            cmd1.Parameters.AddWithValue("@identification", txtId.Value)
            da.SelectCommand = cmd1
            dt.Clear()
            da.Fill(tbl1)
        End If
        msg.Visible = False
        btnViewListPeople_Click(sender, e)
        txtFname.Value = ""
        txtLname.Value = ""
        txtId.Value = ""
        DivAddPerson.Visible = False
        btnAdd.Visible = True

    End Sub
End Class