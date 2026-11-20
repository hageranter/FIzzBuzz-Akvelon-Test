string input =
    "Mary had a little lamb\n" +
    "Little lamb, little lamb\n" +
    "Mary had a little lamb\n" +
    "It's fleece was white as snow";

var detector = new FizzBuzzDetector();
FizzBuzzResult result = detector.getOverlappings(input);

Console.WriteLine("output string:");
Console.WriteLine(result.Output);
Console.WriteLine();
Console.WriteLine($"count: {result.Count}");
