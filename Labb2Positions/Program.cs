using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Positions
{
    class Program
    {
        static void Main(string[] args)
        {

            Position p1 = new Position(10, 10);
            Position p2 = new Position(5, 5);
            Console.WriteLine(p1.Length());
            Console.WriteLine(p1.Equals(p2));

            Console.WriteLine(p1 > p2);
            Console.WriteLine(p1 - p2);

            Console.WriteLine(p1 % p2);

            Console.WriteLine(" ====== ");
            Console.WriteLine(new Position(2, 4) + new Position(1, 2) + "\n");
            Console.WriteLine(new Position(2, 4) - new Position(1, 2) + "\n");
            Console.WriteLine(new Position(1, 2) - new Position(3, 6) + "\n");
            Console.WriteLine(new Position(3, 5) % new Position(1, 3) + "\n");

            SortedPosList list1 = new SortedPosList();

            list1.Add(new Position(3, 3));
            list1.Add(new Position(1, -4));
            list1.Add(new Position(-2, 6));
            list1.Add(new Position(2, 2));
            list1.Add(p1);


            SortedPosList list2 = new SortedPosList();
            list2.Add(new Position(1, 1));
            list2.Add(new Position(2, 2));
            list2.Add(new Position(3, 3));
            list2.Add(new Position(3, 1));
            list2.Add(new Position(3, 2));

            Console.WriteLine("Remove från lista: ");
            Console.WriteLine("Före: " + list1);
            Console.WriteLine(list1.Remove(new Position(10,10)));
            Console.WriteLine("Efter: " + list1 + "\n");

            Console.WriteLine("Kloning av lista: ");
            var newList = list1.CloneList();
            Console.WriteLine(newList + "\n");




            Console.WriteLine("Vilka punkter ligger inom cirkeln: ");
            Position centerPos = new Position(5, 5);

            var shortList = list2.circleContent(centerPos, 4);
            Console.WriteLine(shortList + "\n");



            Console.WriteLine("Sammanslagning av två listor: ");
            Console.WriteLine(list2 + list1 + "\n");


            Console.WriteLine("Index från listan:");
            Console.WriteLine(list1[2]);
            Console.WriteLine("Hela listan: " + list1 + "\n");


            Console.WriteLine("LIST 1 - LIST 2:");
            Console.WriteLine("Orginal: " + list1);
            var minimizedList = list1 - list2;
            Console.WriteLine("New: " + minimizedList + "\n");


            Console.WriteLine("LIST 2 - LIST 1:");
            Console.WriteLine("Orginal: " + list2);
            var minimizedList2 = list2 - list1;
            Console.WriteLine("New: "+ minimizedList2 + "\n");


            CreateListOptions();


            //  Console.WriteLine(list1.Remove(new Position(2,3)));

            //Console.WriteLine("Efter: {0}", list1);


            //Console.WriteLine(list1 + "\n");
            ////list1.Remove(new Position(2, 6));
            //Console.WriteLine(list1 + "\n");

            //list2.Add(new Position(3, 7));
            //list2.Add(new Position(1, 2));
            //list2.Add(new Position(3, 6));
            //list2.Add(new Position(2, 3));
            //Console.WriteLine((list2 + list1) + "\n");

            //SortedPosList circleList = new SortedPosList();
            //circleList.Add(new Position(1, 1));
            //circleList.Add(new Position(2, 2));
            //circleList.Add(new Position(3, 3));
            //Console.WriteLine(circleList.CircleContent(new Position(5, 5), 4) + "\n");
        }

  
        static void CreateListOptions()
        {
            Console.WriteLine("Create new list? (y/n)");
            var answer = Console.ReadLine();
            if (answer == "y")
            {
                CreateNewList();

            } else {
                return;
            }
        }

        static void CreateNewList()
        {
            Console.WriteLine("Give it a name:");
            var listName = Console.ReadLine();
            SortedPosList newListToFile = new SortedPosList(listName);
            CreatePositionOptions(newListToFile);

        
        }

        static void CreatePositionOptions(SortedPosList list)
        {

            Console.WriteLine("Create new Position? (y/n)");
            var answer = Console.ReadLine();
            if (answer == "y") {
                CreateNewPosition(list);

            } else {
                CreateListOptions();
            }
        }

        static void CreateNewPosition(SortedPosList list)
        {
            Console.WriteLine("Please use format (x, y)");
            var newPositionAsString = Console.ReadLine();
            var newPosition = list.ToPosition(newPositionAsString);
            list.Save(newPosition);
            CreatePositionOptions(list);

        }
    }
}
