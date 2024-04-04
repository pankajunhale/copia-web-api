using CopiaWebApi.Entities;
using CopiaWebApi.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace CopiaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutputFileController : ControllerBase
    {
        private readonly OutputFileService _outputFileService;
        public OutputFileController(OutputFileService outputFileService) { 
            _outputFileService = outputFileService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutputFile>>> GetOutputFiles()
        {
            var data = await _outputFileService.GetOutputFiles();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutputFile>> GetOutputFile(int id)
        {
            var data = await _outputFileService.GetOutputFile(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddOutFileTag(OutputFile outputFile)
        {
            await _outputFileService.PostOutputFile(outputFile);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOutFileTag(int id, OutputFile outputFile)
        {
            if (id != outputFile.Id)
            {
                return BadRequest();
            }
            await _outputFileService.PutOutputFile(outputFile);
            return NoContent();
        }
    }
}
