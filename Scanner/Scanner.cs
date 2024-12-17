using System;
using System.Globalization;

namespace ConsoleExtensions.Scanner
{
    public enum InputMode
    {
        In
    }

    public class Scanner
    {
        private readonly InputMode _mode;
        private string[] _tokens;
        private int _currentIndex;

        public Scanner(InputMode mode)
        {
            _mode = mode;
            _tokens = Array.Empty<string>();
            _currentIndex = 0;
        }

        public string nextLine()
        {
            ensureInputModeValid();
            _currentIndex = 0;
            return Console.ReadLine();
        }

        public string next()
        {
            ensureInputModeValid();
            ensureTokensAvailable();
            return _tokens[_currentIndex++];
        }

        public int nextInt()
        {
            return int.Parse(next(), CultureInfo.InvariantCulture);
        }

        public double nextDouble()
        {
            return double.Parse(next(), CultureInfo.InvariantCulture);
        }

        public bool nextBoolean()
        {
            string token = next().ToLower();
            return token == "true" || token == "1";
        }

        public bool hasNext()
        {
            ensureInputModeValid();
            ensureTokensAvailable();
            return _currentIndex < _tokens.Length;
        }

        private void ensureTokensAvailable()
        {
            if (_tokens.Length == 0 || _currentIndex >= _tokens.Length)
            {
                string line = Console.ReadLine();
                if (line != null)
                {
                    _tokens = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    _currentIndex = 0;
                }
                else
                {
                    throw new InvalidOperationException("entrada não disponível.");
                }
            }
        }

        private void ensureInputModeValid()
        {
            if (_mode != InputMode.In)
                throw new NotSupportedException($"o modo de entrada '{_mode}' não é suportado.");
        }
    }
}

