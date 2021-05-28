using System.Collections.Generic;

namespace VirtualCreditCardsApi.Models
{
    public class ClientEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public List<VirtualCreditCard> VirtualCreditCards { get; set; }
    }
}
