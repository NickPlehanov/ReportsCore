using System;
using System.Collections.Generic;
using System.Text;

namespace ReportsCore.Models {
	public class Comparator {
		public Comparator() {
		}

		public string FieldName { get; set; }
		public object OldValue { get; set; }
		public object NewValue { get; set; }

		public string _FiledName {
			get {
				switch(FieldName) {
					case "New_rr_on_off": return "Ежемес. рег. работы";
					case "New_rr_os": return "ОС рег. работы";
					case "New_rr_ps": return "ПС рег. работы";
					case "New_rr_video": return "Видео рег. работы";
					case "New_rr_skud": return "СКУД рег. работы";
					default: return "";
				}
			}
		}
	}
}
