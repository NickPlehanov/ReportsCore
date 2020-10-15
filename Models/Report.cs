using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace ReportsCore.Models {
	public class Report {
		public Report() {
		}
		public int? ObjectNumber { get; set; }
		public string ObjectName { get; set; }
		public string ObjectAddress { get; set; }
		public string WhoChanged { get; set; }
		public DateTime? DateChanged { get; set; }
		public string Before { get; set; }
		public string After { get; set; }
		public DateTime? DateStart { get; set; }
		public string Curator { get; set; }

		//поля для отчёта по сработкам
		public bool? Act { get; set; }
		public bool? Police { get; set; }
		public bool? Owner { get; set; }
		[NotMapped]
		private DateTime? _Alarm;
		public DateTime? Alarm {
			get => _Alarm; 
			set {
				if (value.HasValue)
				_Alarm = value.Value.AddHours(5);
			}
		}
		public DateTime? Departure { get; set; } //отправка
		public DateTime? Arrival { get; set; }//прибытие
		public DateTime? Cancel { get; set; }
		public string Result { get; set; }
		public bool? Os { get; set; }
		public bool? Ps { get; set; }
		public bool? Trs { get; set; }
		public int? Group { get; set; }
		public string Late { get; set; }
		//private string _StringLate;
		//public string StringLate {
		//	get => _StringLate;
		//	set {
		//		if(!string.IsNullOrEmpty(value)) {

		//		}
		//	}
		//}
	}
}
