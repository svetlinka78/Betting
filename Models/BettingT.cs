using Betting.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Betting.Models
{
   
	public class SportT
	{
		[Key]
		public string ID { get; set; }
		public virtual ICollection<EventT> Event { get; set; }
		public string Name { get; set; }
		
	}
	public class OddT
	{

		[Key]
		public string ID { get; set; }
		public string BetID { get; set; }
		public virtual BetT Bet { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public string SpecialBetValue { get; set; }
	}

	public class BetT
	{
		[Key]
		public string ID { get; set; }
		public string MatchID { get; set; }
		public virtual MatchT Match { get; set; }
		public virtual ICollection<OddT> Odd { get; set; }
		public string Name { get; set; }
		public string IsLive { get; set; }
	}

	public class MatchT
	{
		[Key]
		public string ID { get; set; }
		public string EventID { get; set; }
		public virtual EventT Event { get; set; }
		public virtual ICollection<BetT> Bet { get; set; }
		public string Name { get; set; }
		public string StartDate { get; set; }
		public string MatchType { get; set; }
	}

	public class EventT
	{

		[Key]
		public string ID { get; set; }
		public string SportID { get; set; }
		public virtual SportT Sport{ get; set; }
		public  virtual ICollection<MatchT> Match { get; set; }
		public string Name { get; set; }
		public string IsLive { get; set; }
		public string CategoryID { get; set; }
	}
}
