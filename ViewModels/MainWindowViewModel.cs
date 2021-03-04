using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MahApps.Metro.Controls;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using Newtonsoft.Json;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using ReportsCore.Context;
using ReportsCore.Helpers;
using ReportsCore.Models;
using ReportsCore.Models.TotalModels;
using ReportsCore.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ReportsCore.ViewModels {
    public class MainWindowViewModel : BaseViewModel {

        ObservableCollection<Report> FullReports = new ObservableCollection<Report>();

        private bool _FlyoutMenuState;
        public bool FlyoutMenuState {
            get => _FlyoutMenuState;
            set {
                _FlyoutMenuState = value;
                OnPropertyChanged("FlyoutMenuState");
            }
        }

        private bool _FlyoutSettingVisibleState;
        public bool FlyoutSettingVisibleState {
            get => _FlyoutSettingVisibleState;
            set {
                if (value)
                    FlyoutMenuState = false;
                _FlyoutSettingVisibleState = value;
                OnPropertyChanged("FlyoutSettingVisibleState");
            }
        }

        private bool _FlyoutSettingColumnsVisibleState;
        public bool FlyoutSettingColumnsVisibleState {
            get => _FlyoutSettingColumnsVisibleState;
            set {
                _FlyoutSettingColumnsVisibleState = value;
                OnPropertyChanged("FlyoutSettingColumnsVisibleState");
            }
        }

        private bool _ObjectNumberVisibility;
        public bool ObjectNumberVisibility {
            get => _ObjectNumberVisibility;
            set {
                _ObjectNumberVisibility = value;
                OnPropertyChanged(nameof(ObjectNumberVisibility));
            }
        }

        private bool _ObjectNameVisibility;
        public bool ObjectNameVisibility {
            get => _ObjectNameVisibility;
            set {
                _ObjectNameVisibility = value;
                OnPropertyChanged(nameof(ObjectNameVisibility));
            }
        }

        private bool _ObjectAddressVisibility;
        public bool ObjectAddressVisibility {
            get => _ObjectAddressVisibility;
            set {
                _ObjectAddressVisibility = value;
                OnPropertyChanged(nameof(ObjectAddressVisibility));
            }
        }

        private bool _WhoChangedVisibility;
        public bool WhoChangedVisibility {
            get => _WhoChangedVisibility;
            set {
                _WhoChangedVisibility = value;
                OnPropertyChanged(nameof(WhoChangedVisibility));
            }
        }

        private bool _DateChangedVisibility;
        public bool DateChangedVisibility {
            get => _DateChangedVisibility;
            set {
                _DateChangedVisibility = value;
                OnPropertyChanged(nameof(DateChangedVisibility));
            }
        }

        private bool _RrEveryMonthVisibility;
        public bool RrEveryMonthVisibility {
            get => _RrEveryMonthVisibility;
            set {
                _RrEveryMonthVisibility = value;
                OnPropertyChanged(nameof(RrEveryMonthVisibility));
            }
        }

        private bool _BeforeVisibility;
        public bool BeforeVisibility {
            get => _BeforeVisibility;
            set {
                _BeforeVisibility = value;
                OnPropertyChanged(nameof(BeforeVisibility));
            }
        }

        private bool _AfterVisibility;
        public bool AfterVisibility {
            get => _AfterVisibility;
            set {
                _AfterVisibility = value;
                OnPropertyChanged(nameof(AfterVisibility));
            }
        }

        private bool _DateStartVisibility;
        public bool DateStartVisibility {
            get => _DateStartVisibility;
            set {
                _DateStartVisibility = value;
                OnPropertyChanged(nameof(DateStartVisibility));
            }
        }

        private bool _CuratorVisibility;
        public bool CuratorVisibility {
            get => _CuratorVisibility;
            set {
                _CuratorVisibility = value;
                OnPropertyChanged(nameof(CuratorVisibility));
            }
        }

        private bool _ActVisibility;
        public bool ActVisibility {
            get => _ActVisibility;
            set {
                _ActVisibility = value;
                OnPropertyChanged(nameof(ActVisibility));
            }
        }

        private bool _PoliceVisibility;
        public bool PoliceVisibility {
            get => _PoliceVisibility;
            set {
                _PoliceVisibility = value;
                OnPropertyChanged(nameof(PoliceVisibility));
            }
        }

        private bool _OwnerVisibility;
        public bool OwnerVisibility {
            get => _OwnerVisibility;
            set {
                _OwnerVisibility = value;
                OnPropertyChanged(nameof(OwnerVisibility));
            }
        }

        private bool _AlarmVisibility;
        public bool AlarmVisibility {
            get => _AlarmVisibility;
            set {
                _AlarmVisibility = value;
                OnPropertyChanged(nameof(AlarmVisibility));
            }
        }

        private bool _DepartureVisibility;
        public bool DepartureVisibility {
            get => _DepartureVisibility;
            set {
                _DepartureVisibility = value;
                OnPropertyChanged(nameof(DepartureVisibility));
            }
        }

        private bool _ArrivalVisibility;
        public bool ArrivalVisibility {
            get => _ArrivalVisibility;
            set {
                _ArrivalVisibility = value;
                OnPropertyChanged(nameof(ArrivalVisibility));
            }
        }

        private bool _CancelVisibility;
        public bool CancelVisibility {
            get => _CancelVisibility;
            set {
                _CancelVisibility = value;
                OnPropertyChanged(nameof(CancelVisibility));
            }
        }

        private bool _ResultVisibility;
        public bool ResultVisibility {
            get => _ResultVisibility;
            set {
                _ResultVisibility = value;
                OnPropertyChanged(nameof(ResultVisibility));
            }
        }

        private int _ResultWidth;
        public int ResultWidth {
            get => _ResultWidth;
            set {
                _ResultWidth = value;
                OnPropertyChanged(nameof(ResultWidth));
            }
        }

        private DateTime _DateStart;
        public DateTime DateStart {
            get {
                if (_DateStart == DateTime.MinValue)
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                else
                    return _DateStart;
            }
            set {
                _DateStart = value;
                OnPropertyChanged("DateStart");
            }
        }

        private DateTime _DateEnd;
        public DateTime DateEnd {
            get {
                DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
                if (_DateEnd == DateTime.MinValue)
                    return DateTime.Now;
                //else if(DateTime.Now < end)
                //	return DateTime.Now;
                else
                    return DateTime.Parse(_DateEnd.ToShortDateString());
            }
            set {
                _DateEnd = value;
                OnPropertyChanged("DateEnd");
            }
        }

        //private string _DatePatternValue;
        //public string DatePatternValue {
        //	get => _DatePatternValue;
        //	set {
        //		_DatePatternValue = value;
        //		OnPropertyChanged("DatePatternValue");
        //	}
        //}

        private string _FilterParameter;
        public string FilterParameter {
            get => _FilterParameter;
            set {
                _FilterParameter = value;
                OnPropertyChanged("FilterParameter");
            }
        }

        private Binding _GroupPropertyName;
        public Binding GroupPropeprtyName {
            get => _GroupPropertyName;
            set {
                _GroupPropertyName = value;
                OnPropertyChanged(nameof(GroupPropeprtyName));
            }
        }

        private bool _VisibleChangeCostMonthlyPay;
        public bool VisibleChangeCostMonthlyPay {
            get => _VisibleChangeCostMonthlyPay;
            set {
                _VisibleChangeCostMonthlyPay = value;
                OnPropertyChanged(nameof(VisibleChangeCostMonthlyPay));
            }
        }
        private bool _VisibilityActs;
        public bool VisibilityActs {
            get => _VisibilityActs;
            set {
                _VisibilityActs = value;
                OnPropertyChanged(nameof(VisibilityActs));
            }
        }
        private bool _VisibilityLatesGBR;
        public bool VisibilityLatesGBR {
            get => _VisibilityLatesGBR;
            set {
                _VisibilityLatesGBR = value;
                OnPropertyChanged(nameof(VisibilityLatesGBR));
            }
        }

        private bool _VisibilityLatesPult;
        public bool VisibilityLatesPult {
            get => _VisibilityLatesPult;
            set {
                _VisibilityLatesPult = value;
                OnPropertyChanged(nameof(VisibilityLatesPult));
            }
        }

        private bool _VisibilityReglamentWorks;
        public bool VisibilityReglamentWorks {
            get => _VisibilityReglamentWorks;
            set {
                _VisibilityReglamentWorks = value;
                OnPropertyChanged(nameof(VisibilityReglamentWorks));
            }
        }

        //private bool _VisibleAlarmActs;
        //public bool VisibleAlarmActs {
        //	get => _VisibleAlarmActs;
        //	set {
        //		_VisibleAlarmActs = value;
        //		OnPropertyChanged("VisibleAlarmActs");
        //	}
        //}
        //private bool _VisibleLateGbr;
        //public bool VisibleLateGbr {
        //	get => _VisibleLateGbr;
        //	set {
        //		_VisibleLateGbr = value;
        //		OnPropertyChanged("VisibleLateGbr");
        //	}
        //}
        //private bool _VisibleLatePult;
        //public bool VisibleLatePult {
        //	get => _VisibleLatePult;
        //	set {
        //		_VisibleLatePult = value;
        //		OnPropertyChanged("VisibleLatePult");
        //	}
        //}


        private bool _GuardObjectsOnMapsVisibility;
        public bool GuardObjectsOnMapsVisibility {
            get => _GuardObjectsOnMapsVisibility;
            set {
                _GuardObjectsOnMapsVisibility = value;
                OnPropertyChanged(nameof(GuardObjectsOnMapsVisibility));
            }
        }

        private bool _CommonSettingsVisibility;
        public bool CommonSettingsVisibility {
            get => _CommonSettingsVisibility;
            set {
                _CommonSettingsVisibility = value;
                OnPropertyChanged(nameof(CommonSettingsVisibility));
            }
        }

        private bool _GuardObjectOnMapVisibility;
        public bool GuardObjectOnMapVisibility {
            get => _GuardObjectOnMapVisibility;
            set {
                _GuardObjectOnMapVisibility = value;
                OnPropertyChanged(nameof(GuardObjectOnMapVisibility));
            }
        }

        private bool _Loading;
        public bool Loading {
            get => _Loading;
            set {
                _Loading = value;
                OnPropertyChanged(nameof(Loading));
            }
        }

        private bool _TaskBarIconVisibility;
        public bool TaskBarIconVisibility {
            get => _TaskBarIconVisibility;
            set {
                _TaskBarIconVisibility = value;
                OnPropertyChanged(nameof(TaskBarIconVisibility));
            }
        }

        private RelayCommand _MenuOpen;
        public RelayCommand MenuOpen {
            get => _MenuOpen ??= new RelayCommand(obj => {
                FlyoutMenuState = FlyoutMenuState ? false : true;
            });
        }

        private RelayCommand _MenuSettingsOpen;
        public RelayCommand MenuSettingsOpen {
            get => _MenuSettingsOpen ??= new RelayCommand(obj => {
                FlyoutSettingVisibleState = FlyoutSettingVisibleState ? false : true;
            });
        }

        private RelayCommand _MenuSettingColumnsOpen;
        public RelayCommand MenuSettingColumnsOpen {
            get => _MenuSettingColumnsOpen ??= new RelayCommand(obj => {
                FlyoutSettingColumnsVisibleState = FlyoutSettingColumnsVisibleState ? false : true;
            });
        }

        private RelayCommand _FilterOpen;
        public RelayCommand FilterOpen {
            get => _FilterOpen ??= new RelayCommand(obj => {
                //FlyoutSettingVisibleState = FlyoutSettingVisibleState ? false : true;
                if (_SelectedReport.ReportID == Guid.Parse("23f71a51-f909-417c-9b09-69534715c689")) {
                    FlyoutSettingMapsVisibleState = !FlyoutSettingMapsVisibleState;
                }
                else
                    FlyoutMenuState = !FlyoutSettingVisibleState;
            }, obj => SelectedReport != null);
        }
        private RelayCommand _Search;
        public RelayCommand Search {
            get => _Search ??= new RelayCommand(obj => {
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += (s, e) => {
                    Loading = true;
                    Reports = FullReports;
                    if (!string.IsNullOrEmpty(FilterParameter) || !string.IsNullOrWhiteSpace(FilterParameter)) {
                        bool isDigit = false;
                        char[] filter = FilterParameter.ToCharArray();
                        foreach (char item in filter) {
                            if (char.IsDigit(item))
                                isDigit = true;
                            else {
                                isDigit = false;
                                break;
                            }
                        }
                        //TODO: Проверить что второй раз ищется
                        //FullReports = Reports;
                        if (isDigit)
                            Reports = new ObservableCollection<Report>(Reports.Where(x => x.ObjectNumber.ToString().Contains(FilterParameter)));
                        else
                            Reports = new ObservableCollection<Report>(Reports.Where(x => x.ObjectAddress.ToLower().Contains(FilterParameter.ToLower()) || x.ObjectName.ToLower().Contains(FilterParameter.ToLower())));
                        OnPropertyChanged("Reports");
                    }
                    else
                        MessageBox.Show("Значение для фильтрации не может быть пустым");
                };
                bw.RunWorkerCompleted += (s, e) => {
                    Loading = false;
                };
                bw.RunWorkerAsync();
            });
        }
        private RelayCommand _Test;
        public RelayCommand Test {
            get => _Test ??= new RelayCommand(obj => {
                MessageBox.Show(Environment.UserName);
            });
        }

        private RelayCommand _ClearFilter;
        public RelayCommand ClearFilter {
            get => _ClearFilter ??= new RelayCommand(obj => {
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += (s, e) => {
                    Loading = true;
                    FilterParameter = null;
                    Reports = FullReports;
                };
                bw.RunWorkerCompleted += (s, e) => {
                    Loading = false;
                };
                bw.RunWorkerAsync();
            });
        }
        private RelayCommand _SelectDatePattern;
        public RelayCommand SelectDatePattern {
            get => _SelectDatePattern ??= new RelayCommand(obj => {
                DropDownButton o = obj as DropDownButton;
                MessageBox.Show(o.Items.CurrentItem.ToString());
            });
        }
        private RelayCommand _GetData;
        public RelayCommand GetData {
            get => _GetData ??= new RelayCommand(obj => {
                //Dispatcher.CurrentDispatcher.Invoke(() => { 
                if (DateEnd < DateStart)
                    MessageBox.Show("Дата окончания не может быть раньше даты начала.");
                else {
                    Reports.Clear();
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += (s, e) => {
                        Loading = true;
                        //Изменение стоимости Абонентской платы
                        if (SelectedReport.ReportID == Guid.Parse("b904a30b-16b1-4f59-a76d-bd981e18c930")) {
                            //Binding binding = new Binding("WhoChanged");
                            //GroupPropeprtyName = binding;
                            //TODO: переделать на отдельный метод
                            VisibleChangeCostMonthlyPay = true;
                            VisibilityActs = false;
                            VisibilityLatesGBR = false;
                            VisibilityLatesPult = false;
                            VisibilityReglamentWorks = false;
                            using (Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
                                //TODO: Перенести в get
                                NewGuardObjectHistory before = null;
                                NewGuardObjectHistory after = null;
                                DateTime start = DateTime.Parse(DateStart.ToShortDateString()).AddHours(-5);
                                DateTime end = DateTime.Parse(DateEnd.ToShortDateString()).AddHours(-5);
                                List<NewGuardObjectHistory> history = context.NewGuardObjectHistory.Where(x => x.ModifiedOn >= start && x.ModifiedOn <= end).ToList<NewGuardObjectHistory>();
                                var r = history.GroupBy(a => new { a.NewGuardObjectId, a.ModifiedBy, DateTime = DateTime.Parse(a.ModifiedOn.ToString()) }).ToList();
                                foreach (var item in r) {
                                    before = null;
                                    after = null;
                                    foreach (var i in item)
                                        if (i.HistoryState == "Старый")
                                            before = i;
                                        else
                                            after = i;
                                    List<Comparator> t = CompareObject(before, after);
                                    if (t != null)
                                        foreach (var compr in t.Where(x => x.FieldName.Equals("NewMonthlypay"))) {
                                            string WhoChanged = context.SystemUserBase.FirstOrDefault(x => x.SystemUserId == after.ModifiedBy).FullName;
                                            Guid? CuratorId = context.NewGuardObjectExtensionBase.FirstOrDefault(x => x.NewGuardObjectId == after.NewGuardObjectId).NewCurator;
                                            string curatorName = null;
                                            if (CuratorId.HasValue) {
                                                Guid _id = Guid.Empty;
                                                if (Guid.TryParse(CuratorId.Value.ToString(), out _id)) {
                                                    curatorName = context.SystemUserBase.FirstOrDefault(x => x.SystemUserId == CuratorId).FullName;
                                                }
                                            }
                                            DateTime? WhenChanged = after.ModifiedOn;
                                            //object oldValue = null;
                                            //object newValue = null;
                                            //foreach(Comparator c in t) {
                                            //	oldValue = c.OldValue;
                                            //	newValue = c.NewValue;
                                            //}
                                            NewGuardObjectExtensionBase objectExtensionBase = context.NewGuardObjectExtensionBase.FirstOrDefault(x => x.NewGuardObjectId == after.NewGuardObjectId);
                                            if (objectExtensionBase != null)
                                                App.Current.Dispatcher.Invoke((System.Action)delegate {
                                                    Reports.Add(new Report() {
                                                        Before = compr.OldValue.ToString(),
                                                        After = compr.NewValue.ToString(),
                                                        Curator = curatorName,
                                                        DateChanged = WhenChanged,
                                                        DateStart = objectExtensionBase.NewDateStart,
                                                        WhoChanged = WhoChanged,
                                                        ObjectAddress = objectExtensionBase.NewAddress,
                                                        ObjectName = objectExtensionBase.NewName,
                                                        ObjectNumber = objectExtensionBase.NewObjectNumber
                                                    });
                                                });
                                        }
                                    //if(t != null)
                                    //	if(t.Any()) {

                                    //	}
                                }
                            }
                        }
                        //По актам
                        if (SelectedReport.ReportID == Guid.Parse("fa4dd0a5-5b15-45b4-a55a-433267fa50ff")) {
                            //TODO: переделать на отдельный метод
                            VisibleChangeCostMonthlyPay = false;
                            VisibilityActs = true;
                            VisibilityLatesGBR = false;
                            VisibilityLatesPult = false;
                            VisibilityReglamentWorks = false;
                            using (Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
                                DateTime start = DateTime.Parse(DateStart.ToShortDateString()).AddHours(-5);
                                DateTime end = DateTime.Parse(DateEnd.ToShortDateString()).AddHours(-5);
                                var result = context.NewAlarmExtensionBase.Where(x => x.NewAlarmDt >= start && x.NewAlarmDt < end && x.NewAct == true);
                                if (result != null)
                                    if (result.Any()) {
                                        foreach (var item in result) {
                                            using (Vityaz_MSCRMContext context1 = new Vityaz_MSCRMContext()) {
                                                var andromeda = context1.NewAndromedaExtensionBase.Where(x => x.NewAndromedaId == item.NewAndromedaAlarm).ToList();
                                                App.Current.Dispatcher.Invoke((System.Action)delegate {
                                                    Reports.Add(new Report() {
                                                        ObjectName = andromeda.FirstOrDefault(x => x.NewName != null).NewName,
                                                        ObjectNumber = andromeda.FirstOrDefault().NewNumber,
                                                        ObjectAddress = andromeda.FirstOrDefault().NewAddress,
                                                        Os = item.NewOnc,
                                                        Ps = item.NewPs,
                                                        Trs = item.NewTpc,
                                                        Group = item.NewGroup + 69,
                                                        Alarm = item.NewAlarmDt,
                                                        Arrival = item.NewArrival,
                                                        Departure = item.NewDeparture,
                                                        Cancel = item.NewCancel,
                                                        Result = item.NewName,
                                                        Owner = item.NewOwner,
                                                        Police = item.NewPolice,
                                                        Act = item.NewAct,
                                                        DateSort = item.NewAlarmDt.Value.Date.ToShortDateString()
                                                    });
                                                });
                                            }
                                        }
                                    }
                            }
                        }
                        //По опозданиям операторов
                        if (SelectedReport.ReportID == Guid.Parse("a35a2859-3e10-42f1-9e9b-5f29b5e953d9")) {
                            //TODO: переделать на отдельный метод
                            VisibleChangeCostMonthlyPay = false;
                            VisibilityActs = false;
                            VisibilityLatesGBR = false;
                            VisibilityLatesPult = true;
                            VisibilityReglamentWorks = false;
                            using (Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
                                DateTime start1 = DateTime.Parse(DateStart.ToShortDateString()).AddHours(-5);
                                DateTime end1 = DateTime.Parse(DateEnd.ToShortDateString()).AddHours(-5);
                                var result = context.NewAlarmExtensionBase.Where(x => x.NewAlarmDt >= start1 && x.NewAlarmDt < end1);
                                if (result != null)
                                    if (result.Any()) {
                                        foreach (var item1 in result) {
                                            if (item1.NewDeparture.HasValue && item1.NewAlarmDt.HasValue) {
                                                if ((item1.NewDeparture - item1.NewAlarmDt).Value.TotalSeconds > 30) {
                                                    using (Vityaz_MSCRMContext context1 = new Vityaz_MSCRMContext()) {
                                                        var andromeda = context1.NewAndromedaExtensionBase.Where(x => x.NewAndromedaId == item1.NewAndromedaAlarm).ToList();
                                                        App.Current.Dispatcher.Invoke((System.Action)delegate {
                                                            Reports.Add(new Report() {
                                                                ObjectName = andromeda.FirstOrDefault(x => x.NewName != null).NewName,
                                                                ObjectNumber = andromeda.FirstOrDefault().NewNumber,
                                                                ObjectAddress = andromeda.FirstOrDefault().NewAddress,
                                                                Os = item1.NewOnc,
                                                                Ps = item1.NewPs,
                                                                Trs = item1.NewTpc,
                                                                Group = item1.NewGroup + 69,
                                                                Alarm = item1.NewAlarmDt,
                                                                Arrival = item1.NewArrival,
                                                                Departure = item1.NewDeparture,
                                                                Cancel = item1.NewCancel,
                                                                Result = item1.NewName,
                                                                Owner = item1.NewOwner,
                                                                Police = item1.NewPolice,
                                                                Act = item1.NewAct,
                                                                Late = (item1.NewDeparture - item1.NewAlarmDt).Value.ToString(),
                                                                HourSort = item1.NewAlarmDt.Value.AddHours(5).Hour.ToString()
                                                            });
                                                        });
                                                    }
                                                }
                                            }
                                        }
                                    }
                            }
                        }
                        //По опозданиям ГБР
                        if (SelectedReport.ReportID == Guid.Parse("8a7e33df-e27d-413c-80d5-e3812b57853c")) {
                            //TODO: переделать на отдельный метод
                            VisibleChangeCostMonthlyPay = false;
                            VisibilityActs = false;
                            VisibilityLatesGBR = true;
                            VisibilityLatesPult = false;
                            VisibilityReglamentWorks = false;
                            using (Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
                                DateTime start2 = DateTime.Parse(DateStart.ToShortDateString()).AddHours(-5);
                                DateTime end2 = DateTime.Parse(DateEnd.ToShortDateString()).AddHours(-5);
                                var result = context.NewAlarmExtensionBase.Where(x => x.NewAlarmDt >= start2 && x.NewAlarmDt < end2);
                                if (result != null)
                                    if (result.Any()) {
                                        foreach (var item2 in result) {
                                            if (item2.NewArrival.HasValue && item2.NewDeparture.HasValue)
                                                if ((item2.NewArrival - item2.NewDeparture).Value.TotalMinutes >= 12) {
                                                    using (Vityaz_MSCRMContext context1 = new Vityaz_MSCRMContext()) {
                                                        var andromeda = context1.NewAndromedaExtensionBase.Where(x => x.NewAndromedaId == item2.NewAndromedaAlarm).ToList();
                                                        App.Current.Dispatcher.Invoke((System.Action)delegate {
                                                            Reports.Add(new Report() {
                                                                ObjectName = andromeda.FirstOrDefault(x => x.NewName != null).NewName,
                                                                ObjectNumber = andromeda.FirstOrDefault().NewNumber,
                                                                ObjectAddress = andromeda.FirstOrDefault().NewAddress,
                                                                Os = item2.NewOnc,
                                                                Ps = item2.NewPs,
                                                                Trs = item2.NewTpc,
                                                                Group = item2.NewGroup + 69,
                                                                Alarm = item2.NewAlarmDt,
                                                                Arrival = item2.NewArrival,
                                                                Departure = item2.NewDeparture,
                                                                Cancel = item2.NewCancel,
                                                                Result = item2.NewName,
                                                                Owner = item2.NewOwner,
                                                                Police = item2.NewPolice,
                                                                Act = item2.NewAct,
                                                                Late = (item2.NewArrival - item2.NewDeparture).Value.ToString(),
                                                                HourSort = item2.NewAlarmDt.Value.AddHours(5).Hour.ToString()
                                                            });
                                                        });
                                                    }
                                                }
                                        }
                                    }
                            }
                        }
                        //регламентные работы
                        if (SelectedReport.ReportID == Guid.Parse("7C9C1F49-6218-4C9A-8F17-126626E5D1D3")) {
                            //Binding binding = new Binding("WhoChanged");
                            //GroupPropeprtyName = binding;
                            //TODO: переделать на отдельный метод					
                            VisibleChangeCostMonthlyPay = false;
                            VisibilityActs = false;
                            VisibilityLatesGBR = false;
                            VisibilityLatesPult = false;
                            VisibilityReglamentWorks = true;
                            using (Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
                                //var rr = context.NewGuardObjectExtensionBase.Where(y=>y.NewRemoveDate==null && y.NewPriostDate==null && y.NewObjDeleteDate==null).Where(x => x.NewRrOnOff == true || x.NewRrOs == true || x.NewRrPs == true || x.NewRrVideo == true || x.NewRrSkud == true);
                                var rr = from goeb in context.NewGuardObjectExtensionBase
                                         join gob in context.NewGuardObjectBase on goeb.NewGuardObjectId equals gob.NewGuardObjectId
                                         where gob.Statecode == 0 && gob.Statuscode == 1 && gob.DeletionStateCode == 0
                                            && goeb.NewRemoveDate == null && goeb.NewPriostDate == null && goeb.NewObjDeleteDate == null &&
                                            goeb.NewRrOnOff == true /*&& ( goeb.NewRrOs == true || goeb.NewRrPs == true || goeb.NewRrVideo == true || goeb.NewRrSkud == true)*/
                                         select new {
                                             NewObjectNumber = goeb.NewObjectNumber,
                                             NewName = goeb.NewName,
                                             NewAddress = goeb.NewAddress,
                                             NewRrOnOff = goeb.NewRrOnOff,
                                             NewRrOs = goeb.NewRrOs,
                                             NewRrPs = goeb.NewRrPs,
                                             NewRrVideo = goeb.NewRrVideo,
                                             NewRrSkud = goeb.NewRrSkud,
                                             NewGuardObjectId = goeb.NewGuardObjectId
                                         };
                                if (rr != null)
                                    foreach (var item in rr) {
                                        App.Current.Dispatcher.Invoke((System.Action)delegate {
                                            Reports.Add(new Report() {
                                                ObjectNumber = item.NewObjectNumber,
                                                ObjectName = item.NewName,
                                                ObjectAddress = item.NewAddress,
                                                RrEveryMonth = item.NewRrOnOff,
                                                RrOS = item.NewRrOs,
                                                RrPS = item.NewRrPs,
                                                RrVideo = item.NewRrVideo,
                                                RrSkud = item.NewRrSkud,
                                                ObjectID = item.NewGuardObjectId
                                            });
                                        });
                                    }

                                #region данным кодом мы можем получить историю изменений  по галочкам
                                ////TODO: Перенести в get
                                NewGuardObjectHistory before = null;
                                NewGuardObjectHistory after = null;
                                DateTime start = DateTime.Parse(DateStart.ToShortDateString()).AddHours(-5);
                                DateTime end = DateTime.Parse(DateEnd.ToShortDateString()).AddHours(-5);
                                List<NewGuardObjectHistory> history = context.NewGuardObjectHistory.Where(x => x.ModifiedOn >= start && x.ModifiedOn <= end).ToList<NewGuardObjectHistory>();
                                if (history.Where(x => x.NewRrOnOff != null || x.NewRrOs != null || x.NewRrPs != null || x.NewRrSkud != null || x.NewRrVideo != null).Count() > 0) {
                                    var r = history.GroupBy(a => new { a.NewGuardObjectId, a.ModifiedBy, DateTime = DateTime.Parse(a.ModifiedOn.ToString()) }).ToList();
                                    foreach (var item in r) {
                                        before = null;
                                        after = null;
                                        foreach (var i in item)
                                            if (i.HistoryState == "Старый")
                                                before = i;
                                            else
                                                after = i;
                                        List<Comparator> t = CompareObject(before, after);
                                        if (t != null)
                                            foreach (var compr in t.Where(x => x.FieldName.Equals("NewRrOnOff") || x.FieldName.Equals("NewRrOs") || x.FieldName.Equals("NewRrPs") || x.FieldName.Equals("NewRrVideo") || x.FieldName.Equals("NewRrSkud"))) {
                                                string WhoChanged = context.SystemUserBase.FirstOrDefault(x => x.SystemUserId == after.ModifiedBy).FullName;
                                                Guid? CuratorId = context.NewGuardObjectExtensionBase.FirstOrDefault(x => x.NewGuardObjectId == after.NewGuardObjectId).NewCurator;
                                                string curatorName = null;
                                                if (CuratorId.HasValue) {
                                                    Guid _id = Guid.Empty;
                                                    if (Guid.TryParse(CuratorId.Value.ToString(), out _id)) {
                                                        curatorName = context.SystemUserBase.FirstOrDefault(x => x.SystemUserId == CuratorId).FullName;
                                                    }
                                                }
                                                DateTime? WhenChanged = after.ModifiedOn;
                                                NewGuardObjectExtensionBase objectExtensionBase = context.NewGuardObjectExtensionBase.FirstOrDefault(x => x.NewGuardObjectId == after.NewGuardObjectId);
                                                if (objectExtensionBase != null)
                                                    App.Current.Dispatcher.Invoke((System.Action)delegate {
                                                        ReglamentWorksDetailCollection.Add(new ReglamentWorksDetail() {
                                                            UserChanged = WhoChanged,
                                                            DateChanged = WhenChanged,
                                                            FieldChanged = compr.FieldName,
                                                            BeforeChanged = compr.OldValue.ToString(),
                                                            AfterChanged = compr.NewValue.ToString()
                                                        });
                                                    });
                                            }
                                    }
                                }
                                #endregion
                            }
                        }
                        //охр. объекты на карте
                        if (SelectedReport.ReportID == Guid.Parse("23F71A51-F909-417C-9B09-69534715C689")) {
                            GuardObjectsOnMapsVisibility = true;
                            VisibleChangeCostMonthlyPay = false;
                            VisibilityActs = false;
                            VisibilityLatesGBR = false;
                            VisibilityLatesPult = false;
                            VisibilityReglamentWorks = false;
                        }

                        FlyoutMenuState = false;
                        FlyoutSettingVisibleState = false;
                        FullReports = Reports;
                    };
                    bw.RunWorkerCompleted += (s, e) => {
                        Loading = false;
                    };
                    bw.RunWorkerAsync();
                }
            });
        }


        public ObservableCollection<AgreementDetailModel> AgreementDetail {
            get => _AgreementDetail;
            set {
                _AgreementDetail = value;
                OnPropertyChanged(nameof(AgreementDetail));
            }
        }

        private RelayCommand _DetailCommand;
        public RelayCommand DetailCommand {
            get => _DetailCommand ??= new RelayCommand(obj => {
                if (AgreementDetail != null)
                    AgreementDetail.Clear();
                if (obj != null) {
                    var Agreement = obj as Report;
                    if (Agreement != null) {
                        using (Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
                            var agreements = from goeb in context.NewGuardObjectExtensionBase
                                             join ab in context.AccountBase on goeb.NewAccount equals ab.AccountId
                                             join ageb in context.NewAgreementExtensionBase on ab.AccountId equals ageb.NewBpAgreement
                                             join agb in context.NewAgreementBase on ageb.NewAgreementId equals agb.NewAgreementId
                                             join eeb in context.NewExecutorExtensionBase on ageb.NewExecutorAgreement equals eeb.NewExecutorId
                                             join dteb in context.NewDogovorTypeExtensionBase on ageb.NewDogovorTypeAgreement equals dteb.NewDogovorTypeId
                                             where goeb.NewGuardObjectId == Agreement.ObjectID && dteb.NewTechService == true
                                             && agb.Statecode == 0 && agb.Statuscode == 1 && agb.DeletionStateCode == 0
                                             && ageb.NewDeleteDate == null
                                             select new { AgreementNumber = ageb.NewNumber, AgreementExecutor = eeb.NewName, AgreementDate = ageb.NewDate, AgreementType = dteb.NewName };
                            foreach (var item in agreements)
                                App.Current.Dispatcher.Invoke((System.Action)delegate {
                                    AgreementDetail.Add(new AgreementDetailModel(item.AgreementNumber, item.AgreementExecutor, item.AgreementDate, item.AgreementType));
                                });
                        }
                    }
                }
            });
        }

        private RelayCommand _ViewTotalCommand;
        public RelayCommand ViewTotalCommand {
            get => _ViewTotalCommand ??= new RelayCommand(obj => {
                //изм. абонентской платы
                if (SelectedReport.ReportID == Guid.Parse("B904A30B-16B1-4F59-A76D-BD981E18C930")) {
                    if (obj == null) {
                        TotalManagers = new ObservableCollection<TotalManagers>();
                        int CountRecords = Reports.Count;
                        var ChangeByUser = Reports.GroupBy(x => x.WhoChanged);
                        int PlusCounter = 0;
                        int MinusCounter = 0;
                        float PlusSum = 0;
                        float MinusSum = 0;
                        //Todo: доделать общую сумму приходов/расходов/общую
                        //float AllSum = 0;
                        foreach (var item in ChangeByUser) {
                            PlusCounter = 0;
                            MinusCounter = 0;
                            PlusSum = 0;
                            MinusSum = 0;
                            foreach (var i in item) {
                                if ((ParseDigit(i.After) - ParseDigit(i.Before)) > 0) {
                                    PlusCounter++;
                                    PlusSum += (ParseDigit(i.After) - ParseDigit(i.Before));
                                }
                                else {
                                    MinusCounter++;
                                    MinusSum += (ParseDigit(i.After) - ParseDigit(i.Before));
                                }
                            }
                            TotalManagers.Add(new TotalManagers() {
                                ManagerName = item.Key.ToString(),
                                AllCountChanges = item.Count(),
                                MajorCountChanges = PlusCounter,
                                MinorCountChanges = MinusCounter,
                                MajorSumChanges = PlusSum,
                                MinorSumChanges = MinusSum,
                                DeltaSum = (PlusSum - MinusSum * (-1))
                            });
                            MessageBox.Show(item.Key.ToString() + Environment.NewLine
                                + " Всего изменений: " + item.Count().ToString() + Environment.NewLine
                                + "Положительных: " + PlusCounter.ToString() + " на сумму: " + PlusSum.ToString() + Environment.NewLine
                                + "Отрицательных: " + MinusCounter.ToString() + " на сумму: " + MinusSum.ToString() + Environment.NewLine
                                + "Изменение: " + (PlusSum - MinusSum * (-1)).ToString()
                                );
                        }
                    }
                    else {
                        TotalManagers = new ObservableCollection<TotalManagers>();
                        int CountRecords = Reports.Count;
                        var ChangeByUser = Reports.Where(x => x.WhoChanged == obj.ToString()).ToList();
                        int PlusCounter = 0;
                        int MinusCounter = 0;
                        float PlusSum = 0;
                        float MinusSum = 0;
                        //Todo: доделать общую сумму приходов/расходов/общую
                        //float AllSum = 0;
                        foreach (var item in ChangeByUser) {
                            //PlusCounter = 0;
                            //MinusCounter = 0;
                            //PlusSum = 0;
                            //MinusSum = 0;
                            if ((ParseDigit(item.After) - ParseDigit(item.Before)) > 0) {
                                PlusCounter++;
                                PlusSum += (ParseDigit(item.After) - ParseDigit(item.Before));
                            }
                            else {
                                MinusCounter++;
                                MinusSum += (ParseDigit(item.After) - ParseDigit(item.Before));
                            }
                        }
                        MessageBox.Show(obj.ToString() + Environment.NewLine
                            + "Всего изменений: " + ChangeByUser.Count.ToString() + Environment.NewLine
                            + "Положительных: " + PlusCounter.ToString() + " на сумму: " + PlusSum.ToString() + Environment.NewLine
                            + "Отрицательных: " + MinusCounter.ToString() + " на сумму: " + MinusSum.ToString() + Environment.NewLine
                            + "Разница: " + (PlusSum - MinusSum * (-1)).ToString()
                            );
                    }
                }

            }, obj => Reports.Count() > 0);
        }

        private int ParseDigit(string param) {
            string r = null;
            if (string.IsNullOrEmpty(param))
                return 0;
            else if (!int.TryParse(param, out _)) {
                char[] arr = param.ToCharArray();
                foreach (var item in arr) {
                    if (char.IsDigit(item)) {
                        r += item;
                    }
                    else if (char.IsPunctuation(item))
                        break;
                }
                return int.Parse(r);
            }
            else
                return int.Parse(param);
        }

        private List<Comparator> CompareObject(NewGuardObjectHistory _old, NewGuardObjectHistory _new) {
            List<Comparator> comparator = new List<Comparator>();
            if (_old == null || _new == null)
                return null;
            else {
                foreach (var item in _old.GetType().GetProperties()) {
                    object oldValue = _old.GetType().GetProperty(item.Name).GetValue(_old);
                    object newValue = _new.GetType().GetProperty(item.Name).GetValue(_new);
                    if (oldValue != null)
                        if (oldValue.Equals(newValue))
                            continue;
                        else
                                //foreach(var property in _old.GetType().GetProperties()) {
                                if (_old.GetType().GetProperty(item.Name).GetValue(_old) != null && _new.GetType().GetProperty(item.Name).GetValue(_new) != null)
                            if (!_old.GetType().GetProperty(item.Name).GetValue(_old).Equals(_new.GetType().GetProperty(item.Name).GetValue(_new))) {
                                comparator.Add(new Comparator() {
                                    FieldName = item.Name,
                                    OldValue = (_old.GetType().GetProperty(item.Name).GetValue(_old) ?? ""),
                                    NewValue = (_new.GetType().GetProperty(item.Name).GetValue(_new) ?? ""),

                                });
                                //}
                            }
                            //if(item.Name.ToString().Equals("NewMonthlypay"))
                            //	comparator.Add(new Comparator() {
                            //		FieldName = item.Name,
                            //		OldValue = _old.GetType().GetProperty(item.Name).GetValue(_old) == null ? null : _old.GetType().GetProperty(item.Name).GetValue(_old).ToString(),
                            //		NewValue = _new.GetType().GetProperty(item.Name).GetValue(_new) == null ? null : _new.GetType().GetProperty(item.Name).GetValue(_new).ToString()
                            //	});
                            else
                                continue;
                }
                return comparator;
            }
        }

        private ObservableCollection<ReportsList> _ReportList = new ObservableCollection<ReportsList>();
        private ObservableCollection<DatePattern> _DatePatterns = new ObservableCollection<DatePattern>();
        private ObservableCollection<Report> _Reports = new ObservableCollection<Report>();
        private ObservableCollection<TotalManagers> _TotalManagers = new ObservableCollection<TotalManagers>();
        private ObservableCollection<TotalManagersChart> _TotalManagersChart = new ObservableCollection<TotalManagersChart>();
        private ObservableCollection<ReglamentWorksDetail> _ReglamentWorksDetailCollection = new ObservableCollection<ReglamentWorksDetail>();
        private ObservableCollection<AgreementDetailModel> _AgreementDetail = new ObservableCollection<AgreementDetailModel>();


        private ObservableCollection<ObjType> _GroupsList = new ObservableCollection<ObjType>();
        public ObservableCollection<ObjType> GroupsList {
            get => _GroupsList;
            set {
                _GroupsList = value;
                OnPropertyChanged(nameof(GroupsList));
            }
        }

        private int _GroupId;
        public int GroupId {
            get => _GroupId;
            set {
                _GroupId = value;
                OnPropertyChanged(nameof(GroupId));
            }
        }

        private bool _SelectedGroupChecked;
        public bool SelectedGroupChecked {
            get => _SelectedGroupChecked;
            set {
                _SelectedGroupChecked = value;
                OnPropertyChanged(nameof(SelectedGroupChecked));
            }
        }

        private ObjType _SelectedGroup;
        public ObjType SelectedGroup {
            get => _SelectedGroup;
            set {
                _SelectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }

        public GMapControl gmaps_contol { get; set; } = new GMapControl();

        private RelayCommand _SelectGroupCommand;
        public RelayCommand SelectGroupCommand {
            get => _SelectGroupCommand ??= new RelayCommand(async obj => {
                System.Windows.Controls.CheckBox chck = obj is System.Windows.Controls.CheckBox ? obj as System.Windows.Controls.CheckBox : null;
                List<ColorModel> cm = ColorList.Where(x => x.Isfree == true).ToList();
                if (cm.Count <= 0) {
                    chck.IsChecked = false;
                    WPFMessageBoxService service = new WPFMessageBoxService();
                    service.ShowMessage("Достигнуто ограничение по количеству отображаемых объектов", "Ошибка");
                }

                if (chck != null) {
                    //надо рисовать маркеры
                    if (chck.IsChecked.Value) {
                        if (cm.Count>0) {

                            using (A28Context context = new A28Context()) {
                                foreach (var item in context.Object.Where(x => x.ObjTypeId == Int16.Parse(chck.Tag.ToString()) && x.RecordDeleted == false && x.Latitude != null && x.Longitude != null)) {
                                    PointLatLng point = new PointLatLng((double)item.Latitude, (double)item.Longitude);
                                    GMapMarker marker = new GMapMarker(point) {
                                        Shape = new Ellipse {
                                            Width = 12,
                                            Height = 12,
                                            Stroke = cm.First().Color,
                                            StrokeThickness = 7.5,
                                            ToolTip = Convert.ToString(item.ObjectNumber, 16)+" ("+ chck.Content + ")" + Environment.NewLine + item.Name,
                                            AllowDrop=true
                                        }
                                    };
                                    marker.Tag = chck.Tag;
                                    marker.PropertyChanged += Marker_PropertyChanged;
                                    gmaps_contol.Markers.Add(marker);
                                    //GeoCoderStatusCode status;
                                    //GMapProviders.GoogleMap.GetPlacemark(marker.Position, out status);
                                }
                                ColorList.First(x => x.Color == cm.First().Color).Isfree = false;
                                ColorList.First(x => x.Color == cm.First().Color).ObjTypeId = chck.Tag.ToString();
                                GroupsList.First(x => x.ObjTypeId == Int16.Parse(chck.Tag.ToString())).IsShowOnMap=true;
                            }
                        }
                    }
                    else {
                        var markers = gmaps_contol.Markers.Where(x => x.Tag == chck.Tag).ToList();
                        foreach (GMapMarker item in markers) {
                            gmaps_contol.Markers.Remove(item);
                        }
                        GroupsList.First(x => x.ObjTypeId == Int16.Parse(chck.Tag.ToString())).IsShowOnMap = false;
                        if (ColorList.Where(x => x.Isfree == true).ToList().Count > 0) 
                            ColorList.First(x => x.ObjTypeId == chck.Tag.ToString()).Isfree = true;
                    }
                }
                //GroupId = GroupsList.First(x => x.ObjTypeName == chck.Tag.ToString()).ObjTypeId;

                //gmaps_contol.Markers.Clear();

                //string commandParameter = obj is string ? obj as string : null;
                //if (!string.IsNullOrEmpty(commandParameter)) {
                //    int GroupId = GroupsList.First(x => x.ObjTypeName == commandParameter).ObjTypeId;
                //using (A28Context context = new A28Context()) {
                //    foreach (var item in context.Object.Where(x => x.ObjTypeId == GroupId && x.RecordDeleted == false && x.Latitude!=null && x.Longitude!=null)) {
                //        PointLatLng point = new PointLatLng((double)item.Latitude, (double)item.Longitude);
                //        GMapMarker marker = new GMapMarker(point) {
                //            Shape = new Ellipse {
                //                Width = 12,
                //                Height = 12,
                //                Stroke = Brushes.Red,
                //                StrokeThickness = 4.5,
                //                ToolTip= Convert.ToString(item.ObjectNumber, 16) + Environment.NewLine + item.Name                                
                //            }
                //        };
                //        gmaps_contol.Markers.Add(marker);
                //    }
                //}
            });
        }

        private void Marker_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            //throw new NotImplementedException();
        }
        public MainWindowViewModel() {
            //ReportList.Add(new ReportsList() { ReportID = Guid.NewGuid(), ReportName = "Отчёт изменения стоимости абонентской платы" });
            using (ReportContext.ReportContext context = new ReportContext.ReportContext()) {
                string login = Environment.UserName;
                using (ReportContext.ReportContext context1 = new ReportContext.ReportContext()) {
                    foreach (var accessReports in context.UsersReports.Where(x => x.UsrLogin.ToLower().Contains(login.ToLower()))) {
                        ReportList.Add(new ReportsList() {
                            ReportID = context1.Reports.FirstOrDefault(y => y.RptId == accessReports.RptId).RptId,
                            ReportName = context1.Reports.FirstOrDefault(y => y.RptId == accessReports.RptId).RptName
                        });
                    }
                }
                //foreach(var item in context.Reports.ToList()) {
                //	ReportList.Add(new ReportsList() { ReportID = item.RptId, ReportName = item.RptName });
                //}
                GMaps.Instance.Mode = AccessMode.ServerAndCache;
                gmaps_contol.MapProvider = GMap.NET.MapProviders.YandexMapProvider.Instance;
                gmaps_contol.MinZoom = 5;
                gmaps_contol.MaxZoom = 17;
                gmaps_contol.Zoom = 5;
                gmaps_contol.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
                gmaps_contol.CanDragMap = true;
                gmaps_contol.DragButton = MouseButton.Left;
                gmaps_contol.CenterPosition = new PointLatLng(55.159904, 61.401919);
            }
            using (A28Context context = new A28Context()) {
                foreach (ObjType item in context.ObjType.Where(x => x.RecordDeleted == false && x.ObjTypeName.ToLower().Contains("маршрут")).ToList()) {
                    GroupsList.Add(item);
                }
            }
            ColorList.Add(new ColorModel() { Color = Brushes.Red, Isfree = true });//красный
            ColorList.Add(new ColorModel() { Color = Brushes.DarkBlue, Isfree = true });//синий
            ColorList.Add(new ColorModel() { Color = Brushes.Green, Isfree = true });//зеленый
            ColorList.Add(new ColorModel() { Color = Brushes.Black, Isfree = true });//черный
            ColorList.Add(new ColorModel() { Color = Brushes.Purple, Isfree = true });//фиолетовый
            ColorList.Add(new ColorModel() { Color = Brushes.Orange, Isfree = true });//оранжевый
            ColorList.Add(new ColorModel() { Color = Brushes.Yellow, Isfree = true });//желтый
            ColorList.Add(new ColorModel() { Color = Brushes.Blue, Isfree = true });//голубой
            ColorList.Add(new ColorModel() { Color = Brushes.White, Isfree = true });//белый


            //GuardObjectsOnMapsVisibility = true;
            //DatePatterns.Add(new DatePattern() { Id = Guid.NewGuid(), Name = "Текущий месяц" });
            //DatePatterns.Add(new DatePattern() { Id = Guid.NewGuid(), Name = "Прошлый месяц" });
            //DatePatterns.Add(new DatePattern() { Id = Guid.NewGuid(), Name = "Текущий квартал" });
            //DatePatterns.Add(new DatePattern() { Id = Guid.NewGuid(), Name = "Прошлый квартал" });

            //MapProviders = GMap.NET.MapProviders.GMapProvider..YandexMapProvider;
            //SystemUserBase systemUserBase = new SystemUserBase();
            //foreach(FieldInfo item in systemUserBase.GetType().GetFields()) {
            //	int y = 0;
            //}	
        }

        private ObservableCollection<ColorModel> _ColorList = new ObservableCollection<ColorModel>();
        public ObservableCollection<ColorModel> ColorList {
            get => _ColorList;
            set {
                _ColorList = value;
                OnPropertyChanged(nameof(ColorList));
            }
        }

        //public MainWindowViewModel(TotalManagers totalManagers) {
        //	TotalManagers = totalManagers;
        //}

        private bool _FlyoutSettingMapsVisibleState;
        public bool FlyoutSettingMapsVisibleState {
            get => _FlyoutSettingMapsVisibleState;
            set {
                _FlyoutSettingMapsVisibleState = value;
                OnPropertyChanged(nameof(FlyoutSettingMapsVisibleState));
            }
        }
        public ObservableCollection<ReportsList> ReportList {
            get => _ReportList;
            set {
                _ReportList = value;
                OnPropertyChanged("ReportList");
            }
        }

        public ObservableCollection<ReglamentWorksDetail> ReglamentWorksDetailCollection {
            get => _ReglamentWorksDetailCollection;
            set {
                _ReglamentWorksDetailCollection = value;
                OnPropertyChanged(nameof(ReglamentWorksDetailCollection));
            }
        }

        private ReportsList _SelectedReport;
        public ReportsList SelectedReport {
            get => _SelectedReport;
            set {
                _SelectedReport = value;
                FlyoutMenuState = false;
                if (_SelectedReport.ReportID == Guid.Parse("23f71a51-f909-417c-9b09-69534715c689")) {
                    CommonSettingsVisibility = false;
                    GuardObjectOnMapVisibility = true;
                    GuardObjectsOnMapsVisibility = true;
                    FlyoutSettingMapsVisibleState = true;
                }
                else {
                    FlyoutSettingVisibleState = true;
                    CommonSettingsVisibility = true;
                    GuardObjectsOnMapsVisibility = false;
                    GuardObjectOnMapVisibility = false;

                    FlyoutSettingMapsVisibleState = false;
                }
                OnPropertyChanged("SelectedReport");
            }
        }

        private Reports _SelectedReportData;
        public Reports SelectedReportData {
            get {
                if (AgreementDetail != null)
                    AgreementDetail.Clear();
                return _SelectedReportData;
            }
            set {
                if (AgreementDetail != null)
                    AgreementDetail.Clear();
                _SelectedReportData = value;
                OnPropertyChanged(nameof(SelectedReportData));
            }
        }
        public ObservableCollection<TotalManagers> TotalManagers {
            get => _TotalManagers;
            set {
                _TotalManagers = value;
                OnPropertyChanged(nameof(TotalManagers));
            }
        }
        public ObservableCollection<TotalManagersChart> TotalManagersChart {
            get => _TotalManagersChart;
            set {
                _TotalManagersChart = value;
                OnPropertyChanged(nameof(TotalManagersChart));
            }
        }

        public ObservableCollection<DatePattern> DatePatterns {
            get => _DatePatterns;
            set {
                _DatePatterns = value;
                OnPropertyChanged("DatePatterns");
            }
        }

        public ObservableCollection<Report> Reports {
            get => _Reports;
            set {
                _Reports = value;
                OnPropertyChanged("Reports");
            }
        }

        private RelayCommand _CreateWordReport;
        public RelayCommand CreateWordReport {
            get => _CreateWordReport ??= new RelayCommand(obj => {
                createWordReport(Reports.OrderBy(x => x.Alarm));
            }, obj => Reports.Count() > 0);
        }
        string filename = null;
        private void createWordReport(IEnumerable<Report> flo, bool late = false) {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (s, e) => {
                Loading = true;
                //Изменение стоимости абонентской платы
                if (SelectedReport.ReportID == Guid.Parse("b904a30b-16b1-4f59-a76d-bd981e18c930")) {
                    try {
                        if (flo != null) {
                            if (flo.Any()) {
                                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                                SaveFileDialog saveFileDialog_word = new SaveFileDialog() {
                                    //InitialDirectory = "c:\\",
                                    Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*",
                                    FilterIndex = 1
                                };
                                saveFileDialog_word.ShowDialog();
                                if (!string.IsNullOrEmpty(saveFileDialog_word.FileName)) {
                                    string[] headers = Resources.HeaderReportWordChangeCost.Split(',');
                                    filename = saveFileDialog_word.FileName;
                                    object missing = Type.Missing;
                                    Microsoft.Office.Interop.Word._Document word_doc = app.Documents.Add(
                                        ref missing, ref missing, ref missing, ref missing);
                                    var Paragraph = app.ActiveDocument.Paragraphs.Add();
                                    var tableRange = Paragraph.Range;
                                    tableRange.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
                                    tableRange.PageSetup.LeftMargin = 20;
                                    tableRange.PageSetup.RightMargin = 20;
                                    tableRange.PageSetup.TopMargin = 28;
                                    tableRange.PageSetup.BottomMargin = 28;
                                    app.ActiveDocument.Tables.Add(tableRange, 1, headers.Length);
                                    var table = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
                                    table.set_Style("Сетка таблицы");
                                    table.ApplyStyleHeadingRows = true;
                                    table.ApplyStyleLastRow = false;
                                    table.ApplyStyleFirstColumn = true;
                                    table.ApplyStyleLastColumn = false;
                                    table.ApplyStyleRowBands = true;
                                    table.ApplyStyleColumnBands = false;
                                    table.AllowAutoFit = true;
                                    //table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
                                    table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);

                                    for (int i = 0; i < headers.Length; i++)
                                        word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Text = headers[i];

                                    for (int i = 0; i < headers.Length; i++) {
                                        word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Bold = 1;
                                        word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                    }
                                    foreach (var item in flo) {
                                        //foreach(var item in flo.OrderBy(x => x.DateChanged).ThenBy(y => y.WhoChanged)) {
                                        table.Rows.Add();
                                        word_doc.Tables[1].Rows[table.Rows.Count].Range.Bold = 0;
                                        word_doc.Tables[1].Cell(table.Rows.Count, 1).Range.Text = item.ObjectNumber.HasValue ? item.ObjectNumber.ToString() : "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 2).Range.Text = item.ObjectName ?? "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 3).Range.Text = item.ObjectAddress ?? "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 4).Range.Text = item.DateStart.HasValue ? item.DateStart.Value.ToString() : "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 5).Range.Text = item.Curator;
                                        word_doc.Tables[1].Cell(table.Rows.Count, 6).Range.Text = item.WhoChanged;
                                        word_doc.Tables[1].Cell(table.Rows.Count, 7).Range.Text = item.DateChanged.HasValue ? item.DateChanged.Value.ToString() : "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 8).Range.Text = item.Before;
                                        word_doc.Tables[1].Cell(table.Rows.Count, 9).Range.Text = item.After;
                                    }
                                    object filename_local = saveFileDialog_word.FileName;
                                    word_doc.SaveAs(ref filename_local, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing,
                                        ref missing);
                                    object save_changes = false;
                                    word_doc.Close(ref save_changes, ref missing, ref missing);
                                    app.Quit(ref save_changes, ref missing, ref missing);
                                    //notify("Информация", "Отчёт сохранен. Открыть сейчас?", System.Windows.Forms.ToolTipIcon.Info, true);
                                }
                            }
                            else
                                //TaskBarIconVisibility = true;
                                MessageBox.Show("Данных для построения отчёта не обнаружено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                            //notify("Ошибка", "Данных для построения отчёта не обнаружено", System.Windows.Forms.ToolTipIcon.Error, false);
                        }
                        else
                            MessageBox.Show("Данных для построения отчёта не обнаружено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                        //TaskBarIconVisibility = true;
                        //MessageBox.Show("test");
                        //notify("Ошибка", "Данных для построения отчёта не обнаружено", System.Windows.Forms.ToolTipIcon.Error, false);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                        //TaskBarIconVisibility = true;
                        //MessageBox.Show("test");
                        //notify("Ошибка", ex.Message, System.Windows.Forms.ToolTipIcon.Error, false);
                    }
                }
                //Акты
                if (SelectedReport.ReportID == Guid.Parse("fa4dd0a5-5b15-45b4-a55a-433267fa50ff")) {
                    try {
                        if (flo != null) {
                            if (flo.Any()) {
                                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                                SaveFileDialog saveFileDialog_word = new SaveFileDialog() {
                                    //InitialDirectory = "c:\\",
                                    Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*",
                                    FilterIndex = 1
                                };
                                saveFileDialog_word.ShowDialog();
                                if (!string.IsNullOrEmpty(saveFileDialog_word.FileName)) {
                                    string[] headers = Resources.HeaderReportWord.Split(',');
                                    filename = saveFileDialog_word.FileName;
                                    object missing = Type.Missing;
                                    Microsoft.Office.Interop.Word._Document word_doc = app.Documents.Add(
                                        ref missing, ref missing, ref missing, ref missing);
                                    var Paragraph = app.ActiveDocument.Paragraphs.Add();
                                    var tableRange = Paragraph.Range;
                                    tableRange.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
                                    tableRange.PageSetup.LeftMargin = 20;
                                    tableRange.PageSetup.RightMargin = 20;
                                    tableRange.PageSetup.TopMargin = 28;
                                    tableRange.PageSetup.BottomMargin = 28;
                                    app.ActiveDocument.Tables.Add(tableRange, 1, headers.Length);
                                    var table = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
                                    table.set_Style("Сетка таблицы");
                                    table.ApplyStyleHeadingRows = true;
                                    table.ApplyStyleLastRow = false;
                                    table.ApplyStyleFirstColumn = true;
                                    table.ApplyStyleLastColumn = false;
                                    table.ApplyStyleRowBands = true;
                                    table.ApplyStyleColumnBands = false;
                                    table.AllowAutoFit = true;
                                    //table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
                                    table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);

                                    for (int i = 0; i < headers.Length; i++)
                                        word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Text = headers[i];

                                    for (int i = 0; i < headers.Length; i++) {
                                        word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Bold = 1;
                                        word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                    }
                                    word_doc.Tables[1].Cell(table.Rows.Count, 4).Range.Orientation = WdTextOrientation.wdTextOrientationHorizontal;
                                    word_doc.Tables[1].Cell(table.Rows.Count, 5).Range.Orientation = WdTextOrientation.wdTextOrientationHorizontal;
                                    word_doc.Tables[1].Cell(table.Rows.Count, 6).Range.Orientation = WdTextOrientation.wdTextOrientationHorizontal;
                                    word_doc.Tables[1].Cell(table.Rows.Count, 7).Range.Orientation = WdTextOrientation.wdTextOrientationHorizontal;
                                    word_doc.Tables[1].Cell(table.Rows.Count, 8).Range.Orientation = WdTextOrientation.wdTextOrientationHorizontal;



                                    word_doc.Tables[1].Cell(table.Rows.Count, 1).SetWidth(54, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 4).SetWidth(17, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 5).SetWidth(17, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 6).SetWidth(17, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 7).SetWidth(17, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 8).SetWidth(17, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 9).SetWidth(92, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 10).SetWidth(92, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 11).SetWidth(92, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 12).SetWidth(36, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 13).SetWidth(100, WdRulerStyle.wdAdjustProportional);
                                    //word_doc.Tables[1].Cell(table.Rows.Count, 14).SetWidth(100, WdRulerStyle.wdAdjustProportional);
                                    foreach (var item in flo) {
                                        table.Rows.Add();
                                        word_doc.Tables[1].Rows[table.Rows.Count].Range.Bold = 0;
                                        word_doc.Tables[1].Cell(table.Rows.Count, 1).Range.Text = item.ObjectNumber.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 2).Range.Text = item.ObjectName.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 3).Range.Text = item.ObjectAddress.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 4).Range.Text = item.Os.Value ? "+" : "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 5).Range.Text = item.Ps.Value ? "+" : "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 6).Range.Text = item.Trs.Value ? "+" : "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 7).Range.Text = item.Group.ToString().Trim();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 8).Range.Text = item.Police.Value ? "+" : "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 9).Range.Text = item.Alarm.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 10).Range.Text = item.Departure.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 11).Range.Text = item.Arrival.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 12).Range.Text = item.Cancel.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 13).Range.Text = item.Result.ToString();
                                        //word_doc.Tables[1].Cell(table.Rows.Count, 14).Range.Text = item.Late.ToString();
                                    }
                                    word_doc.Tables[1].Cell(1, 4).Range.Orientation = WdTextOrientation.wdTextOrientationVerticalFarEast;
                                    word_doc.Tables[1].Cell(1, 5).Range.Orientation = WdTextOrientation.wdTextOrientationVerticalFarEast;
                                    word_doc.Tables[1].Cell(1, 6).Range.Orientation = WdTextOrientation.wdTextOrientationVerticalFarEast;
                                    word_doc.Tables[1].Cell(1, 7).Range.Orientation = WdTextOrientation.wdTextOrientationVerticalFarEast;
                                    word_doc.Tables[1].Cell(1, 8).Range.Orientation = WdTextOrientation.wdTextOrientationVerticalFarEast;
                                    object filename_local = saveFileDialog_word.FileName;
                                    word_doc.SaveAs(ref filename_local, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing,
                                        ref missing);
                                    object save_changes = false;
                                    word_doc.Close(ref save_changes, ref missing, ref missing);
                                    app.Quit(ref save_changes, ref missing, ref missing);
                                    //notify("Информация", "Отчёт сохранен. Открыть сейчас?", System.Windows.Forms.ToolTipIcon.Info, true);
                                }
                            }
                            else
                                //TaskBarIconVisibility = true;
                                MessageBox.Show("Данных для построения отчёта не обнаружено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                            //notify("Ошибка", "Данных для построения отчёта не обнаружено", System.Windows.Forms.ToolTipIcon.Error, false);
                        }
                        else
                            MessageBox.Show("Данных для построения отчёта не обнаружено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                        //TaskBarIconVisibility = true;
                        //MessageBox.Show("test");
                        //notify("Ошибка", "Данных для построения отчёта не обнаружено", System.Windows.Forms.ToolTipIcon.Error, false);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                        //TaskBarIconVisibility = true;
                        //MessageBox.Show("test");
                        //notify("Ошибка", ex.Message, System.Windows.Forms.ToolTipIcon.Error, false);
                    }
                }
                //Опоздания
                if (SelectedReport.ReportID == Guid.Parse("a35a2859-3e10-42f1-9e9b-5f29b5e953d9") || SelectedReport.ReportID == Guid.Parse("8a7e33df-e27d-413c-80d5-e3812b57853c")) {
                    try {
                        if (flo != null) {
                            if (flo.Any()) {
                                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                                SaveFileDialog saveFileDialog_word = new SaveFileDialog() {
                                    //InitialDirectory = "c:\\",
                                    Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*",
                                    FilterIndex = 1
                                };
                                saveFileDialog_word.ShowDialog();
                                if (!string.IsNullOrEmpty(saveFileDialog_word.FileName)) {
                                    string[] headers = Resources.HeaderReportWordWithLate.Split(',');
                                    filename = saveFileDialog_word.FileName;
                                    object missing = Type.Missing;
                                    Microsoft.Office.Interop.Word._Document word_doc = app.Documents.Add(
                                        ref missing, ref missing, ref missing, ref missing);
                                    var Paragraph = app.ActiveDocument.Paragraphs.Add();
                                    var tableRange = Paragraph.Range;
                                    tableRange.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
                                    tableRange.PageSetup.LeftMargin = 20;
                                    tableRange.PageSetup.RightMargin = 20;
                                    tableRange.PageSetup.TopMargin = 28;
                                    tableRange.PageSetup.BottomMargin = 28;
                                    app.ActiveDocument.Tables.Add(tableRange, 1, headers.Length);
                                    var table = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
                                    table.set_Style("Сетка таблицы");
                                    table.ApplyStyleHeadingRows = true;
                                    table.ApplyStyleLastRow = false;
                                    table.ApplyStyleFirstColumn = true;
                                    table.ApplyStyleLastColumn = false;
                                    table.ApplyStyleRowBands = true;
                                    table.ApplyStyleColumnBands = false;
                                    table.AllowAutoFit = true;
                                    //table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
                                    table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);

                                    for (int i = 0; i < headers.Length; i++)
                                        word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Text = headers[i];

                                    for (int i = 0; i < headers.Length; i++) {
                                        word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Bold = 1;
                                        word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                    }
                                    word_doc.Tables[1].Cell(table.Rows.Count, 4).Range.Orientation = WdTextOrientation.wdTextOrientationHorizontal;
                                    word_doc.Tables[1].Cell(table.Rows.Count, 5).Range.Orientation = WdTextOrientation.wdTextOrientationHorizontal;
                                    word_doc.Tables[1].Cell(table.Rows.Count, 6).Range.Orientation = WdTextOrientation.wdTextOrientationHorizontal;
                                    word_doc.Tables[1].Cell(table.Rows.Count, 7).Range.Orientation = WdTextOrientation.wdTextOrientationHorizontal;
                                    word_doc.Tables[1].Cell(table.Rows.Count, 8).Range.Orientation = WdTextOrientation.wdTextOrientationHorizontal;



                                    word_doc.Tables[1].Cell(table.Rows.Count, 1).SetWidth(54, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 4).SetWidth(17, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 5).SetWidth(17, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 6).SetWidth(17, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 7).SetWidth(17, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 8).SetWidth(17, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 9).SetWidth(92, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 10).SetWidth(92, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 11).SetWidth(92, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 12).SetWidth(36, WdRulerStyle.wdAdjustNone);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 13).SetWidth(100, WdRulerStyle.wdAdjustProportional);
                                    word_doc.Tables[1].Cell(table.Rows.Count, 14).SetWidth(100, WdRulerStyle.wdAdjustProportional);
                                    foreach (var item in flo) {
                                        table.Rows.Add();
                                        word_doc.Tables[1].Rows[table.Rows.Count].Range.Bold = 0;
                                        word_doc.Tables[1].Cell(table.Rows.Count, 1).Range.Text = item.ObjectNumber.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 2).Range.Text = item.ObjectName.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 3).Range.Text = item.ObjectAddress.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 4).Range.Text = item.Os.Value ? "+" : "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 5).Range.Text = item.Ps.Value ? "+" : "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 6).Range.Text = item.Trs.Value ? "+" : "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 7).Range.Text = item.Group.ToString().Trim();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 8).Range.Text = item.Police.Value ? "+" : "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 9).Range.Text = item.Alarm.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 10).Range.Text = item.Departure.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 11).Range.Text = item.Arrival.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 12).Range.Text = item.Cancel.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 13).Range.Text = item.Result.ToString();
                                        word_doc.Tables[1].Cell(table.Rows.Count, 14).Range.Text = item.Late.ToString();
                                    }
                                    word_doc.Tables[1].Cell(1, 4).Range.Orientation = WdTextOrientation.wdTextOrientationVerticalFarEast;
                                    word_doc.Tables[1].Cell(1, 5).Range.Orientation = WdTextOrientation.wdTextOrientationVerticalFarEast;
                                    word_doc.Tables[1].Cell(1, 6).Range.Orientation = WdTextOrientation.wdTextOrientationVerticalFarEast;
                                    word_doc.Tables[1].Cell(1, 7).Range.Orientation = WdTextOrientation.wdTextOrientationVerticalFarEast;
                                    word_doc.Tables[1].Cell(1, 8).Range.Orientation = WdTextOrientation.wdTextOrientationVerticalFarEast;
                                    object filename_local = saveFileDialog_word.FileName;
                                    word_doc.SaveAs(ref filename_local, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing,
                                        ref missing);
                                    object save_changes = false;
                                    word_doc.Close(ref save_changes, ref missing, ref missing);
                                    app.Quit(ref save_changes, ref missing, ref missing);
                                    //notify("Информация", "Отчёт сохранен. Открыть сейчас?", System.Windows.Forms.ToolTipIcon.Info, true);
                                }
                            }
                            else
                                //TaskBarIconVisibility = true;
                                MessageBox.Show("Данных для построения отчёта не обнаружено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                            //notify("Ошибка", "Данных для построения отчёта не обнаружено", System.Windows.Forms.ToolTipIcon.Error, false);
                        }
                        else
                            MessageBox.Show("Данных для построения отчёта не обнаружено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                        //TaskBarIconVisibility = true;
                        //MessageBox.Show("test");
                        //notify("Ошибка", "Данных для построения отчёта не обнаружено", System.Windows.Forms.ToolTipIcon.Error, false);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                        //TaskBarIconVisibility = true;
                        //MessageBox.Show("test");
                        //notify("Ошибка", ex.Message, System.Windows.Forms.ToolTipIcon.Error, false);
                    }
                }
                //регламентные работы 
                if (SelectedReport.ReportID == Guid.Parse("7C9C1F49-6218-4C9A-8F17-126626E5D1D3")) {
                    try {
                        if (flo != null) {
                            if (flo.Any()) {
                                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                                SaveFileDialog saveFileDialog_word = new SaveFileDialog() {
                                    //InitialDirectory = "c:\\",
                                    Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*",
                                    FilterIndex = 1
                                };
                                saveFileDialog_word.ShowDialog();
                                if (!string.IsNullOrEmpty(saveFileDialog_word.FileName)) {
                                    string[] headers = Resources.HeaderReportWordReglamentWorks.Split(',');
                                    filename = saveFileDialog_word.FileName;
                                    object missing = Type.Missing;
                                    Microsoft.Office.Interop.Word._Document word_doc = app.Documents.Add(
                                        ref missing, ref missing, ref missing, ref missing);
                                    var Paragraph = app.ActiveDocument.Paragraphs.Add();
                                    var tableRange = Paragraph.Range;
                                    tableRange.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
                                    tableRange.PageSetup.LeftMargin = 20;
                                    tableRange.PageSetup.RightMargin = 20;
                                    tableRange.PageSetup.TopMargin = 28;
                                    tableRange.PageSetup.BottomMargin = 28;
                                    app.ActiveDocument.Tables.Add(tableRange, 1, headers.Length);
                                    var table = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
                                    table.set_Style("Сетка таблицы");
                                    table.ApplyStyleHeadingRows = true;
                                    table.ApplyStyleLastRow = false;
                                    table.ApplyStyleFirstColumn = true;
                                    table.ApplyStyleLastColumn = false;
                                    table.ApplyStyleRowBands = true;
                                    table.ApplyStyleColumnBands = false;
                                    table.AllowAutoFit = true;
                                    table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);

                                    for (int i = 0; i < headers.Length; i++)
                                        word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Text = headers[i];

                                    for (int i = 0; i < headers.Length; i++) {
                                        word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Bold = 1;
                                        word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                    }
                                    foreach (var item in flo) {
                                        table.Rows.Add();
                                        word_doc.Tables[1].Rows[table.Rows.Count].Range.Bold = 0;
                                        word_doc.Tables[1].Cell(table.Rows.Count, 1).Range.Text = item.ObjectNumber.HasValue ? item.ObjectNumber.ToString() : "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 2).Range.Text = item.ObjectName ?? "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 3).Range.Text = item.ObjectAddress ?? "";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 4).Range.Text = item.RrEveryMonth.HasValue ? item.RrEveryMonth.Value == true ? "+" : "-" : "-";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 5).Range.Text = item.RrOS.HasValue ? item.RrOS.Value == true ? "+" : "-" : "-";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 6).Range.Text = item.RrPS.HasValue ? item.RrPS.Value == true ? "+" : "-" : "-";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 7).Range.Text = item.RrSkud.HasValue ? item.RrSkud.Value == true ? "+" : "-" : "-";
                                        word_doc.Tables[1].Cell(table.Rows.Count, 8).Range.Text = item.RrVideo.HasValue ? item.RrVideo.Value == true ? "+" : "-" : "-";
                                    }
                                    object filename_local = saveFileDialog_word.FileName;
                                    word_doc.SaveAs(ref filename_local, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing,
                                        ref missing);
                                    object save_changes = false;
                                    word_doc.Close(ref save_changes, ref missing, ref missing);
                                    app.Quit(ref save_changes, ref missing, ref missing);
                                }
                            }
                            else
                                MessageBox.Show("Данных для построения отчёта не обнаружено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                        }
                        else
                            MessageBox.Show("Данных для построения отчёта не обнаружено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                    }
                }
            };
            bw.RunWorkerCompleted += (s, e) => {
                try {
                    ProcessStartInfo processStartInfo = new ProcessStartInfo();
                    processStartInfo.FileName = filename;
                    processStartInfo.UseShellExecute = true;
                    Process.Start(processStartInfo);
                }
                catch {
                    MessageBox.Show("Не удалось открыть отчёт", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                }
                finally {
                    Loading = false;
                }
            };
            bw.RunWorkerAsync();
        }

        private RelayCommand _CreatePdfReport;
        public RelayCommand CreatePdfReport {
            get => _CreatePdfReport ??= new RelayCommand(obj => {
                createPDFReport(Reports.OrderBy(x => x.Alarm));
            }, obj => Reports.Count() > 0);
        }

        private void createPDFReport(IEnumerable<Report> flo) {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (s, e) => {
                Loading = true;
                //Изменение стоимости абонентской платы
                if (SelectedReport.ReportID == Guid.Parse("b904a30b-16b1-4f59-a76d-bd981e18c930")) {
                    try {
                        if (flo != null) {
                            if (flo.Any()) {
                                SaveFileDialog saveFileDialog_pdf = new SaveFileDialog() {
                                    Filter = "Документ PDF|*.pdf",
                                    Title = "Выберите путь для сохранения отчёта"
                                };
                                saveFileDialog_pdf.ShowDialog();
                                if (!string.IsNullOrEmpty(saveFileDialog_pdf.FileName)) {
                                    string[] headers = Resources.HeaderReportWordChangeCost.Split(',');
                                    filename = saveFileDialog_pdf.FileName;
                                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
                                    FileStream fileStream = new FileStream(saveFileDialog_pdf.FileName, FileMode.Create);
                                    PdfWriter.GetInstance(doc, fileStream);
                                    doc.Open();
                                    BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                                    PdfPTable table = new PdfPTable(headers.Length);
                                    PdfPCell cell = new PdfPCell(new Phrase("Изменение стоимости абонентской платы", font)) {
                                        Colspan = headers.Length,
                                        HorizontalAlignment = 1,
                                        Border = 0
                                    };
                                    table.AddCell(cell);

                                    for (int i = 0; i < headers.Length; i++) {
                                        cell = new PdfPCell(new Phrase(new Phrase(headers[i], font))) {
                                            BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                                        };
                                        table.AddCell(cell);
                                    }
                                    if (flo != null)
                                        if (flo.Any())
                                            foreach (var item in flo.OrderBy(x => x.DateChanged)) {
                                                table.AddCell(new Phrase(item.ObjectNumber.HasValue ? item.ObjectNumber.ToString() : "", font));
                                                table.AddCell(new Phrase(item.ObjectName ?? "", font));
                                                table.AddCell(new Phrase(item.ObjectAddress ?? "", font));
                                                table.AddCell(new Phrase(item.DateStart.HasValue ? item.DateStart.Value.ToString() : "", font));
                                                table.AddCell(new Phrase(item.Curator, font));
                                                table.AddCell(new Phrase(item.WhoChanged, font));
                                                table.AddCell(new Phrase(item.DateChanged.HasValue ? item.DateChanged.Value.ToString() : "", font));
                                                table.AddCell(new Phrase(item.Before, font));
                                                table.AddCell(new Phrase(item.After, font));
                                            }
                                        else {
                                            MessageBox.Show("По данным условиям нет данных для отображения");
                                        }
                                    doc.Add(table);
                                    doc.Close();
                                    fileStream.Close();
                                    fileStream.Dispose();
                                }
                            }
                            else
                                MessageBox.Show("Данных для построения отчёта не обнаружено");
                        }
                        else
                            MessageBox.Show("Данных для построения отчёта не обнаружено");
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Ошибка построения отчёта: " + ex.Message);
                    }
                }
                //Акты
                if (SelectedReport.ReportID == Guid.Parse("fa4dd0a5-5b15-45b4-a55a-433267fa50ff")) {
                    try {
                        if (flo != null) {
                            if (flo.Any()) {
                                SaveFileDialog saveFileDialog_pdf = new SaveFileDialog() {
                                    Filter = "Документ PDF|*.pdf",
                                    Title = "Выберите путь для сохранения отчёта"
                                };
                                saveFileDialog_pdf.ShowDialog();
                                //saveFileDialog_pdf.FileName = filename;
                                if (!string.IsNullOrEmpty(saveFileDialog_pdf.FileName)) {
                                    string[] headers = Resources.HeaderReportWord.Split(',');
                                    filename = saveFileDialog_pdf.FileName;
                                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
                                    FileStream fileStream = new FileStream(saveFileDialog_pdf.FileName, FileMode.Create);
                                    PdfWriter.GetInstance(doc, fileStream);
                                    doc.Open();
                                    BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                                    PdfPTable table = new PdfPTable(headers.Length);
                                    PdfPCell cell = new PdfPCell(new Phrase("Отчёт по актам", font)) {
                                        Colspan = headers.Length,
                                        HorizontalAlignment = 1,
                                        Border = 0
                                    };
                                    table.AddCell(cell);

                                    for (int i = 0; i < headers.Length; i++) {
                                        cell = new PdfPCell(new Phrase(new Phrase(headers[i], font))) {
                                            BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                                        };
                                        table.AddCell(cell);
                                    }
                                    if (flo != null)
                                        if (flo.Any())
                                            foreach (var item in flo.OrderBy(x => x.Alarm)) {
                                                table.AddCell(new Phrase(item.ObjectNumber.HasValue ? item.ObjectNumber.ToString() : "", font));
                                                table.AddCell(new Phrase(item.ObjectName ?? "", font));
                                                table.AddCell(new Phrase(item.ObjectAddress ?? "", font));
                                                table.AddCell(new Phrase(item.Os.HasValue ? item.Os.Value == true ? "+" : "-" : "-", font));
                                                table.AddCell(new Phrase(item.Ps.HasValue ? item.Ps.Value == true ? "+" : "-" : "-", font));
                                                table.AddCell(new Phrase(item.Trs.HasValue ? item.Trs.Value == true ? "+" : "-" : "-", font));
                                                table.AddCell(new Phrase(item.Group.HasValue ? item.Group.ToString() : "", font));
                                                table.AddCell(new Phrase(item.Police.HasValue ? item.Police.Value == true ? "+" : "-" : "-", font));
                                                table.AddCell(new Phrase(item.Alarm.HasValue ? item.Alarm.Value.ToString() : "", font));
                                                table.AddCell(new Phrase(item.Departure.HasValue ? item.Departure.Value.ToString() : "", font));
                                                table.AddCell(new Phrase(item.Arrival.HasValue ? item.Arrival.Value.ToString() : "", font));
                                                table.AddCell(new Phrase(item.Cancel.HasValue ? item.Cancel.Value.ToString() : "", font));
                                                table.AddCell(new Phrase(item.Result, font));
                                            }
                                        else {
                                            MessageBox.Show("По данным условиям нет данных для отображения");
                                        }
                                    doc.Add(table);
                                    doc.Close();
                                    fileStream.Close();
                                    fileStream.Dispose();
                                }
                            }
                            else
                                MessageBox.Show("Данных для построения отчёта не обнаружено");
                        }
                        else
                            MessageBox.Show("Данных для построения отчёта не обнаружено");
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Ошибка построения отчёта: " + ex.Message);
                    }
                }
                //Опоздания
                if (SelectedReport.ReportID == Guid.Parse("a35a2859-3e10-42f1-9e9b-5f29b5e953d9") || SelectedReport.ReportID == Guid.Parse("8a7e33df-e27d-413c-80d5-e3812b57853c")) {
                    try {
                        if (flo != null) {
                            if (flo.Any()) {
                                SaveFileDialog saveFileDialog_pdf = new SaveFileDialog() {
                                    Filter = "Документ PDF|*.pdf",
                                    Title = "Выберите путь для сохранения отчёта"
                                };
                                saveFileDialog_pdf.ShowDialog();
                                //saveFileDialog_pdf.FileName = filename;
                                if (!string.IsNullOrEmpty(saveFileDialog_pdf.FileName)) {
                                    string[] headers = Resources.HeaderReportWordWithLate.Split(',');
                                    filename = saveFileDialog_pdf.FileName;
                                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
                                    FileStream fileStream = new FileStream(saveFileDialog_pdf.FileName, FileMode.Create);
                                    PdfWriter.GetInstance(doc, fileStream);
                                    doc.Open();
                                    BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                                    PdfPTable table = new PdfPTable(headers.Length);
                                    PdfPCell cell = new PdfPCell(new Phrase("Отчёт по опазданиям", font)) {
                                        Colspan = headers.Length,
                                        HorizontalAlignment = 1,
                                        Border = 0
                                    };
                                    table.AddCell(cell);

                                    for (int i = 0; i < headers.Length; i++) {
                                        cell = new PdfPCell(new Phrase(new Phrase(headers[i], font))) {
                                            BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                                        };
                                        table.AddCell(cell);
                                    }
                                    if (flo != null)
                                        if (flo.Any())
                                            foreach (var item in flo.OrderBy(x => x.ObjectNumber)) {
                                                table.AddCell(new Phrase(item.ObjectNumber.HasValue ? item.ObjectNumber.ToString() : "", font));
                                                table.AddCell(new Phrase(item.ObjectName ?? "", font));
                                                table.AddCell(new Phrase(item.ObjectAddress ?? "", font));
                                                table.AddCell(new Phrase(item.Os.HasValue ? item.Os.Value == true ? "+" : "-" : "-", font));
                                                table.AddCell(new Phrase(item.Ps.HasValue ? item.Ps.Value == true ? "+" : "-" : "-", font));
                                                table.AddCell(new Phrase(item.Trs.HasValue ? item.Trs.Value == true ? "+" : "-" : "-", font));
                                                table.AddCell(new Phrase(item.Group.HasValue ? item.Group.ToString() : "", font));
                                                table.AddCell(new Phrase(item.Police.HasValue ? item.Police.Value == true ? "+" : "-" : "-", font));
                                                table.AddCell(new Phrase(item.Alarm.HasValue ? item.Alarm.Value.ToString() : "", font));
                                                table.AddCell(new Phrase(item.Departure.HasValue ? item.Departure.Value.ToString() : "", font));
                                                table.AddCell(new Phrase(item.Arrival.HasValue ? item.Arrival.Value.ToString() : "", font));
                                                table.AddCell(new Phrase(item.Cancel.HasValue ? item.Cancel.Value.ToString() : "", font));
                                                table.AddCell(new Phrase(item.Result, font));
                                                table.AddCell(new Phrase(item.Late, font));
                                            }
                                        else {
                                            MessageBox.Show("По данным условиям нет данных для отображения");
                                        }
                                    doc.Add(table);
                                    doc.Close();
                                    fileStream.Close();
                                    fileStream.Dispose();
                                }
                            }
                            else
                                MessageBox.Show("Данных для построения отчёта не обнаружено");
                        }
                        else
                            MessageBox.Show("Данных для построения отчёта не обнаружено");
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Ошибка построения отчёта: " + ex.Message);
                    }
                }
                //регламентные работы 
                if (SelectedReport.ReportID == Guid.Parse("7C9C1F49-6218-4C9A-8F17-126626E5D1D3")) {
                    try {
                        if (flo != null) {
                            if (flo.Any()) {
                                SaveFileDialog saveFileDialog_pdf = new SaveFileDialog() {
                                    Filter = "Документ PDF|*.pdf",
                                    Title = "Выберите путь для сохранения отчёта"
                                };
                                saveFileDialog_pdf.ShowDialog();
                                //saveFileDialog_pdf.FileName = filename;
                                if (!string.IsNullOrEmpty(saveFileDialog_pdf.FileName)) {
                                    string[] headers = Resources.HeaderReportWordReglamentWorks.Split(',');
                                    filename = saveFileDialog_pdf.FileName;
                                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
                                    FileStream fileStream = new FileStream(saveFileDialog_pdf.FileName, FileMode.Create);
                                    PdfWriter.GetInstance(doc, fileStream);
                                    doc.Open();
                                    BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                                    PdfPTable table = new PdfPTable(headers.Length);
                                    PdfPCell cell = new PdfPCell(new Phrase("Регламентные работы", font)) {
                                        Colspan = headers.Length,
                                        HorizontalAlignment = 1,
                                        Border = 0
                                    };
                                    table.AddCell(cell);

                                    for (int i = 0; i < headers.Length; i++) {
                                        cell = new PdfPCell(new Phrase(new Phrase(headers[i], font))) {
                                            BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                                        };
                                        table.AddCell(cell);
                                    }
                                    if (flo != null)
                                        if (flo.Any())
                                            foreach (var item in flo.OrderBy(x => x.ObjectNumber)) {
                                                table.AddCell(new Phrase(item.ObjectNumber.HasValue ? item.ObjectNumber.ToString() : "", font));
                                                table.AddCell(new Phrase(item.ObjectName ?? "", font));
                                                table.AddCell(new Phrase(item.ObjectAddress ?? "", font));
                                                table.AddCell(new Phrase(item.RrEveryMonth.HasValue ? item.RrEveryMonth.Value == true ? "+" : "-" : "-", font));
                                                table.AddCell(new Phrase(item.RrOS.HasValue ? item.RrOS.Value == true ? "+" : "-" : "-", font));
                                                table.AddCell(new Phrase(item.RrPS.HasValue ? item.RrPS.Value == true ? "+" : "-" : "-", font));
                                                table.AddCell(new Phrase(item.RrSkud.HasValue ? item.RrSkud.Value == true ? "+" : "-" : "-", font));
                                                table.AddCell(new Phrase(item.RrVideo.HasValue ? item.RrVideo.Value == true ? "+" : "-" : "-", font));
                                            }
                                        else {
                                            MessageBox.Show("По данным условиям нет данных для отображения");
                                        }
                                    doc.Add(table);
                                    doc.Close();
                                    fileStream.Close();
                                    fileStream.Dispose();
                                }
                            }
                            else
                                MessageBox.Show("Данных для построения отчёта не обнаружено");
                        }
                        else
                            MessageBox.Show("Данных для построения отчёта не обнаружено");
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Ошибка построения отчёта: " + ex.Message);
                    }
                }
            };
            bw.RunWorkerCompleted += (s, e) => {
                try {
                    ProcessStartInfo processStartInfo = new ProcessStartInfo();
                    processStartInfo.FileName = filename;
                    processStartInfo.UseShellExecute = true;
                    Process.Start(processStartInfo);
                }
                catch {
                    MessageBox.Show("Не удалось открыть отчёт", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                }
                finally {
                    Loading = false;
                }
            };
            bw.RunWorkerAsync();
        }


        private RelayCommand _MouseRightButtonDownCommand;
        public RelayCommand MouseRightButtonDownCommand {
            get => _MouseRightButtonDownCommand ??= new RelayCommand(async obj => {
                MouseEventArgs mouseEventArgs = obj as MouseEventArgs;
                if (mouseEventArgs.RightButton == MouseButtonState.Pressed) {
                    if (GroupsList.Count(x => x.IsShowOnMap == true) == 1) {
                        if (gmaps_contol.Markers.Count(x => x.Tag == "ГБР") == 0) {
                            System.Windows.Point p = mouseEventArgs.GetPosition((IInputElement)mouseEventArgs.Source);

                            GMapMarker marker = new GMapMarker(new PointLatLng()) {
                                Shape = new Ellipse {
                                    Width = 20,
                                    Height = 20,
                                    Stroke = Brushes.Chocolate,
                                    StrokeThickness = 7.5,
                                    ToolTip = "ГБР",
                                    AllowDrop = true
                                }
                            };
                            marker.Position = gmaps_contol.FromLocalToLatLng((int)p.X, (int)p.Y);
                            marker.Tag = "ГБР";
                            gmaps_contol.Markers.Add(marker);
                        }
                        else if (gmaps_contol.Markers.Count(x => x.Tag == "ГБР") > 0) {
                            WPFMessageBoxService service = new WPFMessageBoxService();
                            service.ShowMessage("Нельзя добавить расположение экипажа на карту. Экипаж уже был добавлен", "Ошибка");
                        }
                    }
                    else if (GroupsList.Count(x => x.IsShowOnMap == true)<=0) {
                        WPFMessageBoxService service = new WPFMessageBoxService();
                        service.ShowMessage("Нельзя добавить расположение экипажа на карту. Не выбраны объекты для отображения", "Ошибка");
                    }
                    else if (GroupsList.Count(x => x.IsShowOnMap == true) >1) {
                        WPFMessageBoxService service = new WPFMessageBoxService();
                        service.ShowMessage("Нельзя добавить расположение экипажа на карту. Выбраны объекты разных маршрутов", "Ошибка");
                    }
                }
            });
        }
        //private PlotModel PieModel;

        private PlotModel _PieModel;
        public PlotModel PieModel {
            get => _PieModel;
            set {
                _PieModel = value;
                OnPropertyChanged(nameof(PieModel));
            }
        }

        private bool _ChartVisibility;
        public bool ChartVisibility {
            get => _ChartVisibility;
            set {
                _ChartVisibility = value;
                OnPropertyChanged(nameof(ChartVisibility));
            }
        }
        private RelayCommand _CalculateRoute;
        public RelayCommand CalculateRoute {
            get => _CalculateRoute ??= new RelayCommand(async obj => {
                var gbr = gmaps_contol.Markers.FirstOrDefault(x => x.Tag == "ГБР");
                var objects = gmaps_contol.Markers.Where(x => x.Tag != "ГБР").ToList();
                List<MatrixTotals> matrix = new List<MatrixTotals>();

                if (gbr!=null && objects!=null)
                    if (objects.Count > 0) {
                        //using (HttpClient client = new HttpClient()) {
                        //    foreach (var item in objects) {
                        //        string resp = @"https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&language=ru&origins=" + gbr.Position.Lat.ToString().Replace(',', '.') + "," + gbr.Position.Lng.ToString().Replace(',', '.') +
                        //            "&destinations=" + item.Position.Lat.ToString().Replace(',','.') + "," + item.Position.Lng.ToString().Replace(',', '.') + "&key=AIzaSyCDXENAPVyVN2TddfuGUuPR6wAV2RL7Dh4";
                        //        HttpResponseMessage response = await client.GetAsync(resp);
                        //        var GoogleMatrixDistance = JsonConvert.DeserializeObject<GoogleMatrixDistanceModel>(response.Content.ReadAsStringAsync().Result);
                        //        if (GoogleMatrixDistance != null) {
                        //            matrix.Add( new MatrixTotals() { Duration=  GoogleMatrixDistance.rows[0].elements[0].duration.value });
                        //        }
                        //    }
                        //}
                        //string msg = "Прибытие более 15 минут: " + matrix.Count(x => x.Duration > 900).ToString() + "(" + Math.Round((double)matrix.Count(x => x.Duration > 900)/objects.Count*100, 0) + "%)" + Environment.NewLine +
                        //"Прибытие 12-15 минут: " + matrix.Count(x => x.Duration >= 720 && x.Duration < 900).ToString() + "(" + Math.Round((double)matrix.Count(x => x.Duration >= 720 && x.Duration < 900) / objects.Count * 100, 0) + "%)" + Environment.NewLine +
                        //"Прибытие 7-12 минут: " + matrix.Count(x => x.Duration >= 420 && x.Duration < 720).ToString() + "(" + Math.Round((double)matrix.Count(x => x.Duration >= 420 && x.Duration < 720) / objects.Count * 100, 0) + "%)" + Environment.NewLine +
                        //"Прибытие 5-7 минут: " + matrix.Count(x => x.Duration >= 300 && x.Duration < 420).ToString() + "(" + Math.Round((double)matrix.Count(x => x.Duration >= 300 && x.Duration < 420) / objects.Count * 100, 0) + "%)" + Environment.NewLine +
                        //"Менее 5 минут: " + matrix.Count(x => x.Duration < 300).ToString() + "(" + Math.Round((double)matrix.Count(x => x.Duration < 300) / objects.Count * 100,0) + "%)" + Environment.NewLine;
                        //WPFMessageBoxService service = new WPFMessageBoxService();
                        //service.ShowMessage(msg, "Информация");

                        //PieModel = new PlotModel { Title = "Chart Sample1" };
                        //var barseries = new BarSeries() {
                        //    ItemsSource = new List<BarItem>(new[] {
                        //        //new BarItem {Value=matrix.Count(x => x.Duration > 900) },
                        //        //new BarItem {Value=matrix.Count(x => x.Duration >= 720 && x.Duration < 900) },
                        //        //new BarItem {Value=matrix.Count(x => x.Duration >= 420 && x.Duration < 720) },
                        //        //new BarItem {Value=matrix.Count(x => x.Duration >= 300 && x.Duration < 420) },
                        //        //new BarItem {Value=matrix.Count(x => x.Duration < 300) }
                        //        new BarItem {Value=2 },
                        //        new BarItem {Value=1 },
                        //        new BarItem {Value=46 },
                        //        new BarItem {Value=122 },
                        //        new BarItem {Value=167 }
                        //    }),
                        //    LabelPlacement = LabelPlacement.Outside
                        //};
                        //PieModel.Series.Add(barseries);

                        //PieModel.Axes.Add(new CategoryAxis {
                        //    Position = AxisPosition.Left,
                        //    ItemsSource = new[]
                        //    {
                        //        ">15",
                        //        "12-15",
                        //        "7-12",
                        //        "5-7",
                        //        "<5"
                        //    }
                        //});



                        PieModel = new PlotModel {
                            Title = "Время прибытия экипажа от места стоянки до объектов (в минутах)"
                        };
                        var barseries = new BarSeries() {
                            ItemsSource = new List<BarItem>(new[] {
                new BarItem {Value=2 },
                new BarItem {Value=46 },
                new BarItem {Value=122 },
                new BarItem {Value=167 },
                new BarItem {Value=1 }
            }),
                            LabelPlacement = LabelPlacement.Outside,
                            LabelFormatString = "{#:0.0}",
                        };
                        PieModel.Series.Add(barseries);

                        PieModel.Axes.Add(new CategoryAxis {
                            Position = AxisPosition.Left,
                            ItemsSource = new[]
                            {
                     ">15",
                                "12-15",
                                "7-12",
                                "5-7",
                                "<5"
                }
                        });

                        //PieModel.Series.Add(seriesP1);
                        ChartVisibility = true;
                    }
            });
        }
    }
}