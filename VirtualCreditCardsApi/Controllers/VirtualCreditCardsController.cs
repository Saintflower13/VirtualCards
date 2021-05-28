using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VirtualCreditCardsApi.Models;
using VirtualCreditCardsApi.Services;

namespace VirtualCreditCardsApi.Controllers
{
    [Route("api/virtual-credit-cards")]
    [ApiController]
    public class VirtualCreditCardsController : ControllerBase
    {
        private readonly VirtualCreditCardsApiContext _context;

        public VirtualCreditCardsController(VirtualCreditCardsApiContext context)
        {
            _context = context;
        }

        [HttpGet("{email}")]
        public ActionResult<IQueryable<VirtualCreditCardDTO>> GetVirtualCreditCardList(string email)
        {
            if (String.IsNullOrEmpty(email))
                return BadRequest();

            var virtualCreditCardList = VirtualCreditCardServices.GetByEmail(email, _context);

            if (virtualCreditCardList?.Count() == 0)
                return NotFound();

            return Ok(virtualCreditCardList);
        }

        [HttpPost]
        public ActionResult<VirtualCreditCardDTO> PostVirtualCreditCard(VirtualCreditCardPostDTO cardPostDTO)
        {
            if (String.IsNullOrEmpty(cardPostDTO.Email))
                return BadRequest();    

            var addedCard = VirtualCreditCardServices.Add(cardPostDTO.Email, _context);
            return Created("", addedCard);
        }
    }
}
