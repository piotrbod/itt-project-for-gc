using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Models
{
    interface ICreditCardRepository
    {
        IEnumerable<CreditCardsAll> GetAllCards();
        IEnumerable<CreditCardSingle> GetSingleCard();
    }
}
