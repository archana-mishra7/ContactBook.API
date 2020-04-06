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
        public ContactGroupsController(ContactsContext context)
        {
            _context = context;

        }

        

    }
}