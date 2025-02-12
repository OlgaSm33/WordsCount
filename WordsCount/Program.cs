using System.Text.RegularExpressions;

namespace WordsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\VS\\WordsCount\\input.txt";

            string text = File.ReadAllText(filePath);
            var words = TextWords(text);
            var wordsCount = WordsCount(words);

            var sortedKeys = wordsCount.Keys.ToList();
            sortedKeys.Sort();
            int mx = 0;
            string mxWord = string.Empty;
            foreach (var word in sortedKeys)
            {
                if (wordsCount[word] > mx)
                {
                    mx = wordsCount[word];
                    mxWord = word;
                }
                //Console.WriteLine(word + " " + wordsCount[word]);
            }

            Console.WriteLine($"Чаще всего встречается слово: {mxWord}");
            Console.WriteLine($"Количество появлений в слове: {mx}");

        }

        /// <summary>
        /// метод возвращает словарь, в котором ключи - слова
        /// а значения - количество их повторений
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static Dictionary<string, int> WordsCount(string[] words)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
                else
                {
                    wordsCount.Add(word, 1);
                }
            }
            return wordsCount;
            
        }

        /// <summary>
        /// метод возвращает список слов, находящихся в строке
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string[] TextWords(string text)
        {
            string newText = Regex.Replace(text, @"[^А-Яа-яЁё\s-]", "");
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var words = newText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

    }
}
