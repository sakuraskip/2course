using dAL003;
namespace test_dal003
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Repository.JSONFileName = "Celebrities.json";

            using(IRepository repository = new Repository("C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\смелов\\lab3\\test_dal003\\Photo\\Celebrities.json"))
            {
                foreach(Celebrity celeb in repository.getAllCelebrities())
                {
                    Console.WriteLine($"id = {celeb.Id}, firstname = {celeb.Firstname}, " +
                        $"surname = {celeb.Surname}, photopath = {celeb.PhotoPath}");
                }
                Celebrity? celeb1 = repository.getCelebrityById(1);
                if(celeb1!=null)
                {
                    Console.WriteLine($"id = {celeb1.Id}, firstname = {celeb1.Firstname}, " +
                       $"surname = {celeb1.Surname}, photopath = {celeb1.PhotoPath}");
                }
                Celebrity? celeb3 = repository.getCelebrityById(3);
                if (celeb3 != null)
                {
                    Console.WriteLine($"id = {celeb3.Id}, firstname = {celeb3.Firstname}, " +
                       $"surname = {celeb3.Surname}, photopath = {celeb3.PhotoPath}");
                }
                Celebrity? celeb222 = repository.getCelebrityById(222);
                if (celeb222 != null)
                {
                    Console.WriteLine($"id = {celeb222.Id}, firstname = {celeb222.Firstname}, " +
                       $"surname = {celeb222.Surname}, photopath = {celeb222.PhotoPath}");
                }
                else
                {
                    Console.WriteLine("222 not found");
                }
                foreach(Celebrity celeb in repository.getCelebritiesBySurname("Knuth"))
                {
                    Console.WriteLine($"id = {celeb.Id}, firstname = {celeb.Firstname}, " +
                        $"surname = {celeb.Surname}, photopath = {celeb.PhotoPath}");
                }
                foreach (Celebrity celeb in repository.getCelebritiesBySurname("xxcxc"))
                {
                    Console.WriteLine($"id = {celeb.Id}, firstname = {celeb.Firstname}, " +
                        $"surname = {celeb.Surname}, photopath = {celeb.PhotoPath}");
                }
                Console.WriteLine($"photopath by id = {repository.getPhotoPathById(1)}");
                Console.WriteLine($"photopath by id = {repository.getPhotoPathById(313)}");



            }
        }
        }
    }

