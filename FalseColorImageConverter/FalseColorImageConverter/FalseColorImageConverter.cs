using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace FalseColorImageConverter
{
    public class FalseColorImageConverter
    {

        public Bitmap grayBitmap, colorBitmap;
        public int[,] colorDiagram = new int[256, 3];

        public FalseColorImageConverter()
        {
            resetColorDiagram(0);
        }

        public void resetColorDiagram(double degreeShift)
        {
            for (int i = 0; i < 256; i++)
            {
                double h = i * 360 / 256 + degreeShift;
                h = truncate(h, 0, 360);
                convertHSVToRGB(h, 1.0, 1.0, out colorDiagram[i, 0], out colorDiagram[i, 1], out colorDiagram[i, 2]);
            }
        }

        public void setBitmap(Bitmap bitmap, double contrast)
        {
            grayBitmap = bitmap;
            colorBitmap = new Bitmap(grayBitmap.Width, grayBitmap.Height);
            convertGrayBitmap();
            convertColorBitmap(contrast);
        }

        void convertGrayBitmap()
        {
            double[] p = new double[3] { 0.114, 0.587, 0.299 };
            int width = grayBitmap.Width, height = grayBitmap.Height;
            BitmapData bitmapData = grayBitmap.LockBits(new System.Drawing.Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int stride = bitmapData.Stride;
            unsafe
            {
                byte* ptr = (byte*)bitmapData.Scan0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        double g = 0;
                        for (int i = 0; i < 3; i++)
                        {
                            g += p[i] * ptr[(x * 3) + y * stride + i];
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            ptr[(x * 3) + y * stride + i] = (byte)(g);
                        }
                    }
                }
            }
            grayBitmap.UnlockBits(bitmapData);
        }

        public void convertColorBitmap(double contrast)
        {
            contrast /= 100;
            int width = grayBitmap.Width, height = grayBitmap.Height;
            BitmapData grayBitmapData = grayBitmap.LockBits(new System.Drawing.Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData colorBitmapData = colorBitmap.LockBits(new System.Drawing.Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int stride = grayBitmapData.Stride;
            unsafe
            {
                byte* ptrGray = (byte*)grayBitmapData.Scan0;
                byte* ptrColor = (byte*)colorBitmapData.Scan0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int g = ptrGray[(x * 3) + y * stride];
                        for (int i = 0; i < 3; i++)
                        {
                            double z = colorDiagram[g, 2 - i];
                            z = truncate(contrast * (z - 128) + 128, 0, 256);
                            ptrColor[(x * 3) + y * stride + i] = (byte)z;
                        }
                    }
                }
            }
            grayBitmap.UnlockBits(grayBitmapData);
            colorBitmap.UnlockBits(colorBitmapData);
        }

        void convertHSVToRGB(double h, double S, double V, out int r, out int g, out int b)
        {
            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {
                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;
                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;
                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;
                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;
                    default:
                        R = G = B = V;
                        break;
                }
            }
            r = clamp((int)(R * 255.0));
            g = clamp((int)(G * 255.0));
            b = clamp((int)(B * 255.0));
        }

        int clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }

        double truncate(double value, double down, double up)
        {
            while (value < down) value = value + (up - down);
            while (value >= up) value = value - (up - down);
            return value;
        }
    }
}
