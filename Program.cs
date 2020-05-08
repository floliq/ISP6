using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
	interface IPerson
	{
		int Id { get; }
		string Surname { get; }
		string Name { get; }
		string Fathername { get; }
		int Age { get; }
	}

	class InfoPerson : IPerson
	{
		public static int Number = 0;
		public int Id { get; }
		public string Surname { get; }
		public string Name { get; }
		public string Fathername { get; }
		public int Age { get; }

		public InfoPerson(string surname, string name, string fathername, int age)
		{
			
			Id = ++Number;
			Surname= surname;
			Name= name;
			Fathername = fathername;
			Age = age;
		}

		public void PrintPerson()
		{
			Console.Write(Id + " " + Surname+ " " + Name + " " + Fathername + " " + Age + " ");
		}
	}

	interface IStudent
	{
		string NameUniversity { get; }
	}

	class Student: IStudent
	{
		public string NameUniversity { get; }


		public Student(string nameUniversity)
		{
			NameUniversity= nameUniversity;
		}

		public void PrintStudent()
		{
			Console.Write(NameUniversity + " ");
		}
	}

	interface ISpeciality
	{
		string Faculty { get; }
		string Group { get; }
	}

	class Speciality : ISpeciality
	{
		public string Faculty { get; }
		public string Group { get; }

		public Speciality(string faculty, string group)
		{
			Faculty = faculty;
			Group = group;
		}

		public void PrintSpeciality()
		{
			Console.Write(Faculty+ " " + Group + " ");
		}
	}

	class Person : IComparable<Person>
	{
		public InfoPerson infoPerson { get; set; }
		public Student student { get; set; }
		public Speciality speciality { get; set; }

		public void Print()
		{
			infoPerson.PrintPerson();
			student.PrintStudent();
			speciality.PrintSpeciality();
		}

		public int CompareTo(Person person)
		{
			return this.infoPerson.Age.CompareTo(person.infoPerson.Age);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Person[] persons = new Person[3];

			persons[0] = new Person();
			persons[1] = new Person();
			persons[2] = new Person();

			persons[0].infoPerson = new InfoPerson("Бойко","Владислав","Богданович",19);
			persons[0].student = new Student("БГУИР");
			persons[0].speciality= new Speciality("ФРЭ", "944691");

			persons[1].infoPerson = new InfoPerson("Аринович", "Владислав", "Батькович", 20);
			persons[1].student = new Student("БГУИР");
			persons[1].speciality = new Speciality("ФРЭ", "944691");

			persons[2].infoPerson = new InfoPerson("Зубакин", "Кирилл", "Александрович", 18);
			persons[2].student = new Student("БНТУ");
			persons[2].speciality = new Speciality("МСФ", "АВС-11");

			foreach (Person i in persons)
			{
				i.Print();
				Console.WriteLine();
			}

			Console.WriteLine(persons[0].CompareTo(persons[1]));
			Console.WriteLine(persons[1].CompareTo(persons[2]));
			Console.ReadKey();
		}
	}
}
