using System;
using Hidari0415.WhatNeedToBeDone.Common;

namespace Hidari0415.WhatNeedToBeDone.Models
{
    public class Todo : NotificationObject
    {
        #region Content 変更通知プロパティ
        private string _Content;
        public string Content
        {
            get
            {
                return this._Content;
            }
            set
            {
                this._Content = value;
                this.RaisePropertyChanged("Content");
            }
        }
        #endregion

        #region IsDone 変更通知プロパティ
        private bool _IsDone;
        public bool IsDone
        {
            get { return this._IsDone; }
            set
            {
                if (this._IsDone != value)
                {
                    this._IsDone = value;
                    this.RaisePropertyChanged("IsDone");
                }
            }
        }
        #endregion

        public Todo(string content)
        {
            this.Content = content;
        }
    }
}
