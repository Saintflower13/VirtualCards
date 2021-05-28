namespace VirtualCreditCardsApi.Models
{
    public class VirtualCreditCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }

        public int ClientEmailId { get; set; }
        public ClientEmail ClientEmail { get; set; }
    }

    public class VirtualCreditCardDTO
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
    }

    public class VirtualCreditCardPostDTO
    {
        public string Email { get; set; }
    }
}
