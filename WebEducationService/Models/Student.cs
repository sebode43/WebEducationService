using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebEducationService.Models {
    public class Student {
        public int Id { get; set; }
        public int MajorId { get; set; }
        [StringLength(30)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(30)]
        [Required]
        public string LastName { get; set; }
        [StringLength(4)]
        public string SAT { get; set; }
        [StringLength(4)]
        public string GPA { get; set; }
        public virtual Major Major { get; set; }

        public Student() {

        }

    }
}
