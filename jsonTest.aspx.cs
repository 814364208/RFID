﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox3.Text = MyManager.Post(Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf('/') + 1) + "Handler.ashx", TextBox2.Text);
        //
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       
    }
}