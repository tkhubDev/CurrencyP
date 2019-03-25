using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Currency.Models
{
	public class Currency
	{
		[Serializable()]
		public class Valute
		{
			[XmlElement(ElementName = "NumCode")]
			public string NumCode { get; set; }
			[XmlElement(ElementName = "CharCode")]
			public string CharCode { get; set; }
			[XmlElement(ElementName = "Nominal")]
			public string Nominal { get; set; }
			[XmlElement(ElementName = "Name")]
			public string Name { get; set; }
			[XmlElement(ElementName = "Value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName = "ID")]
			public string ID { get; set; }
		}

		[Serializable()]
		public class ValCurs
		{
			[XmlElement(ElementName = "Valute")]
			public List<Valute> Valute { get; set; }
			[XmlAttribute(AttributeName = "Date")]
			public string Date { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
		}

	}

}
