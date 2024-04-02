using Microsoft.AspNetCore.Mvc;
using CopiaWebApi.Entities;
using CopiaWebApi.Services;

namespace CopiaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputFilesController : ControllerBase
    {
        private readonly InputFileService _inputFileService;

        public InputFilesController(InputFileService service)
        {
            _inputFileService = service;
        }

        // GET: api/InputFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InputFile>>> GetInputFiles()
        {
            var data = await _inputFileService.GetInputFiles();
            return Ok(data);
        }

        // GET: api/InputFiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InputFile>> GetInputFile(int id)
        {
            var data = await _inputFileService.GetInputFile(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/InputFiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInputFile(int id, InputFile inputFile)
        {
            if (id != inputFile.Id)
            {
                return BadRequest();
            }
            await _inputFileService.PutInputFile(id, inputFile);
            return NoContent();
        }

        // POST: api/InputFiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?   linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostInputFile(InputFile inputFile)
        {
            await _inputFileService.PostInputFile(inputFile);
            return Created();
        }

        // DELETE: api/InputFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInputFile(int id)
        {
             await _inputFileService.DeleteInputFile(id);
            return NoContent();
        }
    }
}
