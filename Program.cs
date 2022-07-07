using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
namespace My_Final_Project_Program
{
    class Program
    {
        /*Honestly this program from my friends akira IT4 but he just made the multiplication of matrix
        in here i want to use his logic for fill the matrix number and add another formula of matrix 
        but again in here my program still has deficiency*/
        //This Method for Main Menu
        static void Main()
        {
            //this is bool for looping if there has typing error
            bool mainmenu = true;
            do
            {
                Console.Clear();
                string welcoming = "Welcome to My Final Project Program";
                string choosenprogram = "Please choose your program (just type the number of the choice)\n1. Matrix Operations\n2. blabla";
                Console.WriteLine(welcoming);
                Console.WriteLine(choosenprogram);
                //user can choose the program by switch case unfortunately i just put one program
                    string inputchoose = Console.ReadLine();
                    switch (inputchoose)
                    {
                        case "1":
                            Matrix();
                            break;
                    }
            }
            while (mainmenu);
        }
        //this is public method to fill the string location because this value can use for some another method
        public static string location = @"/home/marksinabutar/Documents";
        //this method for matrix menu
        public static void Matrix()
        {
            bool matrixmenu = true;
            do
            {
                Console.Clear();
                //create the directory for the result file
                Directory.CreateDirectory(location);
                string beginningwords = "Welcome to my matrix operation program";
                string choosenformula = "What do you want in this operations (just type the number of the choice)\n1. Addition\n2. Subtraction\n3. Multiplicaton\n4. Determinant -> Invers -> Division\n5. Back to first menu";
                Console.WriteLine(beginningwords);
                Console.WriteLine(choosenformula);
                string inputformula = Console.ReadLine();
                switch (inputformula)
                {
                    case "1":
                        AdditionMatrix();
                        break;
                    case "2":
                        SubtractionMatrix();
                        break;
                    case "3":
                        MultiplicationMatrix();
                        break;
                    case "4":
                        DeterminantMatrix();
                        break;
                    case "5":
                        Main();
                        break;
                }
            }
            while (matrixmenu);
            
        }
        public static string pak = "Press Any Key To Continue";
        //this method is addition of matrix
        public static void AdditionMatrix()
        {
            Console.Clear();
            string askingrow1 = "How much row for your first matrix do you want?";
            Console.WriteLine(askingrow1);
            int row1 = int.Parse(Console.ReadLine());
            string askingcolumn1 = "How much column for your first matrix do you want?";
            Console.WriteLine(askingcolumn1);
            int column1 = int.Parse(Console.ReadLine());
            //create the first matrix array
            int[,] matrix1 = new int[row1, column1];
        typingnumbermatrix:
            string intructioninputmatrix1 = "So input your matrix number with the correct format using space to seperate each column";
            Console.WriteLine(intructioninputmatrix1);
            //i just use the for loop because it is easly and customizable for matrix
            for (int steprow1 = 0; steprow1 < row1; steprow1++)
            {
                string line1 = Console.ReadLine();
                //string split is to recognize from input where is each the matrix number
                string[] thelines1 = line1.Split(' ');
                //this is conditional if user has typing error to input matrix number
                if (thelines1.Length > column1 || thelines1.Length < column1)
                {
                    Console.Clear();
                    string typingerrorwords = "You have wrong to input your matrix number please length of number same as your column before";
                    Console.WriteLine("{0}\nYour first matrix column is {1}", typingerrorwords, column1);
                    //this goto for go back to input the matrix number again
                    goto typingnumbermatrix;
                }
                else
                {
                    //this array for the number matrix per line
                    int[] linearray1 = new int[column1];
                    //this function of array to convert all data type of thelines1
                    linearray1 = Array.ConvertAll(thelines1, block => int.Parse(block));
                    //this loop to fill the first matrix array
                    for (int stepcolumn1 = 0; stepcolumn1 < column1; stepcolumn1++)
                    {
                        matrix1[steprow1, stepcolumn1] = linearray1[stepcolumn1];
                    }
                }

            }

            int row2 = row1;
            string askingrow2 = "Your row of second matrix is {0}";
            Console.WriteLine(askingrow2, row2);
            int column2 = column1;
            string askingcolumn2 = "Your column of second matrix is {0}";
            Console.WriteLine(askingcolumn2, column2);
            int[,] matrix2 = new int[row2, column2];
        typingsecondnumbermatrix:
            string intructioninputmatrix2 = "So input your matrix number with the correct format using space to seperate each column";
            Console.WriteLine(intructioninputmatrix2);
            for (int steprow2 = 0; steprow2 < row2; steprow2++)
            {
                string line2 = Console.ReadLine();
                string[] thelines2 = line2.Split(' ');
                if (thelines2.Length > column2 || thelines2.Length < column2)
                {
                    Console.Clear();
                    string typingerrorwords = "You have wrong to input your matrix number please length of number same as your column before";
                    Console.WriteLine("{0}\nYour second matrix column is {1}", typingerrorwords, column2);
                    goto typingsecondnumbermatrix;
                }
                else
                {
                    int[] linearray2 = new int[column2];
                    linearray2 = Array.ConvertAll(thelines2, block => int.Parse(block));
                    for (int stepcolumn2 = 0; stepcolumn2 < column2; stepcolumn2++)
                    {
                        matrix2[steprow2, stepcolumn2] = linearray2[stepcolumn2];
                    }
                }
            }
            //create the addition result array
            int[,] matrixaddition = new int[row1, column1];
            //formula of matrix addition
            for (int steprow1 = 0; steprow1 < row1; steprow1++)
            {
                for (int stepcolumn1 = 0; stepcolumn1 < column1; stepcolumn1++)
                {
                    int sumaddition = 0;
                    sumaddition = matrix1[steprow1, stepcolumn1] + matrix2[steprow1, stepcolumn1];
                    matrixaddition[steprow1, stepcolumn1] = sumaddition;
                }
            }
            //printing to text file
            string addname = "The Addition Result.txt";
            //to show the date when user use it
            DateTime today = DateTime.UtcNow.Date;
            using (StreamWriter fileaddition = new StreamWriter(Path.Combine(location,addname)))
            {
                fileaddition.WriteLine(today.ToString("MM/dd/yyyy hh:mm:ss\n"));
                for (int steprow1 = 0; steprow1 < row1; steprow1++)
                {
                    fileaddition.Write("| ");
                    for (int stepcolumn1 = 0; stepcolumn1 < column1; stepcolumn1++)
                    {
                        fileaddition.Write("{0} ", matrixaddition[steprow1, stepcolumn1]);
                    }
                    fileaddition.Write("|\n");
                }
            }
            Console.Clear();
            //printing the result on console
            string additionresultwords = "So The result is :";
            Console.WriteLine(additionresultwords + "\nYour result has been printed at {0} '{1}'",location,addname);
            for (int steprow1 = 0; steprow1 < row1; steprow1++)
            {
                Console.Write("| ");
                for (int stepcolumn1 = 0; stepcolumn1 < column1; stepcolumn1++)
                {
                    Console.Write("{0} ", matrixaddition[steprow1, stepcolumn1]);
                }
                Console.Write("|\n");
            }
            Console.WriteLine(pak);
            Console.ReadKey();
            bool additionmenu = true;
            do
            {
                Console.Clear();
                Console.WriteLine("What Else?");
                Console.WriteLine("1. Reuse this method\n2. Back to Matrix Menu\n3. Back to Main Menu");
                string inputaddition = Console.ReadLine();
                switch (inputaddition)
                {
                    case "1":
                        AdditionMatrix();
                        break;
                    case "2":
                        Matrix();
                        break;
                    case "3":
                        Main();
                        break;
                }
            }
            while (additionmenu);
        }
        //this method for subtraction of matrix
        public static void SubtractionMatrix()
        {
            Console.Clear();
            string askingrow1 = "How much row for your first matrix do you want?";
            Console.WriteLine(askingrow1);
            int row1 = int.Parse(Console.ReadLine());
            string askingcolumn1 = "How much column for your first matrix do you want?";
            Console.WriteLine(askingcolumn1);
            int column1 = int.Parse(Console.ReadLine());
            int[,] matrix1 = new int[row1, column1];
        typingnumbermatrix:
            string intructioninputmatrix1 = "So input your matrix number with the correct format using space to seperate each column";
            Console.WriteLine(intructioninputmatrix1);
            for (int steprow1 = 0; steprow1 < row1; steprow1++)
            {
                string line1 = Console.ReadLine();
                string[] thelines1 = line1.Split(' ');
                if (thelines1.Length > column1 || thelines1.Length < column1)
                {
                    Console.Clear();
                    string typingerrorwords = "You have wrong to input your matrix number please length of number same as your column before";
                    Console.WriteLine("{0}\nYour first matrix column is {1}", typingerrorwords, column1);
                    goto typingnumbermatrix;
                }
                else
                {
                    int[] linearray1 = new int[column1];
                    linearray1 = Array.ConvertAll(thelines1, block => int.Parse(block));
                    for (int stepcolumn1 = 0; stepcolumn1 < column1; stepcolumn1++)
                    {
                        matrix1[steprow1, stepcolumn1] = linearray1[stepcolumn1];
                    }
                }

            }

            int row2 = row1;
            string askingrow2 = "Your row of second matrix is {0}";
            Console.WriteLine(askingrow2, row2);
            int column2 = column1;
            string askingcolumn2 = "Your column of second matrix is {0}";
            Console.WriteLine(askingcolumn2, column2);
            int[,] matrix2 = new int[row2, column2];
        typingsecondnumbermatrix:
            string intructioninputmatrix2 = "So input your matrix number with the correct format using space to seperate each column";
            Console.WriteLine(intructioninputmatrix2);
            for (int steprow2 = 0; steprow2 < row2; steprow2++)
            {
                string line2 = Console.ReadLine();
                string[] thelines2 = line2.Split(' ');
                if (thelines2.Length > column2 || thelines2.Length < column2)
                {
                    Console.Clear();
                    string typingerrorwords = "You have wrong to input your matrix number please length of number same as your column before";
                    Console.WriteLine("{0}\nYour second matrix column is {1}", typingerrorwords, column2);
                    goto typingsecondnumbermatrix;
                }
                else
                {
                    int[] linearray2 = new int[column2];
                    linearray2 = Array.ConvertAll(thelines2, block => int.Parse(block));
                    for (int stepcolumn2 = 0; stepcolumn2 < column2; stepcolumn2++)
                    {
                        matrix2[steprow2, stepcolumn2] = linearray2[stepcolumn2];
                    }
                }
            }
            int[,] matrixsubtraction = new int[row1, column1];
            for (int steprow1 = 0; steprow1 < row1; steprow1++)
            {
                for (int stepcolumn1 = 0; stepcolumn1 < column1; stepcolumn1++)
                {
                    int sumsubtraction = 0;
                    sumsubtraction = matrix1[steprow1, stepcolumn1] - matrix2[steprow1, stepcolumn1];
                    matrixsubtraction[steprow1, stepcolumn1] = sumsubtraction;
                }
            }
            string subtractionname = "The Subtraction Result.txt";
            DateTime today = DateTime.UtcNow.Date;
            using (StreamWriter filesubtraction = new StreamWriter(Path.Combine(location, subtractionname)))
            {
                filesubtraction.WriteLine(today.ToString("MM/dd/yyyy hh:mm:ss\n"));
                for (int steprow1 = 0; steprow1 < row1; steprow1++)
                {
                    filesubtraction.Write("| ");
                    for (int stepcolumn1 = 0; stepcolumn1 < column1; stepcolumn1++)
                    {
                        filesubtraction.Write("{0} ", matrixsubtraction[steprow1, stepcolumn1]);
                    }
                    filesubtraction.Write("|\n");
                }
            }
            Console.Clear();
            string subtractionresultwords = "So The result is :";
            Console.WriteLine(subtractionresultwords + "\nYour result has been printed at {0} '{1}'", location, subtractionname);
            for (int steprow1 = 0; steprow1 < row1; steprow1++)
            {
                Console.Write("| ");
                for (int stepcolumn1 = 0; stepcolumn1 < column1; stepcolumn1++)
                {
                    Console.Write("{0} ", matrixsubtraction[steprow1, stepcolumn1]);
                }
                Console.Write("|\n");
            }
            Console.WriteLine(pak);
            Console.ReadKey();
            bool subtractionmenu = true;
            do
            {
                Console.Clear();
                Console.WriteLine("What Else?");
                Console.WriteLine("1. Reuse this method\n2. Back to Matrix Menu\n3. Back to Main Menu");
                string inputsubtraction = Console.ReadLine();
                switch (inputsubtraction)
                {
                    case "1":
                        SubtractionMatrix();
                        break;
                    case "2":
                        Matrix();
                        break;
                    case "3":
                        Main();
                        break;
                }
            }
            while (subtractionmenu);
        }
        //this method for mutliplication of matrix
        public static void MultiplicationMatrix()
        {
            Console.Clear();
            string askingrow1 = "How much row for your first matrix do you want?";
            Console.WriteLine(askingrow1);
            int row1 = int.Parse(Console.ReadLine());
            string askingcolumn1 = "How much column for your first matrix do you want?";
            Console.WriteLine(askingcolumn1);
            int column1 = int.Parse(Console.ReadLine());
            int[,] matrix1 = new int[row1, column1];
            typingnumbermatrix:
            string intructioninputmatrix1 = "So input your matrix number with the correct format using space to seperate each column";
            Console.WriteLine(intructioninputmatrix1);
            for (int steprow1 = 0; steprow1 < row1; steprow1++)
            {
                string line1 = Console.ReadLine();
                string[] thelines1 = line1.Split(' ');
                if (thelines1.Length > column1 || thelines1.Length < column1)
                {
                    Console.Clear();
                    string typingerrorwords = "You have wrong to input your matrix number please length of number same as your column before";
                    Console.WriteLine("{0}\nYour first matrix column is {1}",typingerrorwords, column1);
                    goto typingnumbermatrix;
                }
                else {
                    int[] linearray1 = new int[column1];
                    linearray1 = Array.ConvertAll(thelines1, block => int.Parse(block));
                    for (int stepcolumn1 = 0; stepcolumn1 < column1; stepcolumn1++)
                    {
                        matrix1[steprow1, stepcolumn1] = linearray1[stepcolumn1];
                    }
                }
                
            }
            string askingrow2 = "How much row for your second matrix do you want?";
            Console.WriteLine(askingrow2);
            int row2 = int.Parse(Console.ReadLine());
            string askingcolumn2 = "How much column for second matrix do you want?";
            Console.WriteLine(askingcolumn2);
            int column2 = int.Parse(Console.ReadLine());
            int[,] matrix2 = new int[row2, column2];
            typingsecondnumbermatrix:
            string intructioninputmatrix2 = "So input your matrix number with the correct format using space to seperate each column";
            Console.WriteLine(intructioninputmatrix2);
            //i made the multiple condition because in multiplication of matrix has some rules
            for (int steprow2 = 0; steprow2 < row2; steprow2++)
            {
                string line2 = Console.ReadLine();
                string[] thelines2 = line2.Split(' ');
                if (thelines2.Length > column2 || thelines2.Length < column2)
                {
                    Console.Clear();
                    string typingerrorwords = "You have wrong to input your matrix number please length of number same as your column before";
                    Console.WriteLine("{0}\nYour second matrix column is {1}", typingerrorwords, column2);
                    goto typingsecondnumbermatrix;
                }
                else {
                    int[] linearray2 = new int[column2];
                    linearray2 = Array.ConvertAll(thelines2, block => int.Parse(block));
                    for (int stepcolumn2 = 0; stepcolumn2 < column2; stepcolumn2++)
                    {
                        matrix2[steprow2, stepcolumn2] = linearray2[stepcolumn2];
                    }
                }
                
            }
            if (row1 == column2 || column1 == row2)
            {
                //create the array of matrix multiplication
                int[,] matrixmultipication = new int[row1, column2];
                //the formula of multiplication
                int summultiply;
                for (int steprow1 = 0; steprow1 < row1; steprow1++)
                {
                    for (int stepcolumn2 = 0; stepcolumn2 < column2; stepcolumn2++)
                    {
                        summultiply = 0;
                        for (int steprow2 = 0; steprow2 < row2; steprow2++)
                        {
                            summultiply = summultiply + matrix1[steprow1, steprow2] * matrix2[steprow2, stepcolumn2];
                            matrixmultipication[steprow1, stepcolumn2] = summultiply;
                        }
                    }
                }
                if (row1 == column2 && column1 != row2)
                {
                    Console.Clear();
                    Console.WriteLine("I can't calculate your matrix because column of first matrix is different between row of second matrix\nYour column of first matrix is {0}\nYour row of second matrix is {1}", column1, row2);
                    Console.WriteLine(pak);
                    Console.ReadKey();
                    bool multiplicationmenu = true;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("So ?");
                        Console.WriteLine("1. Reuse this method\n2. Back to Matrix Menu\n3. Back to Main Menu");
                        string inputmultiplication = Console.ReadLine();
                        switch (inputmultiplication)
                        {
                            case "1":
                                MultiplicationMatrix();
                                break;
                            case "2":
                                Matrix();
                                break;
                            case "3":
                                Main();
                                break;
                        }
                    }
                    while (multiplicationmenu);
                }
                else {
                    string multiplicationname = "The Multiplication Result.txt";
                    DateTime today = DateTime.UtcNow.Date;
                    using (StreamWriter filemultiplication = new StreamWriter(Path.Combine(location, multiplicationname)))
                    {
                        filemultiplication.WriteLine(today.ToString("MM/dd/yyyy hh:mm:ss\n"));
                        for (int steprow1 = 0; steprow1 < row1; steprow1++)
                        {
                            filemultiplication.Write("| ");
                            for (int stepcolumn1 = 0; stepcolumn1 < column2; stepcolumn1++)
                            {
                                filemultiplication.Write("{0} ", matrixmultipication[steprow1, stepcolumn1]);
                            }
                            filemultiplication.Write("|\n");
                        }
                    }
                    Console.Clear();
                    string multiplicationresultwords = "So The result is :";
                    Console.WriteLine(multiplicationresultwords + "\nYour result has been printed at {0} '{1}'", location, multiplicationname);
                    for (int steprow1 = 0; steprow1 < row1; steprow1++)
                    {
                        Console.Write("| ");
                        for (int stepcolumn2 = 0; stepcolumn2 < column2; stepcolumn2++)
                        {
                            Console.Write("{0} ", matrixmultipication[steprow1, stepcolumn2]);
                        }
                        Console.Write("|\n");
                    }
                    Console.WriteLine(pak);
                    Console.ReadKey();
                    bool multiplicationmenu = true;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("What Else?");
                        Console.WriteLine("1. Reuse this method\n2. Back to Matrix Menu\n3. Back to Main Menu");
                        string inputmultiplication = Console.ReadLine();
                        switch (inputmultiplication)
                        {
                            case "1":
                                MultiplicationMatrix();
                                break;
                            case "2":
                                Matrix();
                                break;
                            case "3":
                                Main();
                                break;
                        }
                    }
                    while (multiplicationmenu);
                }
                
            }
            
