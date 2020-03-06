using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebEducationService.Models {
    public class StudentClass {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        [StringLength(3)]
        public string ClassGradeValue { get; set; }
        [JsonIgnore]
        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}
