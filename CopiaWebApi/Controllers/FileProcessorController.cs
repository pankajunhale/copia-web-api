using CopiaWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CopiaWebApi.Controllers
{
    [Route("api/file-processor")]
    [ApiController]
    public class FileProcessorController : ControllerBase
    {
        private readonly MapperService _service;
        private readonly ILogger<FileProcessorController> _logger;

        public FileProcessorController(ILogger<FileProcessorController> logger, MapperService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get()
        {       
            var result = await this._service.ProcessAndGenerateBankXml();            
            this._logger.LogInformation(JsonConvert.SerializeObject(result));
            return Ok(result);
        }
    }
}
