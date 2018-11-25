using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetRecruit
{
    [TestFixture]
    class AnagramServiceTest
    {

        [TestCase]
        public void SortList()
        {
            AnagramService anagramService = new AnagramService();
            var localPath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
            var dictionaryLocation = Path.Combine(localPath, "testInput.txt");
            IList<AnagramCounter> results = anagramService.Compute(dictionaryLocation).ToList();

            Assert.AreEqual(0, results[0].Count);
            Assert.AreEqual(0, results[1].Count);
            Assert.AreEqual(0, results[2].Count);
            Assert.AreEqual(0, results[3].Count);
            Assert.AreEqual(0, results[4].Count);
            Assert.AreEqual(0, results[5].Count);
            Assert.AreEqual(0, results[6].Count);
            Assert.AreEqual(0, results[7].Count);
            Assert.AreEqual(2, results[8].Count);
            Assert.AreEqual(0, results[9].Count);
        }
    }
}
