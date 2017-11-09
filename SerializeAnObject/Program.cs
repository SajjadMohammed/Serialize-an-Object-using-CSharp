using System;
using System.IO;
using System.Xml.Serialization;

using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeAnObject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Defining an object
            var student = new Student
            {
                Id = 1,
                FullName = "Ahmed Ameen Ali",
                Address = "Kirkuk",
                Age = 23
            };
            XMLSerialize(student);
            var stu = XMLDeserialize("xmlfile.xml");
            Console.WriteLine($"{stu.Id} : {stu.FullName} : {stu.Address} : {stu.Age}");
            Console.ReadKey(); 
        }

        //var memoryStream = BinarySerialize(student);
        //var stu = BinaryDeserialize(memoryStream.ToArray());
        //Console.WriteLine($"{stu.Id} : {stu.FullName} : {stu.Address} : {stu.Age}");
        static void XMLSerialize(Student student)
        {
            using (var xmlFile = File.Create("xmlfile.xml"))
            {
                var xmlSerializer = new XmlSerializer(typeof(Student));
                xmlSerializer.Serialize(xmlFile, student);
            }
        }

        static Student XMLDeserialize(string filePath)
        {
            using (var xmlFile = File.OpenRead(filePath))
            {
                var xmlDeserializer = new XmlSerializer(typeof(Student));
                var student = xmlDeserializer.Deserialize(xmlFile) as Student;
                return student;
            }
        }

        //static MemoryStream BinarySerialize(Student student)
        //{
        //    // Serialization steps
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        var binaryFormatter = new BinaryFormatter();
        //        binaryFormatter.Serialize(memoryStream, student);
        //        return memoryStream;
        //    }
        //}

        //static Student BinaryDeserialize(byte[] bytes)
        //{
        //    // De-Serialization steps
        //    using (var memoryStream = new MemoryStream(bytes))
        //    {
        //        var binaryFormatter = new BinaryFormatter();
        //        var student = binaryFormatter.Deserialize(memoryStream) as Student;
        //        return student;
        //    }
        //}
    }

    [Serializable]
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
}