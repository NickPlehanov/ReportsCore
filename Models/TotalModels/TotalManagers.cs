using System;
using System.Collections.Generic;
using System.Text;

namespace ReportsCore.Models.TotalModels {
	public class TotalManagers {
		public string ManagerName { get; set; }
		public int AllCountChanges { get; set; }
		public int MajorCountChanges { get; set; }
		public int MinorCountChanges { get; set; }
		public double MajorSumChanges { get; set; }
		public double MinorSumChanges { get; set; }
		public double DeltaSum { get; set; }
	}

	public class TotalManagersChart {
		public double MajorSumChanges { get; set; }
		public double MinorSumChanges { get; set; }
	}
}
