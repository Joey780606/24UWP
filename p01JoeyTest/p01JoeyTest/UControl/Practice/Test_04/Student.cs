using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01JoeyTest.UControl.Practice.Test_04
{
    internal class Student
    {
        private string name_;
        public string Name
        {
            get { return name_; }
            set { name_ = value; }
        }

        private string rollno_;
        public string Rollno
        {
            get { return rollno_; }
            set { rollno_ = value; }
        }

        private string phone_;
        public string Phone
        {
            get { return phone_; }
            set { phone_ = value; }
        }
    }
}
