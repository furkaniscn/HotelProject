﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Mail { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime Date { get; set; }
        public int MessageCategoryID { get; set; }//Tablolar arası ilişki örneği(1-n)
        public MessageCategory? MessageCategory { get; set; }
    }
}
