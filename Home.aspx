﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="CovidProject.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/StylePage.css" rel="stylesheet" />
    <title class="title">ברוכים הבאים לקופת חולים..</title>
    <script type="text/javascript">
        function detail_onclick(row) {
            //debugger;
            //GridPeople.EditIndex = row.id
            //document.getElementById("btnDetail").click();

        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainDiv" >
           <div class="txt">קופת חולים ברוכים הבאים</div>
             <div style="display: flex" >
                  <asp:LinkButton ID="btnAdd" Class="btnLink" runat="server" Visible="false" OnClick="btnAddPerson_Click" Text="הוספת חבר"></asp:LinkButton> 
            <div class="addPerson" id="DivAddPerson" style="display: flex; margin-top: 8px;"  runat="server">
                <div class="txtOutpot">שם</div>&nbsp;
            <input type="text" id="txtFname" class="txtinput" style="margin-top: -9px;" maxlength="60" runat="server" autocomplete="off" />
             &nbsp;	&nbsp;	
                <div class="txtOutpot">משפחה</div>&nbsp;
            <input type="text" id="txtLname" class="txtinput" style="margin-top: -9px;" maxlength="60" runat="server" autocomplete="off" />
             &nbsp;	&nbsp;
                <div class="txtOutpot">ת.ז.</div>&nbsp;
            <input type="text" id="txtId" class="txtinput" style="margin-top: -9px;" maxlength="60" runat="server" autocomplete="off" />
             &nbsp;	&nbsp;
                  <asp:Button ID="updatePerson" Text="הוספה" runat="server" OnClick="updatePerson_Click" />
            </div>
                 </div>
            <div id="msg" style="color:red;" runat="server" visible="false">נא למלאות את כל הנתונים</div>
           
           
              <asp:LinkButton ID="btnViewListPeople" Class="btnLink" runat="server" OnClick="btnViewListPeople_Click" Text="רשימת החברים"></asp:LinkButton>  
             <div style="display: flex; max-height: 67%;">
                <div class="divGridPeople" id="divGridPeople" runat="server">
                <asp:GridView ID="GridPeople" Visible="false" Style="width: 100%;" runat="server" 
                    
                    OnRowEditing="GridPeople_RowEditing"
                    AutoGenerateEditButton="false"
                    OnRowDeleting="GridPeople_RowDeleting"
                    AutoGenerateDeleteButton="false"
                    
                    Width="100%">
                    <HeaderStyle Height="40px" />
                    <RowStyle Height="40px" />
                    <Columns>

                         <asp:TemplateField HeaderText="הצג">
                <ItemTemplate>
                    <asp:LinkButton ID="viewDetails" runat="server" Text="הצג"
                        CommandName="View" OnCommand="View_Command" CommandArgument='<%# Eval("ID").ToString()%>' OnClientClick='detail_onclick()'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
                       
                        <asp:CommandField  ShowDeleteButton="True" ButtonType="Link" DeleteText="מחק" HeaderText="מחק" />
                    </Columns>
                </asp:GridView>

            </div>

           <%-- <input style="visibility:hidden" id="btnDetail" runat="server" onserverclick="detail_onclick" type="button"/>--%>
                 
                <div class="DivGridPersonDetails"  id="divPersonDetails" runat="server" visible="true">
                     <asp:LinkButton ID="closeViewDeatails" style="color: #102C2F;" runat="server" Visible="false"  OnClick="closeViewDeatails_Click" Text="סגור פרטים נוספים"></asp:LinkButton>
                 <asp:GridView ID="GridPersonDetails" Visible="false" Style="width: 100%;" runat="server"
                    OnRowCancelingEdit="GridPersonDetails_RowCancelingEdit"
                    OnRowEditing="GridPersonDetails_RowEditing"
                     OnRowUpdating="GridPersonDetails_RowUpdating"
                    AutoGenerateEditButton="false"
                    Width="100%">
                     <HeaderStyle Height="40px" />
                    <RowStyle Height="40px" />
                    <Columns>
                        <asp:CommandField  ShowEditButton="True" ButtonType="Link" EditText="ערוך" HeaderText="ערוך" />
                    </Columns>
                 </asp:GridView>
                   <br /> <br />
                 <asp:LinkButton ID="closeViewCovidDeatails" style="color: #102C2F;" runat="server" Visible="false"  OnClick="closeViewCovidDeatails_Click" Text="סגור פרטי קורונה"></asp:LinkButton>
                     <asp:LinkButton ID="openViewCovidDeatails" style="color: #102C2F;" runat="server" Visible="false"  OnClick="openViewCovidDeatails_Click" Text="פתיחת פרטי קורונה"></asp:LinkButton>       
                <asp:GridView class="DivGridCovidDetails" ID="GridCovidDetails" Visible="false" Style="width: 100%;" runat="server"
                    OnRowCancelingEdit="GridCovidDetails_RowCancelingEdit"
                    OnRowEditing="GridCovidDetails_RowEditing"
                     OnRowUpdating="GridCovidDetails_RowUpdating"
                    AutoGenerateEditButton="false"
                    Width="100%">
                     <HeaderStyle Height="40px" />
                    <RowStyle Height="40px" />
                    <Columns>
                        <asp:CommandField  ShowEditButton="True" ButtonType="Link" EditText="ערוך" HeaderText="ערוך" />
                        
                    </Columns>
                </asp:GridView>

            </div>
                </div>
        </div>
    </form>
</body>
</html>
