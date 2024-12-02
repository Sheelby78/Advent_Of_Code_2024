namespace Day_01
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
            var sum1 = new List<int>();
            var sum2 = new List<int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                string[] parts = input.Split("   ");

                if (int.TryParse(parts[0], out int num1) && int.TryParse(parts[1], out int num2))
                {
                    sum1.Add(num1);
                    sum2.Add(num2);
                }
            }
            var result = new List<int>();
            sum1 = sum1.OrderByDescending(x => x).ToList();
            sum2 = sum2.OrderByDescending(x => x).ToList();

            for (int i = 0; i < sum1.Count; i++)
            {
                result.Add(Math.Abs(sum1[i] - sum2[i]));
            }

            Console.WriteLine(result.Sum());
        }

        static void PartTwo()
        {
            var list1 = new List<int>();
            var list2 = new Dictionary<int, int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                string[] parts = input.Split("   ");

                if (int.TryParse(parts[0], out int num1) && int.TryParse(parts[1], out int num2))
                {
                    list1.Add(num1);
                    if (list2.ContainsKey(num2))
                    {
                        list2[num2]++;
                    }
                    else
                    {
                        list2.Add(num2, 1);
                    }
                }
            }
            var result = 0;

            foreach (var x in list1)
            {
                 if (list2.ContainsKey(x))
                {
                    result += (list2[x] * x);
                }
            }
            Console.WriteLine(result);

        }
    }
}
