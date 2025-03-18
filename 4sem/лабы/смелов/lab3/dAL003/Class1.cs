using Newtonsoft.Json;
namespace dAL003
{
    public interface IRepository:IDisposable
    {
        string BasePath { get; }
        Celebrity[] getAllCelebrities();
        Celebrity? getCelebrityById(int id);
        Celebrity[] getCelebritiesBySurname(string Surname);
        string? getPhotoPathById(int id);
    }
    public record Celebrity(int Id,string Firstname,string Surname,string PhotoPath);
    public class Repository:IRepository
    {
        public static string JSONFileName {  get; set; }
        public  List<Celebrity> _celebrities;
        public bool _disposed = false;
        public string BasePath { get; } = "Photo/";

        public Repository(string filepath)
        {
            if(!File.Exists(filepath))
            {
                Console.WriteLine("аааа");
            }
            string json = File.ReadAllText(filepath);
            _celebrities = JsonConvert.DeserializeObject<List<Celebrity>>(json);
        }
        public Celebrity[] getAllCelebrities()
        {
            return _celebrities.ToArray();
        }
        public Celebrity? getCelebrityById(int id)
        {
            return _celebrities.FirstOrDefault(c => c.Id == id);
        }
        public Celebrity[] getCelebritiesBySurname(string surname)
        {
            return _celebrities.Where(celeb=>celeb.Surname == surname).ToArray();
        }
        public string? getPhotoPathById(int id)
        {
            var celeb = getCelebrityById(id);
            return celeb?.PhotoPath;
        }

         public void Dispose()
        {
            if (!_disposed)
            {


                
                


                _disposed = true;
            }
        }
    }
}
