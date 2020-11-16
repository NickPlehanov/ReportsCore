using System;
using System.ComponentModel.DataAnnotations.Schema;

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
                if(value.HasValue)
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
        private bool? _Os { get; set; }
        public bool? Os {
            get => _Os;
            set {
                _Os = value.HasValue ? value : false;
            }
        }
        private bool? _Ps { get; set; }
        public bool? Ps {
            get => _Ps;
            set {
                _Ps = value.HasValue ? value : false;
            }
        }
        private bool? _Trs { get; set; }
        public bool? Trs {
            get => _Trs;
            set {
                _Trs = value.HasValue ? value : false;
            }
        }
        public int? Group { get; set; }
        public string Late { get; set; }
        private bool? _RrEveryMonth { get; set; }
        public bool? RrEveryMonth {
            get => _RrEveryMonth;
            set {
                _RrEveryMonth = value.HasValue ? value : false;
            }
        }
        private bool? _RrOS { get; set; }
        public bool? RrOS {
            get => _RrOS;
            set {
                _RrOS = value.HasValue ? value : false;
            }
        }
        private bool? _RrPS { get; set; }
        public bool? RrPS {
            get => _RrPS;
            set {
                _RrPS = value.HasValue ? value : false;
            }
        }
        private bool? _RrVideo { get; set; }
        public bool? RrVideo {
            get => _RrVideo;
            set {
                _RrVideo = value.HasValue ? value : false;
            }
        }
        private bool? _RrSkud { get; set; }
        public bool? RrSkud {
            get => _RrSkud;
            set {
                _RrSkud = value.HasValue ? value : false;
            }
        }
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
