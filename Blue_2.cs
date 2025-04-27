using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _sequence;
        public string Output => _output;

        public Blue_2(string input, string sequence) : base(input)
        {
            _sequence = sequence;
            _output = null;
        }

        private (int, int) FindWord(string s, string seq)
        {
            // найти с конца слово
            if (s.Length < seq.Length) return (-1, -1);

            int begin = -1, end = -1;


            for (int i = s.Length - seq.Length; i >= 0; i--)
            {
                if (s.Substring(i, seq.Length) == seq)
                {
                    begin = i;
                    end = i + seq.Length - 1;

                    // нахождение индексов самого слова

                    while (begin > 0 && char.IsLetter(s[begin - 1]))
                        begin--;

                    while (end + 1 < s.Length && char.IsLetter(s[end + 1]))
                        end++;

                    break;
                }
            }

            return (begin, end);
        }

        private string Delete(string s, int begin, int end)
        {
            // бегин - начало слова
            // енд - последняя буква слова

            if (begin != 0 && s[begin - 1] == ' ') begin--;

            // а если слово первым стоит, нужно убирать после него пробел?
            if (begin == 0 && s[end + 1] == ' ') end++;

            string res = s.Remove(begin, end - begin + 1);
            return res;
        }

        public override void Review()
        {
            if (this.Input == null || string.IsNullOrEmpty(_sequence))
            {
                _output = null;
                return;
            }
            if (_sequence.Any(c => char.IsPunctuation(c) || char.IsWhiteSpace(c)))
            {
                _output = Input;
                return;
            }

            string input = Input;
            while (true)
            {
                (int begin, int end) = FindWord(input, _sequence);
                if (begin == -1) break;

                input = Delete(input, begin, end);
            }

            _output = input;
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Output)) return null;

            return Output;
        }
    }
}

