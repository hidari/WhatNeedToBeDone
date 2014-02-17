using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hidari0415.WhatNeedToBeDone.Common
{
    public class NotificationObject: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            var h = this.PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
