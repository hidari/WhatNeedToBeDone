using System;
using System.Windows.Input;

namespace Hidari0415.WhatNeedToBeDone.Common
{
	public class DelegateCommand : ICommand
	{
		private Action execute;
		private Func<bool> canExecute;

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public DelegateCommand(Action execute)
			: this(execute, () => true)
		{
		}

		public DelegateCommand(Action execute, Func<bool> canExecute)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}

			if (canExecute == null)
			{
				throw new ArgumentNullException("canExecute");
			}

			this.execute = execute;
			this.canExecute = canExecute;
		}

		public void Execute(object parameter)
		{
			this.execute();
		}

		public bool CanExecute(object parameter)
		{
			return this.canExecute();
		}

		bool ICommand.CanExecute(object parameter)
		{
			return this.canExecute();
		}

		void ICommand.Execute(object parameter)
		{
			this.execute();
		}
	}
}
