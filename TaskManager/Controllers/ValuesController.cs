using DataAccess.DAL;
using Repositories.Interface;
using Repositories.RepoImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.ModelsDTO;
using TaskManager.Filters;
using System.Web.Http.Description;

namespace TaskManager.Controllers
{
    //[Authorize]
    [CustomFilter]
    public class ValueController : ApiController
    {
        private IQuoteRepo _repo;

        public ValueController()
        {
            this._repo = new QuoteRepo(new QuoteSysEntities());
        }

        public ValueController(IQuoteRepo repos)
        {
            _repo = repos;
        }
        // GET api/values
        public IEnumerable<Quote> Get()
        {
            using(var uow = new UnitofWork(new QuoteSysEntities()))
            {
                return uow.Quotes.GetAll();
            }
        }

        // GET api/values/5
        [ResponseType(typeof(Quote))]
        public IHttpActionResult Get(int id)
        {
            using (var uow = new UnitofWork(new QuoteSysEntities()))
            {
                var data = uow.Quotes.GetbyID(id);
                if(data == null)
                {
                    throw new ExceptionRepo("Task Not Found");
                }

                return Ok(data);
            }
        }

        public IEnumerable<QuoteDTO> GetSelect()
        {
            using (var uow = new UnitofWork(new QuoteSysEntities()))
            {
                return uow.Quotes.Selection();
            }
        }

        // POST api/values
        public void Post([FromBody]Quote tasks)
        {
            using (var uow = new UnitofWork(new QuoteSysEntities()))
            {
                uow.Quotes.Add(tasks);
                uow.Complete();
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Quote tasks)
        {
            using (var uow = new UnitofWork(new QuoteSysEntities()))
            {
                tasks.QuoteID = id;
                uow.Quotes.Update(tasks);
                uow.Complete();
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            using (var uow = new UnitofWork(new QuoteSysEntities()))
            {
                Quote q1 = uow.Quotes.GetbyID(id);
                q1.QuoteID = id;
                uow.Quotes.Remove(q1);
                uow.Complete();
            }
        }
    }
}
