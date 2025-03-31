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
        public static string basepath2 { get; set; }
        private static int changeCounter = 0;
        public Repository(string filepath) : base(filepath)
        {

        }
        public int? addCelebrity(Celebrity celebrity)
        {
            int newid =celebrity.Id;
            if(celebrity.Id == 0)
            {
                 newid = _celebrities.Count +1;
            }
            var newceleb = new Celebrity(newid, celebrity.Firstname, celebrity.Surname, celebrity.PhotoPath);
            _celebrities.Add(newceleb);
            changeCounter++;
            return newid;
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
                int newid = celebrity.Id;
                if (celebrity.Id == 0)
                {
                    newid = _celebrities.Count + 1;
                }
                var newceleb = new Celebrity(newid, celebrity.Firstname, celebrity.Surname, celebrity.PhotoPath);
                changeCounter++;
                _celebrities.Add(newceleb);
                return newid;
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
