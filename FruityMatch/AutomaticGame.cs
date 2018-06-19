using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class AutomaticGame
    {
        public List<int> possibleOrange { get; set; }
        public List<int> possibleWatermelon { get; set; }
        public List<int> possiblePlum { get; set; }
        public List<int> possibleLemon { get; set; }
        public List<int> possibleApple { get; set; }
        public List<int> possiblePeach { get; set; }
        public List<int> sure { get; set; }
        public List<int> sureNo { get; set; }

        public static readonly List<Tuple<int, Tuple<int, int>>> statCombs =
            new List<Tuple<int, Tuple<int, int>>>()
            {
                Tuple.Create(0, new Tuple<int, int>(0, 0)),
                Tuple.Create(1, new Tuple<int, int>(0, 1)),
                Tuple.Create(2, new Tuple<int, int>(0, 2)),
                Tuple.Create(3, new Tuple<int, int>(1, 0)),
                Tuple.Create(4, new Tuple<int, int>(1, 1)),
                Tuple.Create(5, new Tuple<int, int>(2, 0)),

            };
        public LinkedList<Tuple<int, int>> statistics { get; set; }
        List<Fruit> combination { get; set; }
        public AutomaticGame()
        {
            possibleOrange = new List<int>() { 0, 1, 2, 3, 4, 5 };
            possibleWatermelon = new List<int>() { 0, 1, 2, 3, 4, 5 };
            possiblePlum = new List<int>() { 0, 1, 2, 3, 4, 5 };
            possibleLemon = new List<int>() { 0, 1, 2, 3, 4, 5 };
            possibleApple = new List<int>() { 0, 1, 2, 3, 4, 5 };
            possiblePeach = new List<int>() { 0, 1, 2, 3, 4, 5 };
            sure = new List<int>();
            sureNo = new List<int>();
            statistics = new LinkedList<Tuple<int, int>>();
            this.combination = new List<Fruit>();
        }

        public void addCombination(List<Fruit> combination)
        {
            foreach(Fruit f in combination)
            {
                this.combination.Add(f);
            }
        }

        public Tuple<int, int> countCorrect(LittlePlates plates, int pos)
        {
            int counterPlaces = 0, counterFruitsOnly = 0;
            List<Fruit> copy = new List<Fruit>();

            List<LittlePlate> littlePlates = plates.plates[pos];

            foreach (Fruit f in combination)
            {
                copy.Add(f);
            }
            for (int i = 0; i < 4; i++)
            {
                Fruit f1 = copy.ElementAt(i);
                Fruit f2 = littlePlates.ElementAt(i).fruitOn;

                if (f1.type == f2.type)
                {
                    counterPlaces++;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Fruit f2 = littlePlates.ElementAt(i).fruitOn;

                for (int j = 0; j < copy.Count; j++)
                {
                    Fruit f1 = copy.ElementAt(j);
                    if (f1.type == f2.type)
                    {
                        counterFruitsOnly++;
                        copy.RemoveAt(j);
                        break;
                    }
                }
            }
            counterFruitsOnly = counterFruitsOnly - counterPlaces;
            return Tuple.Create(counterPlaces, counterFruitsOnly);
        }

        public void guessCombination2_2(LittlePlates plates)
        {
            if (plates.activeRow == 0)
            {
                List<LittlePlate> firstRow = plates.plates[0];
                int counter = 0;
                foreach (LittlePlate lp in firstRow)
                {
                    Fruit fruit = null;
                    //int pos = rand.Next(0, 6);
                    switch (counter)
                    {
                        case 0:
                        case 1:
                            fruit = new Orange(35, 35, 0, 0); break;
                        case 2:
                        case 3:
                            fruit = new Watermelon(35, 35, 0, 0); break;
                    }
                    counter++;
                    fruit.MoveTo(lp.position.X, lp.position.Y);
                    lp.fruitOn = fruit;
                    //Thread.Sleep(500);
                }
                Tuple<int, int> colors_places = countCorrect(plates, 0);

                foreach(Tuple<int, Tuple<int, int>> t in statCombs)
                {
                    if (colors_places.Equals(t.Item2))
                    {
                        guessSecondStep(t.Item1);
                    }
                }
                
            }
        }

        public void guessSecondStep(int id)
        {
            switch (id)
            {
                case 0: guessSecondStep00(); break;
                //case 1: guessSecondStep01(); break;
                //case 2: guessSecondStep02(); break;
                //case 3: guessSecondStep10(); break;
                //case 4: guessSecondStep11(); break;
                //case 5: guessSecondStep20(); break;
            }
        }

        public void guessSecondStep00()
        {

        }
    }
}
