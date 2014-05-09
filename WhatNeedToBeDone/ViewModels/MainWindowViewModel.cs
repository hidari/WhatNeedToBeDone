using System;
using System.Collections.ObjectModel;
using Hidari0415.WhatNeedToBeDone.Common;
using Hidari0415.WhatNeedToBeDone.Models;

namespace Hidari0415.WhatNeedToBeDone.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		#region Title 変更通知プロパティ
		// ここで一旦初期化しないとぬるり出るので
		private string _Title = "Window";

		public string Title
		{
			get { return _Title; }
			set
			{
				if (this._Title != null)
				{
					this._Title = value;
					this.RaisePropertyChanged("Title");
				}
			}
		}
		#endregion

		#region NewTodoContent 変更通知プロパティ
		private string _NewTodoContent;

		public string NewTodoContent
		{
			get { return _NewTodoContent; }
			set
			{
				if (this._NewTodoContent != value)
				{
					this._NewTodoContent = value;
					this.RaisePropertyChanged("NewTodo");
				}
			}
		}
		#endregion

		#region IsSelectedAll 変更通知プロパティ
		private bool _IsSelectedAll;

		public bool IsSelectedAll
		{
			get { return _IsSelectedAll; }
			set
			{
				if (this._IsSelectedAll != value)
				{
					this._IsSelectedAll = value;
					this.RaisePropertyChanged("IsSelectedAll");
				}
			}
		}
		#endregion

		public TodosViewModel TodoList { get; private set; }

		#region AddNewTodoCommand
		private DelegateCommand _AddNewTodoCommand;
		public DelegateCommand AddNewTodoCommand
		{
			get
			{
				if (this._AddNewTodoCommand == null)
				{
					this._AddNewTodoCommand = new DelegateCommand(AddNewTodo, CanAddNewTodo);
				}

				return this._AddNewTodoCommand;
			}
		}

		private void AddNewTodo()
		{
			this.TodoList.Todos.Add(new Todo(this.NewTodoContent));
		}

		private bool CanAddNewTodo()
		{
			return this.NewTodoContent != string.Empty;
		}
		#endregion

		#region ToggleAllCheckStateCommand
		private DelegateCommand _ToggleAllCheckStateCommand;
		public DelegateCommand ToggleAllCheckStateCommand
		{
			get
			{
				if (this._ToggleAllCheckStateCommand == null)
				{
					this._ToggleAllCheckStateCommand = new DelegateCommand(ToggleAllTodoCheckState);
				}

				return this._ToggleAllCheckStateCommand;
			}
		}


		private void ToggleAllTodoCheckState()
		{
			foreach (var item in this.TodoList.Todos)
			{
				item.IsDone = this.IsSelectedAll;
			}
		}
		#endregion

		public MainWindowViewModel()
		{
			this.Title = App.ProductInfo.Title;
			this.TodoList = new TodosViewModel();
			this.NewTodoContent = "What need to be done?";
		}

		private void ChangeIsSelectedAllValueIfListContainsNotSelectedTodo()
		{
			foreach (var item in this.TodoList.Todos)
			{
				if (!item.IsDone)
				{
					this.IsSelectedAll = false;
					return;
				}
			}
		}
	}
}
