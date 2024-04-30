using LearningAspNETCOREWebAPI.Data;
using LearningAspNETCOREWebAPI.Models;
using LearningAspNETCOREWebAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LearningAspNETCOREWebAPI.Controllers
{
    [Route("api/accounts/{accountId}/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ILogger<CardsController> _logger;
        private readonly INotificationService _notificationService;

        //3 cons, method,prop
        public CardsController(ILogger<CardsController> logger,NotificationService notificationService)
        {
            _logger = logger;
            _notificationService = notificationService;
        }
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


        [HttpGet("{cardId}", Name = "GetCard")]
        public ActionResult<Card> GetCard(int accountId, int cardId)
        {
            _logger.LogInformation("Retrieving data from {@actionName} with {@accountId} and {@cardId}",nameof(GetCard),accountId,cardId);
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

        [HttpPost]
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

            int id = account.Cards.OrderByDescending(x => x.Id).First().Id;

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

        [HttpPatch("{cardId}")]
        public ActionResult<Card> PatchCard(int accountId, int cardId, JsonPatchDocument<UpdateCard> updateCard)
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

            UpdateCard _updateCard = new UpdateCard()
            {
                ExpireDate = card.ExpireDate,
                HolderName = card.HolderName,
                Number = card.Number,
            };

            updateCard.ApplyTo(_updateCard, ModelState);
            
            if(!TryValidateModel(_updateCard))
            {
                return BadRequest(ModelState);
            }


            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            card.Number = _updateCard.Number;
            card.HolderName = _updateCard.HolderName;
            card.ExpireDate = _updateCard.ExpireDate;

            return NoContent();

        }

        [HttpDelete("{cardId}")]
        public ActionResult<Card> DeleteCard(int accountId, int cardId)
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

            account.Cards.Remove(card);
            return NoContent();
        }
    }
}
