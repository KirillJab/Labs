using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class PersonInfo
    {
        public Person Person { get; set; }
        public Address Address { get; set; }
        public BusinessEntityAddress BusinessEntityAddress { get; set; }
        public Password Password { get; set; }
        public PersonPhone PersonPhone { get; set; }

        //public EmailAddress Email { get; set; }

        public PersonInfo()
        {

        }
        public PersonInfo(Person person, Password password, PersonPhone personPhone, Address address, BusinessEntityAddress businessEntityAddress)
        {
            Person = person;
            Address = address;
            BusinessEntityAddress = businessEntityAddress;
            Password = password;
            PersonPhone = personPhone;
        }
        //public PersonInfo(Person person, Password password, EmailAddress email, PersonPhone personPhone, Address address, BusinessEntityAddress businessEntityAddress)
        //{
        //    Person = person;
        //    Address = address;
        //    BusinessEntityAddress = businessEntityAddress;
        //    Email = email;
        //    Password = password;
        //    PersonPhone = personPhone;
        //}
    }
}
