using System;

namespace Approximation_Of_PI
{
    class Program
    {
        static void Main(string[] args)
        {

            #region The geometrical proof, the data type decimal stores too little decimals for this to work (i think)
            /*
            int radius = 100; //doesn't matter
            int amountOfTriangles = 1; //the larger the number, the more precise answer
            
            try
            {
                Console.WriteLine("How many triangles?");
                amountOfTriangles = int.Parse(Console.ReadLine());
            }
            catch (FormatException fe) {
                Console.WriteLine("");
                Console.WriteLine("Couldn't convert the amount of triangles to int"); 
            };

            //angle per triangle 
            decimal angle = 360 / amountOfTriangles;
            
            //each triangle can be seen as an isosceles triangle if you remove the bottom curve 
            //two of the sides will be equal to the radius, and the last one can be calculated
            //by first dividing it into two and seeing it as a right-angled triangle
            decimal triangleBase = 2 * radius * (decimal)Math.Sin((double)angle / 2);

            decimal circumference = triangleBase * amountOfTriangles * 2;
            decimal area = triangleBase * amountOfTriangles * radius;

            //knowing the area (and the radius), we can now calculate the value of PI
            //circumference was also calculated just for the sake of it 

            // area = radius * radius * PI
            // circumference = 2 * radius * PI

            decimal PI = circumference / (2 * radius);


            Console.WriteLine(PI); 
            */
            #endregion 

            #region The easiest "proof", using the Gregory-Liebniz Series
            int amountOfTerms = 1; 
            try
            {
                Console.WriteLine("How many terms? (must be larger than 1)");
                amountOfTerms = int.Parse(Console.ReadLine());
            } catch(FormatException fe) {
                Console.WriteLine("");
                Console.WriteLine("Couldn't convert the amount of terms to integer");
            };

            if (amountOfTerms < 1)
                amountOfTerms = 1; 

            decimal PI = 1; 
            for(int i = 1; i <= amountOfTerms; i++)
            {
                decimal number = i * 2 + 1; //3, 5, 7, 9, 11...
                PI += (decimal)((1/number) * (decimal)Math.Pow(-1, i)); 
            }
            PI *= 4;

            Console.WriteLine("");
            Console.WriteLine(PI);
            #endregion
                
            #region I was kidding, this is the easiest way
            //Console.WriteLine(Math.PI);
            #endregion

            #region The BBP formula (doesn't completely work)
            int levelOfPrecision = 1;
            try
            {
                Console.WriteLine("Level of precision? (must be larger than 0)");
                levelOfPrecision = int.Parse(Console.ReadLine());
            }
            catch (FormatException fe)
            {
                Console.WriteLine("");
                Console.WriteLine("Couldn't convert the answer to integer");
            };

            if (levelOfPrecision < 1)
                levelOfPrecision = 1;

            decimal PI = 0m;
            for (decimal k = 0; k < levelOfPrecision; k++)
            {
                decimal number = (decimal)((decimal)(1 / Math.Pow(16, (int)k)) * 
                    ((4 / (8 * k + 1)) - (2 / (8 * k + 4) - (1 / (8 * k + 5) - (1 / (8 * k + 6))))));
                PI += number;
            }

            Console.WriteLine("");
            Console.WriteLine(PI);
            #endregion
                
        }
                                     
         //static decimal HexPow(decimal num,  decimal k)
        //{

        //    decimal d = num;
        //    for(decimal i = 0m; i < k; i++)
        //    {
        //        d *= num; 
        //    }

        //    return d; 

        //}
    }
}
