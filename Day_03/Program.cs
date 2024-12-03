using System.Text.RegularExpressions;

namespace Day_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }

        static void PartOne()
        {
            var result = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                result += Calculate(input);

            }

            Console.WriteLine(result);
        }

        static void PartTwo()
        {
            var input = "";
            var result = 0;

            while (true)
            {
                var singleInput = Console.ReadLine();

                if (string.IsNullOrEmpty(singleInput))
                {
                    break;
                }

                input += singleInput;
                
            }

            var between = @"do\(\)(.*?)don't\(\)";

            var first = Regex.Match(input, @"(.*?)don't\(\)");

            var finded = Regex.Matches(input, between);

            result += Calculate(first);

            foreach (var f in finded)
            {
                result += Calculate(f);
            }

            Console.WriteLine(result);
        }

        static int Calculate(Object? finded)
        {
            var sum = 0;
            var pattern = @"mul\((\d+),(\d+)\)";
            var findedCommends = Regex.Matches(finded.ToString(), pattern);

            foreach (var f in findedCommends)
            {
                var numbers = Regex.Matches(f.ToString(), @"\d+");
                sum += (int.Parse(numbers[0].Value) * int.Parse(numbers[1].Value));
            }

            return sum;
        }
    }
}
