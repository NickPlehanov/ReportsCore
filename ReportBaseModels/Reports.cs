﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportsCore.ReportBaseModels
{
    public partial class Reports
    {
        [Key]
        [Column("rpt_ID")]
        public Guid RptId { get; set; }
        [Required]
        [Column("rpt_Name")]
        public string RptName { get; set; }
    }
}