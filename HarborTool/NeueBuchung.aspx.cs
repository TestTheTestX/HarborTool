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

public partial class NeueBuchung : System.Web.UI.Page
{
    private string apiUrl = WebConfigurationManager.AppSettings["HarborApi"];
    private HttpWebRequest httpRequest;

    protected void Page_Load(object sender, EventArgs e)
    {
        LabelMeldung.Text = "";
        if (!this.IsPostBack)
        {
            httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(apiUrl + "boats"));
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "GET";
            using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
            {
                using (Stream stream = httpResponse.GetResponseStream())
                {
                    string json = (new StreamReader(stream)).ReadToEnd();
                    DropDownListBoats.DataSource = new JavaScriptSerializer().Deserialize<List<BoatDTO>>(json);
                    DropDownListBoats.DataTextField = "Bezeichnung";
                    DropDownListBoats.DataValueField = "Id";
                    DropDownListBoats.DataBind();
                }
            }

            httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(apiUrl + "docks"));
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "GET";
            using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
            {
                using (Stream stream = httpResponse.GetResponseStream())
                {
                    string json = (new StreamReader(stream)).ReadToEnd();
                    DropDownListDocks.DataSource = new JavaScriptSerializer().Deserialize<List<DockDTO>>(json);
                    DropDownListDocks.DataTextField = "Bezeichnung";
                    DropDownListDocks.DataValueField = "Id";
                    DropDownListDocks.DataBind();
                }
            }
        }
    }

    protected void ButtonBooking_Click(object sender, EventArgs e)
    {
        BookingDTO booking = new BookingDTO()
        {
            BoatId = Convert.ToInt32(DropDownListBoats.SelectedValue),
            DockId = Convert.ToInt32(DropDownListDocks.SelectedValue),
            Arrival = Convert.ToDateTime(CalendarVon.SelectedDate).ToString("dd.MM.yyy"),
            Departure = Convert.ToDateTime(CalendarBis.SelectedDate).ToString("dd.MM.yyy")
        };

        string inputJson = new JavaScriptSerializer().Serialize(booking);
        httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(apiUrl + "bookings"));
        httpRequest.ContentType = "application/json";
        httpRequest.Method = "POST";


        byte[] bytes = Encoding.UTF8.GetBytes(inputJson);
        using (Stream stream = httpRequest.GetRequestStream()) 
        {
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
        }

        try
        {
            HttpWebResponse httpResponse = (HttpWebResponse) httpRequest.GetResponse();
            LabelMeldung.Text = httpResponse.StatusCode.ToString();
        }
        catch (WebException exep)
        {
            if (exep.Status == WebExceptionStatus.ProtocolError && exep.Response != null)
            {
                HttpWebResponse resp = (HttpWebResponse)exep.Response;
                LabelMeldung.Text = resp.StatusCode.ToString();

                using (Stream stream = resp.GetResponseStream())
                {
                    if (stream != null)
                    {
                        string json = (new StreamReader(stream)).ReadToEnd();
                        LabelMeldung.Text += " Meldung: " + json;
                    }                   
                }
            }
            else
            {
                LabelMeldung.Text = exep.Message;
            }         
        }
        catch (Exception exep)
        {         
            LabelMeldung.Text = exep.Message;
        }
     
    }
}