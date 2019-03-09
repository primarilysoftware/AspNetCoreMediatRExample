using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;

        public EditModel(IMediator mediator) => _mediator = mediator;

        [BindProperty] public UpdateAddressRequest UpdateAddressRequest { get; set; }

        public IActionResult OnGet(string id)
        {
            Guid entryId;
            if (!Guid.TryParse(id, out entryId))
            {
                return BadRequest();
            }

            var entry = AddressDb.Addresses.Find(x => x.Id == entryId);
            if (entry == null)
            {
                return NotFound();
            }

            UpdateAddressRequest = new UpdateAddressRequest
            {
                Id = entry.Id.ToString(),
                Line1 = entry.Line1,
                Line2 = entry.Line2,
                City = entry.City,
                State = entry.State,
                PostalCode = entry.PostalCode
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(UpdateAddressRequest);
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}