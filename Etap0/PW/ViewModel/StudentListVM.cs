using PW.Model;
using PW.Model.Error;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PW.ViewModel
{
    public class StudentListVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Student> StudentList { get; set; } = new ObservableCollection<Student>();
        public Student? SelectedStudent { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        public ICommand AddStudentCommand { get; set; }
        public ICommand RemoveStudentCommand { get; set; }

        public IDisplay display { get; set; }

        public StudentListVM()
        {
            AddStudentCommand = new RelayCommand(AddStudent);
            RemoveStudentCommand = new RelayCommand(RemoveStudent);
            display = new Display();
        }

        public void AddStudent()
        {
            if (Name == null || Name == "")
            {
                display.ShowMessage("Failed to create a student.");
                return;
            }
            Student student = new Student(Name, Age);
            StudentList.Add(student);
        }

        public void RemoveStudent()
        {
            if (SelectedStudent == null)
            {
                display.ShowMessage("No student selected.");
                return;
            }
            StudentList.Remove(SelectedStudent);
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
