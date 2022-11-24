namespace MyAppDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpNo { get; set; }

        [Required]
        [StringLength(200)]
        public string EmpName { get; set; }

        [Required]
        [StringLength(200)]
        public string Designation { get; set; }

        public int Salary { get; set; }

        public int DeptNo { get; set; }

        public virtual Department Department { get; set; }
    }
}
