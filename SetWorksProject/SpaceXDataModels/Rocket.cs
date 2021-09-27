using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetWorksProject.SpaceXDataModels
{
    public class Rocket
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
                if(value != _id)
                {
                    _id = value;
                }
            }
        }

        private string _name { get; set; }
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                }
            }
        }
    }
}