﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Member : Person // member inherits properties from 'Person' class
    {
        public string MemberID { get; set; }
        public string MembershipType { get; set; }
        public string MaxBooksAllowed { get; set; }

        // initialize 'member' object
        public Member(string name, string id, string contactNumber, string memberID, string membershipType, string maxBooksAllowed)
            : base(name, id, contactNumber) // call 'Person' constructor to initialize inherited properties (Name, ID, ContactNumber)
        {
            MemberID = memberID;
            MembershipType = membershipType;
            MaxBooksAllowed = maxBooksAllowed;
        }

        // method to return string that includes details from 'Person' class and additional details specific to 'Member'
        public override string ToString()
        {
            return $"{Name,-20} {ID,-5} {ContactNumber,-15} {MemberID,-10} {MembershipType,-18} {MaxBooksAllowed,-5}";
        }
    }

    public class Staff : Person // Staff inherits properties from 'Person' class
    {
        public string StaffID { get; set; }
        public string JobTitle { get; set; }

        // initialize object Staff
        public Staff(string name, string id, string contactNumber, string staffID, string jobTitle)
            : base(name, id, contactNumber) // call 'Person' constructor to initialize inherited properties
        {
            StaffID = staffID;
            JobTitle = jobTitle;
        }

        // method to return string that includes details from 'Person' class and additional details specfic to 'Staff'
        public override string ToString()
        {
            return $"{Name,-20} {ID,-5} {ContactNumber,-15} {StaffID,-10} {JobTitle,-20}";
        }
    }
}
