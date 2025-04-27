using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;
        public (char, double)[] Output
        {
            get
            {
                if (_output == null) return null;

                (char, double)[] temp = new (char, double)[_output.Length];
                Array.Copy(_output, temp, _output.Length);
                return temp;
            }
        }

        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        private void Sort()
        {
            if (_output == null || _output.Length <= 1) return;

            // сортировка output по убыванию freq

            for (int i = 0; i < _output.Length - 1; i++)
            {
                for (int j = 0; j < _output.Length - i - 1; j++)
                {
                    var current = _output[j];
                    var next = _output[j + 1];

                    if (next.Item2 > current.Item2)
                    {
                        _output[j] = next;
                        _output[j + 1] = current;
                    }
                    else if (next.Item2 == current.Item2 && next.Item1 < current.Item1)
                    {
                        _output[j] = next;
                        _output[j + 1] = current;
                    }
                }
            }
        }


        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            // разбить строку на слова
            // каждую первую букву к нижнему регистру, затем проверка на букву

            char[] separators = {' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            string[] words = Input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int wordcnt = 0; // числа не учитываются как слова???
            int[] letterFreq = new int[59]; // подобие словаря через аски

            _output = new (char, double)[0];

            foreach (var word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    char char1 = char.ToLower(word[0]);

                    if (char.IsLetter(char1))
                    {
                        wordcnt++;
                        // a - z eng
                        if (char1 >= 'a' && char1 <= 'z')
                        {
                            letterFreq[char1 - 'a']++; 
                        }
                        // а - я rus
                        else if (char1 >= 'а' && char1 <= 'я')
                        {
                            letterFreq[char1 - 'а' + 26]++; 
                        }

                    }
                }
            }

            // присвоить output'у символы от a до z where freq!= 0
            // сортировать

            for (int i = 0; i < letterFreq.Length; i++)
            {
                if (letterFreq[i] > 0)
                {
                    char letter;
                    if (i < 26) // a - z 
                    {
                        letter = (char)(i + 'a');
                    }
                    else // а - я
                    {
                        letter = (char)(i - 26 + 'а');
                    }
                    double freq = Math.Round(letterFreq[i] * 100.0 / wordcnt, 4);

                    Array.Resize(ref _output, _output.Length + 1);
                    _output[_output.Length - 1] = (letter, freq);
                }
            }
             
            Sort();
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return null;

            string answer = "";
            foreach ((char let, double freq) in _output)
                answer += $"{let} - {freq}\n";
            answer = answer.Remove(answer.Length - 1, 1);

            return answer;
        }
    }
}
