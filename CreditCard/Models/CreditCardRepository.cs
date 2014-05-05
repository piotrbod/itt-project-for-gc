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
            _creditCards = _database.GetCollection("CreditCard");

            // Reset database and add some default entries 
            //_creditCards.RemoveAll();
            /*
            for (int index = 1; index < 5; index++)
            {
                CreditCardItem card = new CreditCardItem
                {
                    Number = string.Format("{0}{0}{0}", index)
                };
                AddCard(card);
            }*/
        }

        public IEnumerable<CreditCardItem> GetAllCards()
        {
            return _creditCards.FindAllAs<CreditCardItem>();
        }

        public CreditCardItem GetCardById(string id)
        {
            IMongoQuery query = Query.EQ("_id", id);
            return _creditCards.FindOneAs<CreditCardItem>(query);
        }
        public CreditCardItem GetCardByNumber(string number)
        {
            IMongoQuery query = Query.EQ("Number", number);
            return _creditCards.FindOneAs<CreditCardItem>(query);
        }
        public CreditCardItem AddCard(CreditCardItem item)
        {
            item.Id = ObjectId.GenerateNewId().ToString();
            _creditCards.Insert(item);

            return item;
        }

        public bool RemoveCard(string id)
        {
            IMongoQuery query = Query.EQ("_id", id);
            SafeModeResult result = _creditCards.Remove(query);

            return result.DocumentsAffected == 1;

        }

        public bool UpdateCard(string id, CreditCardItem item)
        {
            IMongoQuery query = Query.EQ("_id", id);
            IMongoUpdate update = Update
                .Set("Number", item.Number)
                .Set("RiskLevel", item.RiskLevel);
            SafeModeResult result = _creditCards.Update(query, update);

            return result.UpdatedExisting;
        }
    }
}