            else
            {
               Console.Clear();
               Console.WriteLine("I can't calculate your matrix because row of first matrix is different between column of second matrix\nYour row of first matrix is {0}\nYour column of second matrix is {1}",row1,column2);
                Console.WriteLine(pak);
                Console.ReadKey();
                bool multiplicationmenu = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine("So ?");
                    Console.WriteLine("1. Reuse this method\n2. Back to Matrix Menu\n3. Back to Main Menu");
                    string inputmultiplication = Console.ReadLine();
                    switch (inputmultiplication)
                    {
                        case "1":
                            MultiplicationMatrix();
                            break;
                        case "2":
                            Matrix();
                            break;
                        case "3":
                            Main();
                            break;
                    }
                }
                while (multiplicationmenu);
            }
        }
        //create public method of int data type
        public static int matrixdeterminant;
        //create public method of array by using int data type
        public static int[,] matrix2;
        public static int deter;
        //this method to compute matrix determinant
        public static int Computedeter()
        {
            //the formula of matrix determinant i'm using Sarrus Method
            if (row2 == 2 && column2 == 2)
            {
                int[] multiplied = new int[column2];
                //formula 2 row and 2 column of determinant matrix
                int stepcolumnminus = 1;
                for (int stepcolumnplus = 0; stepcolumnplus < column2; stepcolumnplus++)
                {

                    int multiply = matrix2[0, stepcolumnplus] * matrix2[1, stepcolumnminus];
                    stepcolumnminus -= 1;
                    multiplied[stepcolumnplus] = multiply;
                }
                Console.Clear();
                deter = multiplied[0] - multiplied[1];
            }
            if (row2 == 3 && column2 == 3)
            {
                //formula 3 row and 3 column of determinant matrix
                int column3 = column2 + 2;
                int[,] matrixthree = new int[row2, column3];

                for (int steprow2 = 0; steprow2 < row2; steprow2++)
                {
                    for (int stepcolumn1 = 0; stepcolumn1 < column2; stepcolumn1++)
                    {
                        matrixthree[steprow2, stepcolumn1] = matrix2[steprow2, stepcolumn1];
                    }
                }
                for (int steprowadd = 0; steprowadd < row2; steprowadd++)
                {
                    int stepcolumnadd = 0;
                    for (int stepcolumn3 = 3; stepcolumn3 < column3; stepcolumn3++)
                    {
                        matrixthree[steprowadd, stepcolumn3] = matrix2[steprowadd, stepcolumnadd];
                        stepcolumnadd++;
                    }

                }
                int determinantcolumn = 6;
                int[] multiplied = new int[determinantcolumn];
                int stepcolumnleftsecond = 1;
                int stepcolumnleftthird = 2;
                for (int stepcolumnleftfirst = 0; stepcolumnleftfirst < column2; stepcolumnleftfirst++)
                {

                    int multiplyleft = matrixthree[0, stepcolumnleftfirst] * matrixthree[1, stepcolumnleftsecond] * matrixthree[2, stepcolumnleftthird];
                    stepcolumnleftsecond++;
                    stepcolumnleftthird++;
                    multiplied[stepcolumnleftfirst] = multiplyleft;
                }
                int stepcolumnrightsecond = 3;
                int stepcolumnrightthird = 2;
                int rightposition = determinantcolumn;
                for (int stepcolumnrightfirst = 4; stepcolumnrightfirst > 1; stepcolumnrightfirst--)
                {
                    int multiplyright = matrixthree[0, stepcolumnrightfirst] * matrixthree[1, stepcolumnrightsecond] * matrixthree[2, stepcolumnrightthird];
                    stepcolumnrightsecond--;
                    stepcolumnrightthird--;
                    rightposition--;
                    multiplied[rightposition] = multiplyright;

                }
                deter = ((multiplied[0] + multiplied[1] + multiplied[2]) - (multiplied[3] + multiplied[4] + multiplied[5]));
            }
            //the value will be return to deter variable
            return deter;
        }
        public static int row2;
        public static int column2;
        //this method for matrix determinant
        public static void DeterminantMatrix()
        {
            Console.Clear();
            string askingrow2 = "How much row for your first matrix do you want? (but Unfortunatly I only calculate till 3 row)";
            Console.WriteLine(askingrow2);
            row2 = int.Parse(Console.ReadLine());
            string askingcolumn2 = "How much column for your first matrix do you want? (but Unfortunatly I only calculate till 3 column)";
            Console.WriteLine(askingcolumn2);
            column2 = int.Parse(Console.ReadLine());
            matrix2 = new int[row2, column2];
        typingnumbermatrix:
            string intructioninputmatrix1 = "So input your matrix number with the correct format using space to seperate each column";
            Console.WriteLine(intructioninputmatrix1);
            for (int steprow1 = 0; steprow1 < row2; steprow1++)
            {
                string line2 = Console.ReadLine();
                string[] thelines2 = line2.Split(' ');
                if (thelines2.Length > column2 || thelines2.Length < column2)
                {
                    Console.Clear();
                    string typingerrorwords = "You have wrong to input your matrix number please length of number same as your column before";
                    Console.WriteLine("{0}\nYour first matrix column is {1}", typingerrorwords, column2);
                    goto typingnumbermatrix;
                }
                else
                {
                    int[] linearray1 = new int[column2];
                    linearray1 = Array.ConvertAll(thelines2, block => int.Parse(block));
                    for (int stepcolumn1 = 0; stepcolumn1 < column2; stepcolumn1++)
                    {
                        matrix2[steprow1, stepcolumn1] = linearray1[stepcolumn1];
                    }
                }
            }
            //recall the deter value and put at matrixdeterminant variable
                matrixdeterminant = Computedeter();
            string determinantname = "The Determinant Result.txt";
            DateTime today = DateTime.UtcNow.Date;
            using (StreamWriter filedeterminant = new StreamWriter(Path.Combine(location, determinantname)))
            {
                filedeterminant.WriteLine(today.ToString("MM/dd/yyyy hh:mm:ss\n"));
                filedeterminant.WriteLine("The Determinant is {0}", matrixdeterminant);
            }
            string resultdeterminantwords = "So determinant of matrix is : {0}";
                Console.WriteLine(resultdeterminantwords + "\nYour result has been printed at {1} '{2}'", matrixdeterminant, location, determinantname);
            Console.WriteLine(pak);
            Console.ReadKey();
            bool determenu = true;
            do
            {
                Console.Clear();
                Console.WriteLine("What Else?");
                Console.WriteLine("1. Continue to Invers?\n2. Reuse this method\n3. Back to Matrix Menu\n4. Back to Main Menu");
                string gotoinvers = Console.ReadLine();
                switch (gotoinvers)
                {
                    case "1":
                        InversMatrix();
                        break;
                    case "2":
                        DeterminantMatrix();
                        break;
                    case "3":
                        Matrix();
                        break;
                    case "4":
                        Main();
                        break;
                }
            }
            while (determenu);
                
            
        }
        public static float inversfromdeter;
        public static float[,] inversresult;
        //this method for matrix invers
        public static void InversMatrix()
        {
            Console.Clear();
            inversfromdeter = matrixdeterminant;
            Console.WriteLine("The determinant before is : {0}",inversfromdeter);
                int smallcolumnbefore = 2;
                int smallrowbefore = 2;
                int bigcolumnbefore = column2;
                int bigrowbefore = row2;
            if (row2 == 2 && column2 == 2){
                //adjoin formula for 2 row and 2 column
                int stepminus = 1;
                float[,] adjoin = new float[row2, column2];
                for (int steprow = 0; steprow < row2; steprow++)
                {
                    
                    for (int stepcolumn = 0; stepcolumn < column2; stepcolumn++)
                    {
                        
                        if (steprow == stepcolumn)
                        {
                            switch (steprow)
                            {
                                case 0:
                                    int stepdraw = steprow + 1;
                                    adjoin[stepdraw, stepdraw] = matrix2[steprow, stepcolumn];
                                    goto backcounting;
                                case 1:
                                    stepdraw = steprow - 1;
                                    adjoin[stepdraw, stepdraw] = matrix2[steprow, stepcolumn];
                                    goto backcounting;
                            }
                        }
                        else {
                            adjoin[steprow, stepcolumn] = matrix2[steprow, stepcolumn];
                            if (stepminus == 2 || stepminus == 3)
                            {
                                adjoin[steprow, stepcolumn] *= -1;
                            }
                        }

                    backcounting:
                        stepminus++;
                    }
                }
                //formula 2 row and 2 column of invers matrix
                inversresult = new float[row2, column2];
                for (int steprow = 0; steprow < row2; steprow++)
                {
                    for (int stepcolumn = 0; stepcolumn < column2; stepcolumn++)
                    {
                        inversresult[steprow, stepcolumn] = adjoin[steprow, stepcolumn] / matrixdeterminant;
                    }
                }
                string inversname = "The Invers Result.txt";
                DateTime today = DateTime.UtcNow.Date;
                using (StreamWriter fileinvers = new StreamWriter(Path.Combine(location, inversname)))
                {
                    fileinvers.WriteLine(today.ToString("MM/dd/yyyy hh:mm:ss\n"));
                    for (int steprow1 = 0; steprow1 < row2; steprow1++)
                    {
                        fileinvers.Write("| ");
                        for (int stepcolumn1 = 0; stepcolumn1 < column2; stepcolumn1++)
                        {
                            fileinvers.Write("{0} ", inversresult[steprow1, stepcolumn1]);
                        }
                        fileinvers.Write("|\n");
                    }
                }
                Console.WriteLine("Invers matrix :" + "\nYour result has been printed at {0} '{1}'", location, inversname);
                for (int steprow = 0; steprow < row2; steprow++)
                {
                    Console.Write("| ");
                    for (int stepcolumn = 0; stepcolumn < column2; stepcolumn++)
                    {
                        Console.Write("{0} ", inversresult[steprow, stepcolumn]);
                    }
                    Console.Write("|\n");
                }
            }
            if (row2 == 3 && column2 ==3) {
                //adjoin formula for 3 row and 3 column. i use the cofactor method in this case
                int steprowbig = 1;
                float[,] firstpart = new float[smallrowbefore, smallcolumnbefore];
                for (int steprowsmall = 0; steprowsmall < smallrowbefore; steprowsmall++)
                {
                    if (steprowsmall == 1)
                    {
                        steprowbig++;
                    }
                    int stepcolumnbig = 1;
                    for (int stepcolumnsmall = 0; stepcolumnsmall < smallcolumnbefore; stepcolumnsmall++)
                    {

                        firstpart[steprowsmall, stepcolumnsmall] = matrix2[steprowbig, stepcolumnbig];
                        stepcolumnbig++;
                    }

                }
                float[,] matrixinvers = new float[bigrowbefore, bigcolumnbefore];
                float[] multiplied = new float[smallcolumnbefore];
                int stepcolumnminus = 1;
                for (int stepcolumnplus = 0; stepcolumnplus < smallcolumnbefore; stepcolumnplus++)
                {

                    float multiply = firstpart[0, stepcolumnplus] * firstpart[1, stepcolumnminus];
                    stepcolumnminus -= 1;
                    multiplied[stepcolumnplus] = multiply;
                }
                matrixinvers[0, 0] = multiplied[0] - multiplied[1];

                float[,] secondpart = new float[smallrowbefore, smallcolumnbefore];
                steprowbig = 1;
                for (int steprowsmall = 0; steprowsmall < smallrowbefore; steprowsmall++)
                {
                    if (steprowsmall == 1)
                    {
                        steprowbig++;
                    }
                    int stepcolumnbig = 0;
                    for (int stepcolumnsmall = 0; stepcolumnsmall < smallcolumnbefore; stepcolumnsmall++)
                    {

                        secondpart[steprowsmall, stepcolumnsmall] = matrix2[steprowbig, stepcolumnbig];
                        stepcolumnbig += 2;
                    }

                }
                stepcolumnminus = 1;
                for (int stepcolumnplus = 0; stepcolumnplus < smallcolumnbefore; stepcolumnplus++)
                {

                    float multiply = secondpart[0, stepcolumnplus] * secondpart[1, stepcolumnminus];
                    stepcolumnminus -= 1;
                    multiplied[stepcolumnplus] = multiply;
                }
                matrixinvers[0, 1] = multiplied[0] - multiplied[1];

                float[,] thirdpart = new float[smallrowbefore, smallcolumnbefore];
                steprowbig = 1;
                for (int steprowsmall = 0; steprowsmall < smallrowbefore; steprowsmall++)
                {
                    if (steprowsmall == 1)
                    {
                        steprowbig++;
                    }
                    int stepcolumnbig = 0;
                    for (int stepcolumnsmall = 0; stepcolumnsmall < smallcolumnbefore; stepcolumnsmall++)
                    {

                        thirdpart[steprowsmall, stepcolumnsmall] = matrix2[steprowbig, stepcolumnbig];
                        stepcolumnbig++;
                    }

                }
                stepcolumnminus = 1;
                for (int stepcolumnplus = 0; stepcolumnplus < smallcolumnbefore; stepcolumnplus++)
                {

                    float multiply = thirdpart[0, stepcolumnplus] * thirdpart[1, stepcolumnminus];
                    stepcolumnminus -= 1;
                    multiplied[stepcolumnplus] = multiply;
                }
                matrixinvers[0, 2] = multiplied[0] - multiplied[1];
                float[,] fourthpart = new float[smallrowbefore, smallcolumnbefore];
                steprowbig = 0;
                for (int steprowsmall = 0; steprowsmall < smallrowbefore; steprowsmall++)
                {
                    if (steprowsmall == 1)
                    {
                        steprowbig += 2;
                    }
                    int stepcolumnbig = 1;
                    for (int stepcolumnsmall = 0; stepcolumnsmall < smallcolumnbefore; stepcolumnsmall++)
                    {

                        fourthpart[steprowsmall, stepcolumnsmall] = matrix2[steprowbig, stepcolumnbig];
                        stepcolumnbig++;
                    }

                }
                stepcolumnminus = 1;
                for (int stepcolumnplus = 0; stepcolumnplus < smallcolumnbefore; stepcolumnplus++)
                {

                    float multiply = fourthpart[0, stepcolumnplus] * fourthpart[1, stepcolumnminus];
                    stepcolumnminus -= 1;
                    multiplied[stepcolumnplus] = multiply;
                }
                matrixinvers[1, 0] = multiplied[0] - multiplied[1];
                float[,] fifthpart = new float[smallrowbefore, smallcolumnbefore];
                steprowbig = 0;
                for (int steprowsmall = 0; steprowsmall < smallrowbefore; steprowsmall++)
                {
                    if (steprowsmall == 1)
                    {
                        steprowbig += 2;
                    }
                    int stepcolumnbig = 0;
                    for (int stepcolumnsmall = 0; stepcolumnsmall < smallcolumnbefore; stepcolumnsmall++)
                    {

                        fifthpart[steprowsmall, stepcolumnsmall] = matrix2[steprowbig, stepcolumnbig];
                        stepcolumnbig += 2;
                    }

                }
                stepcolumnminus = 1;
                for (int stepcolumnplus = 0; stepcolumnplus < smallcolumnbefore; stepcolumnplus++)
                {

                    float multiply = fifthpart[0, stepcolumnplus] * fifthpart[1, stepcolumnminus];
                    stepcolumnminus -= 1;
                    multiplied[stepcolumnplus] = multiply;
                }
                matrixinvers[1, 1] = multiplied[0] - multiplied[1];
                float[,] sixthpart = new float[smallrowbefore, smallcolumnbefore];
                steprowbig = 0;
                for (int steprowsmall = 0; steprowsmall < smallrowbefore; steprowsmall++)
                {
                    if (steprowsmall == 1)
                    {
                        steprowbig += 2;
                    }
                    int stepcolumnbig = 0;
                    for (int stepcolumnsmall = 0; stepcolumnsmall < smallcolumnbefore; stepcolumnsmall++)
                    {

                        sixthpart[steprowsmall, stepcolumnsmall] = matrix2[steprowbig, stepcolumnbig];
                        stepcolumnbig++;
                    }

                }
                stepcolumnminus = 1;
                for (int stepcolumnplus = 0; stepcolumnplus < smallcolumnbefore; stepcolumnplus++)
                {

                    float multiply = sixthpart[0, stepcolumnplus] * sixthpart[1, stepcolumnminus];
                    stepcolumnminus -= 1;
                    multiplied[stepcolumnplus] = multiply;
                }
                matrixinvers[1, 2] = multiplied[0] - multiplied[1];
                float[,] seventhpart = new float[smallrowbefore, smallcolumnbefore];
                steprowbig = 0;
                for (int steprowsmall = 0; steprowsmall < smallrowbefore; steprowsmall++)
                {
                    if (steprowsmall == 1)
                    {
                        steprowbig++;
                    }
                    int stepcolumnbig = 1;
                    for (int stepcolumnsmall = 0; stepcolumnsmall < smallcolumnbefore; stepcolumnsmall++)
                    {

                        seventhpart[steprowsmall, stepcolumnsmall] = matrix2[steprowbig, stepcolumnbig];
                        stepcolumnbig++;
                    }

                }
                stepcolumnminus = 1;
                for (int stepcolumnplus = 0; stepcolumnplus < smallcolumnbefore; stepcolumnplus++)
                {

                    float multiply = seventhpart[0, stepcolumnplus] * seventhpart[1, stepcolumnminus];
                    stepcolumnminus -= 1;
                    multiplied[stepcolumnplus] = multiply;
                }
                matrixinvers[2, 0] = multiplied[0] - multiplied[1];
                float[,] eighthpart = new float[smallrowbefore, smallcolumnbefore];
                steprowbig = 0;
                for (int steprowsmall = 0; steprowsmall < smallrowbefore; steprowsmall++)
                {
                    if (steprowsmall == 1)
                    {
                        steprowbig++;
                    }
                    int stepcolumnbig = 0;
                    for (int stepcolumnsmall = 0; stepcolumnsmall < smallcolumnbefore; stepcolumnsmall++)
                    {

                        eighthpart[steprowsmall, stepcolumnsmall] = matrix2[steprowbig, stepcolumnbig];
                        stepcolumnbig += 2;
                    }

                }
                stepcolumnminus = 1;
                for (int stepcolumnplus = 0; stepcolumnplus < smallcolumnbefore; stepcolumnplus++)
                {

                    float multiply = eighthpart[0, stepcolumnplus] * eighthpart[1, stepcolumnminus];
                    stepcolumnminus -= 1;
                    multiplied[stepcolumnplus] = multiply;
                }
                matrixinvers[2, 1] = multiplied[0] - multiplied[1];
                float[,] ninthpart = new float[smallrowbefore, smallcolumnbefore];
                steprowbig = 0;
                for (int steprowsmall = 0; steprowsmall < smallrowbefore; steprowsmall++)
                {
                    if (steprowsmall == 1)
                    {
                        steprowbig++;
                    }
                    int stepcolumnbig = 0;
                    for (int stepcolumnsmall = 0; stepcolumnsmall < smallcolumnbefore; stepcolumnsmall++)
                    {

                        ninthpart[steprowsmall, stepcolumnsmall] = matrix2[steprowbig, stepcolumnbig];
                        stepcolumnbig++;
                    }

                }
                stepcolumnminus = 1;
                for (int stepcolumnplus = 0; stepcolumnplus < smallcolumnbefore; stepcolumnplus++)
                {

                    float multiply = ninthpart[0, stepcolumnplus] * ninthpart[1, stepcolumnminus];
                    stepcolumnminus -= 1;
                    multiplied[stepcolumnplus] = multiply;
                }
                matrixinvers[2, 2] = multiplied[0] - multiplied[1];
                int stepinvers = 1;
                int stepeven = 2;
                for (int steprow = 0; steprow < bigrowbefore; steprow++)
                {
                    for (int stepcolumn = 0; stepcolumn < bigcolumnbefore; stepcolumn++)
                    {
                        if (stepinvers == stepeven)
                        {
                            matrixinvers[steprow, stepcolumn] *= -1;
                            stepeven += 2;
                        }
                        stepinvers++;
                    }
                }
                float[,] transposedinvers = new float[row2, column2];
                for (int steprow = 0; steprow < bigrowbefore; steprow++)
                {
                    for (int stepcolumn = 0; stepcolumn < bigcolumnbefore; stepcolumn++)
                    {
                        transposedinvers[stepcolumn, steprow] = matrixinvers[steprow, stepcolumn];
                    }
                    
                }
                //formula 3 row and 3 column of invers matrix
                inversresult = new float[row2, column2];
                for (int steprow = 0; steprow < bigrowbefore; steprow++)
                {
                    for (int stepcolumn = 0; stepcolumn < bigcolumnbefore; stepcolumn++)
                    {
                        inversresult[steprow, stepcolumn] = transposedinvers[steprow, stepcolumn] / matrixdeterminant;
                    }
                }
                string inversname = "The Invers Result.txt";
                DateTime today = DateTime.UtcNow.Date;
                using (StreamWriter fileinvers = new StreamWriter(Path.Combine(location, inversname)))
                {
                    fileinvers.WriteLine(today.ToString("MM/dd/yyyy hh:mm:ss\n"));
                    for (int steprow1 = 0; steprow1 < row2; steprow1++)
                    {
                        fileinvers.Write("| ");
                        for (int stepcolumn1 = 0; stepcolumn1 < column2; stepcolumn1++)
                        {
                            fileinvers.Write("{0} ", inversresult[steprow1, stepcolumn1]);
                        }
                        fileinvers.Write("|\n");
                    }
                }
                Console.WriteLine("Invers Matrix :" + "\nYour result has been printed at {0} '{1}'", location, inversname);
                for (int steprow = 0; steprow < bigrowbefore; steprow++)
                {
                    Console.Write("| ");
                    for (int stepcolumn = 0; stepcolumn < bigcolumnbefore; stepcolumn++)
                    {
                        Console.Write("{0} ", inversresult[steprow, stepcolumn]);
                    }
                    Console.Write("|\n");
                }
            }
            Console.WriteLine(pak);
            Console.ReadKey();
            bool inversmenu = true;
            do
            {
                Console.Clear();
                Console.WriteLine("What Else?");
                Console.WriteLine("1. Continue to Division\n2. Back to Determinant\n3. Back to Matrix Menu\n4. Back to Main Menu");
                string gotodivided = Console.ReadLine();
                switch (gotodivided)
                {
                    case "1":
                        DivisionMatrix();
                        break;
                    case "2":
                        DeterminantMatrix();
                        break;
                    case "3":
                        Matrix();
                        break;
                    case "4":
                        Main();
                        break;
                }
            }
            while (inversmenu);
            
            
        }
        //this method for matrix division
        public static void DivisionMatrix()
        {
            Console.Clear();
            //from determinant before user only input the second matrix so in here will asking again for first matrix
            int row1 = row2;
            int column1 = column2;
            int[,] matrix1 = new int[row1, column1];
        typingnumbermatrix:
            string intructioninputmatrix1 = "So input your first matrix number with the correct format using space to seperate each column";
            Console.WriteLine(intructioninputmatrix1);
            for (int steprow1 = 0; steprow1 < row1; steprow1++)
            {
                string line1 = Console.ReadLine();
                string[] thelines1 = line1.Split(' ');
                if (thelines1.Length > column1 || thelines1.Length < column1)
                {
                    Console.Clear();
                    string typingerrorwords = "You have wrong to input your matrix number please length of number same as your column before";
                    Console.WriteLine("{0}\nYour first matrix column is {1}", typingerrorwords, column1);
                    goto typingnumbermatrix;
                }
                else
                {
                    int[] linearray1 = new int[column1];
                    linearray1 = Array.ConvertAll(thelines1, block => int.Parse(block));
                    for (int stepcolumn1 = 0; stepcolumn1 < column1; stepcolumn1++)
                    {
                        matrix1[steprow1, stepcolumn1] = linearray1[stepcolumn1];
                    }
                }

            }
            //from first matrix will multiplying by the invers
            float[,] matrixmultipication = new float[row2, column2];
            float summultiply;
            for (int steprow1 = 0; steprow1 < row1; steprow1++)
            {
                for (int stepcolumn2 = 0; stepcolumn2 < column2; stepcolumn2++)
                {
                    summultiply = 0;
                    for (int steprow2 = 0; steprow2 < row2; steprow2++)
                    {
                        summultiply = summultiply + matrix1[steprow1, steprow2] * inversresult[steprow2, stepcolumn2];
                        matrixmultipication[steprow1, stepcolumn2] = summultiply;
                    }
                }
            }
            string divisionname = "The Division Result.txt";
            DateTime today = DateTime.UtcNow.Date;
            using (StreamWriter filedivision = new StreamWriter(Path.Combine(location, divisionname)))
            {
                filedivision.WriteLine(today.ToString("MM/dd/yyyy hh:mm:ss\n"));
                for (int steprow1 = 0; steprow1 < row1; steprow1++)
                {
                    filedivision.Write("| ");
                    for (int stepcolumn1 = 0; stepcolumn1 < column2; stepcolumn1++)
                    {
                        filedivision.Write("{0} ", matrixmultipication[steprow1, stepcolumn1]);
                    }
                    filedivision.Write("|\n");
                }
            }
            Console.WriteLine("The Matrix has been divived :" + "\nYour result has been printed at {0} '{1}'", location, divisionname);
            for (int steprow = 0; steprow < row2; steprow++)
            {
                Console.Write("| ");
                for (int stepcolumn = 0; stepcolumn < column2; stepcolumn++)
                {
                    Console.Write("{0} ", matrixmultipication[steprow, stepcolumn]);
                }
                Console.Write("|\n");
            }
            Console.WriteLine(pak);
            Console.ReadKey();
            bool divisionmenu = true;
            do
            {
                Console.Clear();
                Console.WriteLine("What Else?");
                Console.WriteLine("1. Changing the first matrix\n2. Back to Determinant Matrix\n3. Back to Matrix Menu\n4. Back to Main Menu");
                string gotodivided = Console.ReadLine();
                switch (gotodivided)
                {
                    case "1":
                        DivisionMatrix();
                        break;
                    case "2":
                        DeterminantMatrix();
                        break;
                    case "3":
                        Matrix();
                        break;
                    case "4":
                        Main();
                        break;
                }
            }
            while (divisionmenu);
        }
    }
}
