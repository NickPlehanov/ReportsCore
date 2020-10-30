using MahApps.Metro.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
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
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

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
				FlyoutSettingVisibleState = FlyoutSettingVisibleState ? false : true;
				//FlyoutMenuState = !FlyoutSettingVisibleState;
			}, obj => SelectedReport != null);
		}
		private RelayCommand _Search;
		public RelayCommand Search {
			get => _Search ??= new RelayCommand(obj => {
				BackgroundWorker bw = new BackgroundWorker();
				bw.DoWork += (s, e) => {
					Loading = true;
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
				System.Windows.MessageBox.Show(o.Items.CurrentItem.ToString());
			});
		}
		private RelayCommand _GetData;
		public RelayCommand GetData {
			get => _GetData ??= new RelayCommand(obj => {
				//Dispatcher.CurrentDispatcher.Invoke(() => { 
				Reports.Clear();
				BackgroundWorker bw = new BackgroundWorker();
				bw.DoWork += (s, e) => {
					Loading = true;
					//Изменение стоимости Абонентской платы
					if(SelectedReport.ReportID == Guid.Parse("b904a30b-16b1-4f59-a76d-bd981e18c930")) {
						//Binding binding = new Binding("WhoChanged");
						//GroupPropeprtyName = binding;
						//TODO: переделать на отдельный метод					
						VisibleChangeCostMonthlyPay = true;
						VisibilityActs = false;
						VisibilityLatesGBR = false;
						VisibilityLatesPult = false;
						VisibilityReglamentWorks = false;
						using(Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
							//TODO: Перенести в get
							NewGuardObjectHistory before = null;
							NewGuardObjectHistory after = null;
							DateTime start = DateTime.Parse(DateStart.ToShortDateString()).AddHours(-5);
							DateTime end = DateTime.Parse(DateEnd.ToShortDateString()).AddHours(-5);
							List<NewGuardObjectHistory> history = context.NewGuardObjectHistory.Where(x => x.ModifiedOn >= start && x.ModifiedOn <= end).ToList<NewGuardObjectHistory>();
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
									foreach(var compr in t.Where(x => x.FieldName.Equals("NewMonthlypay"))) {
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
										//object oldValue = null;
										//object newValue = null;
										//foreach(Comparator c in t) {
										//	oldValue = c.OldValue;
										//	newValue = c.NewValue;
										//}
										NewGuardObjectExtensionBase objectExtensionBase = context.NewGuardObjectExtensionBase.FirstOrDefault(x => x.NewGuardObjectId == after.NewGuardObjectId);
										if(objectExtensionBase != null)
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
					if(SelectedReport.ReportID == Guid.Parse("fa4dd0a5-5b15-45b4-a55a-433267fa50ff")) {
						//TODO: переделать на отдельный метод
						VisibleChangeCostMonthlyPay = false;
						VisibilityActs = true;
						VisibilityLatesGBR = false;
						VisibilityLatesPult = false;
						VisibilityReglamentWorks = false;
						using(Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
							DateTime start = DateTime.Parse(DateStart.ToShortDateString()).AddHours(-5);
							DateTime end = DateTime.Parse(DateEnd.ToShortDateString()).AddHours(-5);
							var result = context.NewAlarmExtensionBase.Where(x => x.NewAlarmDt >= start && x.NewAlarmDt < end && x.NewAct == true);
							if(result != null)
								if(result.Any()) {
									foreach(var item in result) {
										using(Vityaz_MSCRMContext context1 = new Vityaz_MSCRMContext()) {
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
					if(SelectedReport.ReportID == Guid.Parse("a35a2859-3e10-42f1-9e9b-5f29b5e953d9")) {
						//TODO: переделать на отдельный метод
						VisibleChangeCostMonthlyPay = false;
						VisibilityActs = false;
						VisibilityLatesGBR = false;
						VisibilityLatesPult = true;
						VisibilityReglamentWorks = false;
						using(Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
							DateTime start1 = DateTime.Parse(DateStart.ToShortDateString()).AddHours(-5);
							DateTime end1 = DateTime.Parse(DateEnd.ToShortDateString()).AddHours(-5);
							var result = context.NewAlarmExtensionBase.Where(x => x.NewAlarmDt >= start1 && x.NewAlarmDt < end1);
							if(result != null)
								if(result.Any()) {
									foreach(var item1 in result) {
										if(item1.NewDeparture.HasValue && item1.NewAlarmDt.HasValue) {
											if((item1.NewDeparture - item1.NewAlarmDt).Value.TotalSeconds > 30) {
												using(Vityaz_MSCRMContext context1 = new Vityaz_MSCRMContext()) {
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
					if(SelectedReport.ReportID == Guid.Parse("8a7e33df-e27d-413c-80d5-e3812b57853c")) {
						//TODO: переделать на отдельный метод
						VisibleChangeCostMonthlyPay = false;
						VisibilityActs = false;
						VisibilityLatesGBR = true;
						VisibilityLatesPult = false;
						VisibilityReglamentWorks = false;
						using(Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
							DateTime start2 = DateTime.Parse(DateStart.ToShortDateString()).AddHours(-5);
							DateTime end2 = DateTime.Parse(DateEnd.ToShortDateString()).AddHours(-5);
							var result = context.NewAlarmExtensionBase.Where(x => x.NewAlarmDt >= start2 && x.NewAlarmDt < end2);
							if(result != null)
								if(result.Any()) {
									foreach(var item2 in result) {
										if(item2.NewArrival.HasValue && item2.NewDeparture.HasValue)
											if((item2.NewArrival - item2.NewDeparture).Value.TotalMinutes >= 12) {
												using(Vityaz_MSCRMContext context1 = new Vityaz_MSCRMContext()) {
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
					if(SelectedReport.ReportID == Guid.Parse("7C9C1F49-6218-4C9A-8F17-126626E5D1D3")) {
						//Binding binding = new Binding("WhoChanged");
						//GroupPropeprtyName = binding;
						//TODO: переделать на отдельный метод					
						VisibleChangeCostMonthlyPay = false;
						VisibilityActs = false;
						VisibilityLatesGBR = false;
						VisibilityLatesPult = false;
						VisibilityReglamentWorks = true;
						using(Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
							var rr = context.NewGuardObjectExtensionBase.Where(x => x.NewRrOnOff == true || x.NewRrOs == true || x.NewRrPs == true || x.NewRrVideo == true || x.NewRrSkud == true);
							if(rr != null)
								foreach(var item in rr) {
									App.Current.Dispatcher.Invoke((System.Action)delegate {
										Reports.Add(new Report() {
											ObjectNumber = item.NewObjectNumber,
											ObjectName = item.NewName,
											ObjectAddress = item.NewAddress,
											RrEveryMonth = item.NewRrOnOff,
											RrOS = item.NewRrOs,
											RrPS = item.NewRrPs,
											RrVideo = item.NewRrVideo,
											RrSkud = item.NewRrSkud
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
							if(history.Where(x => x.NewRrOnOff != null || x.NewRrOs != null || x.NewRrPs != null || x.NewRrSkud != null || x.NewRrVideo != null).Count() > 0) {
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
										foreach(var compr in t.Where(x => x.FieldName.Equals("NewRrOnOff") || x.FieldName.Equals("NewRrOs") || x.FieldName.Equals("NewRrPs") || x.FieldName.Equals("NewRrVideo") || x.FieldName.Equals("NewRrSkud"))) {
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
											NewGuardObjectExtensionBase objectExtensionBase = context.NewGuardObjectExtensionBase.FirstOrDefault(x => x.NewGuardObjectId == after.NewGuardObjectId);
											if(objectExtensionBase != null)
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
							context.
						}
					}

					FlyoutMenuState = false;
					FlyoutSettingVisibleState = false;
					FullReports = Reports;
				};
				bw.RunWorkerCompleted += (s, e) => {
					Loading = false;
				};
				bw.RunWorkerAsync();
				//});
			});
		}

		private RelayCommand _ViewTotalCommand;
		public RelayCommand ViewTotalCommand {
			get => _ViewTotalCommand ??= new RelayCommand(obj => {
				//изм. абонентской платы
				if(SelectedReport.ReportID == Guid.Parse("B904A30B-16B1-4F59-A76D-BD981E18C930")) {
					if(obj == null) {
						TotalManagers = new ObservableCollection<TotalManagers>();
						int CountRecords = Reports.Count;
						var ChangeByUser = Reports.GroupBy(x => x.WhoChanged);
						int PlusCounter = 0;
						int MinusCounter = 0;
						float PlusSum = 0;
						float MinusSum = 0;
						//Todo: доделать общую сумму приходов/расходов/общую
						//float AllSum = 0;
						foreach(var item in ChangeByUser) {
							PlusCounter = 0;
							MinusCounter = 0;
							PlusSum = 0;
							MinusSum = 0;
							foreach(var i in item) {
								if((ParseDigit(i.After) - ParseDigit(i.Before)) > 0) {
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
						foreach(var item in ChangeByUser) {
							//PlusCounter = 0;
							//MinusCounter = 0;
							//PlusSum = 0;
							//MinusSum = 0;
							if((ParseDigit(item.After) - ParseDigit(item.Before)) > 0) {
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
			if(string.IsNullOrEmpty(param))
				return 0;
			else if(!int.TryParse(param, out _)) {
				char[] arr = param.ToCharArray();
				foreach(var item in arr) {
					if(char.IsDigit(item)) {
						r += item;
					}
					else if(char.IsPunctuation(item))
						break;
				}
				return int.Parse(r);
			}
			else
				return int.Parse(param);
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
								//foreach(var property in _old.GetType().GetProperties()) {
								if(_old.GetType().GetProperty(item.Name).GetValue(_old) != null && _new.GetType().GetProperty(item.Name).GetValue(_new) != null)
							if(!_old.GetType().GetProperty(item.Name).GetValue(_old).Equals(_new.GetType().GetProperty(item.Name).GetValue(_new))) {
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

		public MainWindowViewModel() {
			//ReportList.Add(new ReportsList() { ReportID = Guid.NewGuid(), ReportName = "Отчёт изменения стоимости абонентской платы" });
			using(ReportContext.ReportContext context = new ReportContext.ReportContext()) {
				string login = Environment.UserName;
				using(ReportContext.ReportContext context1 = new ReportContext.ReportContext()) {
					foreach(var accessReports in context.UsersReports.Where(x => x.UsrLogin.ToLower().Contains(login.ToLower()))) {
						ReportList.Add(new ReportsList() {
							ReportID = context1.Reports.FirstOrDefault(y => y.RptId == accessReports.RptId).RptId,
							ReportName = context1.Reports.FirstOrDefault(y => y.RptId == accessReports.RptId).RptName
						});
					}
				}
				//foreach(var item in context.Reports.ToList()) {
				//	ReportList.Add(new ReportsList() { ReportID = item.RptId, ReportName = item.RptName });
				//}
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

		//public MainWindowViewModel(TotalManagers totalManagers) {
		//	TotalManagers = totalManagers;
		//}

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
				//if(value.ReportID == Guid.Parse("b904a30b-16b1-4f59-a76d-bd981e18c930")) { //отчёт по изменению Абонентской платы
				//	VisibleChangeCostMonthlyPay = true;
				//}
				//else
				//	VisibleChangeCostMonthlyPay = false;
				FlyoutMenuState = false;
				FlyoutSettingVisibleState = true;
				OnPropertyChanged("SelectedReport");
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
				if(SelectedReport.ReportID == Guid.Parse("b904a30b-16b1-4f59-a76d-bd981e18c930")) {
					try {
						if(flo != null) {
							if(flo.Any()) {
								Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
								SaveFileDialog saveFileDialog_word = new SaveFileDialog() {
									//InitialDirectory = "c:\\",
									Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*",
									FilterIndex = 1
								};
								saveFileDialog_word.ShowDialog();
								if(!string.IsNullOrEmpty(saveFileDialog_word.FileName)) {
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

									for(int i = 0; i < headers.Length; i++)
										word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Text = headers[i];

									for(int i = 0; i < headers.Length; i++) {
										word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Bold = 1;
										word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
									}
									foreach(var item in flo) {
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
					catch(Exception ex) {
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
						//TaskBarIconVisibility = true;
						//MessageBox.Show("test");
						//notify("Ошибка", ex.Message, System.Windows.Forms.ToolTipIcon.Error, false);
					}
				}
				//Акты
				if(SelectedReport.ReportID == Guid.Parse("fa4dd0a5-5b15-45b4-a55a-433267fa50ff")) {
					try {
						if(flo != null) {
							if(flo.Any()) {
								Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
								SaveFileDialog saveFileDialog_word = new SaveFileDialog() {
									//InitialDirectory = "c:\\",
									Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*",
									FilterIndex = 1
								};
								saveFileDialog_word.ShowDialog();
								if(!string.IsNullOrEmpty(saveFileDialog_word.FileName)) {
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

									for(int i = 0; i < headers.Length; i++)
										word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Text = headers[i];

									for(int i = 0; i < headers.Length; i++) {
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
									foreach(var item in flo) {
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
					catch(Exception ex) {
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
						//TaskBarIconVisibility = true;
						//MessageBox.Show("test");
						//notify("Ошибка", ex.Message, System.Windows.Forms.ToolTipIcon.Error, false);
					}
				}
				//Опоздания
				if(SelectedReport.ReportID == Guid.Parse("a35a2859-3e10-42f1-9e9b-5f29b5e953d9") || SelectedReport.ReportID == Guid.Parse("8a7e33df-e27d-413c-80d5-e3812b57853c")) {
					try {
						if(flo != null) {
							if(flo.Any()) {
								Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
								SaveFileDialog saveFileDialog_word = new SaveFileDialog() {
									//InitialDirectory = "c:\\",
									Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*",
									FilterIndex = 1
								};
								saveFileDialog_word.ShowDialog();
								if(!string.IsNullOrEmpty(saveFileDialog_word.FileName)) {
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

									for(int i = 0; i < headers.Length; i++)
										word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Text = headers[i];

									for(int i = 0; i < headers.Length; i++) {
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
									foreach(var item in flo) {
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
					catch(Exception ex) {
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
						//TaskBarIconVisibility = true;
						//MessageBox.Show("test");
						//notify("Ошибка", ex.Message, System.Windows.Forms.ToolTipIcon.Error, false);
					}
				}
				//регламентные работы 
				if(SelectedReport.ReportID == Guid.Parse("7C9C1F49-6218-4C9A-8F17-126626E5D1D3")) {
					try {
						if(flo != null) {
							if(flo.Any()) {
								Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
								SaveFileDialog saveFileDialog_word = new SaveFileDialog() {
									//InitialDirectory = "c:\\",
									Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*",
									FilterIndex = 1
								};
								saveFileDialog_word.ShowDialog();
								if(!string.IsNullOrEmpty(saveFileDialog_word.FileName)) {
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

									for(int i = 0; i < headers.Length; i++)
										word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Text = headers[i];

									for(int i = 0; i < headers.Length; i++) {
										word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.Bold = 1;
										word_doc.Tables[1].Cell(table.Rows.Count, i + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
									}
									foreach(var item in flo) {
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
					catch(Exception ex) {
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
						//TaskBarIconVisibility = true;
						//MessageBox.Show("test");
						//notify("Ошибка", ex.Message, System.Windows.Forms.ToolTipIcon.Error, false);
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
				//MessageBox.Show("Отчёт успешно сохранен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
				finally {
					Loading = false;
				}
			};
			bw.RunWorkerAsync();
		}
		//private void notify(string title, string msg, System.Windows.Forms.ToolTipIcon toolTipIcon, bool isClicked) {
		//	NotifyIcon nIcon = new NotifyIcon();
		//	nIcon.Icon = new Icon(@"headphones_audio_sound_10907.ico");
		//	nIcon.Visible = true;
		//	nIcon.ShowBalloonTip(15000, title, msg, toolTipIcon);
		//	if(isClicked)
		//		nIcon.BalloonTipClicked += BallonTipClicked;
		//	//nIcon.Dispose();
		//}

	}

}
