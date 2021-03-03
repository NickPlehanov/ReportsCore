using System;
using System.Collections.Generic;
using System.Text;

namespace ReportsCore.Helpers {
    interface IMessageBoxService {
        bool ShowMessage(string text, string caption);
    }
}
