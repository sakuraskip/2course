using System.Reflection;

namespace lab11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (Reflector<Vector>.writer = new StreamWriter(Reflector<Vector>.outputpath, false))
            { }
            Vector test = new Vector(new List<int> { 12, 32, 14, 15 });

            Reflector<Vector>.GetName(test);

            Reflector<Vector>.HasPublicConstructor(test);
            Reflector<Vector>.PrintPublicMethods(test);
            Reflector<Vector>.PrintMethodsByType(test,typeof(int));

            Растение test1 = new Растение("синий", "фиалка", 1);
            КоллекцияРастений test2 = new КоллекцияРастений();
            test2.Add(test1);
            Reflector<КоллекцияРастений>.GetName(test2);
            Reflector<КоллекцияРастений>.PrintPublicMethods(test2);
            string test3 = "";
            Reflector<string>.PrintPublicMethods(test3);


            Reflector<Vector>.Invoke(test,test,"printSomeText");

            var test4 = Reflector<Vector>.Create(test);

        }
    }
}
