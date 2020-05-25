using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlowServices.Models.child
{
    public class Child
    {
        [Key]
        public Guid ChildId { get; set; }
        public Guid UserId { get; set; }
        public string ChildFirstName { get; set; }
        public DateTime ChildBirthDate { get; set; }
        public int ChildHeight { get; set; }
        public string ChildHeightType { get; set; }
        public int ChildWeight { get; set; }
        public string ChildWeightType { get; set; }
    }
}
