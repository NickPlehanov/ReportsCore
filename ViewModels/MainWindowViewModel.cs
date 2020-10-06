﻿using MahApps.Metro.Controls;
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
				else if(DateTime.Now < end)
					return DateTime.Now;
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
				//if(obj != null)
				//DropDownButton o = obj as DropDownButton.Items;
				DropDownButton o = obj as DropDownButton;
				System.Windows.MessageBox.Show(o.Items.CurrentItem.ToString());
			});
		}
		private RelayCommand _GetData;
		public RelayCommand GetData {
			get => _GetData ??= new RelayCommand(async obj => {
				//List<Report> report = new List<Report>();
				using(Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
					//TODO: Перенести в get
					NewGuardObjectHistory before = null;
					NewGuardObjectHistory after = null;
					DateTime start = DateTime.Parse(DateStart.ToShortDateString()).AddHours(-5);
					DateTime end = DateTime.Parse(DateEnd.ToShortDateString()).AddHours(-5);
					List<NewGuardObjectHistory> history = await context.NewGuardObjectHistory.Where(x => x.ModifiedOn >= start && x.ModifiedOn <= end /*&& x.NewObjectNumber == 2866*/).ToListAsync<NewGuardObjectHistory>();
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
										After = oldValue,
										Before = newValue,
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
						//	if(item.Name.ToString().Equals("ModifiedOn") || item.Name.ToString().Equals("HistoryState"))
						//		continue;
						//else
						//	comparator.Add(new Comparator() {
						//		FieldName = item.Name,
						//		//OldValue = (string)_old.GetType().GetProperty(item.Name).GetValue(_old).ToString(),
						//		//NewValue = (string)_new.GetType().GetProperty(item.Name).GetValue(_new).ToString()
						//		OldValue = _old.GetType().GetProperty(item.Name).GetValue(_old) == null ? null : _old.GetType().GetProperty(item.Name).GetValue(_old).ToString(),
						//		NewValue = _new.GetType().GetProperty(item.Name).GetValue(_new) == null ? null : _new.GetType().GetProperty(item.Name).GetValue(_new).ToString()
						//	});
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
			//ReportList.Add(new ReportsList() { ReportID = Guid.NewGuid(), ReportName = "Отчёт 1" });
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
