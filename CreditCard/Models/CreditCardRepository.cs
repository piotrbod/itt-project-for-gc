using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace CreditCard.Models
{
    public class CreditCardRepository
    {
        MongoClient _client = null;
        MongoServer _server = null;
        MongoDatabase _database = null;
        MongoCollection _creditCards = null;

        public CreditCardRepository(string connection) 
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = "mongodb://localhost:27017";
            }

            _client = new MongoClient(connection);
            _server = _client.GetServer();
            _database = _server.GetDatabase("Customers");
            _creditCards = _database.GetCollection("CreditCards");

            // Reset database and add some default entries 
            _creditCards.RemoveAll();
            for (int index = 1; index < 5; index++)
            {
                CreditCardsAll card = new CreditCardsAll
                {
                    Number = string.Format("{0}", index)
                };
                AddCard(card);
            }
        }

        public IEnumerable<CreditCardsAll> GetAllCards()
        {
            return _creditCards.FindAllAs<CreditCardsAll>();
        }

        public IEnumerable<CreditCardSingle> GetSingleCard()
        {
            return _creditCards.FindOneAs<CreditCardSingle>();
        }

        public CreditCardsAll AddCard(CreditCardsAll item)
        {
            item.Id = ObjectId.GenerateNewId().ToString();
            _creditCards.Insert(item);

            return item;
        }
    }
}