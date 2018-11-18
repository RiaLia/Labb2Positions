using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Labb2Positions
{
    public class SortedPosList
    {
        List<Position> positionList = new List<Position>();
        List<String> listWithStringPositions = new List<string>();
        string path = "";

        public Position this[int i] 
        {
            get 
            {
                return positionList[i];
            }
        }

        public SortedPosList() 
        {
  
        }

        // Overload Constructor the gets a string to use as filename.
        // Check if file exists, if it does - load it. Otherwise create a new file with that name.
        public SortedPosList(string filePath) {
            path = "/Users/Ria/C#/Labb2Positions/Labb2Positions/" + filePath;

            if (File.Exists(path)) {
                Console.WriteLine("File already exists!");
                Console.WriteLine("The list {0} contains: ", filePath);
                Load();
            } else {
                File.CreateText(path);
            }

        }

        // Load the list from the choosen path. For each item in the list -> Convert back to position,
        // -> Add the position to the local postionList, -> Order the list by length. -> Add it to the string list for later use.
        // And print the list.
        public void Load(){

            List<string> data = File.ReadAllLines(path).Distinct().ToList();

            foreach (var item in data)
            {
                var pos = ToPosition(item);
                positionList.Add(pos);
                positionList = positionList.OrderBy(p => p.Length()).ToList();
                listWithStringPositions.Add(pos.ToString());
                Console.WriteLine(item);
            }

        }
        // Check if the list already contatins a position with the same coordinates. If not - add it. 
        // Otherwise ask the use if they really want to add it anyway.

        public void Save(Position pos)
        {

            if (listWithStringPositions.Contains(pos.ToString())){
                Console.WriteLine("Position allready exsits");
                Console.WriteLine("Want to create it anyway? (y/n)");
                var chooise = Console.ReadLine();

                if (chooise == "y") {
                    listWithStringPositions.Add(pos.ToString());
                    listWithStringPositions.ForEach(Console.WriteLine);

                    if (path != "")
                    {
                        File.WriteAllLines(path, listWithStringPositions);
                    } 
                }
                else
                {
                    return;
                }
            } else {
                listWithStringPositions.Add(pos.ToString());
                listWithStringPositions.ForEach(Console.WriteLine);

                if (path != "")
                {
                    File.WriteAllLines(path, listWithStringPositions);
                }
            }

          
        }
        // Method for converting the string from the file to the format Position Class wants. 
        // Remove unnesserary characters, and the split it by "," to get each value by it self.

        public Position ToPosition(string pos){

            pos = pos.Replace("(","");
            pos = pos.Replace(")", "");
            pos = pos.Replace(" ", "");

            string[] posChars = pos.Split(",");

        
            int x = Convert.ToInt32(posChars[0]);
            int y = Convert.ToInt32(posChars[1]);


            Position position = new Position(x, y);

            return position;
        }

        public override string ToString()
        {
            return string.Join(",", positionList);
        }

        public int Count()
        {
            return positionList.Count;
        }

        public void Add(Position pos)
        {
            positionList.Add(pos);
            positionList = positionList.OrderBy(p => p.Length()).ToList();

         

        }

        public bool Remove(Position pos)
        {

            foreach (var p in positionList)
            {
                if (p.X == pos.X && p.Y == pos.Y )
                {
                    positionList.Remove(p);
                    return true;
                }
            }
            return false;
        }

        public SortedPosList CloneList()
        {

            SortedPosList cloned = new SortedPosList();

            foreach (var item in positionList)
            {
                var newItem = item.Clone();
                cloned.positionList.Add(newItem);
            }


            return cloned;
        }


        public SortedPosList circleContent(Position centerPos, double radius)
        {


            SortedPosList withInCircleList = new SortedPosList();

            foreach (var item in positionList)
            {
                var dist = Math.Sqrt(Math.Pow(centerPos.X - item.X, 2) + Math.Pow(centerPos.Y - item.Y, 2));
                if (dist < radius)
                {
                    withInCircleList.Add(item);
                }
            }


            return withInCircleList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
        
            SortedPosList joinedList = new SortedPosList();
            joinedList = sp1.CloneList();


            foreach (var item in sp2.positionList)
            {
                joinedList.Add(item);
            }

            return joinedList;
        }

        public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList minimizedListed = new SortedPosList();
            minimizedListed = sp1.CloneList();

         
                foreach (var pos in sp2.positionList)
                {

                    minimizedListed.positionList.RemoveAll(item => item.X == pos.X && item.Y == pos.Y);
                 }

            return minimizedListed;
        }

    }
}



