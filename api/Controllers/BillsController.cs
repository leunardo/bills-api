using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.domain.dtos;
using application.domain.models;
using application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillsController : ControllerBase
    {
        private readonly ILogger<BillsController> _logger;
        private readonly IBillsService _billsService;

        public BillsController(ILogger<BillsController> logger, IBillsService billsService)
        {
            _logger = logger;
            _billsService = billsService;
        }

        /// <summary>
        /// Get All bills.
        /// </summary>
        /// <response code="200">Returns all bills</response>
        /// <response code="500">If theres a server error</response>            
        [HttpGet]
        [ProducesResponseType(typeof(List<Bill>), 200)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Bill>> Get()
        {
            return Ok(_billsService.GetAllBills());
        }

        /// <summary>
        /// Creates a new bill.
        /// </summary>
        /// <response code="200">Bill is created</response>
        /// <response code="500">If theres a server error</response>            
        [HttpPost]
        [ProducesResponseType(typeof(Boolean), 200)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Create([FromBody] BillDTO bill)
        {
            return Ok(_billsService.CreateBill(bill));
        }
    }
}
