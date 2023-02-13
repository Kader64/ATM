using ConsoleEnhancers;
using System.Runtime.InteropServices;


class Program
{

    static void Main(string[] args)
    {

        ConsoleGUI.SetConsoleFont(3,3,0,0);
        ConsoleGUI.blockWindowResize();
        Console.SetWindowSize(200, 200);
        Console.SetBufferSize(200, 200);

        var canvas = new ASCIICanvas(100, 100);

        demo();

        void demo(){
            for (int y = 0; y < 100; y += 10)
            {
                for (int x = 0; x < 100; x += 10)
                {
                    canvas.StrokeRect(x, y, 10, 10);
                    canvas.strokeStyle = EscapeColor.Random();
                }
                
            }
            canvas.renderBuffer();
            Thread.Sleep(500);
            demo();
        }
        
    }
}


