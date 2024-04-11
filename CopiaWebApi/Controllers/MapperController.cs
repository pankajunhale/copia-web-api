using Microsoft.AspNetCore.Mvc;
using CopiaWebApi.Models;
using CopiaWebApi.Services;
using CopiaWebApi.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CopiaWebApi.Controllers
{
    [Route("api/mapper")]
    [ApiController]
    public class MapperController : ControllerBase
    {
        private readonly MapperService _service;

        public MapperController(MapperService mapperService)
        {
            _service = mapperService;
        }

        // GET: api/<ValuesController>
        [HttpGet]        
        public async Task<ActionResult<List<InputOutputMapper>>> Get()
        {
            var data = await _service.GetAll();
            return Ok(data);
        }

        

        // exl file
        // read row from exl and insert into InputFileDataModel
        // list<InputFileDataModel>
        private string FindOutputTagValueByName(string tag)
        {
            // 1
            // outputfile data
            // from tagname -> outputfile.tagName == tag -- no duplicate
            // res {id (PK), tagName}

            // 2
            // from inputoutputmapper where outfieldId = id
            // mapperRes {id, inputfileId, outputFileId=>id}

            // 3
            // inputfile 
            // from where id == inputfileId
            // inputfileRes {id, index, name, isRequired} // account_number

            // 4
            // input file -> exl sheet data
            // read file
            // for loop
            // row [1, 'abcd', 60000] -> generateXML([1, 'abcd', 60000]) old
            // row [1, 'abcd', 60000] -> generateXML(
            // [{ index: 1, HeaderName: 'account_number', value: 60000}
            //{ index: 1, HeaderName: 'f'}
            //{ index: 1, HeaderName: 'd'}
            //{ index: 1, HeaderName: 'g'}
            //{ index: 1, HeaderName: 'g'}
            //{ index: 1, HeaderName: 'f'}

            // }]) new

            var inputDataRow = new List<InputFileDataModel>
            {
                new InputFileDataModel(2, "Component", "InputMapper"),
                new InputFileDataModel(3, "label", "a")
            };
            ///inputDataRow.Add(new InputFileDataModel(2, "Component", "InputMapper"));
            ///
            return "";
        }

        private void FindOutputTagInfoByName(string name)
        {
            // sql query

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InputOutputMapper>> Get(int id)
        {
            var data = await _service.GetInfoById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post(InputOutputMapper data)
        {
            await _service.Create(data);
            return Created();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,InputOutputMapper data)
        {
            if (id == 0) { return BadRequest(); }
            if (id != data.Id) { return BadRequest(); }
            await _service.Update(data);
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}

