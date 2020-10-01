namespace ReportsCore.Models {
	public class Report {
		public Report() {
		}

		public string ObjectNumber { get; set; }
		public string ObjectName { get; set; }
		public string ObjectAddress { get; set; }
		public string WhoChanged { get; set; }
		public string DateChanged { get; set; }
		public string Before { get; set; }
		public string After { get; set; }
		public string DateStart { get; set; }
		public string Curator { get; set; }
	}
}
