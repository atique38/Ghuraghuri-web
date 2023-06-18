<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcessForm.aspx.cs" Inherits="Ghuraghuri.pages.ProcessForm" ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .rating {
    display: inline-block;
}

.rating input {
    display: none;
}

.rating label {
    float: right;
    cursor: pointer;
    color: #ccc;
}

.rating label:before {
    content: "\2605";
    font-size: 30px;
}

.rating input:checked ~ label {
    color: #ffcc00;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="rating">
    <input type="radio" id="star5" name="rating" value="5" />
    <label for="star5"></label>
    <input type="radio" id="star4" name="rating" value="4" />
    <label for="star4"></label>
    <input type="radio" id="star3" name="rating" value="3" />
    <label for="star3"></label>
    <input type="radio" id="star2" name="rating" value="2" />
    <label for="star2"></label>
    <input type="radio" id="star1" name="rating" value="1" />
    <label for="star1"></label>
</div>
        <asp:Button ID="Button1" runat="server" Text="Get rating" OnClick="Button1_Click" />

    </form>
</body>
</html>
