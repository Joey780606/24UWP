using System;
using System.Collections.Generic;
using System.ComponentModel;    //System.ComponentModel.INotifyPropertyChanged 需要
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01JoeyTest.UControl.Practice.Test_03
{
    internal class Chapters : System.ComponentModel.INotifyPropertyChanged
    {
        string name;
        string photo;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    NotifyPropertyChange("Name");
                }
            }
        }

        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                //if (value != photo)
                {
                    photo = value;
                    NotifyPropertyChange("Photo");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChange(string v)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(v));
        }

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
