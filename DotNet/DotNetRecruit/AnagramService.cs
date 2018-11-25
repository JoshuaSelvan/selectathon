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

            var wordListsByLength = ReadAllLinesToLengthLists(dictionaryLocation);

          

           
            foreach (var word in wordListsByLength[3])
            {
                Console.WriteLine("saved word: {0}", word);
            }

            var input = Console.ReadLine();


            return new List<AnagramCounter>
                       {
                           new AnagramCounter { WordLength = 1, Count = 0 },
                           new AnagramCounter { WordLength = 2, Count = 0 },
                           new AnagramCounter { WordLength = 3, Count = 0 },
                           new AnagramCounter { WordLength = 4, Count = 0 },
                           new AnagramCounter { WordLength = 5, Count = 0 },
                           new AnagramCounter { WordLength = 6, Count = 0 },
                           new AnagramCounter { WordLength = 7, Count = 0 },
                           new AnagramCounter { WordLength = 8, Count = 0 },
                           new AnagramCounter { WordLength = 9, Count = 0 },
                           new AnagramCounter { WordLength = 10, Count = 0 }
                       };
        }


        private List<List<string>> ReadAllLinesToLengthLists(string dictionaryLocation)
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
                //Console.WriteLine(currentTextLine);
                //Console.WriteLine(currentTextLine.Length);
                if (0 < currentTextLine.Length && currentTextLine.Length < 11)
                {
                    //Console.WriteLine(currentTextLine);
                    ListOfWordLists[currentTextLine.Length - 1].Add(currentTextLine);
                }
            }

            Console.WriteLine("single element at position 3 3 {0}", ListOfWordLists[3][3]);
            Console.WriteLine("checking all entries in list before passing back", ListOfWordLists[3][3]);
            foreach (var word in ListOfWordLists[3])
            {
                Console.WriteLine(word);
            }

            return ListOfWordLists;
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
