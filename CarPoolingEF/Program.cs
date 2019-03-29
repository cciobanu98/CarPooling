using System;
using CarPooling.Context;
using CarPooling.Domain;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
namespace CarPooling
{
    class Program
    {

        static void Group()
        {
            var context = new CarPoolingContext();
            var gr = context.Cars.GroupBy(x => x.Model)
                .Select(x => new 
                {
                    Name = x.Key,
                    Number = x.Count()

                });
            foreach(var g in gr)
            {
                Console.WriteLine($"{g.Name} {g.Number}");
            }
        }
        static void GroupMultiple()
        {
            var context = new CarPoolingContext();
            var gr = context.Cars.GroupBy(x => new
            {
                x.Model,
                x.Color
            })
                .Select(x => new
                {
                    Name = x.Key,
                    Number = x.Count()

                }).Where(x => x.Number > 1);
            foreach (var g in gr)
            {
                Console.WriteLine($"{g.Name} {g.Number}");
            }
        }
        static void SubQuery()
        {
            var context = new CarPoolingContext();
            var gr = context.Rides.Select(x => new
            {
                EnrouteCityNumber = x.EnrouteCities.Select(y =>y.CityId).Count(),
                x.Car.Model,
                x.Id

            });
            foreach(var g in gr)
            {
                Console.WriteLine($"{g.EnrouteCityNumber} {g.Id}  {g.Model}");
            }
         }
        static void SubQuery2()
        {
            var context = new CarPoolingContext();
            var gr = context.Rides.Where(x => x.EnrouteCities.Any(y => y.CityId == 1)).Select(x => new
            {
                x.Car.Model,
                x.Id
            });
            foreach (var g in gr)
            {
                Console.WriteLine($" {g.Id}  {g.Model}");
            }
        }

        static void SelectMany()
        {
            var context = new CarPoolingContext();
            var t = context.Rides.SelectMany(x => x.EnrouteCities, (a, b) => new
            {
                a.Id,
                b.City.CityName
            });
            foreach (var tt in t)
            {
                Console.WriteLine($"{tt.Id} {tt.CityName}");
            }
        }
        static void SelectCase()
        {
            var context = new CarPoolingContext();
            var t = context.Rides.Select(x => new
            {
                x.Id,
                priceString = x.Price > 20 ? "Good price" : "Bad price"
            });
            foreach(var tt in t)
            {
                Console.WriteLine($"{tt.Id} {tt.priceString}");
            }
        }
        static void DynamicFilter(bool f1 = false, bool f2 = false, bool f3 = false)
        {
            var context = new CarPoolingContext();
            IQueryable<User> query = context.Users;
            if (f1)
            {
                query = query.Where(x => x.Age >= 21);
            }
            if (f2)
            {
                query = query.Where(x => x.Gender == 'F');
            }
            if (f3)
            {
                query = query.Where(x => x.FirstName.Contains('C'));
            }
            var q = query.Select(x => new
            {
                x.FirstName,
                x.LastName
            });
            foreach(var qq in q)
            {
                Console.WriteLine($"{qq.FirstName} {qq.LastName}");
            }
        }
        static void Pagination(int pagesize, int page = 1)
        {
            var context = new CarPoolingContext();
            while (page * pagesize <= context.Users.Count())
            {
                Console.WriteLine($"Page {page}");
                var q = context.Users.OrderBy(x => x.Age)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize).Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        x.Age
                    });
                page++;
                foreach (var qq in q)
                    Console.WriteLine($"{qq.FirstName} {qq.LastName} {qq.Age}");
            }
            
        }
        //static void JoinTest()
        //{
        //    var context = new CarPoolingContext();
        //    var q = from mc in context.MemberCars
        //            join m in  context.Users on 
        //}
        static void Test()
        {
            var context = new CarPoolingContext();
            var q = context.Rides.GroupBy(x => x.SourceCity.CityName)
                .Select(x => new
                {
                    x.Key,
                    Number = x.Count()
                });
            Console.WriteLine("Source ");
            foreach (var qq in q)
            {
                Console.WriteLine($"{qq.Key} {qq.Number}");
            }
        }
        static void Test2()
        {
            var context = new CarPoolingContext();
            var q = context.Rides.GroupBy(x => x.DestinationCity.CityName)
                .Select(x => new
                {
                    x.Key,
                    Number = x.Count()
                });
            Console.WriteLine("Destination ");
            foreach (var qq in q)
            {
                Console.WriteLine($"{qq.Key} {qq.Number}");
            }
        }
        static void Test3()
        {
            var context = new CarPoolingContext();


            var q = context.Cities.Select(x => new
            {
                name = x.CityName,
                s = context.Rides.Count(u => u.DestinationCity.Id == x.Id),
                d = context.Rides.Count(u => u.SourceCity.Id == x.Id)
            });
            foreach(var qq in q)
            {
                Console.WriteLine($"{qq.s} {qq.name} {qq.d}");
            }
        }
        static void Test4()
        {
            var context = new CarPoolingContext();
            var gr = context.Rides.Select(x => new
            {
                EnrouteCityNumber = x.EnrouteCities.Select(y => y.CityId).Count(),
                x.Id

            }).Where(y => y.EnrouteCityNumber > 3);
            foreach (var g in gr)
            {
                Console.WriteLine($"{g.EnrouteCityNumber} {g.Id}");
            }
        }
        static void Main(string[] args)
        {
            //ConcurentChange();
            //Polimorphic();
            //Group();
            //GroupMultiple();
            //SubQuery();
            //SubQuery2();
            //SelectMany();
            //SelectCase();
            //DynamicFilter(f3 : true);
            //Pagination(2, 1);
            //Test();
            Test4();
            Console.ReadKey();
        }
    }
}
