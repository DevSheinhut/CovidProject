Imports System.Data.SqlClient
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
        Dim ds As DataSet
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
        grid_people.Columns(0).ColumnName = "הצג"
        grid_people.Columns(1).ColumnName = "שם"
        grid_people.Columns(2).ColumnName = "משפחה"
        grid_people.Columns(3).ColumnName = "ת.ז."



        tbl = dt
        If tbl.Rows.Count > 0 Then

            For index = 0 To tbl.Rows.Count - 1
                NEW_ROW = grid_people.NewRow()
                grid_people.Rows.Add(NEW_ROW)
                grid_people.Rows(index)(1) = tbl.Rows(index)("first_name")
                grid_people.Rows(index)(2) = tbl.Rows(index)("last_name")
                grid_people.Rows(index)(3) = tbl.Rows(index)("identification")


            Next
        End If

        GridPeople.DataSource = grid_people

        GridPeople.DataBind()

    End Sub
    Private Sub InitGridPersonDetails()
        ' GridPeople.Visible = True
        Dim strConnString As String = WebConfigurationManager.ConnectionStrings("COVID").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand("Get_Man_Detail_By_Id", con)
        Dim da As New SqlDataAdapter()
        Dim ds As DataSet
        Dim dt, tbl, tbl1 As New DataTable


        con.Open()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@id", GridPeople.EditIndex + 1)
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
        grid_people.Columns(2).ColumnName = "first_name"
        grid_people.Columns(3).ColumnName = "last_name"
        grid_people.Columns(4).ColumnName = "identification"
        grid_people.Columns(5).ColumnName = "address"
        grid_people.Columns(6).ColumnName = "birth_date"
        grid_people.Columns(7).ColumnName = "telephone"
        grid_people.Columns(8).ColumnName = "phone"
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

        GridPersonDetails.Visible = True

    End Sub
    Protected Sub OnRowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        'כאן נמחוק את השורה
    End Sub
    Protected Sub GridPeople_RowEditing(sender As Object, e As GridViewEditEventArgs)
        GridPeople.EditIndex = e.NewEditIndex

        InitGridPersonDetails()
    End Sub
    Protected Sub GridPersonDetails_RowEditing(sender As Object, e As GridViewEditEventArgs)
        GridPersonDetails.EditIndex = e.NewEditIndex


    End Sub
    Protected Sub detail_onclick(sender As Object, e As GridViewRowEventArgs)
        GridPeople.EditIndex = e.Row.RowIndex

        InitGridPersonDetails()
    End Sub
    Protected Sub GridPeople_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow AndAlso GridPeople.EditIndex = e.Row.RowIndex Then
            Dim btnddl As HtmlInputButton = CType(e.Row.FindControl("selectWeight"), HtmlInputButton)

        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridPeople, "Select$" & e.Row.RowIndex)
            e.Row.Cells(0).ToolTip = "Click to select this row."
            e.Row.Cells(0).CssClass = "pointer"
            ' e.Row.Cells(1).Text = "<a style=""cursor:pointer"" >" + "מחק" + "</a>"
            e.Row.Cells(2).Text = "<a style=""cursor:pointer"" >" + "הצג" + "</a>"
            ' e.Row.Cells(6).Text = "<a style=""cursor:pointer"" onclick=""showConfirm1(" + e.Row.RowIndex.ToString + ")"">" + "מחק" + "</a>"

        End If
    End Sub
End Class