using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.API.Models
{
    public class ContactGroups
    {
        [Key]
        public long ContactGroupID { get; set; }
        public string ContactGroupName { get; set; }
        public ContactGroups OtherContactGroups { get; set; }
        public string OtherContactGroupName { get; set; }
        
    }
}