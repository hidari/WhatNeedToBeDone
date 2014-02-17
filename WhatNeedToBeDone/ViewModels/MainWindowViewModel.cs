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

        public MainWindowViewModel()
        {
            this.Title = App.ProductInfo.Title;
            this.TodoList = new TodosViewModel();
            this.NewTodoContent = "What need to be done?";
            
            #region Test Data
            this.TodoList.Todos = new ObservableCollection<Todo>
                {
                    new Todo("テスト TODO1"),
                    new Todo("テスト TODO2"),
                    new Todo("テスト TODO3")
                };

            this.TodoList.Todos[1].IsDone = true;
            #endregion
        }

    }
}
