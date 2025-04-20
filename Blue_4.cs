using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        private string FindNum(string s, ref int begin)
        {
            if (begin > s.Length - 1 || begin < 0) return null;

            // найти начало числа
            // добавить знак
            // добавить само число начиная с бегин (пока всё после него - цифры)

            string num = "";
            while (begin < s.Length && !Char.IsDigit(s[begin]))
            {
                begin++;
            }

            if (begin == s.Length) return null; // чисел нет

            if (begin != 0 && s[begin - 1] == '-') num += '-';
            else num += '+';

            while (begin < s.Length && Char.IsDigit(s[begin]))
            {
                num += s[begin++];
            }

            return num;
        }

        private double StrToInt(string s)
        {
            if (String.IsNullOrEmpty(s) || s.Length <= 1) return 0;

            // проверить на знак
            bool sgn = true;
            if (s[0] == '-') sgn = false;

            double res = 0, pow = s.Length - 2;
            for (int i = 1; i < s.Length; i++)
            {
                res = res * 10 + (s[i] - '0');
            }

            if (!sgn) res *= -1;

            return res;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = 0;
                return;
            }

            // найти число (формат - строка)
            // преобразовать в число
            // преобразованное число прибавить к ответу

            int begin = 0;
            while (begin < Input.Length)
            {
                string strNum = FindNum(Input, ref begin);

                if (strNum == null) return;

                double intNum = StrToInt(strNum);
                _output += (int)intNum;
            }
        }

        public override string ToString()
        {
            string answer = $"{Output}";

            return answer;
        }
    }
}

