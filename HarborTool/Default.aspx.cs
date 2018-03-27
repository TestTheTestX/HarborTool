using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;




public partial class _Default : System.Web.UI.Page
{
    private string apiUrl = WebConfigurationManager.AppSettings["HarborApi"];


    protected void Page_Load(object sender, EventArgs e)
    {
        HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(apiUrl + "bookings"));
        httpRequest.ContentType = "application/json";
        httpRequest.Method = "GET";

        using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
        {
            using (Stream stream = httpResponse.GetResponseStream())
            {
                string json = (new StreamReader(stream)).ReadToEnd();
                RepeaterBookings.DataSource = new JavaScriptSerializer().Deserialize<List<BookingDTO>>(json);
                RepeaterBookings.DataBind();
            }
        }

    }


    protected void RepeaterBookings_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            string id = e.CommandArgument.ToString();

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(apiUrl + "bookings/" + id));
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "DELETE";

            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            Response.Redirect("default.aspx");
        }
    }
}