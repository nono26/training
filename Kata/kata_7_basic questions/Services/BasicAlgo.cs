using System.Text;

namespace Services
{
    public static class BasicAlgo
    {
        public static void Main()    
        {    
                    //Write Program to find fibonacci series for given number    
                    for (int i = 0; i < 10; i++)    
                    {    
                        Console.Write("{0} ", FibbonacciSeries(i));    
                    }    
                    Console.WriteLine(Environment.NewLine);    
            
                    Console.Write("Fibbonacci Series of {0} is : {1} ", 10, FibbonacciSeries1(10));    
            
                    Console.WriteLine(Environment.NewLine);    
            
                    //Write Program to calculate factorial value for given number    
                    Console.WriteLine("The Factorial of {0} is: {1} \n", 6, Factorial(6));    
            
                    //Write Program to find duplicate in String    
                    FindDuplicateCharacterInString("CSharpCorner");    
            
                    Console.WriteLine(Environment.NewLine);    
                    //Write Program to find duplicate in string array    
                    FindDuplicateInstringArray();    
            
                    Console.WriteLine(Environment.NewLine);    
                    //Write Program to Remove duplicate in string    
                    RemoveDuplicate("CSharpCorner");    
            
                    Console.WriteLine(Environment.NewLine);    
                    //Write Program to find number of character in string    
                    FindNumberofCharaterinString();    
            
                    Console.WriteLine(Environment.NewLine);    
                    //Write Program to find number of words in string    
                    ReverseStringWords("Jignesh Kumar");    
            
                    Console.WriteLine(Environment.NewLine);    
                    //Write Program to find consicutive character in string    
                    char[] charArray = { 'A', 'B', 'B', 'C', 'D', 'D', 'E', 'F', 'F' };    
                    FindConsicutiveCharacter(charArray);    
            
                    Console.WriteLine(Environment.NewLine);    
                    //Write Program to check string is palindrome or not    
                    string[] strArray = { "WOW", "NOON", "ABBA", "ANNA", "BOB", "Jimmy", "Peter" };    
            
                    foreach (var item in strArray)    
                    {    
                        Console.WriteLine(" {0} Is palindrome {1}", item, IsStringPalindrome(item));    
                    }    
            
                    Console.WriteLine(Environment.NewLine);    
                    //Write program to check number is palindrome or not    
                    int number = 121;    
                    Console.WriteLine("{0} is Palindrome number {1} ", number, IsNumberPalindrome(number));    
            
                    Console.WriteLine(Environment.NewLine);    
                    //Write program to check number is palindrome or not    
                    number = 127;    
                    Console.WriteLine("{0} is prime number {1} ", number, IsNumberPrime(number));    
                    number = 128;    
                    Console.WriteLine("{0} is prime number {1} ", number, IsNumberPrime(number));    
                    Console.ReadLine();    
        }   

        private static int FibbonacciSeries(int number)    
        {    
                int firstValue = 0;    
                int secondValue = 1;    
                int result = 0;    
                if (number == 0)    
                    return 0;    
                if (number == 1)    
                    return 1;    
                for (int i = 2; i <= number; i++)    
                {    
                    result = firstValue + secondValue;    
                    firstValue = secondValue;    
                    secondValue = result;    
                }    
                return result;    
        }    
            
        public static string FibbonacciSeries1(int n)    
        {    
                int a = 0, b = 1, c;    
                StringBuilder sb = new StringBuilder();    
                for (int i = 1; i < n; i++)    
                {    
                    sb.Append(a.ToString() + ",");    
                    c = a + b;    
                    a = b;    
                    b = c;    
                }    
                return sb.ToString().Remove(sb.Length - 1); ;    
        }

        private static int Factorial(int number)    
        {    
                int fact = 1;    
                if (number == 0)    
                    return 0;    
                if (number == 1)    
                    return 1;    
            
                for (int i = 1; i <= number; i++)    
                {    
                    fact = fact * i;    
                }    
                return fact;    
        }  

