namespace QuickXorHash.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Contains("/?") || args.Contains("--help"))
            {
                PrintUsage();
                return;
            }

            string inputFile = null;
            string expectedHash = null;
            bool compareHash = false;
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                // remove both the hyphen and forward slash prefixes, if present
                arg = arg.TrimStart('-', '/');
                if (arg.Equals("file", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                {
                    inputFile = args[i + 1];
                    // skip the file path argument
                    i++;
                }
                else if (arg.Equals("expected-hash", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                {
                    expectedHash = args[i + 1];
                    // skip the expected hash argument
                    i++;
                    compareHash = true;
                }
            }

            if (inputFile == null)
            {
                Console.WriteLine("Please specify the input file using --file or /file <file_path>");
                return;
            }

            string calculatedHash = QuickXorHashHelper.CalculateHash(inputFile);
            Console.WriteLine("Calculated Hash: " + calculatedHash);

            if (compareHash)
            {
                if (calculatedHash == expectedHash)
                {
                    Console.WriteLine("Hashes match.");
                }
                else
                {
                    Console.WriteLine("Hashes do not match.");
                }
            }
        }

        static void PrintUsage()
        {
            Console.WriteLine("Usage: QuickXorHash.exe [--file <file_path>] [--expected-hash <expected_hash>]");
            Console.WriteLine("Options:");
            Console.WriteLine("  --file or /file     Specify the input file.");
            Console.WriteLine("  --expected-hash or /expected-hash");
            Console.WriteLine("                      Specify the expected hash for comparison.");
            Console.WriteLine("  --help or /?         Display this usage information.");
        }
    }
}
