using ConsoleEnhancers;

var canvas = new ASCIICanvas(200, 200);

//System.Threading.Thread.Sleep(5000);

demo();
void demo()
{

    for(int y = 0;y < 200; y+=10)
    {
        for (int x = 0; x < 200; x+=10)
        {
            canvas.FillRect(x,y,10,10);
        }
        canvas.fillStyle = EscapeColor.Random();
    }
    canvas.renderBuffer();
    canvas.flushBuffer();
    demo();
}

