using System.Linq;
using VirtualCreditCardsApi.Models;

namespace VirtualCreditCardsApi.Services
{
    public static class VirtualCreditCardServices
    {
        public static VirtualCreditCardDTO Add(string email, VirtualCreditCardsApiContext context)
        {
            VirtualCreditCard card = new VirtualCreditCard();

            card.ClientEmail = ClientEmailServices.GetAssociatedClientEmail(email, context);
            card.CardNumber = CardNumberServices.GenerateCardNumber(new MasterCardIIN(), card.ClientEmail.Id);

            context.VirtualCreditCards.Add(card);
            context.SaveChanges();

            return new VirtualCreditCardDTO { Id = card.Id, CardNumber = card.CardNumber };
        }

        public static IQueryable<VirtualCreditCardDTO> 
            GetByEmail(string email, VirtualCreditCardsApiContext context) => from card in context.VirtualCreditCards
                                                                              where card.ClientEmail.Email == email
                                                                              orderby card.Id ascending
                                                                              select new VirtualCreditCardDTO()
                                                                              {
                                                                                  Id = card.Id,
                                                                                  CardNumber = card.CardNumber
                                                                              };
    }
}
