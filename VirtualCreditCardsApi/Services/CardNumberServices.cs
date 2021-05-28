using System;
using VirtualCreditCardsApi.Models;

namespace VirtualCreditCardsApi.Services
{
    public static class CheckDigitCalculator
    {
        private static bool IsEvenIndex(int index) => index % 2 == 0;

        private static int SumDigits(int number)
        {
            int digit, sum = 0;

            while (number > 0)
            {
                digit = number % 10; // O resto é o algarismo mais a direita 
                sum += digit;
                number /= 10; // A parte inteira da divisão é o número sem o algarismo mais a direita 
            }

            return sum;
        }

        private static int CalculateOddNumber(int digit)
        {
            digit *= 2;

            if (digit > 9)
                digit = SumDigits(digit);

            return digit;
        }

        public static int CalculateCheckDigit(string cardNumber)
        {
            int sum = 0, digit;

            for (int i = 0; i < cardNumber.Length; i++)
            {
                digit = (int)Char.GetNumericValue(cardNumber[i]);
                sum += IsEvenIndex(i + 1) ? digit : CalculateOddNumber(digit);
            }

            return 10 - (sum % 10);
        }
    }

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

        private static string GenerateCheckDigit(string cardNumber) => 
            CheckDigitCalculator.CalculateCheckDigit(cardNumber).ToString();

        public static string GenerateCardNumber(BaseCardIIN cardIIN, int clientId)
        {
            var cardNumber = GenerateIssuerIdNumber(cardIIN) + GenerateClientId(clientId);
            return cardNumber + GenerateCheckDigit(cardNumber);
        }
    }
}
