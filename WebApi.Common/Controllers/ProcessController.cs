using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Common.Models;
using WebApi.Common.Providers;

namespace WebApi.Common.Controllers
{
    public class ProcessController : ApiController
    {
        private IProcessProvider provider = new ProcessProvider();

        // GET api/process
        [HttpGet]
        public IEnumerable<ProcessModel> GetProcesses()
        {
            return provider.GetAll();
        }
         
        // GET api/process/5
        [HttpGet]
        public ProcessModel Get(int id)
        {
            var model = provider.GetById(id);
            if (model == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "process not found"));
            }

            return model;
        }

        [NonAction]
        public void TestMethod()
        {
            
        }

        public IEnumerable<ProcessModel> GetByName(string name)
        {
            return provider.GetByName(name);
        } 

        // POST api/process
        public void Post([FromBody]string value)
        {
            provider.Start(value);
        }

        // DELETE api/process/5
        public void Delete(int id)
        {
            provider.Kill(id);
        }
    }


}
