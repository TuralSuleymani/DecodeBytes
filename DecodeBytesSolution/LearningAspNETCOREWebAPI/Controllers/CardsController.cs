using LearningAspNETCOREWebAPI.Data;
using LearningAspNETCOREWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningAspNETCOREWebAPI.Controllers
{
    [Route("api/accounts/{accountId}/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ICollection<Card>> GetCards(int accountId)
        {
            var account = AccountDbContext.Current.Accounts.FirstOrDefault(x => x.Id == accountId);
            if (account is null)
            {
                return BadRequest();
            }
            return Ok(account.Cards);
        }


        [HttpGet("{cardId}", Name ="GetCard")]
        public ActionResult<Card> GetCard(int accountId, int cardId)
        {
            var account = AccountDbContext.Current.Accounts.FirstOrDefault(x => x.Id == accountId);
            if (account is null)
            {
                return BadRequest();
            }
            var card = account.Cards.FirstOrDefault(x => x.Id == cardId);
            if (card is null)
            {
                return BadRequest();
            }
            return Ok(card);
        }

        [HttpPost]//create any resource
        public ActionResult<Card> CreateCard(int accountId, CreateCard createCard)
        {
            //1: check if account exist
            //2. check if number exists
            //3 exist, create a card
            //4.add it to the given account's cards list
            //return response

            var account = AccountDbContext.Current.Accounts.FirstOrDefault(x => x.Id == accountId);
            if (account is null)
            {
                return BadRequest();
            }

            var card = account.Cards.FirstOrDefault(x => x.Number == createCard.Number);
            if (card is not null)
            {
                return BadRequest();
            }

            int id = account.Cards.OrderByDescending(x=>x.Id).First().Id;

            Card _card = new Card()
            {
                ExpireDate = createCard.ExpireDate,
                Number = createCard.Number,
                HolderName = createCard.HolderName,
                Id = ++id
            };

            account.Cards.Add(_card);
            return CreatedAtRoute("GetCard", new { accountId, cardId = _card.Id }, _card);
        }

        [HttpPut("{cardId}")]
        public ActionResult<Card> UpdateCard(int accountId, int cardId, UpdateCard updateCard)
        {
            var account = AccountDbContext.Current.Accounts.FirstOrDefault(x => x.Id == accountId);
            if (account is null)
            {
                return BadRequest();
            }

            var card = account.Cards.FirstOrDefault(x => x.Id == cardId);
            if (card is null)
            {
                return BadRequest();
            }
            card.Number = updateCard.Number;
            card.ExpireDate = updateCard.ExpireDate;
            card.HolderName = updateCard.HolderName;
            return NoContent();//204
        }

    }
}
