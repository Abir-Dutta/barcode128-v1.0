using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using riverOx_barcode128;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        Image img = new Image(); // instantiating the control
        img.Attributes["src"] = Barcode128.generateBarcode(txtCode.Text,false); // setting the path to the image
        plBarCode.Controls.Add(img);
    }
}