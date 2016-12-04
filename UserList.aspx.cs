using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.SessionState;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Drawing;
using Newtonsoft.Json.Linq;

public partial class UserList : System.Web.UI.Page
{
    public void ShowUserList()
    {
        DataTable dt = MyManager.GetDataSet("SELECT * FROM UserList");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowUserList();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String Name = TextBox1.Text;
        String LoginName = TextBox2.Text;
        String PassWord = TextBox3.Text;

        if (Name == "" || LoginName == "" || PassWord == "")
        {
            Response.Write("<span style=\"color:red\">请输入完整信息!</span>");
            return;
        }
        MyManager.ExecSQL("INSERT INTO UserList (Name,LoginName,PassWord) Values('" + Name + "','"
                                                                                        + LoginName + "','"
                                                                                        + PassWord + "')");
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
       
        ShowUserList(); ;
    }
}