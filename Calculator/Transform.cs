using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace StringCalculator
{
    public class Transform
    {
        public Queue<string> PolishNotation(string oroginNotation)
        {
            Stack<char> temp = new Stack<char>();
            Queue<string> rezult = new Queue<string>();
            string operand = "";
            List<char> charapters = oroginNotation.ToList();
            char outTemp;
            bool addMinus = false;
                        
            for(int i =0; i < charapters.Count; i++)
            {
                if (CheckOperand(charapters[i]))
                {
                    while (CheckOperand(charapters[i]))
                    {
                        if (addMinus)
                        {
                            operand += '-';
                            addMinus = false;
                        }
                        operand += charapters[i].ToString();
                        i++;

                        if (i == charapters.Count)
                        {
                            break;
                        }
                    }
                    rezult.Enqueue(operand);
                    operand = "";
                    i--;
                }                    
                                        
                if(charapters[i] == '(')
                {
                    temp.Push(charapters[i]);
                    if (charapters[i + 1] == '-')
                    {
                        addMinus = true;
                        i++;
                        continue;
                    }
                        
                }
                if (charapters[i] == ')')
                {
                    outTemp = temp.Pop();
                    while(outTemp != '(')
                    {
                        rezult.Enqueue(outTemp.ToString());
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
                                rezult.Enqueue(temp.Pop().ToString());
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
                    if (charapters[i] == '-' && rezult.Count == 0)
                        addMinus = true;
                    else
                        temp.Push(charapters[i]);                                      
                }
            }
            
            for(int i = 0; i <= temp.Count; i++)
            {
                rezult.Enqueue(temp.Pop().ToString());
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
