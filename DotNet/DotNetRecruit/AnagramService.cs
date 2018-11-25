namespace DotNetRecruit
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class AnagramService
    {
        public IEnumerable<AnagramCounter> Compute(string dictionaryLocation)
        {
            //var words = File.ReadAllLines(dictionaryLocation);

            var wordListsByLength = ReadAllSortedLinesToLengthLists(dictionaryLocation);

           /*
            foreach (var word in wordListsByLength[3])
            {
                Console.WriteLine("saved word: {0}", word);
            }*/

            //var input = Console.ReadLine();

            var anagramCounter = new List<AnagramCounter>
                       {
                           new AnagramCounter { WordLength = 1, Count = SimpleAnagramCounter(wordListsByLength[0]) },
                           new AnagramCounter { WordLength = 2, Count = SimpleAnagramCounter(wordListsByLength[1]) },
                           new AnagramCounter { WordLength = 3, Count = SimpleAnagramCounter(wordListsByLength[2]) },
                           new AnagramCounter { WordLength = 4, Count = SimpleAnagramCounter(wordListsByLength[3]) },
                           new AnagramCounter { WordLength = 5, Count = SimpleAnagramCounter(wordListsByLength[4]) },
                           new AnagramCounter { WordLength = 6, Count = SimpleAnagramCounter(wordListsByLength[5]) },
                           new AnagramCounter { WordLength = 7, Count = SimpleAnagramCounter(wordListsByLength[6]) },
                           new AnagramCounter { WordLength = 8, Count = SimpleAnagramCounter(wordListsByLength[7]) },
                           new AnagramCounter { WordLength = 9, Count = SimpleAnagramCounter(wordListsByLength[8]) },
                           new AnagramCounter { WordLength = 10, Count = SimpleAnagramCounter(wordListsByLength[9]) }
                       };


            return anagramCounter;
        }


        private List<List<string>> ReadAllSortedLinesToLengthLists(string dictionaryLocation)
        {
            var ListOfWordLists = new List<List<string>>();
            string currentTextLine;

            for (int i = 0; i < 10; i++)
            {
                var wordList = new List<string>();
                ListOfWordLists.Add(wordList);
            }

            var filestream = new System.IO.FileStream(dictionaryLocation,
                                          System.IO.FileMode.Open,
                                          System.IO.FileAccess.Read,
                                          System.IO.FileShare.ReadWrite);
            var file = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);


            while ((currentTextLine = file.ReadLine()) != null)
            {
                if (0 < currentTextLine.Length && currentTextLine.Length < 11)
                {
                    ListOfWordLists[currentTextLine.Length - 1].Add(String.Concat(currentTextLine.OrderBy(c => c)));
                }
            }

          /*  Console.WriteLine("single element at position 3 3 {0}", ListOfWordLists[3][3]);
            Console.WriteLine("checking all entries in list before passing back", ListOfWordLists[3][3]);
            foreach (var word in ListOfWordLists[3])
            {
                Console.WriteLine(word);
            }*/

            return ListOfWordLists;
        }
        
        
       private int SimpleAnagramCounter(/*AnagramCounter results,*/ List<string> wordList)
       {
            int resultsCount = 0;
            var orderedA = "";
            for (int i = 0; i < wordList.Count - 1; i++)
            {
                if (wordList[i] != null)
                {
                    orderedA = wordList[i];
                    for (int j = i + 1; j < wordList.Count; j++)
                    {
                        //Second if statement condition should only be evaluated if the first doesnt fail

                        //Console.WriteLine("Comparing {0} -> {1}", orderedA, wordList[j]);
                        if (wordList[j] != null && orderedA.SequenceEqual(wordList[j]))
                        {
                            //Console.WriteLine("Match!! {0} -> {1}", orderedA, wordList[j]);
                            //Console.WriteLine("result count: {0}", results.Count);
                            resultsCount++;
                            wordList[j] = null;
                        }
                        
                    }
                }
            }

            return resultsCount;
       }


        //Simple approach using LINQ and lambda functions to check if two strings are equal.
        private bool IsAnagramSimple(string a, string b)
        {
            return a.OrderBy(c => c).SequenceEqual(b.OrderBy(c => c));
        }

        //Method which builds up a dictionary for an entry. May be faster if the dictionary value is stored instead of reprocessed
        private Dictionary<char, int> CalculateFrequency(string input)
        {
            var frequency = new Dictionary<char, int>();
            foreach (var c in input)
            {
                if (!frequency.ContainsKey(c))
                {
                    frequency.Add(c, 0);
                }
                ++frequency[c];
            }
            return frequency;
        }
    }
}
