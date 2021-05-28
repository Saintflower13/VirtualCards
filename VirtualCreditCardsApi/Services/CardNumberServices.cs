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

        private static bool IsEvenIndex(int index) => index % 2 == 0;

        private static int CalculateOddNumber(int digit)
        {
            digit = digit * 2;

            if (digit > 9)
            {
                string mult_str = Convert.ToString(digit);
                digit = (int)Char.GetNumericValue(mult_str[0]) + (int)Char.GetNumericValue(mult_str[1]);
            }   

            return digit;
        }

        private static string CalculateDV(string cardNumber)
        {
            int digitsSum = 0;
            int digit, dv = 0;

            for (int i = 0; i < cardNumber.Length; i++)
            {
                digit = (int)Char.GetNumericValue(cardNumber[i]);

                if (IsEvenIndex(i + 1))
                    digitsSum += digit;
                else
                    digitsSum += CalculateOddNumber(digit);
            }

            dv = 10 - (digitsSum % 10);
            return dv.ToString();
        }

        public static string GenerateCardNumber(BaseCardIIN cardIIN, int clientId)
        {
            string cardNumber = GenerateIssuerIdNumber(cardIIN) + GenerateClientId(clientId);
            return cardNumber + CalculateDV(cardNumber);
        }
    }
}
