using MahApps.Metro.Controls;
using Microsoft.EntityFrameworkCore;
using ReportsCore.Context;
using ReportsCore.Helpers;
using ReportsCore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ReportsCore.ViewModels {
	class MainWindowViewModel : BaseViewModel {

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
				if(value)
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

		private DateTime _DateStart;
		public DateTime DateStart {
			get {
				if(_DateStart == DateTime.MinValue)
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
				if(_DateEnd == DateTime.MinValue)
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

		private string _DatePatternValue;
		public string DatePatternValue {
			get => _DatePatternValue;
			set {
				_DatePatternValue = value;
				OnPropertyChanged("DatePatternValue");
			}
		}

		private string _FilterParameter;
		public string FilterParameter {
			get => _FilterParameter;
			set {
				_FilterParameter = value;
				OnPropertyChanged("FilterParameter");
			}
		}

		private bool _VisibleChangeCostMonthlyPay;
		public bool VisibleChangeCostMonthlyPay {
			get => _VisibleChangeCostMonthlyPay;
			set {
				_VisibleChangeCostMonthlyPay = value;
				OnPropertyChanged("VisibleChangeCostMonthlyPay");
			}
		}
		private bool _VisibleAlarmActs;
		public bool VisibleAlarmActs {
			get => _VisibleAlarmActs;
			set {
				_VisibleAlarmActs = value;
				OnPropertyChanged("VisibleAlarmActs");
			}
		}
		private bool _VisibleLateGbr;
		public bool VisibleLateGbr {
			get => _VisibleLateGbr;
			set {
				_VisibleLateGbr = value;
				OnPropertyChanged("VisibleLateGbr");
			}
		}
		private bool _VisibleLatePult;
		public bool VisibleLatePult {
			get => _VisibleLatePult;
			set {
				_VisibleLatePult = value;
				OnPropertyChanged("VisibleLatePult");
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
				FlyoutSettingVisibleState = FlyoutSettingVisibleState ? false : true;
			});
		}
		private RelayCommand _Search;
		public RelayCommand Search {
			get => _Search ??= new RelayCommand(obj => {
				Reports = FullReports;
				if(!string.IsNullOrEmpty(FilterParameter) || !string.IsNullOrWhiteSpace(FilterParameter)) {
					bool isDigit = false;
					char[] filter = FilterParameter.ToCharArray();
					foreach(char item in filter) {
						if(char.IsDigit(item))
							isDigit = true;
						else {
							isDigit = false;
							break;
						}
					}
					//TODO: Проверить что второй раз ищется
					//FullReports = Reports;
					if(isDigit)
						Reports = new ObservableCollection<Report>(Reports.Where(x => x.ObjectNumber.ToString().Contains(FilterParameter)));
					else
						Reports = new ObservableCollection<Report>(Reports.Where(x => x.ObjectAddress.ToLower().Contains(FilterParameter.ToLower()) || x.ObjectName.ToLower().Contains(FilterParameter.ToLower())));
					OnPropertyChanged("Reports");
				}
				else
					MessageBox.Show("Значение для фильтрации не может быть пустым");
			});
		}

		private RelayCommand _ClearFilter;
		public RelayCommand ClearFilter {
			get => _ClearFilter ??= new RelayCommand(obj => {
				FilterParameter = null;
				Reports = FullReports;
			});
		}
		private RelayCommand _SelectDatePattern;
		public RelayCommand SelectDatePattern {
			get => _SelectDatePattern ??= new RelayCommand(obj => {
				DropDownButton o = obj as DropDownButton;
				System.Windows.MessageBox.Show(o.Items.CurrentItem.ToString());
			});
		}
		private RelayCommand _GetData;
		public RelayCommand GetData {
			get => _GetData ??= new RelayCommand(async obj => {
				//Изменение стоимости Абонентской платы
				if(SelectedReport.ReportID == Guid.Parse("b904a30b-16b1-4f59-a76d-bd981e18c930")) {
					Reports.Clear();
					using(Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
						//TODO: Перенести в get
						NewGuardObjectHistory before = null;
						NewGuardObjectHistory after = null;
						DateTime start = DateTime.Parse(DateStart.ToShortDateString()).AddHours(-5);
						DateTime end = DateTime.Parse(DateEnd.ToShortDateString()).AddHours(-5);
						List<NewGuardObjectHistory> history = await context.NewGuardObjectHistory.Where(x => x.ModifiedOn >= start && x.ModifiedOn <= end).ToListAsync<NewGuardObjectHistory>();
						var r = history.GroupBy(a => new { a.NewGuardObjectId, a.ModifiedBy, DateTime = DateTime.Parse(a.ModifiedOn.ToString()) }).ToList();
						foreach(var item in r) {
							before = null;
							after = null;
							foreach(var i in item)
								if(i.HistoryState == "Старый")
									before = i;
								else
									after = i;
							List<Comparator> t = CompareObject(before, after);
							if(t != null)
								if(t.Any()) {
									string WhoChanged = context.SystemUserBase.FirstOrDefault(x => x.SystemUserId == after.ModifiedBy).FullName;
									Guid? CuratorId = context.NewGuardObjectExtensionBase.FirstOrDefault(x => x.NewGuardObjectId == after.NewGuardObjectId).NewCurator;
									string curatorName = null;
									if(CuratorId.HasValue) {
										Guid _id = Guid.Empty;
										if(Guid.TryParse(CuratorId.Value.ToString(), out _id)) {
											curatorName = context.SystemUserBase.FirstOrDefault(x => x.SystemUserId == CuratorId).FullName;
										}
									}
									DateTime? WhenChanged = after.ModifiedOn;
									string oldValue = null;
									string newValue = null;
									foreach(Comparator c in t) {
										oldValue = c.OldValue;
										newValue = c.NewValue;
									}
									NewGuardObjectExtensionBase objectExtensionBase = context.NewGuardObjectExtensionBase.FirstOrDefault(x => x.NewGuardObjectId == after.NewGuardObjectId);
									if(objectExtensionBase != null)
										Reports.Add(new Report() {
											Before = oldValue,
											After = newValue,
											Curator = curatorName,
											DateChanged = WhenChanged,
											DateStart = objectExtensionBase.NewDateStart,
											WhoChanged = WhoChanged,
											ObjectAddress = objectExtensionBase.NewAddress,
											ObjectName = objectExtensionBase.NewName,
											ObjectNumber = objectExtensionBase.NewObjectNumber
										});
								}
						}
					}					
				}
				//По актам
				if(SelectedReport.ReportID == Guid.Parse("fa4dd0a5-5b15-45b4-a55a-433267fa50ff")) {
					Reports.Clear();
					using (Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
						DateTime start = DateTime.Parse(DateStart.ToShortDateString()).AddHours(-5);
						DateTime end = DateTime.Parse(DateEnd.ToShortDateString()).AddHours(-5);
						var result = context.NewAlarmExtensionBase.Where(x => x.NewAlarmDt >= start && x.NewAlarmDt < end && x.NewAct == true);
						if (result!=null)
							if(result.Any()) {
								foreach(var item in result) {
									using(Vityaz_MSCRMContext context1 = new Vityaz_MSCRMContext()) {
										var andromeda = context1.NewAndromedaExtensionBase.Where(x => x.NewAndromedaId == item.NewAndromedaAlarm).ToList();
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
											Act = item.NewAct
										});
									}
								}
							}
					}
				}
				FlyoutMenuState = false;
				FlyoutSettingVisibleState = false;
				FullReports = Reports;
			});
		}

		private List<Comparator> CompareObject(NewGuardObjectHistory _old, NewGuardObjectHistory _new) {
			List<Comparator> comparator = new List<Comparator>();
			if(_old == null || _new == null)
				return null;
			else {
				foreach(var item in _old.GetType().GetProperties()) {
					object oldValue = _old.GetType().GetProperty(item.Name).GetValue(_old);
					object newValue = _new.GetType().GetProperty(item.Name).GetValue(_new);
					if(oldValue != null)
						if(oldValue.Equals(newValue))
							continue;
						else
						if(item.Name.ToString().Equals("NewMonthlypay"))
							comparator.Add(new Comparator() {
								FieldName = item.Name,
								OldValue = _old.GetType().GetProperty(item.Name).GetValue(_old) == null ? null : _old.GetType().GetProperty(item.Name).GetValue(_old).ToString(),
								NewValue = _new.GetType().GetProperty(item.Name).GetValue(_new) == null ? null : _new.GetType().GetProperty(item.Name).GetValue(_new).ToString()
							});
						else
							continue;
				}
				return comparator;
			}
		}


		private ObservableCollection<ReportsList> _ReportList = new ObservableCollection<ReportsList>();
		private ObservableCollection<DatePattern> _DatePatterns = new ObservableCollection<DatePattern>();
		private ObservableCollection<Report> _Reports = new ObservableCollection<Report>();

		public MainWindowViewModel() {
			//ReportList.Add(new ReportsList() { ReportID = Guid.NewGuid(), ReportName = "Отчёт изменения стоимости абонентской платы" });
			using(ReportContext context = new ReportContext()) {
				foreach(var item in context.Reports.ToList()) {
					ReportList.Add(new ReportsList() { ReportID=item.RptId, ReportName=item.RptName });
				}
			}
			DatePatterns.Add(new DatePattern() { Id = Guid.NewGuid(), Name = "Текущий месяц" });
			DatePatterns.Add(new DatePattern() { Id = Guid.NewGuid(), Name = "Прошлый месяц" });
			DatePatterns.Add(new DatePattern() { Id = Guid.NewGuid(), Name = "Текущий квартал" });
			DatePatterns.Add(new DatePattern() { Id = Guid.NewGuid(), Name = "Прошлый квартал" });
			//SystemUserBase systemUserBase = new SystemUserBase();
			//foreach(FieldInfo item in systemUserBase.GetType().GetFields()) {
			//	int y = 0;
			//}	
		}

		public ObservableCollection<ReportsList> ReportList {
			get => _ReportList;
			set {
				_ReportList = value;
				OnPropertyChanged("ReportList");
			}
		}

		private ReportsList _SelectedReport;
		public ReportsList SelectedReport {
			get => _SelectedReport;
			set {
				_SelectedReport = value;
				//if(value.ReportID == Guid.Parse("b904a30b-16b1-4f59-a76d-bd981e18c930")) { //отчёт по изменению Абонентской платы
				//	VisibleChangeCostMonthlyPay = true;
				//}
				//else
				//	VisibleChangeCostMonthlyPay = false;
				OnPropertyChanged("SelectedReport");
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
	}
}
