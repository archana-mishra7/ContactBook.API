using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactBook.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactGroupsController : ControllerBase
    {
        public ContactsContext _context { get; set; }
        private static int ContactGroupID = 0;
        public ContactGroupsController(ContactsContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> ListAllContacts()
        {
            var contactGroupList = await _context.ContactGroups.ToListAsync();
           return Ok(contactGroupList);
        }
        [HttpPost("addcontacttoGroup")]
        public async Task<IActionResult> AddContactToGroup(Contacts contact)
        {
            var dbContactList = await _context.Contacts.ToListAsync(); 
            var phoneNumber = contact.PhoneNumber;
            var phoneCheck =  dbContactList.Find(
                            x => x.PhoneNumber == phoneNumber);
            if (phoneCheck != null)
             return StatusCode(409);   //409 is statuscode for duplicate entry  
            
            ContactGroups contactGroup = new ContactGroups();
            contactGroup.ContactGroupID = ContactGroupID + 1;
            contactGroup.Contact = contact;
            
            //adding to contacts table as well
            var contactWGroupID = new Contacts();
            contactWGroupID = contact;
            contactWGroupID.contactGroupID = contactGroup.ContactGroupID;
            _context.Contacts.Add(contactWGroupID);


            _context.ContactGroups.Add(contactGroup)  ;
            await _context.SaveChangesAsync();
           
            return CreatedAtAction(nameof(contactGroup), contactGroup);
        }

        [HttpPost("addcontactgroup")]
        public async Task<ActionResult<ContactGroups>> AddContactGroup(ContactGroups contactGroup)
        {
            var phoneNumber = contactGroup.Contact.PhoneNumber;
            var phoneCheck = await _context.Contacts.FirstOrDefaultAsync(
                x => x.PhoneNumber == phoneNumber);

            if(phoneCheck != null)
            return StatusCode(409);   //409 is statuscode for duplicate entry          
            
            contactGroup.ContactGroupID = ContactGroupID +1;
            _context.ContactGroups.Add(contactGroup);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPost("addcontactlisttogroup")]
        public async Task<ActionResult<ContactGroups>> AddContactListToGroup(List<Contacts> contactList)
        {
            try
            {
                var dbContactList = await _context.Contacts.ToListAsync();

                if (contactList.Count < 0)
                    return StatusCode(404);

                //var ContactGroupsList = new List<ContactGroups>();
                foreach (var contact in contactList)
                {
                    var phoneNumber = contact.PhoneNumber;
                    var phoneCheck = dbContactList.Find(
                        x => x.PhoneNumber == phoneNumber);
                    if (phoneCheck != null)
                        return StatusCode(409);   //409 is statuscode for duplicate entry  

                    ContactGroups contactGroup = new ContactGroups();
                    contactGroup.ContactGroupID = ContactGroupID + 1;
                    contactGroup.Contact = contact;
                    //adding to contacts table as well
                    var contactWGroupID = new Contacts();
                    contactWGroupID = contact;
                    contactWGroupID.contactGroupID = contactGroup.ContactGroupID;
                    _context.Contacts.Add(contactWGroupID);
                   // ContactGroupsList.Add(contactGroup);
                    _context.ContactGroups.Add(contactGroup);

                }
                 
                await _context.SaveChangesAsync();
                 return StatusCode(201);
            }
            catch(Exception ex)
            {
                var message = ex.Message;
                return StatusCode(500);
            }
        }

    }
}