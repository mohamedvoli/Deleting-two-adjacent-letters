using System;
using System.Collections.Generic;

namespace Deletion_adjacent_letters
{
    internal class Program
    {
        //Function (( 1 )) To get the number of test cases from the user with validation.
        static int GetTestCasesNumber()
        {
            Console.WriteLine("Please Enter a valid number of test cases t (1≤t≤1000) .");
            string TestCasesNO_string = Console.ReadLine();
            int TestCaseNO_int;
            bool Success = int.TryParse(TestCasesNO_string, out TestCaseNO_int);
            while ((!Success) || (TestCaseNO_int < 1) || (TestCaseNO_int > 1000))
            {
                Console.WriteLine("Please Enter a valid number of test cases t (1≤t≤1000) .");
                TestCasesNO_string = Console.ReadLine();
                Success = int.TryParse(TestCasesNO_string, out  TestCaseNO_int);
            }
            return TestCaseNO_int;
        }
        //Function (( 2 )) To check if the the string length between 1~49
        static bool CheckStringLength(string AString)
        {
            int StringLength = AString.Length;
            if ((StringLength >= 1) && (StringLength <=49) && (StringLength%2 !=0))
            {
                return true;
            }
            else { return false; }
        }
        //Function (( 3 )) To check if the string is consisting of only one char.
        static bool IsStringOneChar(string AString)
        {
            int StringLength = AString.Length;
            if (StringLength == 1)
            {
                return true;
            }
            else { return false; }
        }
        //Function (( 4 )) To fill the array of string with test cases.
        static bool FillArr(int NumberOfLines,string[] StringArr)
        {
            Console.WriteLine($"Please enter the {NumberOfLines} Lines to apply the operation on.");
            for (int i = 0; i<NumberOfLines;i++)
            {
                StringArr[i] = Console.ReadLine().Trim().ToLower();
                if (((i == 0 ) || (i%2==0)) && (!CheckStringLength(StringArr[i])))
                {
                    return false;
                }else if ((i%2 !=0) && (!IsStringOneChar(StringArr[i])))
                {
                    return false;
                }
            }
            return true;
        }
        //Function (( 5 )) To fill the result array.
        static List<string> CreateAndFillResult(string[] TestCases)
        {
            List<string> Result = new List<string>();
            for (int i =0;i<TestCases.Length;i+=2)
            {
                if (TestCases[i].Contains(TestCases[i + 1]))
                {
                    bool flag = false;
                    int Counter = -1;
                    foreach (char Letter in TestCases[i])
                    {
                        Counter++;
                        if ((Letter == Char.Parse(TestCases[i + 1])) && ((Counter == 0) || (Counter % 2 == 0))) {
                                flag = true;
                                break;
                        }
                    }
                    if (flag) { Result.Add("YES"); } else { Result.Add("NO"); }
                }
                else
                {
                    Result.Add("NO");
                }
            }
            return Result;
        }
        static void Main(string[] args)
        {
            int NumberOfTestCases = GetTestCasesNumber();
            int LinesNumber = NumberOfTestCases * 2;
            string[] TestCases = new string[LinesNumber];
            bool ArrayFilledSuccessfully = FillArr(LinesNumber, TestCases);
            while (!ArrayFilledSuccessfully)
            {
                Console.WriteLine("Please enter valid test cases.");
                Array.Clear(TestCases,0,TestCases.Length);
                ArrayFilledSuccessfully = FillArr(LinesNumber, TestCases);
            }
            List<string> Result = CreateAndFillResult(TestCases);
            foreach (string OutPut in Result){Console.WriteLine(OutPut);}
        }
    }
}