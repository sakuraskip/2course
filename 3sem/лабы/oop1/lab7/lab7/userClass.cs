using System.Runtime;

    public class unknownShip
    {
        public int id {  get; set; }
        public string Name { get; set; } = "unknown";
        public int Speed { get; set; }

        void IsMoving()
        {
            Console.WriteLine("корабль движется, вроде");
        }
    public unknownShip() { }
    public unknownShip(int id,string name,int speed)
        {
            this.id = id;
            Name = name;
            Speed = speed;
        }
   
    public override string ToString()
    {
        return $"Id: {id}, Название:{Name}, скорость:{Speed} ";
    }
}
