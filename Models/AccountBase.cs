﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportsCore.Models
{
    public partial class AccountBase
    {
        public AccountBase()
        {
            InverseMaster = new HashSet<AccountBase>();
            InverseParentAccount = new HashSet<AccountBase>();
            NewAgreementExtensionBase = new HashSet<NewAgreementExtensionBase>();
            NewGuardObjectExtensionBaseNewAccountAgentNavigation = new HashSet<NewGuardObjectExtensionBase>();
            NewGuardObjectExtensionBaseNewAccountNavigation = new HashSet<NewGuardObjectExtensionBase>();
            NewGuardObjectExtensionBaseNewReactionAccountNavigation = new HashSet<NewGuardObjectExtensionBase>();
            NewGuardObjectExtensionBaseNewTechserviceAccountNavigation = new HashSet<NewGuardObjectExtensionBase>();
            NewGuardObjectExtensionBaseNewUvoUnitNavigation = new HashSet<NewGuardObjectExtensionBase>();
        }

        [Key]
        public Guid AccountId { get; set; }
        public int? AccountCategoryCode { get; set; }
        public Guid? TerritoryId { get; set; }
        public Guid? DefaultPriceLevelId { get; set; }
        public int? CustomerSizeCode { get; set; }
        public int? PreferredContactMethodCode { get; set; }
        public int? CustomerTypeCode { get; set; }
        public int? AccountRatingCode { get; set; }
        public int? IndustryCode { get; set; }
        public int? TerritoryCode { get; set; }
        public int? AccountClassificationCode { get; set; }
        public int DeletionStateCode { get; set; }
        public int? BusinessTypeCode { get; set; }
        public Guid? OwningBusinessUnit { get; set; }
        public Guid? OwningTeam { get; set; }
        public Guid? OwningUser { get; set; }
        public Guid? OriginatingLeadId { get; set; }
        public int? PaymentTermsCode { get; set; }
        public int? ShippingMethodCode { get; set; }
        public Guid? PrimaryContactId { get; set; }
        public bool? ParticipatesInWorkflow { get; set; }
        [StringLength(160)]
        public string Name { get; set; }
        [StringLength(20)]
        public string AccountNumber { get; set; }
        [Column(TypeName = "money")]
        public decimal? Revenue { get; set; }
        public int? NumberOfEmployees { get; set; }
        public string Description { get; set; }
        [Column("SIC")]
        [StringLength(20)]
        public string Sic { get; set; }
        public int? OwnershipCode { get; set; }
        [Column(TypeName = "money")]
        public decimal? MarketCap { get; set; }
        public int? SharesOutstanding { get; set; }
        [StringLength(10)]
        public string TickerSymbol { get; set; }
        [StringLength(20)]
        public string StockExchange { get; set; }
        [Column("WebSiteURL")]
        [StringLength(200)]
        public string WebSiteUrl { get; set; }
        [Column("FtpSiteURL")]
        [StringLength(200)]
        public string FtpSiteUrl { get; set; }
        [Column("EMailAddress1")]
        [StringLength(100)]
        public string EmailAddress1 { get; set; }
        [Column("EMailAddress2")]
        [StringLength(100)]
        public string EmailAddress2 { get; set; }
        [Column("EMailAddress3")]
        [StringLength(100)]
        public string EmailAddress3 { get; set; }
        public bool? DoNotPhone { get; set; }
        public bool? DoNotFax { get; set; }
        [StringLength(50)]
        public string Telephone1 { get; set; }
        [Column("DoNotEMail")]
        public bool? DoNotEmail { get; set; }
        [StringLength(50)]
        public string Telephone2 { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [StringLength(50)]
        public string Telephone3 { get; set; }
        public bool? DoNotPostalMail { get; set; }
        [Column("DoNotBulkEMail")]
        public bool? DoNotBulkEmail { get; set; }
        public bool? DoNotBulkPostalMail { get; set; }
        [Column(TypeName = "money")]
        public decimal? CreditLimit { get; set; }
        public bool? CreditOnHold { get; set; }
        public bool? IsPrivate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public byte[] VersionNumber { get; set; }
        public Guid? ParentAccountId { get; set; }
        [Column(TypeName = "money")]
        public decimal? Aging30 { get; set; }
        public int StateCode { get; set; }
        [Column(TypeName = "money")]
        public decimal? Aging60 { get; set; }
        public int? StatusCode { get; set; }
        [Column(TypeName = "money")]
        public decimal? Aging90 { get; set; }
        public int? PreferredAppointmentDayCode { get; set; }
        public Guid? PreferredSystemUserId { get; set; }
        public int? PreferredAppointmentTimeCode { get; set; }
        public bool? Merged { get; set; }
        [Column("DoNotSendMM")]
        public bool? DoNotSendMm { get; set; }
        public Guid? MasterId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUsedInCampaign { get; set; }
        public Guid? PreferredServiceId { get; set; }
        public Guid? PreferredEquipmentId { get; set; }
        [Column(TypeName = "decimal(23, 10)")]
        public decimal? ExchangeRate { get; set; }
        [Column("UTCConversionTimeZoneCode")]
        public int? UtcconversionTimeZoneCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OverriddenCreatedOn { get; set; }
        public int? TimeZoneRuleVersionNumber { get; set; }
        public int? ImportSequenceNumber { get; set; }
        public Guid? TransactionCurrencyId { get; set; }
        [Column("CreditLimit_Base", TypeName = "money")]
        public decimal? CreditLimitBase { get; set; }
        [Column("Aging30_Base", TypeName = "money")]
        public decimal? Aging30Base { get; set; }
        [Column("Revenue_Base", TypeName = "money")]
        public decimal? RevenueBase { get; set; }
        [Column("Aging90_Base", TypeName = "money")]
        public decimal? Aging90Base { get; set; }
        [Column("MarketCap_Base", TypeName = "money")]
        public decimal? MarketCapBase { get; set; }
        [Column("Aging60_Base", TypeName = "money")]
        public decimal? Aging60Base { get; set; }
        [StringLength(160)]
        public string YomiName { get; set; }

        [ForeignKey(nameof(MasterId))]
        [InverseProperty(nameof(AccountBase.InverseMaster))]
        public virtual AccountBase Master { get; set; }
        [ForeignKey(nameof(OwningUser))]
        [InverseProperty(nameof(SystemUserBase.AccountBaseOwningUserNavigation))]
        public virtual SystemUserBase OwningUserNavigation { get; set; }
        [ForeignKey(nameof(ParentAccountId))]
        [InverseProperty(nameof(AccountBase.InverseParentAccount))]
        public virtual AccountBase ParentAccount { get; set; }
        [ForeignKey(nameof(PreferredSystemUserId))]
        [InverseProperty(nameof(SystemUserBase.AccountBasePreferredSystemUser))]
        public virtual SystemUserBase PreferredSystemUser { get; set; }
        [InverseProperty(nameof(AccountBase.Master))]
        public virtual ICollection<AccountBase> InverseMaster { get; set; }
        [InverseProperty(nameof(AccountBase.ParentAccount))]
        public virtual ICollection<AccountBase> InverseParentAccount { get; set; }
        [InverseProperty("NewBpAgreementNavigation")]
        public virtual ICollection<NewAgreementExtensionBase> NewAgreementExtensionBase { get; set; }
        [InverseProperty(nameof(NewGuardObjectExtensionBase.NewAccountAgentNavigation))]
        public virtual ICollection<NewGuardObjectExtensionBase> NewGuardObjectExtensionBaseNewAccountAgentNavigation { get; set; }
        [InverseProperty(nameof(NewGuardObjectExtensionBase.NewAccountNavigation))]
        public virtual ICollection<NewGuardObjectExtensionBase> NewGuardObjectExtensionBaseNewAccountNavigation { get; set; }
        [InverseProperty(nameof(NewGuardObjectExtensionBase.NewReactionAccountNavigation))]
        public virtual ICollection<NewGuardObjectExtensionBase> NewGuardObjectExtensionBaseNewReactionAccountNavigation { get; set; }
        [InverseProperty(nameof(NewGuardObjectExtensionBase.NewTechserviceAccountNavigation))]
        public virtual ICollection<NewGuardObjectExtensionBase> NewGuardObjectExtensionBaseNewTechserviceAccountNavigation { get; set; }
        [InverseProperty(nameof(NewGuardObjectExtensionBase.NewUvoUnitNavigation))]
        public virtual ICollection<NewGuardObjectExtensionBase> NewGuardObjectExtensionBaseNewUvoUnitNavigation { get; set; }
    }
}