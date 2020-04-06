using ContactBook.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        public ContactsContext _context { get; set; }
        public ContactsController(ContactsContext context)
        {
            _context = context;

        }
        List<Contacts> contacts = new List<Contacts>{
            new Contacts{ContactId=1, FirstName="John", LastName="Doe",PhoneNumber="1234567890"},
            new Contacts{ContactId=2,FirstName="Smith", LastName="HGJ",PhoneNumber="1234567809"}
        };

        [HttpGet]
        public async Task<IActionResult> ListAllContacts()
        {
            var contactList = await _context.Contacts.ToListAsync();
           return Ok(contactList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Contacts>> GetContactItem(long id)
        {
            var contactItem = await _context.Contacts.FirstOrDefaultAsync(x => x.ContactId == id);
            if (contactItem == null)
            {
                return NotFound();
            }
            return contactItem;
        }

        [HttpPost("addcontact")]
        public async Task<ActionResult<Contacts>> AddContact(Contacts contact)
        {
            try{
            //check for duplicate entries in contacts from Phone Number
            var phoneNumber = contact.PhoneNumber;
            var phoneCheck = await _context.Contacts.FirstOrDefaultAsync(
                x => x.PhoneNumber == phoneNumber);
            
            if(phoneCheck != null)
            return StatusCode(409);   //409 is statuscode for duplicate entry          
            
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
           
            return CreatedAtAction(nameof(contact), new { id = contact.ContactId }, contact);
            }
            catch(Exception ex)
            {
                var message = ex.Message;
                return StatusCode(500);
            }
        }

        

    }
}