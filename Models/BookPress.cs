﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// The entity class used to represent the publishing house information
    /// </summary>

    public class BookPress
    {
        public int PressId { get; set; }   //Press Id
        public string PressName { get; set; }  //Press Name
        public string PressTel { get; set; }   //Press Telephone number
        public string PressContact { get; set; }  //Press Contact
        public string PressAddress { get; set; }   //Press Address
    }
}
