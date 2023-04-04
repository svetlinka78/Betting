using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.Models
{
	public class SportV
	{
		public string ID { get; set; }
		public virtual ICollection<EventV> Event { get; set; }

		public string Name { get; set; }
	}

	public class OddV
	{

		public string ID { get; set; }
		public string BetID { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public string SpecialBetValue { get; set; }
	}

	public class BetV
	{
		public string ID { get; set; }
		public string MatchID { get; set; }
		public virtual ICollection<OddV> Odd { get; set; }
		public string Name { get; set; }
		public string IsLive { get; set; }
	}

	public class MatchV
	{
		public string ID { get; set; }
		public string EventID { get; set; }
		public virtual ICollection<BetV> Bet { get; set; }
		public string Name { get; set; }
		public string StartDate { get; set; }
		public string MatchType { get; set; }
	}

	public class EventV
	{

		public string ID { get; set; }
		public string SportID { get; set; }
		public virtual ICollection<MatchV> Match { get; set; }
		public string Name { get; set; }
		public string IsLive { get; set; }
		public string CategoryID { get; set; }
    }
}
