using System;

namespace ReportsCore.Models {
	public class AgreementDetailModel {
		public AgreementDetailModel(int? agreementNumber, string agreementExecutor, DateTime? agreementDate, string agreementType) {
			AgreementNumber = agreementNumber;
			AgreementExecutor = agreementExecutor;
			AgreementDate = agreementDate;
			AgreementType = agreementType;
		}

		public int? AgreementNumber { get; set; }
		public string AgreementExecutor { get; set; }

		private DateTime? _AgreementDate;
		public DateTime? AgreementDate {
			get => _AgreementDate;
			set {
				_AgreementDate = value.Value.AddHours(5);
			}
		}
		public string AgreementType { get; set; }
	}
}
