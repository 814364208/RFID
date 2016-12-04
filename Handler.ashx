<%@ WebHandler Language="C#" Class="Handler"Debug="true" %>

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

public class Handler : IHttpHandler, IRequiresSessionState
{
    HttpContext gCtx;
    /// <summary>
    /// 处理用户登录
    /// </summary>
    /// <param name="JO">客户端传来的账号和密码</param>
    /// <returns>返登录结果</returns>
    public String userLogin(JObject JO)
    {
        DataTable dt= MyManager.GetDataSet("SELECT * From UserList WHERE  LoginName ='" + JO["lname"].ToString() + "' AND password = '" + JO["pwd"].ToString()+"'");
        if (dt.Rows.Count!=0){
            return "{\"status\":\"success\",\"name\":\"" + dt.Rows[0]["Name"].ToString() + "\"}";
        }
        else
        {
            return "{\"status\":\"failed\",\"msg\":\"用户名或密码错误！\"}";
        }
        
    }
    /// <summary>
    /// 获取数据库Tools列表中的工具信息
    /// </summary>
    /// <returns>将工具信息以JSON的数据格式返回</returns>
    public String getTools()
    {
        //创建可以书写JSON数据格式的jWrite对象
        StringWriter sw = new StringWriter();
        JsonWriter jWrite = new JsonTextWriter(sw);
        
        //访问数据库Tools列表
        DataTable dt = MyManager.GetDataSet("SELECT * FROM Tools Where Type = 0 ORDER BY id ASC");
       
        //写json数据
        jWrite.WriteStartObject();//页面会输出“{”
        jWrite.WritePropertyName("status");
        jWrite.WriteValue("success");
        //会在页面输出{"status":"success"
        jWrite.WritePropertyName("data");
        jWrite.WriteStartArray();//页面会输出“[”
        
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            jWrite.WriteStartObject();//页面会输出“{”
            jWrite.WritePropertyName("toolid");
            jWrite.WriteValue(dt.Rows[i]["id"].ToString());
            jWrite.WritePropertyName("toolname");
            jWrite.WriteValue(dt.Rows[i]["ToolName"].ToString());
            jWrite.WritePropertyName("state");
            jWrite.WriteValue(dt.Rows[i]["State"].ToString());
 	        jWrite.WritePropertyName("rstate");
            jWrite.WriteValue(dt.Rows[i]["State"].ToString()=="0"?"2":"3");// 认为所有工具都不正常，要么丢失，要么意外在库

/*
	0:理论在库 1:理论借出 	2：工具丢失 3：意外在库  4:正常在库 5:正常不在库  
*/
            jWrite.WritePropertyName("posy");
            jWrite.WriteValue(dt.Rows[i]["PosY"].ToString());
            jWrite.WriteEndObject();//}
        }         
        
        jWrite.WriteEndArray();//]
        jWrite.WriteEndObject();//}
        //此时会将数据库Tools表中的数据以如下的方式
        //{"status":"success","data":[{"toolid":"1","state":"0","posy":"2"}]}
        //在网页中显示
        
        return sw.ToString();
    }
    



    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
  
 public void ProcessRequest (HttpContext context) 
   {

        int i = 0;
        String json_old = "",Cmd = "",retJSON = "";
        context.Response.ContentType = "text/plain";
        gCtx = context;
        retJSON = "{\"status\":\"failed\",\"msg\":\"命令错误!\"}";
       try
        {
            
         StreamReader reader = new StreamReader(context.Request.InputStream);
         json_old = reader.ReadToEnd();
            JObject JO = JObject.Parse(json_old);
             Cmd = JO["cmd"].ToString();
            
            if (Cmd == "userLogin")
            {
                retJSON = userLogin(JO);
            }

            if (Cmd == "getTools")
            {
                retJSON = getTools();        
            }
              
        
           
           context.Response.Write(retJSON);
        }
        catch (Exception ee)
        {
           context.Response.Write(json_old);
            context.Response.Write("{\"status\":\"failed\",\"msg\":\""+ee.ToString()+ "\"}");
           // MyManager.ExecSQL("INSERT INTO jsonCmdErr(Json,ErrMsg) VALUES ('" + System.Web.HttpUtility.HtmlEncode(json_old) + "','" + DateTime.Now.ToString() + "'");
        }
}
}
