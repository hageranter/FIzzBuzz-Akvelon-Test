using System.Text;

public class FizzBuzzDetector
{
    // Constraints: input not null, 7 <= length <= 100, only alphanumeric words count.
    public FizzBuzzResult getOverlappings(string input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));

        if (input.Length < 7 || input.Length > 100)
            throw new ArgumentException("Input length must be between 7 and 100 characters.", nameof(input));

        var output = new StringBuilder();
        int wordNumber = 0;
        int count = 0;

        for (int i = 0; i < input.Length; i++)
        {
            // Not part of a word: is a spaces or commas
            if (!IsWordChar(input[i]))
            {
                output.Append(input[i]);
                continue;
            }

            //  move i to its last character
            int start = i;
            for (; i + 1 < input.Length; i++)
            {
                char next = input[i + 1];

                if (IsWordChar(next))
                    continue;

                // Apostrophe inside a word, like "It's"  // I neeeded here to search for some syntax 
                if (next == '\'' && i + 2 < input.Length && IsWordChar(input[i + 2]))
                    continue;

                break;
            }

            // the replacment
            string word = input.Substring(start, i - start + 1);
            wordNumber++;

            if (wordNumber % 3 == 0 && wordNumber % 5 == 0)
            {
                output.Append("FizzBuzz");
                count++;
            }
            else if (wordNumber % 3 == 0)
            {
                output.Append("Fizz");
                count++;
            }
            else if (wordNumber % 5 == 0)
            {
                output.Append("Buzz");
                count++;
            }
            else
            {
                output.Append(word);
            }
        }

        return new FizzBuzzResult(output.ToString(), count);
    }

    private static bool IsWordChar(char c)
    {
        return (c >= 'a' && c <= 'z')
            || (c >= 'A' && c <= 'Z')
            || (c >= '0' && c <= '9');
    }
}