using System.Collections.Generic;
using WebApi.Common.Models;

namespace WebApi.Common.Providers
{
    public interface IProcessProvider
    {
        IEnumerable<ProcessModel> GetAll();
        IEnumerable<ProcessModel> GetByName(string name);
        ProcessModel GetById(int id);
        void Kill(int id);
        void Start(string fileName);
    }
}