using System;
using System.Collections.Generic;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public static class AddressDb
    {
        public static List<AddressBookEntry> Addresses { get; set; } = new List<AddressBookEntry>();
    }

    public class AddressBookEntry
    {
        private AddressBookEntry(string line1, string city, string state, string postalCode)
        {
            Id = Guid.NewGuid();
            Line1 = line1;
            Line2 = Line2;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        private AddressBookEntry(string line1, string line2, string city, string state, string postalCode)
            : this(line1, city, state, postalCode) =>
            Line2 = line2;

        public Guid Id { get; }
        public string Line1 { get; private set; }
        public string Line2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }

        public static AddressBookEntry Create(string line1, string city, string state, string postalCode)
            => new AddressBookEntry(line1, city, state, postalCode);

        public static AddressBookEntry Create(string line1, string line2, string city, string state, string postalCode)
            => new AddressBookEntry(line1, line2, city, state, postalCode);

        public void ModifyAddress(string line1, string city, string state, string postalCode)
        {
            Line1 = line1;
            Line2 = null;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public void ModifyAddress(string line1, string line2, string city, string state, string postalCode)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            State = state;
            PostalCode = postalCode;
        }
    }
}