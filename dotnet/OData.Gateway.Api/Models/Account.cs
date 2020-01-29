using System;
namespace OData.Gateway.Api.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }

        public Address Address { get; set; }
    }
}
