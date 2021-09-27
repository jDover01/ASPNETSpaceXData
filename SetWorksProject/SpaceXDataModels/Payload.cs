using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetWorksProject.SpaceXDataModels
{
    public class Payload
    {
        private string _id { get; set; }
        public string id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                }
            }
        }

        private string _mass_lbs { get; set; }
        public string Mass_lbs
        {
            get
            {
                return _mass_lbs;
            }
            set
            {
                if(value != _mass_lbs)
                {
                    _mass_lbs = value;
                }
            }
        }
    }
}