using dAL003;
using DAL004;
namespace Test_DAL004
{
    public class Program
    {
        static void Main(string[] args)
        {
            DAL004.Repository.JSONFileName = "C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\смелов\\lab3\\Test_DAL004\\Celebrities.json";

            using (DAL004.IRepository repository = new DAL004.Repository(DAL004.Repository.JSONFileName))
            {
                void print(string label)
                {
                    Console.WriteLine("--- " + label + " ---");

                    foreach (Celebrity celebrity in repository.getAllCelebrities())
                    {
                        Console.WriteLine($"ID: {celebrity.Id}, First Name: {celebrity.Firstname}, Photo Path: {celebrity.PhotoPath}");
                    }
                };
                    print("Start");

                    int? testdel1 = repository.addCelebrity(new Celebrity(8, "TestDel1","TestDel1", "Photo/Testdel1.jpg"));
                    int? testdel2 = repository.addCelebrity(new Celebrity(9, "TestDel2", "TestDel2", "Photo/Testdel2.jpg"));
                    int? testupd1 = repository.addCelebrity(new Celebrity(10, "Testupd1", "Testupd1", "Photo/Testupd1.jpg"));
                    int? testupd2 = repository.addCelebrity(new Celebrity(11, "Testupd2", "Testupd21", "Photo/Testupd2.jpg"));
                    repository.SaveChanges();

                print("add4");
                   
                if(testdel1 != null)
                {
                    if(repository.delCelebrityById((int)testdel1))
                    {
                        Console.WriteLine($"delete {testdel1}");
                    }
                    else
                    {
                        Console.WriteLine($"delete {testdel1} error");
                    }
                }
                if(testdel2 !=null)
                {
                    if(repository.delCelebrityById((int)testdel2))
                    {
                        Console.WriteLine($"delete {testdel2}");
                    }
                    else
                    {
                        Console.WriteLine($"delete {testdel2} error");
                    }
                }
                if (repository.delCelebrityById(1000))
                {
                    Console.WriteLine($"delete {1000}");
                }
                else
                {
                    Console.WriteLine($"delete {1000} error");
                }

                repository.SaveChanges();
                    print("del2");

                    if(testupd1 !=null)
                    {
                        if (repository.updCelebrity((int)testupd1, new Celebrity(12, "Updated1", "updated1", "Photo/Updated1.jpg")) != 0)
                        {
                            Console.WriteLine($"update {testupd1}");
                        }
                        else Console.WriteLine($" update {testupd1} failed");
                    }
                    if (testupd2 != null)
                    {
                        if (repository.updCelebrity((int)testupd2, new Celebrity(13, "Updated2", "updated2", "Photo/Updated2.jpg")) != 0)
                        {
                            Console.WriteLine($"update {testupd2}");
                        }
                        else Console.WriteLine($" update {testupd2} failed");
                    }
                    if (repository.updCelebrity(1000, new Celebrity(52, "Updated1000", "updated1000", "Photo/Updated1000.jpg")) != 0)
                    {
                        Console.WriteLine($"update {1000}");
                    }
                    else Console.WriteLine($" update {1000} failed");
                repository.SaveChanges();

                print("upd2");
            }
        }
    }
}
