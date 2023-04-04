﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
    
namespace Betting.Models
{
	[XmlRoot(ElementName = "Odd")]
	public class Odd
	{
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "ID")]
		public string ID { get; set; }
		[XmlAttribute(AttributeName = "Value")]
		public string Value { get; set; }
		[XmlAttribute(AttributeName = "SpecialBetValue")]
		public string SpecialBetValue { get; set; }
	}

	[XmlRoot(ElementName = "Bet")]
	public class Bet
	{
		[XmlElement(ElementName = "Odd")]
		public List<Odd> Odd { get; set; }
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "ID")]
		public string ID { get; set; }
		[XmlAttribute(AttributeName = "IsLive")]
		public string IsLive { get; set; }
	}

	[XmlRoot(ElementName = "Match")]
	public class Match
	{
		[XmlElement(ElementName = "Bet")]
		public List<Bet> Bet { get; set; }
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "ID")]
		public string ID { get; set; }
		[XmlAttribute(AttributeName = "StartDate")]
		public string StartDate { get; set; }
		[XmlAttribute(AttributeName = "MatchType")]
		public string MatchType { get; set; }
	}

	[XmlRoot(ElementName = "Event")]
	public class Event
	{
		[XmlElement(ElementName = "Match")]
		public List<Match> Match { get; set; }
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "ID")]
		public string ID { get; set; }
		[XmlAttribute(AttributeName = "IsLive")]
		public string IsLive { get; set; }
		[XmlAttribute(AttributeName = "CategoryID")]
		public string CategoryID { get; set; }
	}

	[XmlRoot(ElementName = "Sport")]
	public class Sport
	{
		[XmlElement(ElementName = "Event")]
		public List<Event> Event { get; set; }
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "ID")]
		public string ID { get; set; }
	}

	[XmlRoot(ElementName = "XmlSports")]
	public class XmlSports
	{
		[XmlElement(ElementName = "Sport")]
		public Sport Sport { get; set; }
		[XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsd { get; set; }
		[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
		[XmlAttribute(AttributeName = "CreateDate")]
		public string CreateDate { get; set; }
	}

}
