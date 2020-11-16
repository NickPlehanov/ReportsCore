﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportsCore.Models
{
    [Table("New_executorExtensionBase")]
    public partial class NewExecutorExtensionBase
    {
        [Key]
        [Column("New_executorId")]
        public Guid NewExecutorId { get; set; }
        [Column("New_name")]
        [StringLength(100)]
        public string NewName { get; set; }
        [Column("New_address")]
        [StringLength(300)]
        public string NewAddress { get; set; }
        [Column("New_inn")]
        [StringLength(12)]
        public string NewInn { get; set; }
        [Column("New_kpp")]
        [StringLength(9)]
        public string NewKpp { get; set; }
        [Column("New_ogrn")]
        [StringLength(50)]
        public string NewOgrn { get; set; }
        [Column("New_bank_name")]
        [StringLength(100)]
        public string NewBankName { get; set; }
        [Column("New_bank_rs")]
        [StringLength(20)]
        public string NewBankRs { get; set; }
        [Column("New_bank_ks")]
        [StringLength(20)]
        public string NewBankKs { get; set; }
        [Column("New_bank_bik")]
        [StringLength(15)]
        public string NewBankBik { get; set; }
        [Column("New_boss_name")]
        [StringLength(70)]
        public string NewBossName { get; set; }
        [Column("New_boss_fiio")]
        [StringLength(100)]
        public string NewBossFiio { get; set; }
        [Column("New_boss_namer")]
        [StringLength(100)]
        public string NewBossNamer { get; set; }
        [Column("New_boss_fior")]
        [StringLength(100)]
        public string NewBossFior { get; set; }
        [Column("New_phone")]
        [StringLength(100)]
        public string NewPhone { get; set; }
        [Column("New_Email")]
        [StringLength(100)]
        public string NewEmail { get; set; }
        [Column("New_Web")]
        [StringLength(50)]
        public string NewWeb { get; set; }
        [Column("New_info1")]
        [StringLength(150)]
        public string NewInfo1 { get; set; }
        [Column("New_info2")]
        [StringLength(100)]
        public string NewInfo2 { get; set; }
        [Column("New_license_no")]
        [StringLength(20)]
        public string NewLicenseNo { get; set; }
        [Column("New_license_issued_when", TypeName = "datetime")]
        public DateTime? NewLicenseIssuedWhen { get; set; }
        [Column("New_license_issued_who")]
        [StringLength(100)]
        public string NewLicenseIssuedWho { get; set; }
        [Column("New_license_issued_till", TypeName = "datetime")]
        public DateTime? NewLicenseIssuedTill { get; set; }
        [Column("New_license_case")]
        [StringLength(100)]
        public string NewLicenseCase { get; set; }
        [Column("New_gun_license_no")]
        [StringLength(30)]
        public string NewGunLicenseNo { get; set; }
        [Column("New_gun_license_issued", TypeName = "datetime")]
        public DateTime? NewGunLicenseIssued { get; set; }
        [Column("New_gun_license_who")]
        [StringLength(100)]
        public string NewGunLicenseWho { get; set; }
        [Column("New_gun_responsible")]
        [StringLength(150)]
        public string NewGunResponsible { get; set; }
        [Column("New_CrmCode")]
        [StringLength(100)]
        public string NewCrmCode { get; set; }
        [Column("New_isCoExecutor")]
        public bool? NewIsCoExecutor { get; set; }
        [Column("New_FullName")]
        [StringLength(100)]
        public string NewFullName { get; set; }
        [Column("New_BossPhone")]
        [StringLength(100)]
        public string NewBossPhone { get; set; }
    }
}