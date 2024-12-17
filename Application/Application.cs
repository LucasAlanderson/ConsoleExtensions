using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ConsoleExtensions.Application
{
    public class Application
    {
        public static void run(string format, params object[] args)
        {
            int argIndex = 0;
            string result = Regex.Replace(format, @"%(\.\d+)?[sd]|%(\.\d+)f", match =>
            {
                string specifier = match.Value;
                string replacement = string.Empty;

                if (specifier.Contains("s"))
                    replacement = args[argIndex]?.ToString();
                else if (specifier.Contains("d"))
                    replacement = Convert.ToInt32(args[argIndex]).ToString(CultureInfo.InvariantCulture);
                else if (specifier.Contains("f"))
                {
                    if (specifier.StartsWith("%."))
                    {
                        int precision = int.Parse(specifier[2..^1]);
                        replacement = Convert.ToDouble(args[argIndex]).ToString($"F{precision}", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        replacement = Convert.ToDouble(args[argIndex]).ToString("F", CultureInfo.InvariantCulture);
                    }
                }

                argIndex++;
                return replacement;
            });

            Console.Write(result);
        }

        public static void runln(object arg)
        {
            Console.WriteLine(arg);
        }

        public static void runln(string format, params object[] args)
        {
            run(format, args);
            Console.WriteLine();
        }

        public static void runln()
        {
            Console.WriteLine();
        }
    }
}

