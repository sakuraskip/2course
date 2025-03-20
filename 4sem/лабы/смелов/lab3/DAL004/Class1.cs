using dAL003;
using System.Text.Json;
namespace DAL004
{
    public interface IRepository:dAL003.IRepository
    {
        int? addCelebrity(Celebrity celebrity);
        bool delCelebrityById(int id);
        int updCelebrity(int id,Celebrity celebrity);
        int SaveChanges();
    }
    public class Repository : dAL003.Repository, IRepository
    {
        private static int changeCounter = 0;
        public Repository(string filepath) : base(filepath)
        {

        }
        public int? addCelebrity(Celebrity celebrity)
        {
            _celebrities.Add(celebrity);
            changeCounter++;
            return celebrity.Id;
        }
        public bool delCelebrityById(int id)
        {
            if (_celebrities.Remove(_celebrities.Find(x => x.Id == id)))
            {
                changeCounter++;
                return true;
            }
            return false;
        }
        public int updCelebrity(int id,Celebrity celebrity)
        {
            if(_celebrities.Remove(_celebrities.Find(c=>c.Id == id)))
            {
                changeCounter++;
                _celebrities.Add(celebrity);
                return celebrity.Id;
            }
            return 0;
        }
        public int SaveChanges()
        {
            if(!File.Exists("Celebrities.json"))
            {
                Console.WriteLine("aaaa");
            }
            string filepath = JSONFileName = "Celebrities.json";
           
            string json = JsonSerializer.Serialize(_celebrities);

            File.WriteAllText(filepath, json);
            return changeCounter;
        }
    }
}
