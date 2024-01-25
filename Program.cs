namespace Lab1._2
{
    internal class Program
    {

        public class Person
        {
            public int PersonId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FavoriteColour { get; set; }
            public int Age { get; set; }
            public bool IsWorking { get; set; }

            public Person(int personId, string firstName, string lastName, string favoriteColour, int age, bool isWorking)
            {
                PersonId = personId;
                FirstName = firstName;
                LastName = lastName;
                FavoriteColour = favoriteColour;
                Age = age;
                IsWorking = isWorking;
            }

            public void DisplayPersonInfo()
            {
                Console.WriteLine($"{PersonId}: {FirstName} {LastName}'s favorite color is {FavoriteColour}");
            }

            public void ChangeFavoriteColour()
            {
                FavoriteColour = "White";
            }

            public int GetAgeInTenYears()
            {
                return Age + 10;
            }

            public override string ToString()
            {
                return $"PersonId: {PersonId}, Name: {FirstName} {LastName}, Favorite Colour: {FavoriteColour}, Age: {Age}, Is Working: {IsWorking}";
            }
        }

        public class Relation
        {

            public RelationshipType Type { get; set; }

            public Relation(RelationshipType type)
            {
                Type = type;
            }

            public enum RelationshipType
            {
                Sister,
                Brother,
                Mother,
                Father
            }

            public void ShowRelationship(Person person1, Person person2)
            {
                Console.WriteLine($"Relationship between {person1.FirstName} {person1.LastName} and {person2.FirstName} {person2.LastName}: {Type}");
            }
        }
        static void Main(string[] args)
        {
            Person person1 = new Person(1, "Ian", "Brooks", "Red", 30, true);
            Person person2 = new Person(2, "Gina", "James", "Green", 18, false);
            Person person3 = new Person(3, "Mike", "Briscoe", "Blue", 45, true);
            Person person4 = new Person(4, "Mary", "Beals", "Yellow", 28, true);

            person2.DisplayPersonInfo();
            Console.WriteLine(person3.ToString());
            person1.ChangeFavoriteColour();
            person1.DisplayPersonInfo();
            Console.WriteLine(person4.GetAgeInTenYears());

            Relation ginaMary = new Relation(Relation.RelationshipType.Sister);
            Relation ianMike = new Relation(Relation.RelationshipType.Brother);

            ginaMary.ShowRelationship(person2, person4);
            ianMike.ShowRelationship(person1, person3);

            List<Person> peopleList = new List<Person> { person1, person2, person3, person4 };
            int totalAge = person1.Age + person2.Age + person3.Age + person4.Age;
            float averageAge = totalAge / 4;
            Console.WriteLine(averageAge.ToString());

            Person youngestPerson = peopleList.OrderBy(person => person.Age).First();
            Person oldestPerson = peopleList.OrderByDescending(person => person.Age).First();
            Console.WriteLine($"Youngest Person: {youngestPerson.FirstName} {youngestPerson.LastName}");
            Console.WriteLine($"Oldest Person: {oldestPerson.FirstName} {oldestPerson.LastName}");

            var bluePerson = peopleList.FirstOrDefault(person => person.FavoriteColour.Equals("Blue", StringComparison.OrdinalIgnoreCase));
            if ( bluePerson != null)
            {
                Console.WriteLine(bluePerson.ToString());
            }
        }
    }
}
