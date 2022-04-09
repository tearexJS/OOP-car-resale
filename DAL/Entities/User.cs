using System;
using System.Collections.Generic;

namespace DAL
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public List<Advertisement> Advertisements { get; set; }

    }
}
