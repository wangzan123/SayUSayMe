using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using SayUSayMe.BLL;
using SayUSayMe.DAL;

public partial class WebData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string HasFile(string AID)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();

        comm.CommandText = "GetArticleFileByID";

        //新建命令参数
        DbParameter parm = comm.CreateParameter();
        int aid = Convert.ToInt32(AID.ToString());
        //参数设置
        parm.ParameterName = "@AID";
        parm.DbType = DbType.Int32;
        parm.Value = aid;
        comm.Parameters.Add(parm);

        parm = comm.CreateParameter();
        parm.ParameterName = "@CID";
        parm.DbType = DbType.Int32;
        parm.Value =-1;
        comm.Parameters.Add(parm);
        DataTable dt= GenericDataAccess.ExecuteSelectCommand(comm);
        if (dt.Rows.Count > 0)
            return "是";
        else
            return "否";
    }
}
