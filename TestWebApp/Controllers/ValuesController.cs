using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IMapper mapper;

        public ValuesController(IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(IDataPage<Language>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(void), StatusCodes.Status415UnsupportedMediaType)]
        public IDataPage<Language> Get()
        {
            var languagesList = new LanguageEntity[] { new LanguageEntity { Code = "en", Description = "english" }, new LanguageEntity { Code = "it", Description = "italian" } };
            var languagePagedList = new PagedList<LanguageEntity>(languagesList.AsQueryable(), 1, 10);

            return mapper.Map<IPagedList<LanguageEntity>, IDataPage<Language>>(languagePagedList);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
