using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BilibiliProjects
{
    /// <summary>
    /// 提升SetPixel和GetPixel的速度
    /// 来源于网络
    /// </summary>
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        int[] Bits = null;
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new int[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, 
                PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color colour)
        {
            SetPixelRGB(x, y, colour.ToArgb());
        }

        public void SetPixelRGB(int x, int y, int colour)
        {
            Bits[x + (y * Width)] = colour;
        }

        public Color GetPixel(int x, int y)
        {
            return Color.FromArgb(GetPixelRGB(x, y));
        }

        public int GetPixelRGB(int x, int y)
        {
            return Bits[x + (y * Width)];
        }

        private bool Disposed = false;

        public void Dispose()
        {
            if (Disposed)
                return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
