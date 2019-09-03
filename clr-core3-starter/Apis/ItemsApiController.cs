using clr_core3_starter.Infrastructure;
using clr_core3_starter.Models;
using clr_core3_starter.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clr_core3_starter.Apis
{
    [Route("api/items")]
    public class ItemsApiController : Controller
    {
        IItemsRepository _ItemsRepository;
        ILogger _Logger;

        public ItemsApiController(IItemsRepository itemsRepo, ILoggerFactory loggerFactory)
        {
            _ItemsRepository = itemsRepo;
            _Logger = loggerFactory.CreateLogger(nameof(ItemsApiController));
        }

        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(List<Item>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> States()
        {
            try
            {
                var states = await _ItemsRepository.GetItemsAsync();
                return Ok(states);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }


        // GET api/items/5
        [HttpGet("{id}", Name = "GetItemRoute")]
        [NoCache]
        [ProducesResponseType(typeof(Item), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Customers(string id)
        {
            try
            {
                var item = await _ItemsRepository.GetItemAsync(id);
                return Ok(item);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }
    }
}
