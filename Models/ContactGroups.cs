using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.API.Models
{
    public class ContactGroups
    {
        [Key]
        public long ContactGroupID { get; set; }
        public string ContactGroupName { get; set; }
        public long OtherContactGroupID { get; set; }
        public string OtherContactGroupName { get; set; }
        
    }
}