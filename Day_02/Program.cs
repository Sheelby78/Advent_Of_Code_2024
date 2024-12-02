namespace Day_02
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
            var numbers = new List<List<int>>();
            var bad = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                var row = input.Split(" ").Select(int.Parse).ToList();
                numbers.Add(row);

                if(!isGood(row))
                {
                    bad++;
                }
            }
            Console.WriteLine(numbers.Count() - bad);
        }

        static void PartTwo()
        {
            var numbers = new List<List<int>>();
            var bad = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                var row = input.Split(" ").Select(int.Parse).ToList();
                numbers.Add(row);


                if (!isGood(row))
                {
                    var anyGood = false;
                    var temp = new List<List<int>>();

                    for (int i = row.Count(); i != 0; i--)
                    {
                        var temp2 = new List<int>();
                        temp2.AddRange(row);
                        temp2.RemoveAt(i - 1);
                        temp.Add(temp2);
                    }

                    foreach (var x in temp)
                    {
                        if (isGood(x))
                        {
                            anyGood = true;
                            break;
                        }
                    }
                    if (!anyGood)
                    {
                        bad++;
                    }
                }
            }
            Console.WriteLine(numbers.Count() - bad);
        }

        static bool isGood(List<int> row)
        {
            if (row.SequenceEqual(row.OrderByDescending(x => x)) || row.SequenceEqual(row.OrderBy(x => x)))
            {
                for (int i = 0; i < row.Count() - 1; i++)
                {
                    var temp = Math.Abs(row[i] - row[i + 1]);

                    if (temp > 3 || temp == 0)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
