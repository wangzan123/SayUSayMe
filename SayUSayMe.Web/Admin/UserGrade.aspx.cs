using System;
using SayUSayMe.BLL;

public partial class Admin_UserGrade : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void addBtnClick(object sender, EventArgs e)
    {
        CatalogAdmin.AddUserGrade(Int32.Parse(gradeID.Text.Trim()), Int32.Parse(level1.Text.Trim()), Int32.Parse(level2.Text.Trim()), Int32.Parse(level3.Text.Trim()), Int32.Parse(level4.Text.Trim()), Int32.Parse(gradScore.Text.Trim()));

    }
}
