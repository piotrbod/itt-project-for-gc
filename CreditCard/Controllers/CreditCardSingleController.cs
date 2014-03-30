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
    public class CreditCardSingleController : ApiController
    {
        private static readonly CreditCardRepository _card = new CreditCardRepository("mongodb://rest-user:R35t123@172.16.76.108/Customers");

        // GET api/CreditCardSingle
        public IEnumerable<CreditCardSingle> GetSingleCard()
        {
            return _card.GetSingleCard().AsQueryable();
        }
    }
}