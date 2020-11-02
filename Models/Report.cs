using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace ReportsCore.Models {
	public class Report {
		public Report() {
		}
		public Guid? ObjectID { get; set; }
		public int? ObjectNumber { get; set; }
		public string ObjectName { get; set; }
		public string ObjectAddress { get; set; }
		public string WhoChanged { get; set; }
		[NotMapped]
		private DateTime? _DateChanged;
		public DateTime? DateChanged {
			get => _DateChanged;
			set {
				if(value.HasValue)
					_DateChanged = value.Value.AddHours(5);
			}
		}
		public string Before { get; set; }
		public string After { get; set; }
		[NotMapped]
		private DateTime? _DateStart;
		public DateTime? DateStart {
			get => _DateStart;
			set {
				if(value.HasValue)
					_DateStart = value.Value.AddHours(5);
			}
		}
		public string Curator { get; set; }

		//поля для отчёта по сработкам
		public bool? Act { get; set; }
		public bool? Police { get; set; }
		public bool? Owner { get; set; }	
		public string DateSort { get; set; }
		public string HourSort { get; set; }

		[NotMapped]
		private DateTime? _Alarm;
		public DateTime? Alarm {
			get => _Alarm; 
			set {
				if (value.HasValue)
				_Alarm = value.Value.AddHours(5);
			}
		}
		[NotMapped]
		private DateTime? _Departure;
		public DateTime? Departure {//отправка
			get => _Departure;
			set {
				if(value.HasValue)
					_Departure = value.Value.AddHours(5);
			}
		}
		[NotMapped]
		private DateTime? _Arrival;
		public DateTime? Arrival {//прибытие
			get => _Arrival;
			set {
				if(value.HasValue)
					_Arrival = value.Value.AddHours(5);
			}
		}
		[NotMapped]
		private DateTime? _Cancel;
		public DateTime? Cancel {
			get => _Cancel;
			set {
				if(value.HasValue)
					_Cancel = value.Value.AddHours(5);
			}
		}
		public string Result { get; set; }
		public bool? Os { get; set; }
		public bool? Ps { get; set; }
		public bool? Trs { get; set; }
		public int? Group { get; set; }
		public string Late { get; set; }
		public bool? RrEveryMonth { get; set; }
		public bool? RrOS { get; set; }
		public bool? RrPS { get; set; }
		public bool? RrVideo { get; set; }
		public bool? RrSkud { get; set; }
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
