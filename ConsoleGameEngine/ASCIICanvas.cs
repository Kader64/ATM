using System.Drawing;
using System.IO;
using System.Text;

namespace ConsoleGameEngine
{

    public class ASCIICanvas
    {

        private int CanvasW;
        private int CanvasH;

        public string fillStyle;
        public string strokeStyle;

        private string[,] buffer;
        private string[,] escapeCodes;

        private StringBuilder view;
        private StringBuilder row;

        public ASCIICanvas(int w, int h)
        {

            CanvasH = h + 1;
            CanvasW = w + 1;

            buffer = new string[CanvasH, CanvasW];
            escapeCodes = new string[CanvasH, CanvasW];

            fillStyle = EscapeColor.Color("White");
            strokeStyle = EscapeColor.Color("White");

            ConsoleManager.blockWindowResize();

            view = new StringBuilder();
            row = new StringBuilder();

        }
        public void SetupConsole()
        {
            ConsoleManager.SetConsoleFont(3, 3, 0, 0);
            Console.SetBufferSize(CanvasW, CanvasH );
            Console.SetWindowSize(CanvasW + 4, CanvasH + 4);
        }

        public void FlushBuffer()
        {
            buffer = new string[CanvasH, CanvasW];
            escapeCodes = new string[CanvasH, CanvasW];
        }

        public void RenderBuffer()
        {
            view.Clear();
            row.Clear();
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < CanvasH; y++)
            {
                row.Clear();
                for (int x = 0; x < CanvasW; x++)
                {
                    if (x == 0) row.Append(escapeCodes[y, x]);
                    else if (escapeCodes[y, x] != escapeCodes[y, x - 1]) row.Append(escapeCodes[y, x]);
                    row.Append(buffer[y, x] != null ? buffer[y, x] : " ");
                }
                view.AppendLine(row.ToString());
            }
            Console.Write(view.ToString());
        }

        public void SetPoint(int x, int y, bool autoBufferRender = false)
        {
            buffer[y, x] = fillStyle + "█";
            if (autoBufferRender) RenderBuffer();
        }

        public void FillRect(int x, int y, int w, int h, bool autoBufferRender = false)
        {
            for (int rH = 0; rH < h; rH++)
            {
                for (int rW = 0; rW < w; rW++)
                {
                    if (y + rH >= CanvasH || x + rW >= CanvasW || x + rW < 0 || y + rH < 0) continue;
                    buffer[y + rH, x + rW] = "█";
                    escapeCodes[y + rH, x + rW] = fillStyle;
                }
            }
            if (autoBufferRender) RenderBuffer();
        }

        public void StrokeRect(int x, int y, int w, int h, bool autoBufferRender = false)
        {
            for (int rH = 0; rH < h; rH++)
            {
                for (int rW = 0; rW < w; rW++)
                {
                    if (y + rH >= CanvasH || x + rW >= CanvasW || x + rW < 0 || y + rH < 0) continue;
                    if (rH == 0 || rW == 0 || rW == w - 1 || rH == h - 1) 
                    {
                        buffer[y + rH, x + rW] = "█";
                        escapeCodes[y + rH, x + rW] = strokeStyle;
                    } 
                }
            }
            if (autoBufferRender) RenderBuffer();
        }

        public void StrokeLine(int x1, int y1, int x2, int y2)
        {
            int w = x2 - x1;
            int h = y2 - y1;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                if (y1 >= CanvasH || x1 >= CanvasW || x1 < 0 || y1 < 0) continue;
                buffer[y1, x1] = strokeStyle + "█";
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x1 += dx1;
                    y1 += dy1;
                }
                else
                {
                    x1 += dx2;
                    y1 += dy2;
                }
            }
        }

    }
}