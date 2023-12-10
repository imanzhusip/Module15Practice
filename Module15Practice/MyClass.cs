using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15Practice
{
    public class MyClass
    {
        public int privateField;
        public string publicField;

        public int PublicProperty { get; set; }
        public string PrivateProperty { get; set; }

        public MyClass()
        {
        }

        public MyClass(int value)
        {
            this.privateField = value;
        }

        public void PublicMethod()
        {
        }

        public string PrivateMethod()
        {
            return "Вызываемый частный метод.";
        }
    }

}
