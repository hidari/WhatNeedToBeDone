﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using Hidari0415.WhatNeedToBeDone.Common;
using Hidari0415.WhatNeedToBeDone.Models;

namespace Hidari0415.WhatNeedToBeDone.ViewModels
{
	public class TodosViewModel: ViewModelBase
	{
		#region SelectedCount 変更通知プロパティ
		private int _SelectedCount;
		public int SelectedCount
		{
			get { return this._SelectedCount; }
			set
			{
				this._SelectedCount = value;
				this.RaisePropertyChanged("SelectedCount");
			}
		}
		#endregion

		#region UnCompletedCount 変更通知プロパティ
		private int _UnCompletedCount;
		public int UnCompletedCount
		{
			get { return _UnCompletedCount; }
			set
			{
				this._UnCompletedCount = value;
				this.RaisePropertyChanged("UnCompletedCount");
			}
		}
		#endregion

		public ObservableCollection<Todo> Todos { get; set; }

		public TodosViewModel()
		{
			this.Todos = new ObservableCollection<Todo>();
		}

		#region DeleteSelectedCommand
		private DelegateCommand _DeleteSelectedCommand;
		public DelegateCommand DeleteSelectedCommand
		{
			get
			{
				if (this._DeleteSelectedCommand == null)
				{
					this._DeleteSelectedCommand = new DelegateCommand(this.DeleteSelected, this.CanDeleteSelected);
				}

				return this._DeleteSelectedCommand;
			}
		}

		private bool CanDeleteSelected()
		{
			this.SelectedCount = this.Todos.Count<Todo>((t) => t.IsDone == true);
			this.UnCompletedCount = this.Todos.Count - this.SelectedCount;
			return this.SelectedCount > 0;
		}

		private void DeleteSelected()
		{
			for (int i = this.Todos.Count-1; i >=0 ; i--)
			{
				if (this.Todos[i].IsDone)
				{
					this.Todos.Remove(this.Todos[i]);
				}
			}
		}
		#endregion
	}
}
