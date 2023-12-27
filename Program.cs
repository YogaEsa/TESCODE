class Program
{
    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("Choose mode:");
            Console.WriteLine("1. WeightedString");
            Console.WriteLine("2. HighestPalindrome");
            Console.WriteLine("3. BalancedBracket");
            Console.WriteLine("0. Exit");

            Console.Write("Enter mode (0, 1, 2, or 3): ");
            
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    WeightedString();
                    break;
                case 2:
                    HighestPalindrome();
                    break;
                case 3:
                    BalancedBracket();
                    break;

                case 0:
                    Console.WriteLine("Exiting program.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

        } while (choice != 0);

        Console.ReadLine();
    }

    #region WeightedString
    static void WeightedString()
    {
        Console.WriteLine("Enter a string (example : aabbccd):");
        string input = Console.ReadLine();

        List<string> substrings = GenerateDistinctSubstrings(input);
        List<int> intList = ConvertStringListToIntArray(substrings);

        Console.Write("Enter queries separated by comma (example: 1,3,4,5,6): ");
        string inputQueries = Console.ReadLine();
        string[] queriesString = inputQueries.Split(',');
        int[] queriesInt = ConvertStringArrayToIntArray(queriesString);

        string result = "[";

        foreach (var query in queriesInt)
        {
            result += intList.Contains(query) ? "Yes," : "No,";
        }

        result = result.TrimEnd(',') + "]";

        Console.WriteLine(result);
        Console.WriteLine("=================================="+ Environment.NewLine + Environment.NewLine);
    }

    static int[] ConvertStringArrayToIntArray(string[] stringArray)
    {
        int[] intArray = new int[stringArray.Length];

        for (int i = 0; i < stringArray.Length; i++)
        {
            if (int.TryParse(stringArray[i], out int result))
            {
                intArray[i] = result;
            }
            else
            {
                Console.WriteLine($"Invalid input: {stringArray[i]} is not a valid integer.");
            }
        }

        return intArray;
    }

    static List<string> GenerateDistinctSubstrings(string input)
    {
        HashSet<string> substrings = new HashSet<string>();

        for (int i = 0; i < input.Length; i++)
        {
            string currentSubstring = input[i].ToString();
            substrings.Add(currentSubstring);

            for (int j = i + 1; j < input.Length && input[j] == input[i]; j++)
            {
                currentSubstring += input[j];
                substrings.Add(currentSubstring);
            }
        }

        return new List<string>(substrings);
    }

    static List<int> ConvertStringListToIntArray(List<string> stringList)
    {
        Dictionary<char, int> charValues = new Dictionary<char, int>
        {
            {'a', 1}, {'b', 2}, {'c', 3}, {'d', 4}, {'e', 5}, {'f', 6}, {'g', 7}, {'h', 8}, {'i', 9},
            {'j', 10}, {'k', 11}, {'l', 12}, {'m', 13}, {'n', 14}, {'o', 15}, {'p', 16}, {'q', 17}, {'r', 18},
            {'s', 19}, {'t', 20}, {'u', 21}, {'v', 22}, {'w', 23}, {'x', 24}, {'y', 25}, {'z', 26}
        };

        List<int> intList = new();

        foreach (var charSequence in stringList)
        {
            int value = 0;

            foreach (char c in charSequence)
            {
                if (charValues.ContainsKey(c))
                {
                    value += charValues[c];
                }
            }

            intList.Add(value);
        }

        return intList.ToList();
    }

    #endregion



    #region HighestPalindrome
    static void HighestPalindrome()
    {
        Console.Write("Enter a string of digits: ");
        string input = Console.ReadLine();

        Console.Write("Enter the value of k: ");
        int k = int.Parse(Console.ReadLine());

        string highestPalindrome = FindHighestPalindrome(input, k);

        Console.WriteLine($"Highest Palindrome: {highestPalindrome}");

        Console.ReadLine();
        Console.WriteLine("=================================="+ Environment.NewLine + Environment.NewLine);
    }

    static string FindHighestPalindrome(string str, int k)
    {
        char[] charArray = str.ToCharArray();
        return FindPalindrome(charArray, 0, charArray.Length - 1, k) ? new string(charArray) : "-1";
    }

    static bool FindPalindrome(char[] charArray, int left, int right, int k)
    {
        if (left >= right)
        {
            return true;
        }

        if (charArray[left] != charArray[right])
        {
            charArray[left] = charArray[right] = (char)Math.Max(charArray[left], charArray[right]);
            k--;

            if (k < 0)
            {
                return false;
            }
        }

        return FindPalindrome(charArray, left + 1, right - 1, k);
    }

    #endregion



    #region BalancedBracket
    static void BalancedBracket()
    {
        Console.Write("Enter a string with parentheses: ");
        string input = Console.ReadLine();

        bool isValid = IsValidParentheses(input);

        Console.WriteLine(isValid ? "YES" : "NO");
        Console.WriteLine("=================================="+ Environment.NewLine + Environment.NewLine);
    }
    static bool IsValidParentheses(string input)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in input)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (c == ')' && (stack.Count == 0 || stack.Pop() != '('))
            {
                return false;
            }
            else if (c == ']' && (stack.Count == 0 || stack.Pop() != '['))
            {
                return false;
            }
            else if (c == '}' && (stack.Count == 0 || stack.Pop() != '{'))
            {
                return false;
            }
        }

        return stack.Count == 0;
    }
    #endregion
}
