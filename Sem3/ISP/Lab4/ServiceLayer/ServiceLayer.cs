using Converter;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class ServiceLayer
    {
        public DataAccessLayer.DataAccessLayer dal;
        public ServiceLayer(DataAccessLayer.Options.ConnectionOptions options, IParser parser)
        {
            dal = new DataAccessLayer.DataAccessLayer(options, parser);
        }

        public PersonInfo GetPersonInfo(int id) 
        {
            Person person = dal.GetPerson(id);
            PersonInfo personInfo = GetInfo(person);
            return personInfo;
        }

        public List<PersonInfo> GetPersonInfoList(int count)
        {
            List<PersonInfo> list = new List<PersonInfo>();
            PersonInfo person;
            for (int id = 1; id < count; id++)
            {
                person = GetPersonInfo(id);
                list.Add(person);
            }
            return list;
        }
        public List<PersonInfo> GetPersonInfoList(int startIndex, int count)
        {
            List<PersonInfo> list = new List<PersonInfo>();
            PersonInfo person;
            for (int id = startIndex; id < startIndex + count; id++)
            {
                person = GetPersonInfo(id);
                list.Add(person);
            }
            return list;
        }
        PersonInfo GetInfo(Person person)
        {
            PersonInfo personInfo = new PersonInfo();
            int id = person.BusinessEntityID;

            personInfo.Address = dal.GetPersonOpts<Address>(id);
            personInfo.BusinessEntityAddress = dal.GetPersonOpts<BusinessEntityAddress>(id);
            personInfo.Password = dal.GetPersonOpts<Password>(id);
            personInfo.Person = dal.GetPersonOpts<Person>(id);
            personInfo.PersonPhone = dal.GetPersonOpts<PersonPhone>(id);
            return personInfo;
        }
    }
}
