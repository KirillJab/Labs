using DataAccessLayer.Models;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IServiceLayer
    {
        PersonInfo GetPersonInfo(Person person);
        List<PersonInfo> GetPersonInfoList(int count);
    }
}