using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayConsoleApplication
{
   
    public class Train
    {
        public int Id;
        public string Name;
        public string Source;
        public string Destination;

        public Train()
        {

        }


        public void Takedetailsfromuser()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Enter Train Id");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=================================");
            Console.WriteLine("Enter Train Name");
            Name = Console.ReadLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Enter Source");
            Source = Console.ReadLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Enter Destination");
            Destination = Console.ReadLine();
            Console.WriteLine("=================================");



        }

        public static List<Train> AllTrains()
        {
            List<Train> trainlist = new List<Train>();

            trainlist.Add(new Train
            {
                Id = 101,
                Name = "Rajdhani Express",
                Source = "Bangalore",
                Destination = "Delhi"

            });
            trainlist.Add(new Train
            {
                Id = 102,
                Name = "Duronto Express",
                Source = "Bangalore",
                Destination = "Ahemdabad"

            });


            return trainlist;
        }

        
    }
    
}
