using MahApps.Metro.Controls;
using Microsoft.EntityFrameworkCore;
using ReportsCore.Context;
using ReportsCore.Helpers;
using ReportsCore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Documents;

namespace ReportsCore.ViewModels {
	class MainWindowViewModel : BaseViewModel {

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
				using(Vityaz_MSCRMContext context = new Vityaz_MSCRMContext()) {
					//TODO: Перенести в get
					NewGuardObjectHistory before = null;
					NewGuardObjectHistory after = null;
					DateTime start = DateTime.Parse(DateStart.ToShortDateString());
					DateTime end = DateTime.Parse(DateEnd.ToShortDateString());
					List<NewGuardObjectHistory> history = await context.NewGuardObjectHistory.Where(x => x.ModifiedOn >= start && x.ModifiedOn <= end/* && x.NewObjectNumber == 7640*/).ToListAsync<NewGuardObjectHistory>();
					var r = history.GroupBy(a => new { a.NewGuardObjectId, a.ModifiedBy, DateTime = DateTime.Parse(a.ModifiedOn.ToString()) }).ToList();
					foreach(var item in r) {
						foreach(var i in item)
							if(i.HistoryState == "Старый")
								before = i;
							else
								after = i;
						List<Comparator> t = CompareObject(before, after);
						if(t.Any()) {
							string WhoChanged = context.SystemUserBase.FirstOrDefault(x => x.ModifiedBy == after.ModifiedBy).FullName;
							Guid? CuratorId = context.NewGuardObjectExtensionBase.FirstOrDefault(x => x.NewGuardObjectId == after.NewGuardObjectId).NewCurator;
							string curatorName = null;
							if(CuratorId.HasValue) {
								Guid _id = Guid.Empty;
								if(Guid.TryParse(CuratorId.Value.ToString(), out _id)) {
									curatorName = context.SystemUserBase.FirstOrDefault(x => x.SystemUserId == CuratorId).FullName;
								}
							}
						}
					}
				}
			});
		}

		private List<Comparator> CompareObject(NewGuardObjectHistory _old, NewGuardObjectHistory _new) {
			List<Comparator> comparator = new List<Comparator>();
			if(_old == null && _new == null)
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
				OnPropertyChanged("Report");
			}
		}
	}
}
