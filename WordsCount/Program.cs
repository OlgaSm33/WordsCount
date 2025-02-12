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

            var sortedByValue = wordsCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value); // сортируем по значениям

            Console.WriteLine("Десять наиболее часто встречающихся слов и их количество:");
            int count = 0;
            foreach (var item in sortedByValue)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
                count++;
                if (count == 10)
                {
                    break;
                }
            }
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
            //string newText = Regex.Replace(text, @"[^А-Яа-яЁё\s-]", ""); // второй вариант избавления от знаков препинания и прочих символов
            var newText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var words = newText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

    }
}
