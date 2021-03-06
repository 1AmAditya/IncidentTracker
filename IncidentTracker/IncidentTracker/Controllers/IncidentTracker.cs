using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentTracker.Common.Interface;
using IncidentTracker.Common.Model;
using Microsoft.AspNetCore.Mvc;
using static IncidentTracker.Common.Enum.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IncidentTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentTracker : ControllerBase
    {
        public IIncidentBusinessLayer incidentBusinessLayer;
        public IIncidentData incidentData;
        public IncidentTracker(IIncidentBusinessLayer incidentBusinessLayer , IIncidentData incidentData)
        {
            this.incidentBusinessLayer = incidentBusinessLayer;
            this.incidentData = incidentData;
        }



        // GET: api/<IncidentTracker>
        [HttpGet]
        public IEnumerable<IncidentDataModel> Get()
        {
            return incidentData.GetIncidentDatas;
        }

        // GET api/<IncidentTracker>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IncidentDataModel result =  incidentData.GetIncidentDatas.Where(x => x.IncidentID == id).FirstOrDefault();
           return  Ok(result);

        }

        // POST api/<IncidentTracker>
        [HttpPost]
        [Route("InsertUpdate")]
        public IActionResult Post([FromBody] IncidentDataModel indicentDataModel)
        {
            IncidentDataModel result;
            if (!ModelState.IsValid)
            {
                return BadRequest("Model validation failed");
            }
            if(indicentDataModel.IncidentID == 0)
            {
                 result = incidentBusinessLayer.IncidentInsertUpdate(indicentDataModel);
            }
            else
            {
                IncidentDataModel item = incidentData.GetIncidentDatas.Where(x => x.IncidentID == indicentDataModel.IncidentID).FirstOrDefault();

                if (item== null)
                {
                    return BadRequest("Wrong request ID");
                }
                result = incidentBusinessLayer.IncidentInsertUpdate(indicentDataModel);
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateStatus")]
        public IActionResult PutStatus(int Id , StatusEnum statusEnum)
        {
            IncidentDataModel item = incidentData.GetIncidentDatas.Where(x => x.IncidentID == Id).FirstOrDefault();

            if (item == null)
            {
                return BadRequest("Wrong request ID");
            }
            IncidentDataModel result = incidentBusinessLayer.IncidentStatusUpdate(Id, statusEnum);

            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateSeverity")]
        public IActionResult PutSeverity(int Id, SeverityEnum statusEnum)
        {
            IncidentDataModel item = incidentData.GetIncidentDatas.Where(x => x.IncidentID == Id).FirstOrDefault();

            if (item == null)
            {
                return BadRequest("Wrong request ID");
            }
            IncidentDataModel result = incidentBusinessLayer.IncidentSeverityUpdate(Id, statusEnum);

            return Ok(result);
        }


        // DELETE api/<IncidentTracker>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id <0)
            {
                return BadRequest("Idis null");
            }
            bool result = incidentBusinessLayer.IncidentDelete(id);
            return Ok(result);
        }
    }
}
