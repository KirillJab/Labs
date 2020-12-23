using Converter;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Threading;

namespace ServiceLayer
{
    public class ServiceLayer : IServiceLayer
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
        public async Task<PersonInfo> GetPersonInfoAsync(int id)
        {
            Person person = await dal.GetPersonAsync(id);
            PersonInfo personInfo = GetInfo(person);
            return personInfo;
        }

        public List<PersonInfo> GetPersonInfoList(int count)
        {
            List<PersonInfo> list = GetPersonInfoList(1, count);
            return list;
        }
        public async Task<List<PersonInfo>> GetPersonInfoListAsync(int count)
        {
            List<PersonInfo> list = await GetPersonInfoListAsync(1, count);
            return list;
        }
        public async Task<List<PersonInfo>> GetPersonInfoListAsync(int startIndex, int count)
        {
            List<Task<PersonInfo>> tasks = new List<Task<PersonInfo>>();

            for (int id = startIndex; id < startIndex + count; id++)
            {
                int i = id;
                tasks.Add(Task.Run(() => GetPersonInfoAsync(i)));
            }
            var res = await Task.WhenAll(tasks);
            return res.ToList();
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
        async Task<PersonInfo> GetInfoAsync(Person person)
        {
            PersonInfo personInfo = new PersonInfo();
            int id = person.BusinessEntityID;
            //List<Task<PersonInfo>> tasks = new List<Task<PersonInfo>>();
            //tasks.Add(Task.Run(() => dal.GetPersonOpts<Address>(id)));
            //tasks.Add(Task.Run(() => dal.GetPersonOpts<BusinessEntityAddress>(id)));
            //tasks.Add(Task.Run(() => dal.GetPersonOpts<Password>(id)));
            //tasks.Add(Task.Run(() => dal.GetPersonOpts<Person>(id)));
            //tasks.Add(Task.Run(() => dal.GetPersonOpts<PersonPhone>(id)));
            //PersonInfo[] personInfos = await Task.WhenAll(tasks);
            personInfo.Address = await dal.GetPersonOptsAsync<Address>(id);
            personInfo.BusinessEntityAddress = await dal.GetPersonOptsAsync<BusinessEntityAddress>(id);
            personInfo.Password = await dal.GetPersonOptsAsync<Password>(id);
            personInfo.Person = await dal.GetPersonOptsAsync<Person>(id);
            personInfo.PersonPhone = await dal.GetPersonOptsAsync<PersonPhone>(id);
            return personInfo;
        }
    }
}