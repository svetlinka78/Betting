using AutoMapper;
using Betting.AutoMapper;
using Betting.BackgroundService;
using Betting.Models;
using Betting.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Twilio.TwiML;

namespace Betting.ScheduleTask
{
    public class PullApiCallTask : ScheduleProcessor
    {
        private readonly ISportServices _sportService;
        IMapper _mapper = null;
        public PullApiCallTask (IServiceScopeFactory serviceScopeFactory, ISportServices sportService, IMapper mapper) :base(serviceScopeFactory)
       {    
            _sportService = sportService;
            _mapper = mapper;
       }

        protected override string Schedule => "*/1 * * * *";

        private async Task<Sport> GetXMLData()
        {
            using var client = new HttpClient();
           
            // Accept Header is set to get response in XML format
            client.DefaultRequestHeaders.Add("Accept", "application/xml");
            string xml = "";
            HttpContent body = new StringContent(xml, Encoding.UTF8, "application/xml");
            var response = client.GetAsync("https://sports.ultraplay.net/sportsxml?clientKey=9C5E796D-4D54-42FD-A535-D7E77906541A&sportId=2357&days=7").Result;

            if (response.IsSuccessStatusCode)
            {
                    var content = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                {
                    XmlSerializer responseserializer = new XmlSerializer(typeof(XmlSports));
                    using (StringReader reader = new StringReader(content))
                    {
                        try
                        {
                            var xmlsport = (XmlSports)responseserializer.Deserialize(reader);
                            return xmlsport.Sport;

                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.InnerException);

                        }

                    }

                }
            }
            return null;
        }
        public override async Task ProcessInScope(IServiceProvider serviceProvider)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Sport, SportT>()
                .AfterMap((s, d) => {
                    foreach (var c in d.Event.ToList())
                         c.SportID = d.ID;
                    });

                cfg.CreateMap<Event, EventT>()
                .AfterMap((s, d) =>
                {
                    foreach (var c in d.Match)
                        c.EventID = d.ID;
                });

                cfg.CreateMap<Match, MatchT>()
                   .AfterMap((s, d) =>
                   {
                       foreach (var c in d.Bet)
                           c.MatchID = d.ID;
                   });
                cfg.CreateMap<Bet, BetT>()
                  .AfterMap((s, d) =>
                  {
                      foreach (var c in d.Odd)
                          c.BetID = d.ID;
                  });
                cfg.CreateMap<Odd, OddT>();
               // .ForMember(x => x.BetID, opt => opt.MapFrom(p => p.ID));
            });

            var mapper = config.CreateMapper();
     
            var sports = new List<SportT>();
            var sport = await GetXMLData();
            try
            {

                var sportMapping = mapper.Map<Sport, SportT>(sport);



                //var sList = new List<SportT>();
                //var s1 = new SportT() { ID = "0", Name = "Sport1" };
                //sList.Add(s1);

                //var eList = new List<EventT>();
                //var e1 = new EventT() { ID = "0", SportID = "0", Name = "Event1" };
                //var e2 = new EventT() { ID = "1", SportID = "0", Name = "Event2" };
                //eList.Add(e1);

                //var mList = new List<MatchT>();
                //var m1 = new MatchT() { ID = "0", EventID = "0", Name = "Match1" };
                //mList.Add(m1);


                //e1.Match = mList;
                //s1.Event = eList;
                //s1.Event.Add(e2);

                //sports.Add(s1);
                sports.Add(sportMapping);
                _sportService.BulkInsert(sports);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
          
            Console.WriteLine("PullApiCall : " + DateTime.Now.ToString());
            await Task.Run(() => {
                return Task.CompletedTask;
            });
        }
    }
}
    