using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CreditCardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("getallbycustomerid")]
        public IActionResult GetCreditCardByCustomerId(int customerId)
        {
            var result = _cardService.Get(customerId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Card creditCard)
        {
            var result = _cardService.Add(creditCard);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Card creditCard)
        {
            var result = _cardService.Delete(creditCard);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }

}