        private static void FindDuplicateCharacterInString(string inPutString)    
        {    
            
                    if (string.IsNullOrEmpty(inPutString))    
                    {    
                        Console.WriteLine("Please enter valid Input");    
                    }    
                    else    
                    {    
                        var list = new List<char>();    
                        string result = string.Empty;    
            
                        foreach (char item in inPutString)    
                        {    
                            if (list.Contains(item))    
                            {    
                                if (!result.Contains(item))    
                                    result += item;    
                            }    
                            else    
                            {    
                                list.Add(item);    
                            }    
                        }    
                        Console.WriteLine("Duplicate Found : {0} ", result);    
                    }      
        }  
        public static void FindDuplicateInstringArray()    
        {    
                    string[] strArray = { "Sunday", "Monday", "Tuesday", "Wednesday", "Sunday", "Monday" };    
                    List<string> lstString = new List<string>();    
                    StringBuilder sb = new StringBuilder();    
            
                    foreach (var str in strArray)    
                    {    
                        if (lstString.Contains(str))    
                        {    
                            sb.Append(" " + str);    
            
                        }    
                        else    
                        {    
                            lstString.Add(str);    
                        }    
                    }    
                    Console.WriteLine("Duplicate Found : {0}", sb.ToString());    
        } 

        public static void RemoveDuplicate(string inputString)    
        {    
                    var list = new List<char>();    
            
                    foreach (var item in inputString)    
                    {    
                        if (!list.Contains(item))    
                        {    
                            list.Add(item);    
                        }    
                    }    
            
            Console.WriteLine("Orignal String {0}, After duplicate removed {1}", inputString, new string(list.ToArray()));    
        }
        public static void FindNumberofCharaterinString()    
        {    
                    string StringToCount = "DotNetDeveloper";    
                    var result = FindOccuranceofCharacterInString(StringToCount);    
            
                    Console.WriteLine("Number of occurrences of a character in given string");    
                    foreach (var count in result)    
                    {    
                        Console.WriteLine(" {0} - {1} ", count.Key, count.Value);    
                    }    
        }    
            
        public static SortedDictionary<char, int> FindOccuranceofCharacterInString(string str)    
        {    
        SortedDictionary<char, int> count = new SortedDictionary<char, int>();    
            
                    foreach (var chr in str)    
                    {    
                        if (!(count.ContainsKey(chr)))    
                        {    
                            count.Add(chr, 1);    
                        }    
                        else    
                        {    
                            count[chr]++;    
                        }    
                    }    
            
            return count;    
        }  

        public static void ReverseStringWords(string inputString)    
        {    
                    string[] seprator = { " " };    
                    string[] words = inputString.Split(seprator, StringSplitOptions.RemoveEmptyEntries);    
                    string result = string.Empty;    
                    for (int i = words.Length - 1; i >= 0; i--)    
                    {    
                        result += words[i].ToString();    
                    }    
            Console.WriteLine("Reverse words in string {0}", result);    
        }  

        public static void FindConsicutiveCharacter(char[] characterArray)    
        {    
                int len = characterArray.Length - 1;    
                List<char> result = new List<char>();    
                for (int i = 0; i < len; i++)    
                {    
                    for (int j = i + 1; j <= len; j++)    
                    {    
                        if (characterArray[i] == characterArray[j])    
                        {    
                            if (!result.Contains(characterArray[i]))    
                                result.Add(characterArray[i]);    
                            continue;    
                        }    
                        else    
                        {    
                            break;    
                        }    
                    }    
                }    
            
                Console.WriteLine("Consicutive Character found {0} ", new string(result.ToArray()));    
        } 

        public static bool IsStringPalindrome(string inputString)    
        {    
                    int minIdex = 0;    
                    int maxIdex = inputString.Length - 1;    
                    while (true)    
                    {    
                        if (minIdex > maxIdex)    
                        {    
                            return true;    
                        }    
                        char charfromLeft = inputString[minIdex];    
                        char charfromRight = inputString[maxIdex];    
                        if (charfromLeft != charfromRight)    
                        {    
                            return false;    
                        }    
                        minIdex++;    
                        maxIdex--;    
                    }      
        }      
        public static bool IsNumberPalindrome(int number)    
        {    
                    int reminder, sum = 0;    
                    int tempNumber;    
                    tempNumber = number;    
                    bool IsPalindrome = false;    
                    while (number > 0)    
                    {    
                        reminder = number % 10;    
                        number = number / 10;    
                        sum = sum * 10 + reminder;    
                        if (tempNumber == sum)    
                        {    
                            IsPalindrome = true;    
                        }    
                    }    
                    return IsPalindrome;    
        } 

        public static bool IsNumberPrime(int number)    
        {    
                    int i;    
                    for (i = 2; i <= number - 1; i++)    
                    {    
                        if (number % i == 0)    
                        {    
                            return false;    
                        }    
                    }    
                    if (i == number)    
                    {    
                        return true;    
                    }    
                    return false;    
        }   
    } 
}