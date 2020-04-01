using Repositories.Interface;
using Repositories.RepoImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.DAL;

namespace TaskManager.Controllers
{
    public class QuoteController : ApiController
    {
        private IQuoteRepo _repo;

        public QuoteController()
        {
            this._repo = new QuoteRepo(new QuoteSysEntities());
        }

        public QuoteController(IQuoteRepo repos)
        {
            _repo = repos;
        }

        
    }
}
