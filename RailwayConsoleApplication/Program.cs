using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RailwayConsoleApplication
{
    public class Program
    {
       
        Train tr = new Train();
        List<Train> trainlist = Train.AllTrains();
        List<Train> booktrainlist = new List<Train>();

        void DisplayMenu()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("Railway Console Application");
            Console.WriteLine("*********************************");
            bool value = true;
            while (value == true)
            {
                var table = new ConsoleTable("Choice", "Functionality Type");
                table.AddRow("1", "Add Train");
                table.AddRow("2", "Search Train");
                table.AddRow("3", "View All Trains");
                table.AddRow("4", "Book Ticket");
                table.AddRow("5", "Booked Train List");
                table.AddRow("6", "Delete Train ");
                table.AddRow("7", "Exit");

                Console.WriteLine(table.ToString());

                Console.WriteLine("=================================");
                Console.WriteLine("Enter the Choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("=================================");

                switch (choice)
                {
                    case 1:
                        AddTrain();
                        break;
                    case 2:
                        Console.WriteLine("=================================");
                        Console.WriteLine("Enter Source");
                        string source = Console.ReadLine();
                        Console.WriteLine("=================================");
                        Console.WriteLine("Enter Destination");
                        string destination = Console.ReadLine();
                        Console.WriteLine("=================================");
                        foreach(var sourcedest in trainlist)
                        {
                            if(sourcedest.Source!=source && sourcedest.Destination != destination)
                            {
                                Console.WriteLine("Train Not Available from {0} to {1}", source, destination);
                                break;
                            }
                            else
                            {
                                SearchTrain(source, destination);

                            }
                        }

                        break;
                    case 3:
                        ViewAllTrains();
                        break;
                    case 4:
                        Console.WriteLine("=================================");
                        Console.WriteLine("Enter Number of Passengers");
                        int noOfPassesngers = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("=================================");
                        Console.WriteLine("Enter Train Id ");
                        int trainId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("=================================");
                        int totalprice = Bookticket(noOfPassesngers, trainId);
                        Console.WriteLine("*********************************");
                        Console.WriteLine("Total fare:{0} and Train Id:{1}" ,totalprice,trainId);
                        Console.WriteLine("*********************************");
                        break;
                    case 5:
                        ViewBookTrainList();
                        break;
                    case 6:
                        Console.WriteLine("Enter Train Id ");
                        int TrainId = Convert.ToInt32(Console.ReadLine());
                        foreach(var traindata in trainlist)
                        {
                            if (traindata.Id == TrainId)
                            {
                                DeleteTrain(TrainId);

                            }
                            else
                            {
                                Console.WriteLine("Deletion of train failed!");
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine("*********************************");
                        Console.WriteLine("Thank You!");
                        Console.WriteLine("*********************************");
                        value = false;
                        break;
                    
                    default:
                        Console.WriteLine("*********************************");
                        Console.WriteLine("Invalid choice");
                        Console.WriteLine("*********************************");
                        break;



                }

            }
        }

        private void DeleteTrain(int trainId)
        {
            trainlist.RemoveAll(x => x.Id == trainId);
            Console.WriteLine("Train Deletion Successfully!");

        }

        private void ViewBookTrainList()
        {
            foreach(var bookedtraindata in booktrainlist)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine(bookedtraindata.Id);
                Console.WriteLine("*********************************");
                Console.WriteLine(bookedtraindata.Name);
                Console.WriteLine("*********************************");
                Console.WriteLine(bookedtraindata.Source);
                Console.WriteLine("*********************************");
                Console.WriteLine(bookedtraindata.Destination);
                Console.WriteLine("*********************************");

            }
        }

        int Bookticket(int noOfPassesngers, int trainId)
        {
            List<Train> bookedtrainlistdata = (from tr in trainlist where tr.Id == trainId select tr).ToList();
            foreach(var traindata in bookedtrainlistdata)
            {
                booktrainlist.Add(new Train { Id=traindata.Id,Name=traindata.Name,Source=traindata.Source,Destination=traindata.Destination});

            }

            int individualfare = 200;
            int totalfare = noOfPassesngers * individualfare;
            return totalfare;

        }



        void ViewAllTrains()
        {
            
            foreach(var train in trainlist)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Train Id: " + train.Id);
                Console.WriteLine("Train Name: " + train.Name);
                Console.WriteLine("Train Source: " + train.Source);
                Console.WriteLine("Train Destination: " + train.Destination);
                Console.WriteLine("*********************************");

            }
        }

        void SearchTrain(string source,string destination)
        {
            foreach(var i in trainlist)
            {
                if(i.Source==source && i.Destination == destination)
                {
                    Console.WriteLine("*********************************");
                    Console.WriteLine("Train Id: "+i.Id);
                    Console.WriteLine("*********************************");
                    Console.WriteLine("Train Name: "+i.Name);
                    Console.WriteLine("*********************************");
                    Console.WriteLine("Train Source: "+i.Source);
                    Console.WriteLine("*********************************");
                    Console.WriteLine("Train Destination: "+i.Destination);
                    Console.WriteLine("*********************************");

                }
            }



        }

        void AddTrain()
        {
            tr.Takedetailsfromuser();
            trainlist.Add(new Train
            {
                Id = tr.Id,
                Name = tr.Name,
                Source = tr.Source,
                Destination = tr.Destination
            });

        }

        static void Main(string[] args)
        {

            Program pg = new Program();
            pg.DisplayMenu();

        }
    }
}
