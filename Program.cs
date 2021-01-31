using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine("\n");

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }
            Console.WriteLine();

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5, 8, 10 };
            Console.WriteLine(String.Join(", ", arr));
            Console.WriteLine("Q4: Enter the absolute difference to check from above array");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);
            Console.WriteLine();

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);
            Console.WriteLine();

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" }, { "Tampa", "Vizag" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);
            Console.WriteLine();

        }

        /// <summary>
        ///Print a pattern with n rows given n as input
        ///n – number of rows for the pattern, integer (int)
        ///This method prints a triangle pattern.
        ///For example n = 5 will display the output as: 
        ///     *
        ///    ***
        ///   *****
        ///  *******
        /// *********
        ///returns      : N/A
        ///return type  : void
        /// </summary>
        /// <param name="n"></param>
        private static void printTriangle(int n)
        {
            try
            {
                for (int rows = 1; rows <= n; rows++)    // num of for-loop iterations = the user input = rows 
                {
                    for (int cols = 1; cols <= n - rows; cols++) // for-loop to fill spaces in columns = cols
                    {
                        Console.Write(" "); // When in 'rows' row, printing 'n-rows' spaces
                    }
                    for (int cols = 1; cols <= 2 * rows - 1; cols++) // for-loop to print '2r-1' stars, as per the row number
                    {
                        Console.Write("*"); // while in 'rows' row, printing '2rows-1' number of stars
                    }
                    Console.WriteLine();    // end of a row, printing to next line
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        ///<para>
        ///In mathematics, the Pell numbers are an infinite sequence of integers.
        ///The sequence of Pell numbers starts with 0 and 1, and then each Pell number is the sum of twice of the previous Pell number and 
        ///the Pell number before that.:thus, 70 is the companion to 29, and 70 = 2 × 29 + 12 = 58 + 12. The first few terms of the sequence are :
        ///0, 1, 2, 5, 12, 29, 70, 169, 408, 985, 2378, 5741, 13860,… 
        ///Write a method that prints first n numbers of the Pell series
        /// Returns : N/A
        /// Return type: void
        ///</para>
        /// </summary>
        /// <param name="n2"></param>
        private static void printPellSeries(int n2)
        {
            try
            {
                int i = 1;
                int j = 0;
                int r = 0;
                int s = 0;
                if (n2 == 0) // returns 'N/A' when user inputs 0
                {
                    Console.WriteLine("N/A");
                }
                else if (n2 == 1) // returns j = 0, when user inputs 1
                {
                    Console.WriteLine(j);       
                }
                else if (n2 == 2) // returns j = 0 & i =1, when user inputs 2
                {
                    Console.Write(j + "\t");    // The value of 'j' is initialized with '0'
                    Console.Write(i + "\t");    // The value of 'i' is initialized with '1'
                }
                else    // all other cases, where user input is > 2
                {
                    Console.Write(j + "\t");    // 'j' = 0 
                    Console.Write(i + "\t");    // 'i' = 1
                    r = (2 * i) + j;          // pell series formula
                    Console.Write(r + "\t");  // third number(i.e 2) in the series is stored in 'r'
                    for (int k = 0; k < (n2 - 3); k++)
                    {
                        s = (2 * r) + i;         // pell series formula 
                        i = r;                     // updating the 'i' value with each iteration
                        Console.Write(s + "\t");   // printing the next num in series
                        r = s;                   // updating the 'r' value with each iteration  
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        ///Given a non-negative integer c, decide whether there're two integers a and b such that a^2 + b^2 = c.
        ///For example:
        ///Input: C = 5 will return the output: true (1*1 + 2*2 = 5)
        ///Input: C = 3 will return the output : false
        ///Input: C = 4 will return the output: true
        ///Input: C = 1 will return the output : true
        ///Note: You cannot use inbuilt Math Class functions.
        /// </summary>
        /// <param name="n3"></param>
        /// <returns>True or False</returns>

        private static bool squareSums(int n3)
        {
            try
            {
                for (int a = 0; a <= n3; a++) // for-loop to incerement a
                {
                    for (int b = 0; b <= n3; b++)    // for-loop to incerement b
                    {
                        if (((a * a) + (b * b) == n3) && (a != b)) // ensuring a and b are unique integers
                        {
                            return true;
                        }
                    }
                }
                return false; 

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Given an array of integers and an integer n, you need to find the number of unique
        /// n-diff pairs in the array.Here a n-diff pair is defined as an integer pair (i, j),
        ///where i and j are both numbers in the array and their absolute difference is n.
        ///Example 1:
        ///Input: [3, 1, 4, 1, 5], k = 2
        ///Output: 2
        ///Explanation: There are two 2-diff pairs in the array, (1, 3) and(3, 5).
        ///Although we have two 1s in the input, we should only return the number of unique   
        ///pairs.
        ///Example 2:
        ///Input:[1, 2, 3, 4, 5], k = 1
        ///Output: 4
        ///Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and
        ///(4, 5).
        ///Example 3:
        ///Input: [1, 3, 1, 5, 4], k = 0
        ///Output: 1
        ///Explanation: There is one 0-diff pair in the array, (1, 1).
        ///Note : The pairs(i, j) and(j, i) count as same.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns>Number of pairs in the array with the given number as difference</returns>
        private static int diffPairs(int[] nums, int k)
        {
            try
            {
                
                int c = 0;      // var 'c' counts the unique numbers in 2nd array
                int fc = 0; // var 'fc' gives the final count of pairs with the difference 'k'
                int ele = 0;    // var 'ele' to filter the duplicates from the original array
                int[] dummy = new int[nums.Length]; // a new array to save unique numbers from the original array
                Array.Sort(nums);   // sorted to eliminate duplicates
                ele = nums[0];
                dummy[c++] = ele;   // 2nd array assigned with the variable ele
                
                for (int i = 1; i < nums.Length; i++) // loop to take out the unique values to 2nd array using 1st array
                {
                    if (nums[i] == ele) // continues if there is duplicate 
                    {
                        continue;
                    }
                    else // appends to ele if there is NO duplicate, appends to 2nd array too
                    {
                        ele = nums[i];
                        dummy[c++] = ele;
                    }
                }
                if (k == 0) // to check for duplicates
                {
                    int len1 = nums.Length;
                    int len2 = c + 1;
                    fc = len1 - len2; // duplicate pairs = difference between the 1st and 2nd array
                }
                else
                {
                    for (int z3 = 0; z3 < dummy.Length; z3++)
                    {
                        for (int z4 = 0; z4 < dummy.Length; z4++)
                        {
                            if ((dummy[z3] > dummy[z4]) && (dummy[z3] - dummy[z4] == k) && (dummy[z4] > 0) && (z3 != z4)) // In other cases, it calculates the exact number of pairs by traversing through the second array which has only unique numbers
                            {
                                fc++; // Whenever a pair has the difference that is equal to the number specified it adds the final count of the pairs
                            }
                        }
                    } 
                    if (k > (dummy[dummy.Length - 1] - dummy[0])) // if user input > the highest number in array
                    {
                        fc = 0;
                    }
                }
                return fc; // finalcount returned 
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        /// <summary>
        /// An Email has two parts, local name and domain name. 
        /// Eg: rocky @usf.edu – local name : rocky, domain name : usf.edu
        /// Besides lowercase letters, these emails may contain '.'s or '+'s.
        /// If you add periods ('.') between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name.
        /// For example, "bulls.z@usf.com" and "bullsz@leetcode.com" forward to the same email address.  (Note that this rule does not apply for domain names.)
        /// If you add a plus('+') in the local name, everything after the first plus sign will be ignored.This allows certain emails to be filtered, for example ro.cky+bulls @usf.com will be forwarded to rocky@email.com.  (Again, this rule does not apply for domain names.)
        /// It is possible to use both of these rules at the same time.
        /// Given a list of emails, we send one email to each address in the list.Return, how many different addresses actually receive mails?
        /// Eg:
        /// Input: ["dis.email+bull@usf.com","dis.e.mail+bob.cathy@usf.com","disemail+david@us.f.com"]
        /// Output: 2
        /// Explanation: "disemail@usf.com" and "disemail@us.f.com" actually receive mails
        /// </summary>
        /// <param name="emails"></param>
        /// <returns>The number of unique emails in the given list</returns>

        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                List<string> newEmails = new List<string>();
                for (int num1 = 0; num1 < emails.Count; num1++)
                {
                    string str = emails[num1];  // Each iteration copies one email to str
                    int p = str.IndexOf("@");   // found the index of '@' from the email ID and assigned to 'p'
                    int e = str.Length;         // found the length of the email for trimming and assigned to 'e'
                    string loc = str.Substring(0, p);   // extracted the local name from the email ID and assigned to 'loc'
                    p++;
                    string dom = str.Substring(p);      // extracted the domain name and assigned to 'dom'
                    int plus = loc.IndexOf("+");        // found the index of '+' in the local name
                    loc = loc.Substring(0, plus);       // discared all text after '+'
                    string res = loc;
                    int dot = loc.IndexOf(".");           // found the index of '.' in the local name part
                    while (dot > -1)                      // while loop runs until there are no dots '.' left in the modified local name
                    {
                        res = res.Remove(dot, 1);         // '.' character is found and dropped 
                        dot = res.IndexOf(".");           // dot is assigned with the updated index of '.', till the value of dot = -1
                    }
                    int space = res.IndexOf(" ");       // removing spaces 
                    while (space > -1)
                    {
                        res = res.Remove(space, 1);     // same as above '.'
                        space = res.IndexOf(" ");       // same as above '.'
                    }
                    string final_res = res + "@" + dom;     // modified email ID assigned to 'final_res'
                    newEmails.Add(final_res);               // appended to newEmails list
                }
                List<string> uniqueEmails = newEmails.Distinct().ToList(); // unique emails created using the distict method
                int counter = 0;    
                foreach (string emailID in uniqueEmails) // counting unique emails
                {
                    counter++;      
                }
                return counter;     // returning output
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /// <summary>
        /// You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi. Return the destination city, that is, the city without any path outgoing to another city.
        /// It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        /// Example 1:
        /// Input: paths = [["London", "New York"], ["New York","Tampa"], ["Delhi","London"]]
        /// Output: "Tampa" 
        /// Explanation: Starting at "Delhi" city you will reach "Tampa" city which is the destination city.Your trip consist of: "Delhi" -> "London" -> "New York" -> "Tampa".
        /// Input: paths = [["B","C"],["D","B"],["C","A"]]
        /// Output: "A"
        /// Explanation: All possible trips are: 
        /// "D" -> "B" -> "C" -> "A". 
        /// "B" -> "C" -> "A". 
        /// "C" -> "A". 
        /// "A". 
        /// Clearly the destination city is "A".
        /// </summary>
        /// <param name="paths"></param>
        /// <returns>The destination city string</returns>
        private static string DestCity(string[,] paths)
        {
            try
            {
                int rows = paths.GetLength(0);      // number of rows
                //Console.WriteLine(rows);
                int cols = paths.GetLength(1);   // number of columns
                //Console.WriteLine(cols);
                string dest = null;          // final destination city name
                for (int a = 0; a < rows; a++)      
                {
                    for (int b = 0; b < rows; b++)
                    {
                        if (paths[b, 1] != paths[a, 0])  // traversing through destinations to see if it matches with any source
                        {
                            dest = paths[b, 1];  // if no match with any source, that's our final destination 
                            //Console.WriteLine(dest);
                        }
                    }
                }
                return dest; // returning final destination


            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}
