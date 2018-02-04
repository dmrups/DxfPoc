using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netDxf;
using Newtonsoft.Json;

namespace DxfPoc.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class MainController : Controller
    {
        [HttpGet("test")]
        public JsonResult Test()
        {
            var dxf1 = DxfDocument.Load(@"Drawings\Коллектор.dxf");
            var dxf2 = DxfDocument.Load(@"Drawings\Втулки.dxf");
            var dxf3 = DxfDocument.Load(@"Drawings\Детали для изг.dxf");

            return new JsonResult(new
            {
                Circles = dxf2.Circles,
                Lines = dxf2.Lines
            },
            new JsonSerializerSettings
            {
                ContractResolver = new ShouldSerializeContractResolver()
            });
        }
    }
}