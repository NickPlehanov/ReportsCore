﻿using System.Windows;

namespace ReportsCore.Helpers {
    public class BindingProxy : Freezable {
        #region Overrides of Freezable

        protected override Freezable CreateInstanceCore() {
            return new BindingProxy();
        }
        #endregion

        public object Data {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty,value); }
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("_Data",typeof(object),
                                         typeof(BindingProxy));
    }
}
