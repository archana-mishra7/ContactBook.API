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

        public async Task<bool> DuplicateCheckonPhone(string newPhoneNumber){
             var phoneCheck = await _context.Contacts.FirstOrDefaultAsync(
                x => x.PhoneNumber == newPhoneNumber);
            
            if(phoneCheck != null)
            return true;   //409 is statuscode for duplicate entry    
            
            return true;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllContacts()
        {
            var contactGroupList = await _context.ContactGroups.ToListAsync();
           return Ok(contactGroupList);
        }
        //for adding contact to an existing group
        [HttpPut("{id}")]
        public async Task<IActionResult> AddContactToGroup(long ContactGroupID ,Contacts contact)
        {
            if(DuplicateCheckonPhone(contact.PhoneNumber).Result)
             return StatusCode(409);   //409 is statuscode for duplicate entry 
            
            //adding to contacts table 
            var contactWGroupID = new Contacts();
            contactWGroupID = contact;
            if(string.IsNullOrEmpty(contact.contactGroupID))
            contactWGroupID.contactGroupID = ContactGroupID.ToString();
            else
             contactWGroupID.contactGroupID = contactWGroupID.contactGroupID + " , " + ContactGroupID.ToString();
            
            _context.Contacts.Add(contactWGroupID);
            await _context.SaveChangesAsync();
           
            return StatusCode(201);
        }

        //adding a contactgroup to an existing group -- work in progress
        [HttpPost("addcontactgroup")] 
        public async Task<ActionResult<ContactGroups>> AddContactGroup(ContactGroups contactGroup)
        {
            
            contactGroup.ContactGroupID = ContactGroupID +1;
            _context.ContactGroups.Add(contactGroup);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        //Create new Contact Group -- Work in progress.
        [HttpPost("newcontactgroup")]
        public async Task<ActionResult<ContactGroups>> CreateNewContactGroup(ContactGroups contactGroups)
        {
           
                await _context.SaveChangesAsync();
                 return StatusCode(201);
            
            
        }

    }
}