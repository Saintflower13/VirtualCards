using Microsoft.EntityFrameworkCore;

namespace VirtualCreditCardsApi.Models
{
    public class VirtualCreditCardsApiContext : DbContext
    {
        public VirtualCreditCardsApiContext
                (DbContextOptions<VirtualCreditCardsApiContext> options) : base(options)
        {

        }

        public DbSet<ClientEmail> ClientEmails { get; set; }
        public DbSet<VirtualCreditCard> VirtualCreditCards { get; set; }
    }
}
