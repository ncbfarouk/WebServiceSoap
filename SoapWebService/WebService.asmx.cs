using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using Newtonsoft.Json;

namespace SoapWebService
{
    /// <summary>
    /// Description résumée de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]

        public int Fibonacci(int n)
        {
            int x;
            if (!int.TryParse(n.ToString(), out x)) return -1;
            if (n < 1 || n > 100) return -1;

            int curIndex = 1, prevIndex = 0;

            for (int i = 1; i < n; i++)
            {

                int tempIndex = curIndex;
                curIndex += prevIndex;
                prevIndex = tempIndex;
            }
            return curIndex;
        }

        [WebMethod]

        public string XmlToJson(string xml)
        {

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            return jsonText;
        }
    }
}
