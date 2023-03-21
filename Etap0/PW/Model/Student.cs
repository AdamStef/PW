using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.Model
{
    public class Student
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
