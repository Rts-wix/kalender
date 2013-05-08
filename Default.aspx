<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        div.day
        {
            border: 1px solid blue;
            margin-bottom: 1px;
            display:inline-block;
            float:left;
            width:12%;
        }
        
        /* mandag */
        div.day:nth-child(7n+6)
        {
            clear:both;
            background-color:Aqua;
        }
        
        div.calendar
        {
            clear:both;
            margin-bottom:20px;
            background-color:Silver;
            float:left;
            width:90%;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="calendar">
        <asp:Repeater ID="RepeaterMonth1" runat="server" 
            onitemdatabound="RepeaterMonth1_ItemDataBound">
            <ItemTemplate>
                <div class="day">
                    <p><%# Eval("day") %></p>
                    <asp:Repeater ID="RepeaterDay1" runat="server">
                       <ItemTemplate>
                            <div>
                                <%# Eval("start_time") %>
                                <%# Eval("title") %>
                            </div>
                       </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
   
    <div class="calendar">
        <asp:Repeater ID="RepeaterMonth2" runat="server" 
            onitemdatabound="RepeaterMonth2_ItemDataBound">
            <ItemTemplate>
                <div class="day">
                    <p><%# Eval("day") %></p>
                    <asp:Repeater ID="RepeaterDay2" runat="server">
                       <ItemTemplate>
                            <div>
                                <%# Eval("start_time") %>
                                <%# Eval("title") %>
                            </div>
                       </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>    
    </div>
    </form>
</body>
</html>
