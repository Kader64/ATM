using ConsoleEnhancers;

var canvas = new ASCIICanvas(200, 200);

System.Threading.Thread.Sleep(5000);

demo();
void demo()
{
    int x = 0;
    int y = 0;
    for (int i = 0; i < 200; i++)
    {
        canvas.fillStyle = EscapeColor.Random();
        canvas.SetPoint(x, y);
        System.Threading.Thread.Sleep(50);
        x++;
        y++;
    }
    canvas.flushBuffer();
    demo();
}
