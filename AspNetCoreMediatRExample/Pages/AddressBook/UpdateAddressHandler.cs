using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class UpdateAddressHandler
        : IRequestHandler<UpdateAddressRequest>
    {
        public Task<Unit> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Guid entryId;
            if (!Guid.TryParse(request.Id, out entryId))
            {
                throw new Exception($"Invalid AddressBookEntry ID: {request?.Id ?? "NULL"}");
            }

            var entry = AddressDb.Addresses.Find(x => x.Id == entryId);
            if (entry == null)
            {
                throw new Exception($"Could not find AddressBookEntry with ID {entryId}");
            }

            entry.ModifyAddress(
                request.Line1,
                request.Line2,
                request.City,
                request.State,
                request.PostalCode);

            return Unit.Task;
        }
    }
}