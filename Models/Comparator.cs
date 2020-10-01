using System;
using System.Collections.Generic;
using System.Text;

namespace ReportsCore.Models {
	public class Comparator {
		public Comparator() {
		}

		public string FieldName { get; set; }
		public string OldValue { get; set; }
		public string NewValue { get; set; }
	}
}
