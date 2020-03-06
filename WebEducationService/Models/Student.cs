using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebEducationService.Models {
    public class Student {
        public int Id { get; set; }
        public int? MajorId { get; set; }
        [StringLength(30)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(30)]
        [Required]
        public string LastName { get; set; }
        public int SAT { get; set; }
        public double GPA { get; set; } //make float or double instead of decimal since it will not be changed mathmatically
        public virtual Major Major { get; set; }

        public Student() {

        }

    }
}
