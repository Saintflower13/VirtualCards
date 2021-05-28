namespace VirtualCreditCardsApi.Models
{
    // IIN - Issuer Identification Number
    // Font: https://en.wikipedia.org/wiki/Payment_card_number#Issuer_identification_number_.28IIN.29

    public abstract class BaseCardIIN
    {
        public int Min;
        public int Max;
    }

    public class MasterCardIIN: BaseCardIIN
    {
        public MasterCardIIN()
        {
            Min = 510000;
            Max = 550000;
        }
    }

    public class VisaIIN : BaseCardIIN
    {
        public VisaIIN()
        {
            Min = 400000;
            Max = 499999;
        }
    }
}
