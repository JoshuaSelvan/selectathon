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

            var wordListsByLength = ReadAllSortedLinesToLengthLists(dictionaryLocation);
            SortWordLists(ref wordListsByLength);

            var anagramCounter = new List<AnagramCounter>
                       {
                           new AnagramCounter { WordLength = 1, Count = AnagramCounterOnSortedList(wordListsByLength[0]) },
                           new AnagramCounter { WordLength = 2, Count = AnagramCounterOnSortedList(wordListsByLength[1]) },
                           new AnagramCounter { WordLength = 3, Count = AnagramCounterOnSortedList(wordListsByLength[2]) },
                           new AnagramCounter { WordLength = 4, Count = AnagramCounterOnSortedList(wordListsByLength[3]) },
                           new AnagramCounter { WordLength = 5, Count = AnagramCounterOnSortedList(wordListsByLength[4]) },
                           new AnagramCounter { WordLength = 6, Count = AnagramCounterOnSortedList(wordListsByLength[5]) },
                           new AnagramCounter { WordLength = 7, Count = AnagramCounterOnSortedList(wordListsByLength[6]) },
                           new AnagramCounter { WordLength = 8, Count = AnagramCounterOnSortedList(wordListsByLength[7]) },
                           new AnagramCounter { WordLength = 9, Count = AnagramCounterOnSortedList(wordListsByLength[8]) },
                           new AnagramCounter { WordLength = 10, Count = AnagramCounterOnSortedList(wordListsByLength[9]) }
                       };

            return anagramCounter;
        }


        //Reads in the words from the file and presorts them into alphabetical order
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

        //Sorts a list of words by alphabetical order
        private void SortWordLists(ref List<List<string>> listSet)
        {
            foreach (var list in listSet)
            {
                list.Sort();
            }
        }

        //Counts the number of identical words in a sorted list with a single runthrough
        private int AnagramCounterOnSortedList(List<string> wordList)
        {
            int resultCount = 0;
            if (wordList.Count > 0)
            {
                var currentEntry = wordList[0];
                for (int i = 1; i < wordList.Count; i++)
                {
                    if (currentEntry.SequenceEqual(wordList[i]) != true)
                        currentEntry = wordList[i];
                    else
                        resultCount++;
                }
            }
            return resultCount;
        }


    }
}
