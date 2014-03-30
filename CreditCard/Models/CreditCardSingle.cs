using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace CreditCard.Models
{
    public class CreditCardSingle
    {
        [BsonId]
        public string Id { get; set; }
        public string Number { get; set; }
    }
}