﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="CovidProject.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/StylePage.css" rel="stylesheet" />
    <title class="title">ברוכים הבאים לקופת חולים..</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainDiv" style="display: flex">
            <%-- <div style="margin-right:6%; direction:rtl;width: 30%;">
             
             
        
         </div>--%>
            <div class="divGridPeople" id="divGridPeople" runat="server">
                <asp:LinkButton ID="btnViewListPeople" Class="btnList" runat="server" OnClick="btnViewListPeople_Click" Text="רשימת החברים"></asp:LinkButton>
               
                <asp:GridView ID="GridPeople" Visible="false" Style="width: 100%;" runat="server" 
                    
                    OnRowEditing="GridPeople_RowEditing"
                    AutoGenerateEditButton="false"
                    AutoGenerateDeleteButton="false"
                    
                    Width="100%">
                    <HeaderStyle Height="40px" />
                    <RowStyle Height="40px" />
                    <Columns>
                        <asp:CommandField  ShowEditButton="True" ButtonType="Link" EditText="ערוך" HeaderText="ערוך" />
                        <asp:CommandField  ShowDeleteButton="True" ButtonType="Link" DeleteText="מחק" HeaderText="מחק" />
                    </Columns>
                </asp:GridView>

            </div>

            <div class="DivGridPersonDetails" id="divPersonDetails" runat="server" visible="true">
                <asp:GridView ID="GridPersonDetails" Visible="false" Style="width: 100%;" runat="server"
                     OnRowEditing="GridPersonDetails_RowEditing"
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
    </form>
</body>
</html>
