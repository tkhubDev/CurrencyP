using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Currency.Models.Currency;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Currency.Controllers
{
	public class CurrencyController : Controller
	{
		ValCurs curs = null;
		public async Task<IActionResult> Index()
		{
			try
			{
				string URL = "https://www.cbr-xml-daily.ru/daily_eng.xml";

				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
				using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
				{
					string responseString;
					using (Stream stream = response.GetResponseStream())
					{
						StreamReader reader = new StreamReader(stream, Encoding.UTF8);
						responseString = reader.ReadToEnd();
						XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));
						curs = (ValCurs)serializer.Deserialize(new StringReader(responseString));
					}
				}
				return View(curs.Valute);
			}
			catch (WebException ex)
			{
				ViewData["Exception"] = "На сервере возникла ошибка!";
				return View();
			}
			catch(Exception ex)
			{
				ViewData["Exception"] = "На сервере возникла ошибка!";
				return View();
			}
			
		}
	}
}
