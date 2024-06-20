using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Member : Person
    {
        public string MemberID { get; set; }
        public string MembershipType { get; set; }
        public string MaxBooksAllowed { get; set; }

        public Member(string name, string id, string contactNumber, string memberID, string membershipType, string maxBooksAllowed)
            : base(name, id, contactNumber) // to get the constructor of Person class
        {
            MemberID = memberID;
            MembershipType = membershipType;
            MaxBooksAllowed = maxBooksAllowed;
        }

        public string GetMemberDetails()
        {
            return GetMemberDetails() + $", MemberID: {MemberID}, Membership Type: {MembershipType}, Max Books Allowed: {MaxBooksAllowed}";
        }
    }

    public class Staff : Person
    {
        public string StaffID { get; set; }
        public string JobTitle { get; set; }

        public Staff(string name, string id, string contactNumber, string staffID, string jobTitle)
            : base(name, id, contactNumber)
        {
            StaffID = staffID;
            JobTitle = jobTitle;
        }

        public string GetStaffDetails()
        {
            return GetStaffDetails() + $", StaffID: {StaffID}, Job Title: {JobTitle}";
        }
    }
}
