﻿using System;
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
        private static readonly CreditCardRepository _cards = new CreditCardRepository("mongodb://rest-user:R35t123@172.16.76.108/Customers");

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
    }
}