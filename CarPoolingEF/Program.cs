using System;
using CarPooling.Context;
using CarPooling.Domain;
namespace CarPooling
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new GenericRepository<User>().GetAll();
            foreach(var u in users)
            {
                Console.WriteLine($"{u.FirstName} {u.LastName}");
            }
            var prefer = new GenericRepository<Preferences>().GetAll();
            Console.WriteLine("Preferences Description");
            foreach(var p in prefer)
            {
                Console.WriteLine($"{p.Description}");
            }
            Console.WriteLine("Volume");
            var mPrefer = new GenericRepository<MusicPreferences>().GetAll();
            foreach(var m in mPrefer)
            {
                Console.WriteLine($"{m.Volume}");
            }
            Console.ReadKey();
        }
    }
}
