using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace StringCalculator
{
    class Transform
    {
        public Stack<string> PolishNotation(string oroginNotation)
        {
            Stack<char> temp = new Stack<char>();
            Stack<string> rezult = new Stack<string>();
            string operand = "";
            List<char> charapters = oroginNotation.ToList();
            char outTemp;
                        
            for(int i =0; i < charapters.Count; i++)
            {
                if (CheckOperand(charapters[i]))
                {
                    while (CheckOperand(charapters[i]))
                    {
                        operand += charapters[i].ToString();
                        i++;

                        if (i == charapters.Count)
                        {
                            break;
                        }
                    }
                    rezult.Push(operand);
                    operand = "";
                    i--;
                }                    
                                        
                if(charapters[i] == '(')
                {
                    temp.Push(charapters[i]);
                }
                if (charapters[i] == ')')
                {
                    outTemp = temp.Pop();
                    while(outTemp != '(')
                    {
                        rezult.Push(outTemp.ToString());
                        outTemp = temp.Pop();
                    }
                }

                if (Operator(charapters[i]))
                {
                    if(temp.Count > 0) 
                    { 
                        if (Operator(temp.Peek()))
                        {
                            if (Priority(charapters[i])<=Priority(temp.Peek()))
                            {
                                rezult.Push(temp.Pop().ToString());
                                temp.Push(charapters[i]);
                                continue;
                            }
                            else
                            {
                                temp.Push(charapters[i]);
                                continue;
                            }
                        }
                    }
                    temp.Push(charapters[i]);
                                       
                }
            }
            
            for(int i = 0; i < temp.Count; i++)
            {
                rezult.Push(temp.Pop().ToString());
            }

            return rezult;
        }

        private bool CheckOperand(char ch)
        {
            Regex regex = new Regex(@"\d");
            MatchCollection matches = regex.Matches(ch.ToString());
            return (matches.Count > 0);
        }

        private bool Operator(char ch)
        {
            if ("/*-+^".IndexOf(ch) != -1)
            {
                return true;
            }else
                return false;
        }
        private int Priority(char ch)
        {
            switch (ch)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                case '^': return 3;
                default: return 0;
            }
        }
    }
}
