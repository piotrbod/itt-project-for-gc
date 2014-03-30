using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Models
{
    interface ICreditCardRepository
    {
        IEnumerable<CreditCardItem> GetAllCards();
        CreditCardItem GetCardById(string id);
        CreditCardItem GetCardByNumber(string number);
        CreditCardItem AddCard(CreditCardItem item);
    }
}
