using System;
using System.IO;

namespace RainbowTeacherData
{
    class Teacher
    {
        public int id;
        public string name;
        public string classname;
        public string section;

        public void EnterDetails()
        {
            Console.WriteLine("Enter Teacher Info \n");
            Console.WriteLine("Enter Teacher ID");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Teacher NAme");
            name = Console.ReadLine();
            Console.WriteLine("Enter class details");
            classname = Console.ReadLine();
            Console.WriteLine("Enter section details");
            section = Console.ReadLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TeacherInfo teacherInfo = new TeacherInfo();
            teacherInfo.CreateFile();
            String choice;
            do
            {
                Console.WriteLine("Select the operation to be performed on teacher's data");
                Console.WriteLine("Enter 1 to write Teacher's data \n Enter 2 to display Teacher's Data \n Enter 3 to Modify Teacher's Data \n");
                int operation = Convert.ToInt32(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        teacherInfo.WriteFile();
                        break;

                    case 2:
                        teacherInfo.ReadFile();
                        break;
                    case 3:
                        teacherInfo.UpdateFile();
                        break;

                    default:
                        Console.WriteLine("exiting switch case");
                        break;
                }
                Console.WriteLine("Do you wish to continue?");
                choice = Console.ReadLine();
            } while (choice == "Yes" || choice == "Y" || choice == "yes");
        }
    }
}
