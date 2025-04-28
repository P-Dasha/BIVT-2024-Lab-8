using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output;

        public Blue_1(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            var words = Input.Split(' ');
            string currentLine = "";

            string[] lines = new string[words.Length];
            int сount = 0;

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                if (currentLine.Length + 1 + word.Length <= 50)
                {
                    if (currentLine.Length > 0) currentLine += " " + word;
                    else currentLine += word;
                }
                else
                {
                    lines[сount++] = currentLine;
                    currentLine = word;
                }
            }

            if (currentLine.Length > 0)
            {
                lines[сount++] = currentLine;
            }

            _output = new string[сount];
            Array.Copy(lines, _output, сount);
        }


        public override string ToString()
        {
            if (_output == null) return null;

            string answer = "";
            foreach (var s in _output)
            {
                answer += $"{s}{Environment.NewLine}";
            }
            answer = answer.Remove(answer.Length - Environment.NewLine.Length, Environment.NewLine.Length);

            return answer;
        }
    }
}
