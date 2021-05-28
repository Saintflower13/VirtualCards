using System;
using VirtualCreditCardsApi.Models;

namespace VirtualCreditCardsApi.Services
{
    public static class CardNumberServices
    {
        private static string GenerateIssuerIdNumber(BaseCardIIN cardIIN)
        {
            Random randNumber = new Random();
            return randNumber.Next(cardIIN.Min, cardIIN.Max).ToString();
        }

        private static string GenerateClientId(int clientId)
        {
            return clientId.ToString().PadLeft(9, '0');
        }

        private static string CalculateDV()
        {
            Random randNumber = new Random();
            return randNumber.Next(10).ToString();
        }

        public static string GenerateCardNumber(BaseCardIIN cardIIN, int clientId)
        {   
            return GenerateIssuerIdNumber(cardIIN) + GenerateClientId(clientId) + CalculateDV();
        }
    }
}
