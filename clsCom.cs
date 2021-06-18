using System;
using System.Collections.Generic;
using System.Text;

namespace Draw3D
{
    class clsCom
    {
        public static double PAI = 3.14159;
        public static int TEXT_LINE_D = 2;		// 文字と直線の間隔
        public static int TEXT_TEXT_D = 2;		// 文字と文字の間隔
        public static int XSU = 50;             // Ｘ線数
        public static int YSU = 50;             // Ｙ線数

        public static int zsub(int a, int b)
        {
            return (System.Math.Abs(b - a));
        }

    }

    public class clsPnt
    {
        public int x;
        public int y;
    }
}
