using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruityMatch
{
    public class AutomaticGame
    {



        public List<String> combinations { get; set; }
        public List<String> combinationsForDelete { get; set; }
        public String playerCombination { get; set; }
        public List<Fruit> fruitCombination { get; set; }
        public String previousComb { get; set; }
        public bool isFirstCombination { get; set; }
        public static readonly Dictionary<Fruit.TYPE, string> fruitToString = new Dictionary<Fruit.TYPE, string>()
            {
                { Fruit.TYPE.ORANGE, "1" },
                { Fruit.TYPE.WATERMELON, "2" },
                { Fruit.TYPE.PLUM, "3" },
                { Fruit.TYPE.LEMON, "4" },
                { Fruit.TYPE.APPLE, "5" },
                { Fruit.TYPE.PEACH, "6" }
            };
        public static readonly Dictionary<char, string> charToFruit = new Dictionary<char, string>()
            {
                //{'1', new Orange(Form1.getRatioX(35), Form1.getRatioY(35),0,0) },
                //{'2', new Watermelon(Form1.getRatioX(35), Form1.getRatioY(35),0,0) },
                //{'3', new Plum(Form1.getRatioX(35), Form1.getRatioY(35),0,0) },
                //{'4', new Lemon(Form1.getRatioX(35), Form1.getRatioY(35),0,0) },
                //{'5', new Apple(Form1.getRatioX(35), Form1.getRatioY(35),0,0) },
                //{'6', new Peach(Form1.getRatioX(35), Form1.getRatioY(35),0,0) },
                {'1', "orange" },
                {'2', "watermelon" },
                {'3', "plum" },
                {'4', "lemon" },
                {'5', "apple" },
                {'6', "peach" },



        };
        public AutomaticGame()
        {

            fruitCombination = new List<Fruit>();
            isFirstCombination = true;
            previousComb = "";
            
            combinations = new List<String>();
            combinationsForDelete = new List<String>();
            initializeList();
            //play();
        }

        public void setCombination(List<Fruit> FruitCombination)
        {
            fruitCombination = FruitCombination;
            playerCombination = getStringOfFruits(FruitCombination);

            

        }

        public static String getStringOfFruits(List<Fruit> FruitCombination)
        {
            String s = "";
            foreach (Fruit f in FruitCombination)
            {
                s += fruitToString[f.type];
            }
            return s;
        }

        public List<Fruit> nextCombination()
        {
            if(isFirstCombination)
            {
                previousComb = generateRandomCombination(false);
                isFirstCombination = false;
                //MessageBox.Show(previousComb);
            }
            else
            {
                String result = Match(previousComb, playerCombination);
                deleteImpossible(result, previousComb);
                previousComb = nextCombinationByMinMax();
                //MessageBox.Show(previousComb);
            }
            return getFruitList(previousComb);
        }

        public void deleteImpossible(String result, string combination)
        {
            List<String> removed = new List<string>();
            foreach (String comb in combinationsForDelete)
            {
                // if comb was the real combination it should give the same result
                if (Match(combination, comb) != result)
                {
                    removed.Add(comb);
                }
            }
            combinationsForDelete.RemoveAll(a => removed.Contains(a));
        }
        public int countImpossible(String result, string combination)
        {
            int counter = 0;
            foreach (String comb in combinationsForDelete)
            {
                // if comb was the real combination it should give the same result
                if (Match(combination, comb) != result)
                {
                    counter++;
                }
            }
            return counter;
        }


        public String Match(String code, String playerCombination)
        {

            int counterPlaces = 0, counterFruitsOnly = 0;
            List<Char> guessCode = new List<Char>()
            {
                code[0],
                code[1],
                code[2],
                code[3]
            };

            List<Char> trueCode = new List<Char>()
            {
                playerCombination[0],
                playerCombination[1],
                playerCombination[2],
                playerCombination[3]
            };


            for (int i = 0; i < 4; i++)
            {
                char gC = guessCode[i];
                char tC = trueCode[i];

                if (gC == tC)
                {
                    counterPlaces++;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                char tC = trueCode[i];
                for (int j = 0; j < guessCode.Count; j++)
                {
                    char gC = guessCode[j];
                    if (tC == gC)
                    {
                        counterFruitsOnly++;
                        guessCode.RemoveAt(j);
                        break;
                    }
                }
            }
            counterFruitsOnly = counterFruitsOnly - counterPlaces;
            return counterPlaces.ToString() + counterFruitsOnly.ToString();

        }

        public static bool containsDigit(int number, int digit)
        {
            while (number > 0)
            {
                int c = number % 10;
                if (c == digit) return true;
                number /= 10;
            }
            return false;
        }

        public static bool checkAllDigitsDifferent(int number)
        {
            HashSet<int> setOfDigits = new HashSet<int>();
            while(number > 0)
            {
                int c = number % 10;
                setOfDigits.Add(c);
                number /= 10;
            }
            return setOfDigits.Count() == 4;
        }

        public static String generateRandomCombination(bool allDifferent)
        {
            List<String> combList = new List<string>();
            List<String> combListDifferent = new List<string>();
            for (int i = 1111; i < 6666; i++)
            {
                if (!containsDigit(i, 0) && !containsDigit(i, 7) && !containsDigit(i, 8) && !containsDigit(i, 9))
                {
                    if(allDifferent)
                    {
                        if(checkAllDigitsDifferent(i))
                        {
                            combList.Add(i.ToString());
                        }
                    } else
                    {
                        combList.Add(i.ToString());
                    }
                }
            }
            Random rand = new Random();
            int ind = rand.Next(0, combList.Count() - 1);

            return combList[ind];
        }

        public static List<Fruit> getFruitList(String s)
        {
            List<Fruit> lista = new List<Fruit>();

            for(int i=0; i<4; i++)
            {
                char c = s[i];
                switch (c)
                {
                    case '1':
                        lista.Add(new Orange(Form1.getRatioX(35), Form1.getRatioY(35), 0, 0));
                        break;
                    case '2':
                        lista.Add(new Watermelon(Form1.getRatioX(35), Form1.getRatioY(35), 0, 0));
                        break;
                    case '3':
                        lista.Add(new Plum(Form1.getRatioX(35), Form1.getRatioY(35), 0, 0));
                        break;
                    case '4':
                        lista.Add(new Lemon(Form1.getRatioX(35), Form1.getRatioY(35), 0, 0));
                        break;
                    case '5':
                        lista.Add(new Apple(Form1.getRatioX(35), Form1.getRatioY(35), 0, 0));
                        break;
                    case '6':
                        lista.Add(new Peach(Form1.getRatioX(35), Form1.getRatioY(35), 0, 0));
                        break;
                }
            }
            return lista;

        }

        public void play()
        {
            initializeList();
            String firstComb = generateRandomCombination(false);
            while (firstComb != playerCombination)
            {
                String result = Match(firstComb, playerCombination);
                deleteImpossible(result, firstComb);
                firstComb = nextCombinationByMinMax();
                //MessageBox.Show(firstComb);
            }
        }

        public void initializeList()
        {
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    for (int k = 1; k <= 6; k++)
                    {
                        for (int l = 1; l <= 6; l++)
                        {
                            String s = i.ToString() + j.ToString() + k.ToString() + l.ToString();
                            combinations.Add(s);
                            combinationsForDelete.Add(s);
                        }
                    }
                }
            }
        }

        public String nextCombinationByMinMax()
        {
            Dictionary<int, String> score = new Dictionary<int, String>();
            foreach (String s in combinationsForDelete)
            {
                List<int> numberOfImpossibles = new List<int>();
                numberOfImpossibles.Add(countImpossible("00", s));
                numberOfImpossibles.Add(countImpossible("10", s));
                numberOfImpossibles.Add(countImpossible("01", s));
                numberOfImpossibles.Add(countImpossible("11", s));
                numberOfImpossibles.Add(countImpossible("20", s));
                numberOfImpossibles.Add(countImpossible("02", s));
                numberOfImpossibles.Add(countImpossible("03", s));
                numberOfImpossibles.Add(countImpossible("04", s));
                numberOfImpossibles.Add(countImpossible("40", s));
                numberOfImpossibles.Add(countImpossible("22", s));
                numberOfImpossibles.Add(countImpossible("21", s));
                numberOfImpossibles.Add(countImpossible("12", s));
                numberOfImpossibles.Add(countImpossible("30", s));
                numberOfImpossibles.Add(countImpossible("13", s));

                numberOfImpossibles.Sort();


                score[numberOfImpossibles.Min()] = s;
            }
            int maxValue = score.Keys.Max();
            return score[maxValue];

        }


    }
}
