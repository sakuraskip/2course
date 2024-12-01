using System.Text.RegularExpressions;

namespace lab8
{
    public class Program
    {
        public static void printEvent(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            User user1 = new User(5, 10f);
            User user2 = new User(2, 15f);
            User user3 = new User(10, 1f);


            user1.MoveTo += printEvent;
            user1.Compress += printEvent;
            user2.MoveTo += printEvent;
            user3.Compress += printEvent;

            user1.ChangePosition(15);
            user1.CompressSize(3);
            user2.ChangePosition(-5);
            user3.CompressSize(5);

            Console.WriteLine($"user1: pos: {user1.Position}, filesize: {user1.SizeOf}");
            Console.WriteLine($"user2: pos: {user2.Position}, filesize: {user2.SizeOf}");
            Console.WriteLine($"user3: pos: {user3.Position}, filesize: {user3.SizeOf}");



            Func<string, string> deletePunctuation = text => Regex.Replace(text, @"[^\p{L}\p{N}\s]", "");
            Func<string, string> addsymbols = text => text+" абырвалг";
            Func<string, string> touppercase = text=> text.ToUpper();

            Predicate<string> checkLetter = text=> text.IndexOf('А') >= 0;
            Action<string> print = text=> Console.WriteLine(text);

            string test1 = "ананасы яблоки!!!,,,, .. бананчики.... 45";
            string test2 = deletePunctuation(test1);
            test2 = addsymbols(test2);
            test2 = touppercase(test2);
            Console.WriteLine(checkLetter(test2));
            print(test2);
            
        }
        //public static string DeletePunctiation(string text)
        //{
        //    string buff = Regex.Replace(text, @"[^\p{L}\p{N}\s]", "");
        //    return buff;
        //}
        //public static string AddSymbols(string text)
        //{
        //    return text + " абырвалг";
        //}
        //public static string ToUpperCase(string text)
        //{
        //    return text.ToUpper();
        //}
        //public static bool hasLetterA(string text)
        //{
        //    return text.IndexOf('А') >= 0;
        //}
        //public static void PrintResult(string text)
        //{
        //    Console.WriteLine(text);
        //}
    }
    

}
