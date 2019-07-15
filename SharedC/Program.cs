using System;
using System.Runtime.InteropServices;

namespace SharedC
{
    class Program
    {
        struct GoString
        {
            public IntPtr p;
            public int n;
        }

        struct GoSlice
        {
            public IntPtr data;
            public int len;
            public int cap;
        }

        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("GODEBUG", "cgocheck=0");

            int a       = 10;
            int b       = 2;
            double x    = 100;

            int addResult       = GoMath.Add(a, b);
            int subResult       = GoMath.Sub(a, b);
            double cosineResult = GoMath.Cosine(x);
            GoSlice vals        = GoMath.Sort();

            int[] arr   = new int[vals.len];
            for (int i  = 0; i < vals.len; i++)
            {
                arr[i]  = Marshal.ReadInt32(vals.data, i * Marshal.SizeOf(typeof(Int32)));
            }

            Console.WriteLine($"Add: {addResult}");
            Console.WriteLine($"Sub: {subResult}");
            Console.WriteLine($"Cos: {cosineResult}");
            
            for(int i = 0; i < arr.Length; i++)
            {
                if (i == (arr.Length - 1))
                {
                    Console.Write($"{arr[i]}\n");
                }
                else if(i == 0)
                {
                    Console.Write($"Array: {arr[i]}");
                }
                else
                {
                    Console.Write($"{arr[i]}, ");
                }
            }

            GoHello.HelloWorld();
        }

        static class GoMath
        {
            [DllImport("math.win.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern int Add(int a, int b);

            [DllImport("math.win.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern int Sub(int a, int b);

            [DllImport("math.win.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern double Cosine(double x);

            [DllImport("math.win.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern GoSlice Sort();
        }

        static class GoHello
        {
            [DllImport("helloworld.win.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern void HelloWorld();
        }
    }
}
