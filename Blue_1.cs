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

        private void AddOutput(string s)
        {
            if (_output == null) _output = new string[1];
            else Array.Resize(ref _output, _output.Length + 1);

            _output[_output.Length - 1] = s;
        }

        private string Split(string s)
        {
            if (s.Length <= 50)
            {
                AddOutput(s);
                return null;
            }
            
            // найти индекс посл пробела (инд)
            // добавить всё что до него в аутпут (от 0 до инд - 1)
            // обрезать строку (с индекса пробела +1 до конца)

            int ind = s.LastIndexOf(' ', 49, 50); //(нач с 50(49)-элемента и 50 элементов к началу)
            string toAnswer = s.Substring(0, ind);
            AddOutput(toAnswer);
            s = s.Substring(ind + 1);

            return s;
        }

        public override void Review()
        {
            if (this.Input == null)
            {
                _output = new string[0];
                return;
            }

            string input = Input;
            while (!string.IsNullOrEmpty(input))
            {
                input = Split(input);
            }

            return;
        }

        public override string ToString()
        {
            if (_output == null) return null;

            string answer = "";
            foreach (var s in _output)
            {
                answer += $"{s}\n";
            }
            answer = answer.Remove(answer.Length - 1, 1);

            return answer;
        }
    }
}
