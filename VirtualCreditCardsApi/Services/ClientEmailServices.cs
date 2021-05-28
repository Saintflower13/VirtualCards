using System;
using System.Linq;
using VirtualCreditCardsApi.Models;

namespace VirtualCreditCardsApi.Services
{
    public static class ClientEmailServices
    {
        private static ClientEmail CreateClientEmail(string email, VirtualCreditCardsApiContext context)
        {
            var client = new ClientEmail { Email = email };
            context.ClientEmails.Add(client);
            context.SaveChanges();
            return client;
        }

        public static ClientEmail GetAssociatedClientEmail(string email, VirtualCreditCardsApiContext context)
        {
            var clientEmail = context.ClientEmails
                                .Where(e => e.Email == email)
                                .FirstOrDefault();

            if (clientEmail is null)
                clientEmail = CreateClientEmail(email, context);

            return clientEmail;
        }
    }
}
