using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CardsDll
{
    public class Cards
    {

        [DllImport(@"cards.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool cdtInit(ref int width, ref int height);

        [DllImport(@"cards.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void cdtTerm();

        [DllImport(@"cards.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool cdtDraw(IntPtr hdc, int x, int y, int card, int mode, long color);


        public Cards()
        {
            int width = 71;
            int height = 95;
            if (!cdtInit(ref width, ref height))
                throw new Exception("cards.dll did not load");
        }

        public void Dispose()
        {
            cdtTerm();
        }

        public bool DrawCard(IntPtr hdc, int x, int y, int card, int mode, long color)
        {
            try
            {
                return cdtDraw(hdc, x, y, card, mode, color);
            }
            catch
            {
                return true;
            }
        }

        public bool DrawCardBack(IntPtr hdc, int x, int y, int back)
        {
            return cdtDraw(hdc, x, y, back, 1, 912420);
        }
    }
}