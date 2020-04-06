using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.API.Models
{
    public class ContactGroups
    {
        [Key]
        public long ContactGroupID { get; set; }
        public Contacts Contact { get; set; }
        public ContactGroups OtherContactGroups { get; set; }
        
    }
}