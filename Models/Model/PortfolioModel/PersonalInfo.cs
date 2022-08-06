using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.PortfolioModel
{
    public class PersonalInfo
    {
        [Key]
        public Guid PeronalInfoId { get; set; }
        public string? Backgroundimg { get; set; }
        public string? Profileimg { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string? Email { get; set; }
        public string? Mobileno { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? Country { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? City { get; set; }
        public int Age { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? Degree { get; set; }
        public string? Website { get; set; }
        public string? Detail { get; set; }
        public string? Experience { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
