using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class HelloWorld
{
    public static void Main(string[] args)
    {

        int num = 0, num1 = 0, num2 = 0, num3 = 0, height_rec = 0, width_rec = 0, height_tri = 0, width_tri = 0, calcOrprint = 0;
        while (num3 != 1)
        {
            Console.WriteLine("enter number, to choose rectangle press 1 and to choose triangular press 2. to exit press 3: ");
            num = int.Parse(Console.ReadLine());

            //מלבן
            if (num == 1)
            {
                num1 = num;
                Console.WriteLine("enter the height and the width of the rectangle");
                height_rec = int.Parse(Console.ReadLine());
                width_rec = int.Parse(Console.ReadLine());

                //בדיקה האם ריבוע או הפרש אורכי הצלעות גדול מ5
                if (height_rec == width_rec || height_rec - width_rec > 5 || width_rec - height_rec > 5)
                {
                    Console.WriteLine("the area is: " + height_rec * width_rec);
                }
                else
                {
                    Console.WriteLine("the perimeter is: " + ((height_rec * 2) + (width_rec * 2)));
                }
            }

            //משולש
            else
            if (num == 2)
            {
                num2 = num;
                Console.WriteLine("enter the height and the width of the triangular");
                height_tri = int.Parse(Console.ReadLine());
                width_tri = int.Parse(Console.ReadLine());
                Console.WriteLine("choose 1 to calculate the perimeter and 2 to print");
                calcOrprint = int.Parse(Console.ReadLine());
                //חישוב ההיקף
                if (calcOrprint == 1)
                {
                    int perimeter = (height_tri - 1) * 2 + (width_tri - 1);
                    Console.WriteLine("the perimeter is: " + perimeter);
                }
                //הדפסת המשולש
                else if (calcOrprint == 2)
                {
                    //בדיקה האם הרוחב זוגי או שהרוחב ארוך ביותר מפי 2 מהגובה
                    if (width_tri % 2 == 0 || width_tri > height_tri * 2)
                    {
                        Console.WriteLine("Unable to print the triangle");
                    }
                    else
                    {
                        //כתות הרווח מימין ומשמאל
                        int space = (width_tri - 1) / 2, numGroups = (width_tri - 2) / 2, nump = 3, numLinesInGroup = (height_tri - 2) / numGroups;
                        //הדפסת הכוכבית הראשונה כולל רווחים
                        for (int j = 0; j < space; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.Write("*");
                        for (int j = 0; j < space; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine();
                        space--;

                        //לולאה שעוברת על מס' השורות במשולש עם אותה כמות כוכביות
                        for (int i = 0; i < numGroups; i++, space--, nump += 2)
                        {
                            if (nump == 3)
                            {
                                numLinesInGroup += (height_tri - 2) % numGroups;
                            }
                            //לולאה שמדפיסה שורת כוכביות
                            for (int k = 0; k < numLinesInGroup; k++)
                            {
                                for (int j = 0; j < space; j++)
                                {
                                    Console.Write(" ");
                                }
                                for (int j = 0; j < nump; j++)
                                {
                                    Console.Write("*");
                                }
                                for (int j = 0; j < space; j++)
                                {
                                    Console.Write(" ");
                                }
                                Console.WriteLine();
                            }
                        }

                        //הדפסת השורה האחרונה - מב' הכוכביות כרוחב המשולש
                        for (int i = 0; i < width_tri; i++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }
                }
            }
            //יציאה
            else
            if (num == 3)
            {
                num3 = 1;
                Console.WriteLine("exit");
            }
        }

    }
}
