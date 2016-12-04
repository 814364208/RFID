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

public partial class _Default : System.Web.UI.Page
{
    /// <summary>
    /// 将数据库ToolBags表与控件GridView绑定
    /// </summary>
    public void ShowBags()
    {
        DataTable dt = MyManager.GetDataSet("SELECT BagID as 工具编号 FROM ToolBags");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    /// <summary>
    /// 将数据库ToolBags表里的内容在控件GridView中显示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowBags();
    }
    /// <summary>
    /// 点击添加按钮添加工具包
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        String ToolBagID = TextBox1.Text;
        String ToolBagName = TextBox2.Text;
        String PosX = TextBox3.Text;
        String PosY = TextBox4.Text;

        if (ToolBagID == "" || ToolBagName == "" || PosX == "" || PosY == "")
        {
            Response.Write("<span style=\"color:red\">请输入完整信息!</span>");
            return;
        }

        //更新数据库ToolBags表里的内容
        MyManager.ExecSQL("INSERT INTO ToolBags (BagID,BagName,State,PosX,PosY) Values('" + ToolBagID + "','"
                                                                                        + ToolBagName + "',0,"
                                                                                        + PosX + ","
                                                                                        + PosY + ")");
        //清空文本框
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        ShowBags();

    }
}