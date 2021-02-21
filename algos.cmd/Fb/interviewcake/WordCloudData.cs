/*

You want to build a word cloud, an infographic where the size of a word corresponds to how often it appears in the body of text.

To do this, you'll need data. Write code that takes a long string and builds its word cloud data in a dictionary ↴ , where the keys are words and the values are the number of times the words occurred.

Think about capitalized words. For example, look at these sentences:

  "After beating the eggs, Dana read the next step:"
"Add milk and eggs, then add flour and sugar."
What do we want to do with "After", "Dana", and "add"? In this example, your final dictionary should include one "Add" or "add" with a value of 22. Make reasonable (not necessarily perfect) decisions about cases like "After" and "Dana".

Assume the input will only contain words and standard punctuation.

You could make a reasonable argument to use regex in your solution. We won't, mainly because performance is difficult to measure and can get pretty bad.
*/


using System.Collections.Generic;
using NUnit.Framework;

namespace algos.Fb
{
    [TestFixture]
    public class WordCloudData
    {
        private Dictionary<string, int> _wordsToCounts = new Dictionary<string, int>();

        public IDictionary<string, int> WordsToCounts
        {
            get { return _wordsToCounts; }
        }

        public WordCloudData(string inputString)
        {
            PopulateWordsToCounts(inputString);
        }

        private void PopulateWordsToCounts(string inputString)
        {
            // Count the frequency of each word


        }



        // Tests

        // There are lots of valid solutions for this one. You
        // might have to edit some of these tests if you made
        // different design decisions in your solution.

        [Test]
        public void SimpleSentenceTest()
        {
            var text = "I like cake";
            var expected = new Dictionary<string, int>() { { "I", 1 }, { "like", 1 }, { "cake", 1 } };
            var actual = new WordCloudData(text);
            Assert.AreEqual(expected, actual.WordsToCounts);
        }

        [Test]
        public void LongerSentenceTest()
        {
            var text = "Chocolate cake for dinner and pound cake for dessert";
            var expected = new Dictionary<string, int>() { { "and", 1 }, { "pound", 1 }, { "for", 2 },
            { "dessert", 1 }, { "Chocolate", 1 }, { "dinner", 1 }, { "cake", 2 } };
            var actual = new WordCloudData(text);
            Assert.AreEqual(expected, actual.WordsToCounts);
        }

        [Test]
        public void PunctuationTest()
        {
            var text = "Strawberry short cake? Yum!";
            var expected = new Dictionary<string, int>() { { "cake", 1 }, { "Strawberry", 1 },
            { "short", 1 }, { "Yum", 1 } };
            var actual = new WordCloudData(text);
            Assert.AreEqual(expected, actual.WordsToCounts);
        }

        [Test]
        public void HyphenatedWordsTest()
        {
            var text = "Dessert - mille-feuille cake";
            var expected = new Dictionary<string, int>() { { "cake", 1 }, { "Dessert", 1 },
            { "mille-feuille", 1 } };
            var actual = new WordCloudData(text);
            Assert.AreEqual(expected, actual.WordsToCounts);
        }

        [Test]
        public void EllipsesBetweenWordsTest()
        {
            var text = "Mmm...mmm...decisions...decisions";
            var expected = new Dictionary<string, int>() { { "mmm", 2 }, { "decisions", 2 } };
            var actual = new WordCloudData(text);
            Assert.AreEqual(expected, actual.WordsToCounts);
        }

        [Test]
        public void ApostrophesTest()
        {
            var text = "Allie's Bakery: Sasha's Cakes";
            var expected = new Dictionary<string, int>() { { "Bakery", 1 }, { "Cakes", 1 },
            { "Allie's", 1 }, { "Sasha's", 1 } };
            var actual = new WordCloudData(text);
            Assert.AreEqual(expected, actual.WordsToCounts);
        }
    }

}
















