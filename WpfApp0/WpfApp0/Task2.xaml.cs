using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace WpfApp0
{
    /// <summary>
    /// Логика взаимодействия для Task2.xaml
    /// </summary>
    public partial class Task2 : Window
    {
        public Task2()
        {
            InitializeComponent();
            GetPath();
            Deserialize();
        }

        private int FirstMark, SecondMark, NumberSchool, LastName, FirstName;

        private string Path = "";
        private void GetPath()
        {
            Path = $"{Directory.GetCurrentDirectory()}/task2.json";
        }

        public List<Student> Students { get; set; } = new List<Student>();

        private void AddStudent()
        {
            Students.Add(new Student(InputLastName.Text, InputFirstName.Text, int.Parse(InputNumberSchool.Text), int.Parse(InputFirstMark.Text), int.Parse(InputSecondMark.Text)));
            ListViewTask2.Items.Add(Students[Students.Count - 1]);
            Serialize();
        }

        private Student GetBestStudent(int CurrentSchoolNumber)
        {
            var BestResult = 0;
            var BestStudent = Students[0];
            foreach (Student Stud in Students)
            {
                if (Stud.NumberSchool == CurrentSchoolNumber)
                {
                    if (Stud.FirstMark + Stud.SecondMark > BestResult)
                    {
                        BestResult = Stud.FirstMark + Stud.SecondMark;
                        BestStudent = Stud;
                    }
                }
            }
            return BestStudent;
        }

        private bool StudentExist(int CurrentSchoolNumber)
        {
            foreach (Student Stud in Students)
            {
                if (Stud.NumberSchool == CurrentSchoolNumber) return true;
            }
            return false;
        }

        private void BestStudents()
        {
            var Result = new List<TextBlock>() { BestFromSchool1, BestFromSchool2, BestFromSchool3, BestFromSchool4, BestFromSchool5};
            foreach (var TextBlock in Result)
            {
                if (StudentExist(Result.IndexOf(TextBlock) + 1))
                {
                    TextBlock.Text = $"{GetBestStudent(Result.IndexOf(TextBlock) + 1).LastName} {GetBestStudent(Result.IndexOf(TextBlock) + 1).FirstName}";
                }
                else
                {
                    TextBlock.Text = "-";
                }
            }
        }

        private void Serialize()
        {
            string JsonString = System.Text.Json.JsonSerializer.Serialize(Students);
            File.WriteAllText(Path, JsonString);
        }

        private void Deserialize()
        {
            if (File.Exists(Path))
            {
                Students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(Path));
                foreach (Student Stud in Students)
                {
                    ListViewTask2.Items.Add(Stud);
                }
            }
        }

        private void Clear()
        {
            InputLastName.Clear();
            InputFirstName.Clear();
            InputNumberSchool.Clear();
            InputFirstMark.Clear();
            InputSecondMark.Clear();
        }

        private void AddDataTask2_Click(object sender, RoutedEventArgs e)
        {
            if (InputLastName.Text.Length < 1 || InputFirstName.Text.Length < 1 || InputNumberSchool.Text.Length < 1 || InputFirstMark.Text.Length < 1 || InputSecondMark.Text.Length < 1)
            {
                MessageBox.Show("Введите параметр");
            }
            else
            {
                AddStudent();
                BestStudents();
                Clear();
            }
        }

        private void BackMenuTask2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void DeleteStudent(Student SelectedStudent)
        {
            Students.Remove(SelectedStudent);
            Serialize();
        }

        private void InputFirstMark_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputFirstMark.Text.Length > 0)
            {
                if (!int.TryParse(InputFirstMark.Text, out FirstMark) || InputFirstMark.Text.Length > 1 || FirstMark > 5 || FirstMark < 2)
                {
                    MessageBox.Show("Неверный параметр");
                    InputFirstMark.Clear();
                }
            }
        }

        private void InputFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputFirstName.Text.Length > 0) //тут должны были быть регулярки
            {
                if (InputFirstName.Text.Contains('0') || InputFirstName.Text.Contains('1') || InputFirstName.Text.Contains('2') || InputFirstName.Text.Contains('3') || InputFirstName.Text.Contains('4') 
                    || InputFirstName.Text.Contains('5') || InputFirstName.Text.Contains('6') || InputFirstName.Text.Contains('7') || InputFirstName.Text.Contains('8') || InputFirstName.Text.Contains('9'))
                {
                    MessageBox.Show("Неверный параметр");
                    InputFirstName.Clear();
                }
                if (InputFirstName.Text.Contains('.') || InputFirstName.Text.Contains(',') || InputFirstName.Text.Contains('`') || InputFirstName.Text.Contains('~') || InputFirstName.Text.Contains('!')
                    || InputFirstName.Text.Contains('@') || InputFirstName.Text.Contains('#') || InputFirstName.Text.Contains('$') || InputFirstName.Text.Contains('%') || InputFirstName.Text.Contains('^')
                    || InputFirstName.Text.Contains('&') || InputFirstName.Text.Contains('*') || InputFirstName.Text.Contains('(') || InputFirstName.Text.Contains(')') || InputFirstName.Text.Contains('-')
                    || InputFirstName.Text.Contains('=') || InputFirstName.Text.Contains('+') || InputFirstName.Text.Contains('"') || InputFirstName.Text.Contains('№') || InputFirstName.Text.Contains(';')
                    || InputFirstName.Text.Contains(':') || InputFirstName.Text.Contains('?') || InputFirstName.Text.Contains('/') || InputFirstName.Text.Contains('|') || InputFirstName.Text.Contains('[')
                    || InputFirstName.Text.Contains('<') || InputFirstName.Text.Contains('>') || InputFirstName.Text.Contains(']') || InputFirstName.Text.Contains('{') || InputFirstName.Text.Contains('}'))
                {
                    MessageBox.Show("Неверный параметр");
                    InputFirstName.Clear();
                }
            }
        }

        private void InputSecondMark_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputSecondMark.Text.Length > 0)
            {
                if (!int.TryParse(InputSecondMark.Text, out SecondMark) || InputSecondMark.Text.Length > 1 || SecondMark > 5 || SecondMark < 2)
                {
                    MessageBox.Show("Неверный параметр");
                    InputSecondMark.Clear();
                }
            }
        }

        private void InputLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputLastName.Text.Length > 0) //тут должны были быть регулярки
            {
                if (InputLastName.Text.Contains('0') || InputLastName.Text.Contains('1') || InputLastName.Text.Contains('2') || InputLastName.Text.Contains('3') || InputLastName.Text.Contains('4') 
                    || InputLastName.Text.Contains('5') || InputLastName.Text.Contains('6') || InputLastName.Text.Contains('7') || InputLastName.Text.Contains('8') || InputLastName.Text.Contains('9'))
                {
                    MessageBox.Show("Неверный параметр");
                    InputLastName.Clear();
                }
                if (InputLastName.Text.Contains('.') || InputLastName.Text.Contains(',') || InputLastName.Text.Contains('`') || InputLastName.Text.Contains('~') || InputLastName.Text.Contains('!')
                    || InputLastName.Text.Contains('@') || InputLastName.Text.Contains('#') || InputLastName.Text.Contains('$') || InputLastName.Text.Contains('%') || InputLastName.Text.Contains('^')
                    || InputLastName.Text.Contains('&') || InputLastName.Text.Contains('*') || InputLastName.Text.Contains('(') || InputLastName.Text.Contains(')') || InputLastName.Text.Contains('-')
                    || InputLastName.Text.Contains('=') || InputLastName.Text.Contains('+') || InputLastName.Text.Contains('"') || InputLastName.Text.Contains('№') || InputLastName.Text.Contains(';')
                    || InputLastName.Text.Contains(':') || InputLastName.Text.Contains('?') || InputLastName.Text.Contains('/') || InputLastName.Text.Contains('|') || InputLastName.Text.Contains('[')
                    || InputLastName.Text.Contains('<') || InputLastName.Text.Contains('>') || InputLastName.Text.Contains(']') || InputLastName.Text.Contains('{') || InputLastName.Text.Contains('}'))
                {
                    MessageBox.Show("Неверный параметр");
                    InputLastName.Clear();
                }
            }
        }

        private void SelectItem(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var Item = ListViewTask2.SelectedItem as Student;
            DeleteStudent(Item);
            ListViewTask2.Items.Remove(Item);
            BestStudents();
        }

        private void InputNumberSchool_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputNumberSchool.Text.Length > 0)
            {
                if (!int.TryParse(InputNumberSchool.Text, out NumberSchool) || InputNumberSchool.Text.Length > 1 || NumberSchool > 5 || NumberSchool < 1)
                {
                    MessageBox.Show("Неверный параметр");
                    InputNumberSchool.Clear();
                }
            }
        }
    }
}
