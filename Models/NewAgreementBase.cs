﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportsCore.Models
{
    [Table("New_agreementBase")]
    public partial class NewAgreementBase
    {
        public NewAgreementBase()
        {
            NewNewAgreementNewGuardObjectBase = new HashSet<NewNewAgreementNewGuardObjectBase>();
        }

        [Key]
        [Column("New_agreementId")]
        public Guid NewAgreementId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid? OwningUser { get; set; }
        public Guid? OwningBusinessUnit { get; set; }
        [Column("statecode")]
        public int Statecode { get; set; }
        [Column("statuscode")]
        public int? Statuscode { get; set; }
        public int? DeletionStateCode { get; set; }
        public byte[] VersionNumber { get; set; }
        public int? ImportSequenceNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OverriddenCreatedOn { get; set; }
        public int? TimeZoneRuleVersionNumber { get; set; }
        [Column("UTCConversionTimeZoneCode")]
        public int? UtcconversionTimeZoneCode { get; set; }
        public Guid? TransactionCurrencyId { get; set; }
        [Column(TypeName = "decimal(23, 10)")]
        public decimal? ExchangeRate { get; set; }

        [ForeignKey(nameof(OwningUser))]
        [InverseProperty(nameof(SystemUserBase.NewAgreementBase))]
        public virtual SystemUserBase OwningUserNavigation { get; set; }
        [InverseProperty("NewAgreement1")]
        public virtual NewAgreementExtensionBase NewAgreementExtensionBase { get; set; }
        [InverseProperty("NewAgreement")]
        public virtual ICollection<NewNewAgreementNewGuardObjectBase> NewNewAgreementNewGuardObjectBase { get; set; }
    }
}