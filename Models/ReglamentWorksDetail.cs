using System;

namespace ReportsCore.Models {
    public class ReglamentWorksDetail {
        public string UserChanged { get; set; }
        public DateTime? DateChanged { get; set; }
        public string FieldChanged { get; set; }
        public string BeforeChanged { get; set; }
        public string AfterChanged { get; set; }
    }
}
