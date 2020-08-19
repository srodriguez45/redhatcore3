using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace com.redhat.simplenetcore.services.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        protected IConfiguration Config;

        public ValuesController(IConfiguration configuration)
        {
            this.Config = configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            return new string[] {
                Environment.GetEnvironmentVariable("FIRST"),
                Environment.GetEnvironmentVariable("SECOND"),
                this.Config.GetSection("Config:value1").Value,
                this.Config.GetSection("Config:value2").Value,
                this.Config.GetSection("Config:value3").Value
            };

        }
    }
}
