using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetWorksProject.SpaceXDataModels
{
    public class Launch
    {
        private string _rocket { get; set; }
        public string Rocket
        {
            get
            {
                return _rocket;
            }
            set
            {
                if(value != _rocket)
                {
                    _rocket = value;
                }
            }
        }

        private List<string> _payloads { get; set; }
        public List<string> Payloads
        {
            get
            {
                return _payloads;
            }
            set
            {
                if(value != _payloads)
                {
                    _payloads = value;
                }
            }
        }

        private DateTime _date_utc { get; set; }
        public DateTime Date_utc
        {
            get
            {
                return _date_utc;
            }
            set
            {
                if(value != _date_utc)
                {
                    _date_utc = value;
                }
            }
        }

        private bool? _success { get; set; }
        public bool? Success
        {
            get
            {
                return _success;
            }
            set
            {
                if (value != _success)
                {
                    _success  = value;
                }
            }
        }
    }
}