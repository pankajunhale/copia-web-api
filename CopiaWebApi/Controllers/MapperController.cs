using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using CopiaWebApi.Models;
using Humanizer;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CopiaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapperController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", this.GenerateHeader("dfdf") };
        }

        private string GenerateHeader(string profileId)
        {
            var msgId = DateTime.Now.ToString("yyyyMMddTHHmmssfff");
            string creDtm = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss:fff");
            int noOfTrans = 10;

            var xml = @"<?xml version='1.0' encoding='UTF-8'?>
            <Document xmlns='urn:iso:std:iso:20022:tech:xsd:pain.001.001.03' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
	        <CstmrCdtTrfInitn>
		        <GrpHdr>
			        <MsgId>" + msgId + @"</MsgId>
			        <CreDtTm>" + creDtm + @"</CreDtTm>
			        <Authstn>
				        <Cd>ILEV</Cd>
			        </Authstn>
			        <NbOfTxs>" + noOfTrans + @"</NbOfTxs>
			        <InitgPty>
				        <Id>
					        <OrgId>
						        <Othr>
							        <Id>" + profileId + @"</Id>
						        </Othr>
					        </OrgId>
				        </Id>
			        </InitgPty>
		        </GrpHdr>
            <CstmrCdtTrfInitn>";
            return xml;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


public static class TodoEndpoints
{
	public static void MapTodoEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Todo").WithTags(nameof(Todo));

        group.MapGet("/", () =>
        {
            return new [] { new Todo() };
        })
        .WithName("GetAllTodos")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Todo { ID = id };
        })
        .WithName("GetTodoById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Todo input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateTodo")
        .WithOpenApi();

        group.MapPost("/", (Todo model) =>
        {
            //return TypedResults.Created($"/api/Todos/{model.ID}", model);
        })
        .WithName("CreateTodo")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Todo { ID = id });
        })
        .WithName("DeleteTodo")
        .WithOpenApi();
    }
}}
