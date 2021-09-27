using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetWorksProject.SpaceXDataModels
{
    public class Mission
    {
        //private string _rocketName { get; set; }
        public string RocketName
        {
            get; set;
            //get
            //{
            //    return _rocketName;
            //}
            //set
            //{
            //    if (value != _rocketName)
            //    {
            //        _rocketName = value;
            //    }
            //}
        }

        //private DateTime _missionDate { get; set; }
        public DateTime MissionDate
        {
            get; set;
            //get
            //{
            //    return _missionDate;
            //}
            //set
            //{
            //    if (value != _missionDate)
            //    {
            //        _missionDate = value;
            //    }
            //}
        }

        //private double _payloadMass { get; set; }
        public double PayloadMass
        {
            get; set;
            //get
            //{
            //    return _payloadMass;
            //}
            //set
            //{
            //    if (value != _payloadMass)
            //    {
            //        _payloadMass = value;
            //    }
            //}
        }

        //private bool _launchSuccess { get; set; }
        public bool LaunchSuccess
        {
            get; set;
            //get
            //{
            //    return _launchSuccess;
            //}
            //set
            //{
            //    if (value != _launchSuccess)
            //    {
            //        _launchSuccess = value;
            //    }
            //}
        }

        public int Rank { get; set; }
    }
}