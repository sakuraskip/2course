using dAL003;
using DAL004;
namespace Test_DAL004
{
    public class Program
    {
        static void Main(string[] args)
        {
            DAL004.Repository.JSONFileName = "Celebrities.json";

            using (DAL004.IRepository repository = new DAL004.Repository(DAL004.Repository.JSONFileName))
            {
                void print(string label)
                {
                    Console.WriteLine("--- " + label + " ---");

                    foreach (Celebrity celebrity in repository.getAllCelebrities())
                    {
                        Console.WriteLine($"ID: {celebrity.Id}, First Name: {celebrity.Firstname}, Photo Path: {celebrity.PhotoPath}");
                    }

                    print("Start");

                    int? testdel1 = repository.addCelebrity(new Celebrity(0, "TestDel1","TestDel1", "Photo/Testdel1.jpg"));
                    int? testdel2 = repository.addCelebrity(new Celebrity(0, "TestDel2", "TestDel2", "Photo/Testdel2.jpg"));
                    int? testupd1 = repository.addCelebrity(new Celebrity(0, "Testupd1", "Testupd1", "Photo/Testupd1.jpg"));
                    int? testupd2 = repository.addCelebrity(new Celebrity(0, "Testupd2", "Testupd21", "Photo/Testupd2.jpg"));
                    repository.SaveChanges();
                    if (testdel1 != null)
                        if (repository.delCelebrityById((int)testdel1)) Console.WriteLine($" delete {testdel1}"); else Console.WriteLine($"delete {testdel1} error");
                    if(testdel2!= null)
                    {
                        if (repository.delCelebrityById((int)testdel2)) Console.WriteLine($" delete {testdel2}"); else Console.WriteLine($"delete {testdel2} error");

                    }
                    if (repository.deleteCelebrityById((int)test))
                        Console.WriteLine($"Deleted: {testId1}");
                    else
                        Console.WriteLine($"Failed to delete: {testId1}");

                    if (repository.getCelebrityById((int)testId2) != null)
                    {
                        Console.WriteLine($"Celebrity found: {testId2}");
                        repository.updateCelebrity(new Celebrity((int)testId2, "Updated", "Photo/Updated.jpg"));
                        Console.WriteLine($"Updated: {testId2}");
                    }

                    repository.saveChanges();
                }

                // Вызов функции
                print("Celebrity List");
            }
        }
    }
}
