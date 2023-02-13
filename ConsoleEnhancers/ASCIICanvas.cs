using System.Text;

namespace ConsoleEnhancers
{

    public class ASCIICanvas
    {

        private int CanvasW;
        private int CanvasH;

        public string fillStyle;
        public string strokeStyle;

        private string[,] buffer;

        public ASCIICanvas(int w, int h) {

            CanvasH = h;
            CanvasW = h;

            buffer = new string[h,w];

            fillStyle = EscapeColor.Color("White");
            strokeStyle = EscapeColor.Color("White");
        }

        public void flushBuffer()
        {
            buffer = new string[CanvasH, CanvasW];
        }

        public void renderBuffer()
        {
            Console.SetCursorPosition(0,0);
            StringBuilder view = new StringBuilder();
            for(int y=0; y<CanvasH;y++)
            {
                string xLine = "";
                for (int x = 0; x < CanvasW; x++)
                {
                    xLine += buffer[y, x] != null ? buffer[y, x] : " ";
                }
                view.AppendLine(xLine);
            }
            Console.WriteLine(view.ToString());
        }

        public void SetPoint(int x, int y, bool autoBufferRender = true)
        {
            buffer[y, x] = fillStyle+"█";
            if (autoBufferRender) renderBuffer(); 
        }



        public void FillRect(int x, int y , int w, int h)
        {

        }

        public void StrokeRect(int x, int y, int w, int h)
        {

        }

        public void strokeLine(int x1, int y1, int x2, int y2, int t) 
        { 
            
        }

    }
}