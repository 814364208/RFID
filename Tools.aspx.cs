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

public partial class Tools : System.Web.UI.Page
{
    public void ShowTools()
    {
        DataTable dt = MyManager.GetDataSet("SELECT * FROM Tools");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowTools();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String toolName = TextBox1.Text;
        String inBagName = TextBox2.Text;
        String PosX = TextBox3.Text;
        String PosY = TextBox4.Text;

        if (toolName == "" || inBagName == "" || PosX == "" || PosY == "")
        {
            Response.Write("<span style=\"color:red\">请输入完整信息!</span>");
            return;
        }

        //更新数据库ToolBags表里的内容
        MyManager.ExecSQL("INSERT INTO Tools (ToolName,Type,BagID,PosX,PosY,State,BorrowedUserID) Values('" + toolName + "',0,'"
                                                                                        + inBagName + "',"
                                                                                        + PosX + ","
                                                                                        + PosY + ",0,0)");
        //清空文本框
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        ShowTools();
    }
}