<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BOOPprojectWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <asp:Image ID="logo" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <center>
                <img src="./images/logo.png" style="height: 147px; width: 526px"/>
                </center>
                <p>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-8 col-md-8">
                <form id="form1" runat="server">

                    <asp:TextBox ID="TextBox1" runat="server" Height="270" Rows="2" CssClass="form-control input-lg" TextMode="MultiLine"></asp:TextBox>
                    <p>
                        <br />
                        <asp:Button ID="Confirm_btn" runat="server" Text="Analyze" CssClass="btn btn-primary" OnClick="Confirm_btn_Click" />
                    </p>

                </form>
            </div>
            <div class="col-xs-4 col-md-4">
                <asp:Table ID="ResultsTable" runat="server" Height="205px" Width="244px" CssClass="table table-hover">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><b>Sentences</b></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><b>Words</b></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><b>Indicative mood</b></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><b>Questions</b></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><b>Imperative mood</b></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><b>Consonants</b></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><b>Vowels</b></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><b>Lines</b></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server"><b>Special characters</b></asp:TableCell>
                        <asp:TableCell runat="server"></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <p>
                    <b>Most frequent word: </b>
                    <asp:Label ID="MostFreqWord" runat="server" Text=""></asp:Label><br />
                    <b>Longest sentences: </b>
                    <asp:Label ID="LongestSntc" runat="server" Text=""></asp:Label><br />
                    <b>Longest words: </b>
                    <asp:Label ID="LongestWrds" runat="server" Text=""></asp:Label><br />
                    <b>Shortest sentences:</b>
                    <asp:Label ID="ShortestSntc" runat="server" Text=""></asp:Label><br />
                    <b>Shortest words:</b>
                    <asp:Label ID="ShortestWrds" runat="server" Text=""></asp:Label><br />
                </p>
                <div runat="server" id="WrdsMapDiv">
                </div>
                <div runat="server" id="CharMapDiv">
                </div>
                <script>
                    $(document).ready(function () {
                        $('[data-toggle="tooltip"]').tooltip();
                    });
                </script>
            </div>

        </div>
    </div>


</body>
</html>
