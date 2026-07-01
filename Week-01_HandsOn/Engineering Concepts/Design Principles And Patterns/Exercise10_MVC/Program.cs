using System;

namespace MVCPatternExample
{
    class Student
    {
        private string name;
        private string id;
        private string grade;

        public Student(string id, string name, string grade)
        {
            this.id = id;
            this.name = name;
            this.grade = grade;
        }

        public string getName() => name;
        public void setName(string name) => this.name = name;

        public string getId() => id;
        public void setId(string id) => this.id = id;

        public string getGrade() => grade;
        public void setGrade(string grade) => this.grade = grade;
    }

    class StudentView
    {
        public void displayStudentDetails(string studentName, string studentId, string studentGrade)
        {
            Console.WriteLine("Student ID: " + studentId);
            Console.WriteLine("Student Name: " + studentName);
            Console.WriteLine("Student Grade: " + studentGrade);
        }
    }

    class StudentController
    {
        private Student model;
        private StudentView view;

        public StudentController(Student model, StudentView view)
        {
            this.model = model;
            this.view = view;
        }

        public void setStudentName(string name) => model.setName(name);
        public string getStudentName() => model.getName();

        public void setStudentId(string id) => model.setId(id);
        public string getStudentId() => model.getId();

        public void setStudentGrade(string grade) => model.setGrade(grade);
        public string getStudentGrade() => model.getGrade();

        public void updateView()
        {
            view.displayStudentDetails(model.getName(), model.getId(), model.getGrade());
        }
    }

    public class Program
    {
        public static void Main()
        {
            Student model = new Student("C101", "Krishna Mishra", "A");
            StudentView view = new StudentView();

            StudentController controller = new StudentController(model, view);

            controller.updateView();

            Console.WriteLine();

            controller.setStudentGrade("A+");
            controller.updateView();
        }
    }
}