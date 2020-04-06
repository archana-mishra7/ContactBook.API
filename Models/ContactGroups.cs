using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.API.Models
{
    public class ContactGroups
    {
        [Key]
        public long contactGroupID { get; set; }
        public Contacts contact { get; set; }
        public List<Contacts> contactGroup { get; set; }
        
    }
}