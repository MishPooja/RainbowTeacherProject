using System;
using System.IO;
using System.Text;

namespace RainbowTeacherData
{
    class TeacherInfo
    {
        public string fileName = "C:\\Users\\Pooja_Mishra5\\source\\repos\\RainbowTeacherData\\TeacherData.txt";
        Teacher teacher = new Teacher();
        
        public void CreateFile()
        {
            if (!File.Exists(fileName))
            {
                TextWriter textWriter = File.CreateText(fileName);
                textWriter.WriteLine("ID \t Name \t className \t section");
                textWriter.Close();
                Console.WriteLine("File created Successfully");
            }
            else
            {
                Console.WriteLine("File Already Exist in the given path");
            }
        }
        public void WriteFile()
        {

            FileStream fileStream = new FileStream(fileName, FileMode.Append);
            teacher.EnterDetails();
            byte[] bdata = Encoding.Default.GetBytes(teacher.id +"\t" + teacher.name +"\t"+ teacher.classname +"\t"+ teacher.section +"\n");
            fileStream.Write(bdata, 0, bdata.Length);
            Console.WriteLine("Content written to the file Successfully.");
            fileStream.Close();
        }

        public void ReadFile()
        {
            FileStream filestream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader streamreader = new StreamReader(filestream);
            Console.WriteLine("Do you want to retrieve specific info ?");
            String answer = Console.ReadLine();
            if (answer.ToUpper() == "YES")
            {
                Console.WriteLine("Enter Teacher's ID for who you want to retrieve data");
                string Id = Console.ReadLine();
                var data = streamreader.ReadLine();
                while (data!= null)
                {
                    string[] TeacherRetrieveLine = data.Split("\t");
                    if (TeacherRetrieveLine[0] == Id)
                    {
                        Console.WriteLine("Details of the Teacher as below -");
                        Console.WriteLine("ID is -" + TeacherRetrieveLine[0]);
                        Console.WriteLine("NAme is -" + TeacherRetrieveLine[1]);
                        Console.WriteLine("ClassName is -" + TeacherRetrieveLine[2]);
                        Console.WriteLine("Section is -" + TeacherRetrieveLine[3]);
                        break;
                    }
                    else
                    {
                        data = streamreader.ReadLine();
                    }
                }
            }
            else
            {
                var data = streamreader.ReadToEnd();
                Console.WriteLine("Data in file is : \n {0}", data);
            }
            filestream.Close();
        }

        public void UpdateFile()
        {
            FileStream filestream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader streamreader = new StreamReader(filestream);

            //REad first line 
            var data = streamreader.ReadLine();
            string updateID = null; 

            //Read all the data in file
            string filevalue = File.ReadAllText(fileName);

            // User Input to see 
            Console.WriteLine("Do you want to make updates to data?");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "YES")
            {
                Console.WriteLine("Please enter the Teacher ID where you want to make updates");
                updateID = Console.ReadLine();
            }
            while (data != null)
            {
                string[] TeacherDataLine = data.Split("\t");
                int i = 0;
                if (TeacherDataLine[0] == updateID)
                {
                    Console.WriteLine("Enter the field which needs to be updated - Id , Name , className or section");
                    string fieldvalue = Console.ReadLine();
                    Console.WriteLine("Enter the new value which needs to be updated.");
                    string value = Console.ReadLine();
                    switch (fieldvalue.ToUpper())
                    {
                        case "ID":
                            i = 0;
                            break;
                        case "NAME":
                            i = 1;
                            break;
                        case "CLASSNAME":
                            i = 2;
                            break;
                        case "SECTION":
                            i = 3;
                            break;
                    }
                    //TeacherDataLine[i] = value;
                    filevalue = filevalue.Replace(TeacherDataLine[i], value);
                    break;
                }
                else
                { 
                    data = streamreader.ReadLine();
                    if (data == null)
                    {
                        Console.WriteLine("Given Id does not exist in file. Please enter a valid Id");
                        break;
                    }
                }
            }
            filestream.Close();
            File.WriteAllText(fileName, filevalue);
            Console.WriteLine("File is updated successfully");
        }
    }
}
