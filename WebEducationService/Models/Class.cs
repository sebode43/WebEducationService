using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebEducationService.Models {
    public class Class {
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Subject { get; set; }
        [StringLength(30)]
        [Required]
        public string Section { get; set; }

        public Class() {

        }
    }
}
