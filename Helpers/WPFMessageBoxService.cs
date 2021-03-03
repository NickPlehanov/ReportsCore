using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ReportsCore.Helpers {
    class WPFMessageBoxService : IMessageBoxService {
        public bool ShowMessage(string text, string caption) {
            MessageBox.Show(text, caption, MessageBoxButton.OK, MessageBoxImage.Information);
            return true;
        }
    }
}
