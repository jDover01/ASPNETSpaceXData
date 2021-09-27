using Newtonsoft.Json;
using SetWorksProject.SpaceXDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SetWorksProject
{
    public partial class SpaceXData : System.Web.UI.Page
    {
        private List<Launch> Launches { get; set; } = new List<Launch>();
        private List<Payload> Payloads { get; set; } = new List<Payload>();
        private List<Rocket> Rockets { get; set; } = new List<Rocket>();
        //ONLY NEED TO INITIALIZE ONCE 
        private static HttpClient Client = new HttpClient();
        /// <summary>
        /// PAGE LOAD
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventAgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// IN ORDER FOR THE SORTING TO WORK I HAD TO USE NEEDDATASOURCE
        /// </summary>
        /// <param name="sender">object/param>
        /// <param name="e">GridNeedDataSourceEventArgs</param>
        protected void RadGrid2_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGrid2.DataSource = GetMissions();
        }
        /// <summary>
        /// GET MISSIONS
        /// </summary>
        /// <returns></returns>
        public List<Mission> GetMissions()
        {
            List<Mission> missions = new List<Mission>();

            try
            {
                GetRockets();
                GetPayloads();
                if (Launches.Count == 0)
                {
                    Launches = MakeRequest<Launch>("https://api.spacexdata.com/v5/launches");
                }

                Launches.ForEach(x =>
                {
                    missions.Add(new Mission
                    {
                        RocketName = Rockets.Where(w => w.id == x.Rocket).FirstOrDefault().name,
                    //MissionDate = DateTime.ParseExact(x.Date_utc.ToString().Replace("CDT", "-05:00"), "MMM dd, yyyy H:mm:ss tt zzz", null),
                    //TO DO
                    //CONVERT DATE TIME TO CST
                    MissionDate = x.Date_utc,
                        PayloadMass = GetPayloadMass(x.Payloads),
                        LaunchSuccess = x.Success.HasValue ? x.Success.Value : false
                    });
                    var maxPayloadMass = missions.Max(m => m.PayloadMass);
                    missions.ForEach(y => y.Rank = (y.PayloadMass == maxPayloadMass) ? 1 : 0);
                });
            }
            catch(Exception ex)
            {
                //TO DO LOGGING
            }
            return missions;
        }
        /// <summary>
        /// GENERIC METHOD TO MAKE ALL REQUESTS FOR SPACE X DATA
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="uri">string</param>
        /// <returns>List of Generic Type</returns>
        private List<T> MakeRequest<T>(string uri)
        {
            List<T> data = new List<T>();
            try
            {
                //specify to use TLS 1.2 as default connection
                System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var launchTask = Client.GetAsync(uri).Result;
                var jsonString = launchTask.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<T>>(jsonString);
            }
            catch (Exception ex)
            {
                //TO DO LOGGING
            }

            return data;
        }
        /// <summary>
        /// GET THE PAYLOAD MASS SINCE PAYLOAD IS AN ARRAY THE MASS_LBS NEEDS TO BE SUMMED UP
        /// </summary>
        /// <param name="launchPayloads">List&lt;string&gt;</param>
        /// <returns></returns>
        private double GetPayloadMass(List<string> launchPayloads)
        {
            double totalMass = 0;
            try
            {
                launchPayloads.ForEach(x =>
                {
                    var payload = GetPayloadById(x);
                    try
                    {
                        totalMass += Convert.ToDouble(String.IsNullOrWhiteSpace(payload.Mass_lbs) ? "0" : payload.Mass_lbs);
                    }
                    catch (Exception ex)
                    {
                        var a = ex;
                    }
                });
            }
            catch(Exception ex)
            {
                //TO DO LOGGING
            }
            return totalMass;
        }
        /// <summary>
        /// GET PAYLOAD BY ID
        /// </summary>
        /// <param name="payloadId"></param>
        /// <returns></returns>
        private Payload GetPayloadById(string payloadId)
        {
            return Payloads.Where(w => w.id == payloadId).FirstOrDefault();
        }
        /// <summary>
        /// GET ROCKETS / SET ROCKETS
        /// </summary>
        private void GetRockets()
        {
            if (Rockets.Count == 0)
            {
                Rockets = MakeRequest<Rocket>("https://api.spacexdata.com/v4/rockets");
            }
        }
        /// <summary>
        /// GET PAYLOADS / SET PAYLOADS
        /// </summary>
        private void GetPayloads()
        {
            if (Payloads.Count == 0)
            {
                Payloads = MakeRequest<Payload>("https://api.spacexdata.com/v4/payloads");
            }
        }
    }
}