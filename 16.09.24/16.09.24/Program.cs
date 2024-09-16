using System.Globalization;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
namespace _16._09._24
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Creator creator = new CreatorConcreteCourse();
            Product subproducts = creator.FactoryMethod(["1", "All"]);
            creator = new ConcreteCreatorStudent();
            Product subproducts1 = creator.FactoryMethod(["1", "Egor"]);
            creator = new ConcreteCreatorTeacher();
            Product subproducts2 = creator.FactoryMethod(["1", "10", "Karpenko"]);
            var course1 = (ConcreteCourse)subproducts;
            var teacher1 = (ConcreteTeacher)subproducts2;
            var student1 = (ConcreteStudent)subproducts1;
            course1.Teachers.Add(teacher1);
            course1.Students.Add(student1);
            AddInFile(course1.ToString());
            List<string> data = ReadToFile();
            Product product;
            foreach (string s in data)
            {
                string[] atributs = s.Split(new char[] { ';' });
                if (atributs[0] == "course")
                {
                    creator = new CreatorConcreteCourse();
                    product = creator.FactoryMethod([atributs[1], atributs[2]]);
                    var course = (ConcreteCourse)product;
                    string[] students = atributs[3].Split(new char[] { ':' });
                    foreach (string a in students)
                    {
                        if (a != "")
                        {
                            string[] atributStudens = a.Split(new char[] { '!' });
                            creator = new ConcreteCreatorStudent();
                            Product subproduct = creator.FactoryMethod([atributStudens[0], atributStudens[1]]);
                            var student = (ConcreteStudent)subproduct;
                            course.Students.Add(student);
                            student.Courses.Add(course);
                        }
                    }
                    string[] teachers = atributs[4].Split(new char[] { ':' });
                    foreach (string a in teachers)
                    {
                        if (a != "")
                        {
                            string[] atributTeachers = a.Split(new char[] { '!' });
                            creator = new ConcreteCreatorTeacher();
                            Product subproduct = creator.FactoryMethod([atributTeachers[0], atributTeachers[1], atributTeachers[2]]);
                            var teacher = (ConcreteTeacher)subproduct;
                            course.Teachers.Add(teacher);
                            teacher.Courses.Add(course);
                        }
                    }
                }
            }
        }
        internal static void AddInFile(string data)
        {
            string path = "data.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(data);
            }
        }

        internal static List<string> ReadToFile()
        {
            List<string> data = new List<string>();
            string path = "data.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    data.Add(line);
                }
            }
            return data;
        }
    }
}