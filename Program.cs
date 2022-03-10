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

            #region The easiest proof, using the Gregory-Liebniz Series
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

            Console.WriteLine(PI);
            #endregion

        }
    }
}
