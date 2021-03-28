using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    public class Validation
    {
        public string Check(string exeption)
        {
            int bracket = 0;
            bool lastCharOper = false;
            
            if(exeption.Length == 0)
            {
                return "Вы не ввели выражение";
            }

            if ("/*+^".IndexOf(exeption[0]) != -1)
            {
                return $"Выражение не может начинатся с оператора {exeption[0]}";
            }

            for (int i = 0; i < exeption.Length; i++)
            {
                if ("0123456789/*-+^()".IndexOf(exeption[i]) == -1)
                    return $"Выражение {exeption} содержит недоспустимый символ {exeption[i]}!";

                if(exeption[i] == '(')
                    bracket++;
                if(exeption[i] == ')')
                    bracket--;

                if ("/*-+^".IndexOf(exeption[i]) != -1)
                {
                    if (lastCharOper == true)
                        return $"Выражение содержит подряд идущие операторы! {exeption[i - 1]} и {exeption[i]}";
                    else
                        lastCharOper = true;
                }
                else
                    lastCharOper = false;
            }

            if(bracket != 0)
            {
                return "Выражение содержит разное кол. отрытых и закрытых скобок!";
            }

            return "";
        }
    }
}
