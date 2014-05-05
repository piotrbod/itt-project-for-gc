using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CreditCard.Models;
using CreditCardApp.Models;

namespace CreditCard.Controllers
{
    public class CreditCardController : ApiController
    {
        private static readonly CreditCardRepository _cards = new CreditCardRepository("mongodb://rest-user:R35t123@54.247.178.80/Customers");

        // GET api/CreditCard
        public IEnumerable<CreditCardItem> GetAllCards()
        {
            return _cards.GetAllCards().AsQueryable();
        }

        // GET api/CreditCard/5335438707fc2900d8b02967
        public CreditCardItem GetCardById(string id)
        {
            return _cards.GetCardById(id);
        }

        // GET api/CreditCard?111
        public CreditCardItem GetCardByNumber(string number)
        {
            return _cards.GetCardByNumber(number);
        }

        // POST api/CreditCard
        public CreditCardItem AddCard(CreditCardItem value)
        {
            // check if given RiskValue is in range
            if (value.RiskLevel < 1 || value.RiskLevel > 3)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            // check if card number was given
            if (string.IsNullOrEmpty(value.Number))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            CreditCardItem card = _cards.AddCard(value);

            return card;
        }

        // DELETE api/CreditCard/{id}
        public void Delete(string id)
        {
            if (!_cards.RemoveCard(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // POST api/CreditCard/{id}
        public void Update(string id, CreditCardItem value)
        {
            // check if given RiskValue is in range
            if (value.RiskLevel < 1 || value.RiskLevel > 3)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            // check if card number was given
            if (string.IsNullOrEmpty(value.Number))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            if (!_cards.UpdateCard(id, value))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}