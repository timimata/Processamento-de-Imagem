using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Emgu.CV.CvEnum;
using System.IO;
using System.Linq;

namespace CG_OpenCV
{
    class ImageClass
    {
       
        /// <summary>
        /// Image Negative using EmguCV library
        /// Slower method
        /// </summary>
        /// <param name="img">Image</param>
        public static void Negative(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red;
                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;
                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // store in the image
                            dataPtr[0] = (byte)Math.Round(((int)255 - blue) / 1.0);
                            dataPtr[1] = (byte)Math.Round(((int)255 - green) / 1.0);
                            dataPtr[2] = (byte)Math.Round(((int)255 - red) / 1.0);

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
            //for (y = 0; y < img.Height; y++)
            //{
            // for (x = 0; x < img.Width; x++)
            // {
            // acesso directo : mais lento 
            //   aux = img[y, x];
            //  img[y, x] = new Bgr(255 - aux.Blue, 255 - aux.Green, 255 - aux.Red);
            // }
            //  }
        }
        /// <summary>
        /// Convert to gray
        /// Direct access to memory - faster method
        /// </summary>
        public static string frase = "";
        /// <param name="img">image</param>
        public static void ConvertToGray(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red, gray;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // convert to gray
                            gray = (byte)Math.Round(((int)blue + green + red) / 3.0);

                            // store in the image
                            dataPtr[0] = gray;
                            dataPtr[1] = gray;
                            dataPtr[2] = gray;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }
        public static void BrightContrast(Image<Bgr, byte> img, int bright, double contrast)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                int brightblue = 0;
                int brightgreen = 0;
                int brightred = 0;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            brightblue = (int)Math.Round((contrast * blue) + bright);
                            brightgreen = (int)Math.Round((contrast * green) + bright);
                            brightred = (int)Math.Round((contrast * red) + bright);
                            // store in the image
                            dataPtr[0] = (byte)brightblue;
                            dataPtr[1] = (byte)brightgreen;
                            dataPtr[2] = (byte)brightred;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }
        public static void RedChannel(Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;
                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // store in the image
                            dataPtr[0] = red;
                            dataPtr[1] = red;
                            dataPtr[2] = red;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }

            }

        }
        public static void BlueChannel(Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;
                int step = m.widthStep;
                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = (dataPtr + x * nChan + y * step)[0];
                            green = (dataPtr + x * nChan + y * step)[1];
                            red = (dataPtr + x * nChan + y * step)[2];

                            // store in the image
                            dataPtr[0] = blue;
                            dataPtr[1] = blue;
                            dataPtr[2] = blue;

                            // advance the pointer to the next pixel
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)

                    }
                }

            }

        }
        public static void GreenChannel(Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;
                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];

                            // store in the image
                            dataPtr[0] = green;
                            dataPtr[1] = green;
                            dataPtr[2] = green;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }
        public static void Translation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, int dx, int dy)
        {
            unsafe
            {

                MIplImage m = img.MIplImage;
                MIplImage mUndo = imgCopy.MIplImage;
                byte* dataPtrimgCopy = (byte*)mUndo.imageData.ToPointer();
                byte* dataPtr = (byte*)m.imageData.ToPointer();
                byte* dataPtrimgCopy_aux;
                int width = imgCopy.Width;
                int height = imgCopy.Height;
                int nChan = m.nChannels;
                int step = m.widthStep;
                int padding = m.widthStep - m.nChannels * m.width;
                byte blue, green, red;
                int x_o, y_o;
                int y, x;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            x_o = x - dx;
                            y_o = y - dy;
                            dataPtrimgCopy_aux = (byte*)(dataPtrimgCopy + x_o * nChan + y_o * step);
                            if (x_o < width && x_o >= 0 && y_o < height && y_o >= 0)
                            {
                                blue = (byte)Math.Round((double)(dataPtrimgCopy_aux[0]));
                                green = (byte)Math.Round((double)(dataPtrimgCopy_aux[1]));
                                red = (byte)Math.Round((double)(dataPtrimgCopy_aux[2]));
                            }
                            else
                            {
                                blue = 0;
                                red = 0;
                                green = 0;

                            }

                            (dataPtr + y * step + x * nChan)[0] = blue;
                            (dataPtr + y * step + x * nChan)[1] = green;
                            (dataPtr + y * step + x * nChan)[2] = red;
                            // advance the pointer to the next pixel
                        }

                    }
                }
            }

        }
        public static void Rotation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float angle)
        {
            unsafe
            {

                MIplImage m = img.MIplImage;
                MIplImage mUndo = imgCopy.MIplImage;
                byte* dataPtrimgCopy = (byte*)mUndo.imageData.ToPointer();
                byte* dataPtr = (byte*)m.imageData.ToPointer();
                byte* dataPtrimgCopy_aux;
                int width = imgCopy.Width;
                int height = imgCopy.Height;
                int nChan = m.nChannels;
                int step = m.widthStep;
                int padding = m.widthStep - m.nChannels * m.width;
                byte blue, green, red;
                int y, x;
                int xang, yang;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            xang = (int)Math.Round(((x - width / 2.0) * Math.Cos(angle)) - ((height / 2.0 - y) * Math.Sin(angle)) + (width / 2.0));
                            yang = (int)Math.Round(height / 2.0 - ((x - (width / 2.0)) * Math.Sin(angle)) - ((height / 2.0 - y) * Math.Cos(angle)));
                            dataPtrimgCopy_aux = (dataPtrimgCopy + xang * nChan + yang * step);
                            //retrive 3 colour components
                            if (xang < width && xang >= 0 && yang < height && yang >= 0)
                            {
                                blue = (dataPtrimgCopy_aux[0]);
                                green = (dataPtrimgCopy_aux[1]);
                                red = (dataPtrimgCopy_aux[2]);
                            }
                            else
                            {
                                blue = 0;
                                green = 0;
                                red = 0;
                            }
                            (dataPtr + y * step + x * nChan)[0] = blue;
                            (dataPtr + y * step + x * nChan)[1] = green;
                            (dataPtr + y * step + x * nChan)[2] = red;
                            // advance the pointer to the next pixel


                            // advance the pointer to the next pixel
                        }
                        //at the end of the line advance the pointer by the aligment bytes (padding)
                    }
                }
            }
        }
        public static void Scale(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float scaleFactor)
        {
            unsafe
            {

                MIplImage m = img.MIplImage;
                MIplImage mUndo = imgCopy.MIplImage;
                byte* dataPtrimgCopy = (byte*)mUndo.imageData.ToPointer();
                byte* dataPtr = (byte*)m.imageData.ToPointer();
                byte* dataPtrimgCopy_aux;
                int width = imgCopy.Width;
                int height = imgCopy.Height;
                int nChan = m.nChannels;
                int step = m.widthStep;
                int padding = m.widthStep - m.nChannels * m.width;
                byte blue, green, red;
                int x_o, y_o;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        x_o = (int)Math.Round(x / scaleFactor);
                        y_o = (int)Math.Round(y / scaleFactor);
                        dataPtrimgCopy_aux = (byte*)(dataPtrimgCopy + x_o * nChan + y_o * step);
                        //retrive 3 colour components
                        if (x_o < width && x_o >= 0 && y_o < height && y_o >= 0)
                        {
                            blue = (byte)Math.Round((double)(dataPtrimgCopy_aux[0]));
                            green = (byte)Math.Round((double)(dataPtrimgCopy_aux[1]));
                            red = (byte)Math.Round((double)(dataPtrimgCopy_aux[2]));
                        }
                        else
                        {
                            blue = 0;
                            green = 0;
                            red = 0;
                        }
                        (dataPtr + y * step + x * nChan)[0] = blue;
                        (dataPtr + y * step + x * nChan)[1] = green;
                        (dataPtr + y * step + x * nChan)[2] = red;
                        // advance the pointer to the next pixel
                    }
                    //at the end of the line advance the pointer by the aligment bytes (padding)
                }
            }
        }
        public static void Scale_point_xy(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float scaleFactor, int centerX, int centerY)
        {
            {
                unsafe
                {
                    MIplImage m = img.MIplImage;
                    MIplImage mUndo = imgCopy.MIplImage;

                    byte* dataPtrRead = (byte*)mUndo.imageData.ToPointer();
                    byte* dataPtrWrite = (byte*)m.imageData.ToPointer();

                    int width = imgCopy.Width;
                    int height = imgCopy.Height;
                    int nChan = mUndo.nChannels;
                    int widthStep = mUndo.widthStep;
                    byte red, green, blue;
                    int xo, yo;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            xo = (int)Math.Round(((x - width / 2) / scaleFactor) + centerX);

                            yo = (int)Math.Round(((y - height / 2) / scaleFactor) + centerY);

                            if (xo >= 0 && xo < width && yo >= 0 && yo < height)
                            {
                                blue = (dataPtrRead + nChan * xo + widthStep * yo)[0];
                                green = (dataPtrRead + nChan * xo + widthStep * yo)[1];
                                red = (dataPtrRead + nChan * xo + widthStep * yo)[2];
                            }
                            else
                            {
                                blue = green = red = 0;
                            }
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = blue;
                            (dataPtrWrite + nChan * x + widthStep * y)[1] = green;
                            (dataPtrWrite + nChan * x + widthStep * y)[2] = red;
                        }
                    }
                }
            }
        }
        public static void Mean(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                MIplImage mUndo = imgCopy.MIplImage;

                byte* dataPtrRead = (byte*)mUndo.imageData.ToPointer();
                byte* dataPtrWrite = (byte*)m.imageData.ToPointer();
                int padding = m.widthStep - m.nChannels * m.width;
                int width = imgCopy.Width;
                int height = imgCopy.Height;
                int nChan = mUndo.nChannels;
                int widthStep = mUndo.widthStep;
                byte red, green, blue;


                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (x > 0 && y > 0 && x < width - 1 && y < height - 1)
                        {
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = (byte)Math.Round(
                            (((dataPtrRead + nChan * x + widthStep * y)[0])
                            + ((dataPtrRead + nChan * (x + 1) + widthStep * (y + 1))[0])
                            + ((dataPtrRead + nChan * (x - 1) + widthStep * (y - 1))[0])
                            + ((dataPtrRead + nChan * (x) + widthStep * (y - 1))[0])
                            + ((dataPtrRead + nChan * (x - 1) + widthStep * (y))[0])
                            + ((dataPtrRead + nChan * (x + 1) + widthStep * y)[0])
                            + ((dataPtrRead + nChan * x + widthStep * (y + 1))[0])
                            + ((dataPtrRead + nChan * (x - 1) + widthStep * (y + 1))[0])
                            + ((dataPtrRead + nChan * (x + 1) + widthStep * (y - 1))[0])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[1] = (byte)Math.Round(
                                (((dataPtrRead + nChan * x + widthStep * y)[1])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y + 1))[1])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y - 1))[1])
                                + ((dataPtrRead + nChan * (x) + widthStep * (y - 1))[1])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y))[1])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * y)[1])
                                + ((dataPtrRead + nChan * x + widthStep * (y + 1))[1])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y + 1))[1])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y - 1))[1])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[2] = (byte)Math.Round(
                                (((dataPtrRead + nChan * x + widthStep * y)[2])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y + 1))[2])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y - 1))[2])
                                + ((dataPtrRead + nChan * (x) + widthStep * (y - 1))[2])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y))[2])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * y)[2])
                                + ((dataPtrRead + nChan * x + widthStep * (y + 1))[2])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y + 1))[2])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y - 1))[2])) / 9.0);
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 250;
                            }

                            blue = (dataPtrWrite + nChan * x + widthStep * y)[0];
                            green = (dataPtrWrite + nChan * x + widthStep * y)[1];
                            red = (dataPtrWrite + nChan * x + widthStep * y)[2];

                        }
                        if (x == 0 && y == 0)
                        {
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = (byte)Math.Round(
                                ((((dataPtrRead + nChan * (x) + widthStep * y)[0]) * 4)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y + 1))[0]) * 2)
                                + (((dataPtrRead + nChan * (x + 1) + widthStep * y)[0]) * 2)
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y + 1))[0])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[1] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[1]) * 4)
                               + (((dataPtrRead + nChan * (x) + widthStep * (y + 1))[1]) * 2)
                               + (((dataPtrRead + nChan * (x + 1) + widthStep * y)[1]) * 2)
                               + ((dataPtrRead + nChan * (x + 1) + widthStep * (y + 1))[1])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[2] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[2]) * 4)
                               + (((dataPtrRead + nChan * (x) + widthStep * (y + 1))[2]) * 2)
                               + (((dataPtrRead + nChan * (x + 1) + widthStep * y)[2]) * 2)
                               + ((dataPtrRead + nChan * (x + 1) + widthStep * (y + 1))[2])) / 9.0);
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 250;
                            }
                            blue = (dataPtrWrite + nChan * x + widthStep * y)[0];
                            green = (dataPtrWrite + nChan * x + widthStep * y)[1];
                            red = (dataPtrWrite + nChan * x + widthStep * y)[2];

                        }
                        if (x == width - 1 && y == height - 1)
                        {
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = (byte)Math.Round(
                                ((((dataPtrRead + nChan * (x) + widthStep * y)[0]) * 4)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y - 1))[0]) * 2)
                                + (((dataPtrRead + nChan * (x - 1) + widthStep * y)[0]) * 2)
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y - 1))[0])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[1] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[1]) * 4)
                               + (((dataPtrRead + nChan * (x) + widthStep * (y - 1))[1]) * 2)
                               + (((dataPtrRead + nChan * (x - 1) + widthStep * y)[1]) * 2)
                               + ((dataPtrRead + nChan * (x - 1) + widthStep * (y - 1))[1])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[2] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[2]) * 4)
                               + (((dataPtrRead + nChan * (x) + widthStep * (y - 1))[2]) * 2)
                               + (((dataPtrRead + nChan * (x - 1) + widthStep * y)[2]) * 2)
                               + ((dataPtrRead + nChan * (x - 1) + widthStep * (y - 1))[2])) / 9.0);
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 250;
                            }
                            blue = (dataPtrWrite + nChan * x + widthStep * y)[0];
                            green = (dataPtrWrite + nChan * x + widthStep * y)[1];
                            red = (dataPtrWrite + nChan * x + widthStep * y)[2];


                        }
                        if (x == 0 && y == height - 1)
                        {
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = (byte)Math.Round(
                            ((((dataPtrRead + nChan * (x) + widthStep * y)[0]) * 4)
                            + (((dataPtrRead + nChan * (x) + widthStep * (y - 1))[0]) * 2)
                            + (((dataPtrRead + nChan * (x + 1) + widthStep * y)[0]) * 2)
                            + ((dataPtrRead + nChan * (x + 1) + widthStep * (y - 1))[0])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[1] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[1]) * 4)
                               + (((dataPtrRead + nChan * (x) + widthStep * (y - 1))[1]) * 2)
                               + (((dataPtrRead + nChan * (x + 1) + widthStep * y)[1]) * 2)
                               + ((dataPtrRead + nChan * (x + 1) + widthStep * (y - 1))[1])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[2] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[2]) * 4)
                               + (((dataPtrRead + nChan * (x) + widthStep * (y - 1))[2]) * 2)
                               + (((dataPtrRead + nChan * (x + 1) + widthStep * y)[2]) * 2)
                               + ((dataPtrRead + nChan * (x + 1) + widthStep * (y - 1))[2])) / 9.0);
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 250;
                            }
                            blue = (dataPtrWrite + nChan * x + widthStep * y)[0];
                            green = (dataPtrWrite + nChan * x + widthStep * y)[1];
                            red = (dataPtrWrite + nChan * x + widthStep * y)[2];


                        }

                        if (x == width - 1 && y == 0)
                        {
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = (byte)Math.Round(
                                ((((dataPtrRead + nChan * (x) + widthStep * y)[0]) * 4)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y + 1))[0]) * 2)
                                + (((dataPtrRead + nChan * (x - 1) + widthStep * y)[0]) * 2)
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y + 1))[0])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[1] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[1]) * 4)
                               + (((dataPtrRead + nChan * (x) + widthStep * (y + 1))[1]) * 2)
                               + (((dataPtrRead + nChan * (x - 1) + widthStep * y)[1]) * 2)
                               + ((dataPtrRead + nChan * (x - 1) + widthStep * (y + 1))[1])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[2] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[2]) * 4)
                               + (((dataPtrRead + nChan * (x) + widthStep * (y + 1))[2]) * 2)
                               + (((dataPtrRead + nChan * (x - 1) + widthStep * y)[2]) * 2)
                               + ((dataPtrRead + nChan * (x - 1) + widthStep * (y + 1))[2])) / 9.0);
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 250;
                            }
                            blue = (dataPtrWrite + nChan * x + widthStep * y)[0];
                            green = (dataPtrWrite + nChan * x + widthStep * y)[1];
                            red = (dataPtrWrite + nChan * x + widthStep * y)[2];

                        }
                        if (x == 0 && y > 0 && y < height - 1)
                        {
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = (byte)Math.Round(
                                ((((dataPtrRead + nChan * (x) + widthStep * y)[0]) * 2)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y - 1))[0]) * 2)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y + 1))[0]) * 2)
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y))[0])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y + 1))[0])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y - 1))[0])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[1] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[1]) * 2)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y - 1))[1]) * 2)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y + 1))[1]) * 2)
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y))[1])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y + 1))[1])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y - 1))[1])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[2] = (byte)Math.Round(
                               (((dataPtrRead + nChan * (x) + widthStep * y)[2]) * 2)
                                + ((((dataPtrRead + nChan * (x) + widthStep * (y - 1))[2]) * 2)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y + 1))[2]) * 2)
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y))[2])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y + 1))[2])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y - 1))[2])) / 9.0);

                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 250;
                            }
                            blue = (dataPtrWrite + nChan * x + widthStep * y)[0];
                            green = (dataPtrWrite + nChan * x + widthStep * y)[1];
                            red = (dataPtrWrite + nChan * x + widthStep * y)[2];



                        }
                        if (x == width - 1 && y > 0 && y < height - 1)
                        {
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = (byte)Math.Round(
                                ((((dataPtrRead + nChan * (x) + widthStep * y)[0]) * 2)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y - 1))[0]) * 2)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y + 1))[0]) * 2)
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y))[0])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y + 1))[0])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y - 1))[0])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[1] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[1]) * 2)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y - 1))[1]) * 2)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y + 1))[1]) * 2)
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y))[1])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y + 1))[1])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y - 1))[1])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[2] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[2]) * 2)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y - 1))[2]) * 2)
                                + (((dataPtrRead + nChan * (x) + widthStep * (y + 1))[2]) * 2)
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y))[2])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y + 1))[2])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y - 1))[2])) / 9.0);

                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 250;
                            }
                            blue = (dataPtrWrite + nChan * x + widthStep * y)[0];
                            green = (dataPtrWrite + nChan * x + widthStep * y)[1];
                            red = (dataPtrWrite + nChan * x + widthStep * y)[2];

                        }
                        if (y == height - 1 && x > 0 && x < width - 1)
                        {
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = (byte)Math.Round(
                                ((((dataPtrRead + nChan * (x) + widthStep * y)[0]) * 2)
                                + (((dataPtrRead + nChan * (x - 1) + widthStep * y)[0]) * 2)
                                + (((dataPtrRead + nChan * (x + 1) + widthStep * y)[0]) * 2)
                                + ((dataPtrRead + nChan * (x) + widthStep * (y - 1))[0])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y - 1))[0])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y - 1))[0])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[1] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[1]) * 2)
                                + (((dataPtrRead + nChan * (x - 1) + widthStep * (y))[1]) * 2)
                                + (((dataPtrRead + nChan * (x + 1) + widthStep * y)[1]) * 2)
                                + ((dataPtrRead + nChan * (x) + widthStep * (y - 1))[1])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y - 1))[1])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y - 1))[1])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[2] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[2]) * 2)
                                + (((dataPtrRead + nChan * (x - 1) + widthStep * (y))[2]) * 2)
                                + (((dataPtrRead + nChan * (x + 1) + widthStep * y)[2]) * 2)
                                + ((dataPtrRead + nChan * (x) + widthStep * (y - 1))[2])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y - 1))[2])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y - 1))[2])) / 9.0);

                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 250;
                            }
                            blue = (dataPtrWrite + nChan * x + widthStep * y)[0];
                            green = (dataPtrWrite + nChan * x + widthStep * y)[1];
                            red = (dataPtrWrite + nChan * x + widthStep * y)[2];



                        }
                        if (y == 0 && x > 0 && x < width - 1)
                        {
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = (byte)Math.Round(
                                ((((dataPtrRead + nChan * (x) + widthStep * y)[0]) * 2)
                                + (((dataPtrRead + nChan * (x - 1) + widthStep * y)[0]) * 2)
                                + (((dataPtrRead + nChan * (x + 1) + widthStep * y)[0]) * 2)
                                + ((dataPtrRead + nChan * (x) + widthStep * (y + 1))[0])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y + 1))[0])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y + 1))[0])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[1] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[1]) * 2)
                                + (((dataPtrRead + nChan * (x - 1) + widthStep * (y))[1]) * 2)
                                + (((dataPtrRead + nChan * (x + 1) + widthStep * y)[1]) * 2)
                                + ((dataPtrRead + nChan * (x) + widthStep * (y + 1))[1])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y + 1))[1])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y + 1))[1])) / 9.0);

                            (dataPtrWrite + nChan * x + widthStep * y)[2] = (byte)Math.Round(
                               ((((dataPtrRead + nChan * (x) + widthStep * y)[2]) * 2)
                                + (((dataPtrRead + nChan * (x - 1) + widthStep * (y))[2]) * 2)
                                + (((dataPtrRead + nChan * (x + 1) + widthStep * y)[2]) * 2)
                                + ((dataPtrRead + nChan * (x) + widthStep * (y + 1))[2])
                                + ((dataPtrRead + nChan * (x + 1) + widthStep * (y + 1))[2])
                                + ((dataPtrRead + nChan * (x - 1) + widthStep * (y + 1))[2])) / 9.0);

                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] < 0)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 0;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[2] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[2] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[1] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[1] = 250;
                            }
                            if ((dataPtrWrite + nChan * x + widthStep * y)[0] > 250)
                            {
                                (dataPtrWrite + nChan * x + widthStep * y)[0] = 250;
                            }
                            blue = (dataPtrWrite + nChan * x + widthStep * y)[0];
                            green = (dataPtrWrite + nChan * x + widthStep * y)[1];
                            red = (dataPtrWrite + nChan * x + widthStep * y)[2];

                        }
                    }
                }
            }
        }
        public static void NonUniform(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float[,] matrix, float matrixWeight)
        {
            unsafe
            {

                // obter apontador do inicio da imagem
                MIplImage m = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer();

                int width = imgCopy.Width;
                int height = imgCopy.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthstep = m.widthStep;

                MIplImage mOut = img.MIplImage;
                byte* dataPtrOut = (byte*)mOut.imageData.ToPointer();


                double acomuladorB = 0;
                double acomuladorG = 0;
                double acomuladorR = 0;

                int previousX = 0, nextX = 0,
                    previousY = 0, nextY = 0;

                for (int y = 0; y < height; y++)
                {
                    previousY = y == 0 ? y : y - 1;
                    nextY = y == height - 1 ? y : y + 1;

                    for (int x = 0; x < width; x++)
                    {
                        previousX = x == 0 ? x : x - 1;
                        nextX = x == width - 1 ? x : x + 1;



                        acomuladorB = 0;
                        acomuladorB += (dataPtr + (previousY) * widthstep + (previousX) * nChan)[0] * matrix[0, 0];
                        acomuladorB += (dataPtr + (previousY) * widthstep + (x) * nChan)[0] * matrix[1, 0];
                        acomuladorB += (dataPtr + (previousY) * widthstep + (nextX) * nChan)[0] * matrix[2, 0];
                        acomuladorB += (dataPtr + (y) * widthstep + (previousX) * nChan)[0] * matrix[0, 1];
                        acomuladorB += (dataPtr + (y) * widthstep + (x) * nChan)[0] * matrix[1, 1];
                        acomuladorB += (dataPtr + (y) * widthstep + (nextX) * nChan)[0] * matrix[2, 1];
                        acomuladorB += (dataPtr + (nextY) * widthstep + (previousX) * nChan)[0] * matrix[0, 2];
                        acomuladorB += (dataPtr + (nextY) * widthstep + (x) * nChan)[0] * matrix[1, 2];
                        acomuladorB += (dataPtr + (nextY) * widthstep + (nextX) * nChan)[0] * matrix[2, 2];
                        acomuladorB /= matrixWeight;

                        (dataPtrOut + (y) * widthstep + (x) * nChan)[0] = Math.Round(acomuladorB) > 255 ? (byte)255 : (byte)Math.Round(acomuladorB);


                        acomuladorG = 0;
                        acomuladorG += (dataPtr + (previousY) * widthstep + (previousX) * nChan)[1] * matrix[0, 0];
                        acomuladorG += (dataPtr + (previousY) * widthstep + (x) * nChan)[1] * matrix[1, 0];
                        acomuladorG += (dataPtr + (previousY) * widthstep + (nextX) * nChan)[1] * matrix[2, 0];
                        acomuladorG += (dataPtr + (y) * widthstep + (previousX) * nChan)[1] * matrix[0, 1];
                        acomuladorG += (dataPtr + (y) * widthstep + (x) * nChan)[1] * matrix[1, 1];
                        acomuladorG += (dataPtr + (y) * widthstep + (nextX) * nChan)[1] * matrix[2, 1];
                        acomuladorG += (dataPtr + (nextY) * widthstep + (previousX) * nChan)[1] * matrix[0, 2];
                        acomuladorG += (dataPtr + (nextY) * widthstep + (x) * nChan)[1] * matrix[1, 2];
                        acomuladorG += (dataPtr + (nextY) * widthstep + (nextX) * nChan)[1] * matrix[2, 2];
                        acomuladorG /= matrixWeight;

                        (dataPtrOut + (y) * widthstep + (x) * nChan)[1] = Math.Round(acomuladorG) > 255 ? (byte)255 : (byte)Math.Round(acomuladorG);


                        acomuladorR = 0;
                        acomuladorR += (dataPtr + (previousY) * widthstep + (previousX) * nChan)[2] * matrix[0, 0];
                        acomuladorR += (dataPtr + (previousY) * widthstep + (x) * nChan)[2] * matrix[1, 0];
                        acomuladorR += (dataPtr + (previousY) * widthstep + (nextX) * nChan)[2] * matrix[2, 0];
                        acomuladorR += (dataPtr + (y) * widthstep + (previousX) * nChan)[2] * matrix[0, 1];
                        acomuladorR += (dataPtr + (y) * widthstep + (x) * nChan)[2] * matrix[1, 1];
                        acomuladorR += (dataPtr + (y) * widthstep + (nextX) * nChan)[2] * matrix[2, 1];
                        acomuladorR += (dataPtr + (nextY) * widthstep + (previousX) * nChan)[2] * matrix[0, 2];
                        acomuladorR += (dataPtr + (nextY) * widthstep + (x) * nChan)[2] * matrix[1, 2];
                        acomuladorR += (dataPtr + (nextY) * widthstep + (nextX) * nChan)[2] * matrix[2, 2];
                        acomuladorR /= matrixWeight;

                        (dataPtrOut + (y) * widthstep + (x) * nChan)[2] = Math.Round(acomuladorR) > 255 ? (byte)255 : (byte)Math.Round(acomuladorR);

                    }
                }


            }

        }
        public static void Sobel(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer();
                MIplImage mCopy = imgCopy.MIplImage;
                byte* dataPtrCopy = (byte*)mCopy.imageData.ToPointer();

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // 3 channels (BGR)
                int padding = m.widthStep - nChan * width;

                int lastH = height - 1;
                int lastW = width - 1;

                int sxBlue, sxGreen, sxRed, syBlue, syGreen, syRed;
                int blue, green, red;

                // Process image
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (y == 0 || y == lastH || x == 0 || x == lastW)
                        {
                            // Border pixels set to black (0, 0, 0)
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }
                        else
                        {
                            // Compute Sobel gradients
                            sxBlue = ((dataPtrCopy - m.widthStep - nChan)[0] + 2 * (dataPtrCopy - nChan)[0] + (dataPtrCopy + m.widthStep - nChan)[0]
                                      - (dataPtrCopy - m.widthStep + nChan)[0] - 2 * (dataPtrCopy + nChan)[0] - (dataPtrCopy + m.widthStep + nChan)[0]);

                            syBlue = ((dataPtrCopy - m.widthStep - nChan)[0] + 2 * (dataPtrCopy - m.widthStep)[0] + (dataPtrCopy - m.widthStep + nChan)[0]
                                      - (dataPtrCopy + m.widthStep - nChan)[0] - 2 * (dataPtrCopy + m.widthStep)[0] - (dataPtrCopy + m.widthStep + nChan)[0]);

                            sxGreen = ((dataPtrCopy - m.widthStep - nChan)[1] + 2 * (dataPtrCopy - nChan)[1] + (dataPtrCopy + m.widthStep - nChan)[1]
                                       - (dataPtrCopy - m.widthStep + nChan)[1] - 2 * (dataPtrCopy + nChan)[1] - (dataPtrCopy + m.widthStep + nChan)[1]);

                            syGreen = ((dataPtrCopy - m.widthStep - nChan)[1] + 2 * (dataPtrCopy - m.widthStep)[1] + (dataPtrCopy - m.widthStep + nChan)[1]
                                       - (dataPtrCopy + m.widthStep - nChan)[1] - 2 * (dataPtrCopy + m.widthStep)[1] - (dataPtrCopy + m.widthStep + nChan)[1]);

                            sxRed = ((dataPtrCopy - m.widthStep - nChan)[2] + 2 * (dataPtrCopy - nChan)[2] + (dataPtrCopy + m.widthStep - nChan)[2]
                                      - (dataPtrCopy - m.widthStep + nChan)[2] - 2 * (dataPtrCopy + nChan)[2] - (dataPtrCopy + m.widthStep + nChan)[2]);

                            syRed = ((dataPtrCopy - m.widthStep - nChan)[2] + 2 * (dataPtrCopy - m.widthStep)[2] + (dataPtrCopy - m.widthStep + nChan)[2]
                                      - (dataPtrCopy + m.widthStep - nChan)[2] - 2 * (dataPtrCopy + m.widthStep)[2] - (dataPtrCopy + m.widthStep + nChan)[2]);

                            // Compute final pixel value
                            blue = Math.Abs(sxBlue) + Math.Abs(syBlue);
                            green = Math.Abs(sxGreen) + Math.Abs(syGreen);
                            red = Math.Abs(sxRed) + Math.Abs(syRed);

                            // Clamp values to 255
                            blue = blue > 255 ? 255 : blue < 0 ? 0 : blue;
                            green = green > 255 ? 255 : green < 0 ? 0 : green;
                            red = red > 255 ? 255 : red < 0 ? 0 : red;


                            dataPtr[0] = (byte)blue;
                            dataPtr[1] = (byte)green;
                            dataPtr[2] = (byte)red;
                        }

                        dataPtr += nChan;
                        dataPtrCopy += nChan;
                    }


                    dataPtr += padding;
                    dataPtrCopy += padding;
                }
            }

        }
        public static void Diferentiation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                // obter apontador do inicio da imagem
                MIplImage m = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer();

                int width = imgCopy.Width;
                int height = imgCopy.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthstep = m.widthStep;

                MIplImage mOut = img.MIplImage;
                byte* dataPtrOut = (byte*)mOut.imageData.ToPointer();



                int previousX = 0, nextX = 0,
                    previousY = 0, nextY = 0;


                double sOutput = 0;

                for (int y = 0; y < height; y++)
                {
                    previousY = y == 0 ? y : y - 1;
                    nextY = y == height - 1 ? y : y + 1;

                    for (int x = 0; x < width; x++)
                    {
                        previousX = x == 0 ? x : x - 1;
                        nextX = x == width - 1 ? x : x + 1;
                        sOutput = 0;

                        /*Blue*/
                        sOutput = Math.Abs((dataPtr + (y) * widthstep + (x) * nChan)[0] - (dataPtr + (y) * widthstep + (nextX) * nChan)[0]) + System.Math.Abs((dataPtr + (y) * widthstep + (x) * nChan)[0] - (dataPtr + (nextY) * widthstep + (x) * nChan)[0]);
                        (dataPtrOut + (y) * widthstep + (x) * nChan)[0] = Math.Round(sOutput) > 255 ? (byte)255 : (byte)Math.Round(sOutput);
                        sOutput = 0;

                        /*Green*/
                        sOutput = Math.Abs((dataPtr + (y) * widthstep + (x) * nChan)[1] - (dataPtr + (y) * widthstep + (nextX) * nChan)[1]) + System.Math.Abs((dataPtr + (y) * widthstep + (x) * nChan)[1] - (dataPtr + (nextY) * widthstep + (x) * nChan)[1]);
                        (dataPtrOut + (y) * widthstep + (x) * nChan)[1] = Math.Round(sOutput) > 255 ? (byte)255 : (byte)Math.Round(sOutput);
                        sOutput = 0;

                        /*Red*/
                        sOutput = Math.Abs((dataPtr + (y) * widthstep + (x) * nChan)[2] - (dataPtr + (y) * widthstep + (nextX) * nChan)[2]) + System.Math.Abs((dataPtr + (y) * widthstep + (x) * nChan)[2] - (dataPtr + (nextY) * widthstep + (x) * nChan)[2]);
                        (dataPtrOut + (y) * widthstep + (x) * nChan)[2] = Math.Round(sOutput) > 255 ? (byte)255 : (byte)Math.Round(sOutput);
                        sOutput = 0;

                    }
                }


            }

        }
        public static void Roberts(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {

            unsafe
            {

                // obter apontador do inicio da imagem
                MIplImage m = imgCopy.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer();

                int width = imgCopy.Width;
                int height = imgCopy.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int widthstep = m.widthStep;

                MIplImage mOut = img.MIplImage;
                byte* dataPtrOut = (byte*)mOut.imageData.ToPointer();



                int previousX = 0, nextX = 0,
                    previousY = 0, nextY = 0;


                double sOutput = 0;

                for (int y = 0; y < height; y++)
                {
                    previousY = y == 0 ? y : y - 1;
                    nextY = y == height - 1 ? y : y + 1;

                    for (int x = 0; x < width; x++)
                    {
                        previousX = x == 0 ? x : x - 1;
                        nextX = x == width - 1 ? x : x + 1;
                        sOutput = 0;

                        /*Blue*/
                        sOutput = Math.Abs((dataPtr + (y) * widthstep + (x) * nChan)[0] - (dataPtr + (nextY) * widthstep + (nextX) * nChan)[0]) + System.Math.Abs((dataPtr + (y) * widthstep + (nextX) * nChan)[0] - (dataPtr + (nextY) * widthstep + (x) * nChan)[0]);
                        (dataPtrOut + (y) * widthstep + (x) * nChan)[0] = Math.Round(sOutput) > 255 ? (byte)255 : (byte)Math.Round(sOutput);
                        sOutput = 0;

                        /*Green*/
                        sOutput = Math.Abs((dataPtr + (y) * widthstep + (x) * nChan)[1] - (dataPtr + (nextY) * widthstep + (nextX) * nChan)[1]) + System.Math.Abs((dataPtr + (y) * widthstep + (nextX) * nChan)[1] - (dataPtr + (nextY) * widthstep + (x) * nChan)[1]);
                        (dataPtrOut + (y) * widthstep + (x) * nChan)[1] = Math.Round(sOutput) > 255 ? (byte)255 : (byte)Math.Round(sOutput);
                        sOutput = 0;

                        /*Red*/
                        sOutput = System.Math.Abs((dataPtr + (y) * widthstep + (x) * nChan)[2] - (dataPtr + (nextY) * widthstep + (nextX) * nChan)[2]) + System.Math.Abs((dataPtr + (y) * widthstep + (nextX) * nChan)[2] - (dataPtr + (nextY) * widthstep + (x) * nChan)[2]);
                        (dataPtrOut + (y) * widthstep + (x) * nChan)[2] = Math.Round(sOutput) > 255 ? (byte)255 : (byte)Math.Round(sOutput);
                        sOutput = 0;

                    }
                }


            }

        }
        public static void Median(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Ponteiro para a imagem original
                MIplImage mCopy = imgCopy.MIplImage;
                byte* dataPtrCopy = (byte*)mCopy.imageData.ToPointer(); // Ponteiro para a cópia da imagem

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // Número de canais (BGR)
                int padding = m.widthStep - nChan * width;
                int widthStep = m.widthStep;

                int[] redValues = new int[9];
                int[] greenValues = new int[9];
                int[] blueValues = new int[9];

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int count = 0;

                        // Coleta os valores da janela 3x3
                        for (int ky = -1; ky <= 1; ky++)
                        {
                            for (int kx = -1; kx <= 1; kx++)
                            {
                                int ny = Math.Max(0, Math.Min(height - 1, y + ky));
                                int nx = Math.Max(0, Math.Min(width - 1, x + kx));

                                byte* neighborPixel = dataPtrCopy + ny * widthStep + nx * nChan;

                                blueValues[count] = neighborPixel[0];
                                greenValues[count] = neighborPixel[1];
                                redValues[count] = neighborPixel[2];

                                count++;
                            }
                        }

                        // Ordena os valores para encontrar a mediana
                        Array.Sort(blueValues);
                        Array.Sort(greenValues);
                        Array.Sort(redValues);

                        int medianIndex = 4; // Índice da mediana (janela 3x3 tem 9 elementos)

                        // Atualiza o pixel da imagem original
                        byte* currentPixel = dataPtr + y * widthStep + x * nChan;
                        currentPixel[0] = (byte)blueValues[medianIndex];
                        currentPixel[1] = (byte)greenValues[medianIndex];
                        currentPixel[2] = (byte)redValues[medianIndex];
                    }
                }
            }

        }
        public static int[] Histogram_Gray(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;



                byte* dataPtrWrite = (byte*)m.imageData.ToPointer();
                int padding = m.widthStep - m.nChannels * m.width;
                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels;
                int widthStep = m.widthStep;
                byte red, green, blue;
                double sx, sy;
                int[] estou = new int[256];
                int result = 0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        blue = (dataPtrWrite + nChan * x + widthStep * y)[0];
                        green = (dataPtrWrite + nChan * x + widthStep * y)[1];
                        red = (dataPtrWrite + nChan * x + widthStep * y)[2];

                        result = (int)Math.Round((blue + red + green) / 3.0);
                        estou[result] += 1;
                    }
                }
                Histograma h = new Histograma(estou);
                h.ShowDialog();

                return estou;
            }
        }
        public static int[,] Histogram_All(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red, gray;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels;
                int step = m.widthStep; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;
                int ne = 0;
                int[,] vector = new int[3, 256];
                int valor_pixel = 0;
                for (ne = 0; ne < 3; ne++)
                {
                    switch (ne)
                    {
                        case 0:
                            for (y = 0; y < height; y++)
                            {
                                for (x = 0; x < width; x++)
                                {
                                    valor_pixel = dataPtr[0];
                                    vector[0, valor_pixel]++;
                                    dataPtr += nChan;
                                }
                                dataPtr += padding;
                            }
                            break;
                        case 1:
                            for (y = 1; y < height; y++)
                            {
                                for (x = 1; x < width; x++)
                                {
                                    valor_pixel = dataPtr[1];
                                    vector[1, valor_pixel]++;
                                    dataPtr += nChan;
                                }
                                dataPtr += padding;
                            }

                            break;
                        case 2:
                            for (y = 2; y < height; y++)
                            {
                                for (x = 2; x < width; x++)
                                {
                                    valor_pixel = dataPtr[2];
                                    vector[2, valor_pixel]++;
                                    dataPtr += nChan;
                                }
                                dataPtr += padding;
                            }
                            break;
                    }
                }
                return vector;
            }
        }
        public static int[,] Histogram_RGB(Emgu.CV.Image<Bgr, byte> img)
        {
            {
                unsafe
                {
                    MIplImage m = img.MIplImage;
                    byte* dataPtrImg = (byte*)m.imageData.ToPointer(); // Pointer to the image

                    int width = img.Width;
                    int height = img.Height;
                    int nChan = m.nChannels; // number of channels - 3
                    int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                    int[,] histog = new int[3, 256];

                    byte blue, green, red;
                    int x, y;

                    if (nChan == 3)
                    {
                        for (x = 0; x < height; x++)
                        {
                            for (y = 0; y < width; y++)
                            {
                                blue = dataPtrImg[0];
                                green = dataPtrImg[1];
                                red = dataPtrImg[2];
                                histog[0, blue]++;
                                histog[1, green]++;
                                histog[2, red]++;



                                // advance the pointer to the next pixel
                                dataPtrImg += nChan;
                            }
                            //at the end of the line advance the pointer by the aligment bytes (padding)
                            dataPtrImg += padding;
                        }
                    }
                    return histog;
                }
            }

        }
        public static void ConvertToBW(Emgu.CV.Image<Bgr, byte> img, int threshold)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;



                byte* dataPtrWrite = (byte*)m.imageData.ToPointer();
                int padding = m.widthStep - m.nChannels * m.width;
                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels;
                int widthStep = m.widthStep;
                byte red, green, blue;
                double sx, sy;
                int[] estou = new int[256];
                int result = 0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        blue = (dataPtrWrite + nChan * x + widthStep * y)[0];
                        red = (dataPtrWrite + nChan * x + widthStep * y)[1];
                        green = (dataPtrWrite + nChan * x + widthStep * y)[2];

                        result = (int)Math.Round((blue + red + green) / 3.0);
                        if (result > threshold)
                        {

                            (dataPtrWrite + nChan * x + widthStep * y)[1] = 255;
                            (dataPtrWrite + nChan * x + widthStep * y)[2] = 255;
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = 255;

                        }
                        else
                        {
                            (dataPtrWrite + nChan * x + widthStep * y)[1] = 0;
                            (dataPtrWrite + nChan * x + widthStep * y)[2] = 0;
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = 0;

                        }

                    }
                }

            }

        }
        public static void ConvertToBW_Otsu(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;



                byte* dataPtrWrite = (byte*)m.imageData.ToPointer();
                int padding = m.widthStep - m.nChannels * m.width;
                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels;
                int widthStep = m.widthStep;
                byte red, green, blue;
                double sx, sy;
                int[] estou = new int[256];
                int result = 0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        blue = (dataPtrWrite + nChan * x + widthStep * y)[0];
                        red = (dataPtrWrite + nChan * x + widthStep * y)[1];
                        green = (dataPtrWrite + nChan * x + widthStep * y)[2];

                        result = (int)Math.Round((blue + red + green) / 3.0);
                        if (result > 0)
                        {

                            (dataPtrWrite + nChan * x + widthStep * y)[1] = 255;
                            (dataPtrWrite + nChan * x + widthStep * y)[2] = 255;
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = 255;

                        }
                        else
                        {
                            (dataPtrWrite + nChan * x + widthStep * y)[1] = 0;
                            (dataPtrWrite + nChan * x + widthStep * y)[2] = 0;
                            (dataPtrWrite + nChan * x + widthStep * y)[0] = 0;

                        }

                    }
                }

            }

        }

        public static void Binary(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtrImg = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                byte blue, green, red;
                blue = dataPtrImg[0];
                green = dataPtrImg[1];
                red = dataPtrImg[2];

                int x, y;

                if (nChan == 3)
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {

                            //if a media das 3rgb > threshhold
                            // r = 255 =b=g
                            //else r = b

                            if ((dataPtrImg + x * nChan + y * m.widthStep)[0] == blue &&
                               (dataPtrImg + x * nChan + y * m.widthStep)[1] == green &&
                               (dataPtrImg + x * nChan + y * m.widthStep)[2] == red)
                            {
                                (dataPtrImg + x * nChan + y * m.widthStep)[0] = 0;
                                (dataPtrImg + x * nChan + y * m.widthStep)[1] = 0;
                                (dataPtrImg + x * nChan + y * m.widthStep)[2] = 0;


                            }
                            else
                            {
                                (dataPtrImg + x * nChan + y * m.widthStep)[0] = 255;
                                (dataPtrImg + x * nChan + y * m.widthStep)[1] = 255;
                                (dataPtrImg + x * nChan + y * m.widthStep)[2] = 255;
                            }
                        }
                    }
                }
            }
        }

        public static int[,] ImageSegmentation(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtrImg = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)

                //specific to 

                byte blue, green, red;

                int[,] labels = new int[height, width];
                int etiqueta = 1;
                bool alarme;

                int x, y;


                alarme = false;
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        blue = (dataPtrImg + x * nChan + y * m.widthStep)[0];
                        green = (dataPtrImg + x * nChan + y * m.widthStep)[1];
                        red = (dataPtrImg + x * nChan + y * m.widthStep)[2];
                        if (blue == 255 && green == 255 && red == 255)
                        {
                            labels[y, x] = etiqueta;
                            etiqueta++;
                        }
                        else
                        {
                            labels[y, x] = 0;
                        }
                    }
                }
                /*
                x x x
                x x x
                x x x
                    */
                //localizar 4 cantos 
                //now, labeling top-down/left-right

                do
                {
                    for (y = 1; y < height; y++)
                    {
                        for (x = 1; x < width; x++)
                        {
                            if (labels[y, x] != 0)
                            {
                                int maispequeno = labels[y, x];
                                if (labels[y - 1, x - 1] < maispequeno && labels[y - 1, x - 1] != 0)
                                {
                                    maispequeno = labels[y - 1, x - 1];
                                    alarme = true;

                                }
                                if (labels[y - 1, x] < maispequeno && labels[y - 1, x] != 0)
                                {
                                    maispequeno = labels[y - 1, x];
                                    alarme = true;

                                }
                                if (labels[y - 1, x + 1] < maispequeno && labels[y - 1, x + 1] != 0)
                                {
                                    maispequeno = labels[y - 1, x + 1];
                                    alarme = true;

                                }
                                if (labels[y, x - 1] < maispequeno && labels[y, x - 1] != 0)
                                {
                                    maispequeno = labels[y, x - 1];
                                    alarme = true;

                                }
                                if (labels[y, x + 1] < maispequeno && labels[y, x + 1] != 0)
                                {
                                    maispequeno = labels[y, x + 1];
                                    alarme = true;

                                }
                                if (labels[y + 1, x - 1] < maispequeno && labels[y + 1, x - 1] != 0)
                                {
                                    maispequeno = labels[y + 1, x - 1];
                                    alarme = true;

                                }
                                if (labels[y + 1, x] < maispequeno && labels[y + 1, x] != 0)
                                {
                                    maispequeno = labels[y + 1, x];
                                    alarme = true;

                                }
                                if (labels[y + 1, x + 1] < maispequeno && labels[y + 1, x + 1] != 0)
                                {
                                    maispequeno = labels[y + 1, x + 1];
                                    alarme = true;

                                }
                                labels[y, x] = maispequeno;
                            }
                        }
                    }
                    if (alarme == false)
                        break;
                    alarme = false;
                    for (y = height - 2; y > 0; y--)
                    {
                        for (x = width - 2; x > 0; x--)
                        {
                            if (labels[y, x] != 0)
                            {
                                int maispequeno = labels[y, x];
                                if (labels[y - 1, x - 1] < maispequeno && labels[y - 1, x - 1] != 0)
                                {
                                    maispequeno = labels[y - 1, x - 1];
                                    alarme = true;

                                }
                                if (labels[y - 1, x] < maispequeno && labels[y - 1, x] != 0)
                                {
                                    maispequeno = labels[y - 1, x];
                                    alarme = true;

                                }
                                if (labels[y - 1, x + 1] < maispequeno && labels[y - 1, x + 1] != 0)
                                {
                                    maispequeno = labels[y - 1, x + 1];
                                    alarme = true;

                                }
                                if (labels[y, x - 1] < maispequeno && labels[y, x - 1] != 0)
                                {
                                    maispequeno = labels[y, x - 1];
                                    alarme = true;

                                }
                                if (labels[y, x + 1] < maispequeno && labels[y, x + 1] != 0)
                                {
                                    maispequeno = labels[y, x + 1];
                                    alarme = true;

                                }
                                if (labels[y + 1, x - 1] < maispequeno && labels[y + 1, x - 1] != 0)
                                {
                                    maispequeno = labels[y + 1, x - 1];
                                    alarme = true;

                                }
                                if (labels[y + 1, x] < maispequeno && labels[y + 1, x] != 0)
                                {
                                    maispequeno = labels[y + 1, x];
                                    alarme = true;

                                }
                                if (labels[y + 1, x + 1] < maispequeno && labels[y + 1, x + 1] != 0)
                                {
                                    maispequeno = labels[y + 1, x + 1];
                                    alarme = true;

                                }
                                labels[y, x] = maispequeno;
                            }
                        }
                    }

                }


                while (alarme == true);
                return labels;
            }

        }

        //TODO - fazer função de cortar carta
        public static int[] CortarCarta(Image<Bgr, Byte> img, int[,] imge, int c)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtrImg = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)

                //specific to 


                int[,] labels = new int[height, width];
                int[] ret = new int[8];

                ret[0] = 0;
                ret[1] = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (imge[y, x] == c)
                        {
                            ret[0] = x;
                            ret[1] = y;
                            break;
                        }

                    }
                }

                ret[2] = width - 1;
                ret[3] = height - 1;
                for (int y = height - 1; y >= 0; y--)
                {
                    for (int x = width - 1; x >= 0; x--)
                    {
                        if (imge[y, x] == c)
                        {
                            ret[2] = x;
                            ret[3] = y;
                            break;
                        }

                    }
                }

            

                ret[4] = 0;
                ret[5] = 0;

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (imge[y, x] == c)
                        {
                            ret[4] = x;
                            ret[5] = y;
                            break;
                        }

                    }
                }

                ret[6] = width - 1;
                ret[7] = height - 1;

                for (int x = width - 1; x >= 0; x--)
                {
                    for (int y = height - 1; y >= 0; y--)
                    {
                        if (imge[y, x] == c)
                        {
                            ret[6] = x;
                            ret[7] = y;
                            break;
                        }

                    }
                }
                return ret;
            }
        }

        

                //nota - Antes da binarização, é necessário verificar se a carta é preta ou vermelha

    public static string FindImage(Emgu.CV.Image<Bgr, byte> img)
        {
            //-----Tratamento da base de dados-~//
            string[] Base_Dados = Directory.GetFiles("C:\\Users\\Utilizador\\Documents\\imagem 3 (2)\\imagem 3\\CG_OpenCV_Base\\CG_OpenCV_Base\\CG_OpenCV_Base\\BD");
            int aux = Base_Dados.Length;
            Image<Bgr, byte> img_BD;
            double[] relacoes = new double[aux];
            int width = img.Width;
            int height = img.Height;

            //verificar carta aqui:

            img = img.Resize(50, 50, INTER.CV_INTER_CUBIC); //resize function
            int acc = ReturnBlackPixels(img);
            if (acc > 20)
                Bin_HSV_Black(img);
            else

                Bin_HSV_Red(img);



            for (int B_D = 0; B_D < aux; B_D++)
            {
                img_BD = new Image<Bgr, Byte>(Base_Dados[B_D]);
                img_BD = img_BD.Resize(50, 50, INTER.CV_INTER_CUBIC); //resize function
                acc = ReturnBlackPixels(img_BD);
                if (acc > 20)
                    Bin_HSV_Black(img_BD);

                else
                    Bin_HSV_Red(img_BD);



                relacoes[B_D] = Pixels_Iguais(img, img_BD); //percentagens de igualdade
            }
            double Min = relacoes.Min();
            int index = Array.IndexOf(relacoes, Min);
            string path = Base_Dados[index];
            string result = Path.GetFileNameWithoutExtension(path);
            frase += "\n" + result;
            Console.WriteLine(result);
            //o Nome da carta correspondente
            return result;
        }
        public static double Pixels_Iguais(Emgu.CV.Image<Bgr, byte> img, Emgu.CV.Image<Bgr, byte> imgDB)
        {
            unsafe
            {
                MIplImage imgOriginal = img.MIplImage;
                byte* dataPtrImg = (byte*)imgOriginal.imageData.ToPointer(); // Pointer to the image

                MIplImage imgDataBase = imgDB.MIplImage;
                byte* dataPtrImgDB = (byte*)imgDataBase.imageData.ToPointer();
                int percent = 0;

                int width = img.Width;
                int height = img.Height;
                int nChan = imgOriginal.nChannels; // number of channels - 3
                int padding = imgOriginal.widthStep - imgOriginal.nChannels * imgOriginal.width;

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        percent += Math.Abs((dataPtrImg + i * nChan + j * imgOriginal.widthStep)[0] - (dataPtrImgDB + i * nChan + j * imgDataBase.widthStep)[0]);
                    }
                }

                return percent;
            }

        }


        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G,
            color.B));
            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);

            value = max / 255d;


        }

        public static int ReturnBlackPixels(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int step = m.widthStep; // alinhament bytes (padding)
                byte blue, green, red;

                int acc = 0;

                if (nChan == 3)
                {
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            blue = (dataPtr + x * nChan + y * m.widthStep)[0];
                            green = (dataPtr + x * nChan + y * m.widthStep)[1];
                            red = (dataPtr + x * nChan + y * m.widthStep)[2];
                            if (blue == 0 && green == 0 && red == 0)
                            {
                                acc++;
                            }
                        }
                    }
                }
                return acc;
            }
        }


        public static void Bin_HSV_Black(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int step = m.widthStep; // alinhament bytes (padding)


                int x, y;

                if (nChan == 3)
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            Color original = Color.FromArgb((dataPtr + nChan * x + step * y)[2],
    (dataPtr + nChan * x + step * y)[1], (dataPtr + nChan * x + step * y)[0]);
                            ColorToHSV(original, out double hue, out double saturation, out double value);
                            //if a media das 3rgb > threshhold
                            // r = 255 =b=g
                            //else r = b


                            if (value < 0.5) // verm hue <30 ou hue sup 340 e satruration>0.5
                            {
                                (dataPtr + x * nChan + y * m.widthStep)[0] = 255;
                                (dataPtr + x * nChan + y * m.widthStep)[1] = 255;
                                (dataPtr + x * nChan + y * m.widthStep)[2] = 255;


                            }
                            else
                            {
                                (dataPtr + x * nChan + y * m.widthStep)[0] = 0;
                                (dataPtr + x * nChan + y * m.widthStep)[1] = 0;
                                (dataPtr + x * nChan + y * m.widthStep)[2] = 0;
                            }
                        }
                    }
                }
            }
        }
        public static void Bin_HSV_Red(Emgu.CV.Image<Bgr, byte> img)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int step = m.widthStep; // alinhament bytes (padding)


                int x, y;

                if (nChan == 3)
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            Color original = Color.FromArgb((dataPtr + nChan * x + step * y)[2],
    (dataPtr + nChan * x + step * y)[1], (dataPtr + nChan * x + step * y)[0]);
                            ColorToHSV(original, out double hue, out double saturation, out double value);
                            //if a media das 3rgb > threshhold
                            // r = 255 =b=g
                            //else r = b

                            if (hue < 30 || hue > 340 && saturation > 0.5) // verm hue <30 ou hue sup 340 e satruration>0.5
                            {
                                (dataPtr + x * nChan + y * m.widthStep)[0] = 255;
                                (dataPtr + x * nChan + y * m.widthStep)[1] = 255;
                                (dataPtr + x * nChan + y * m.widthStep)[2] = 255;


                            }
                            else
                            {
                                (dataPtr + x * nChan + y * m.widthStep)[0] = 0;
                                (dataPtr + x * nChan + y * m.widthStep)[1] = 0;
                                (dataPtr + x * nChan + y * m.widthStep)[2] = 0;
                            }
                        }
                    }
                }
            }
        }
        public static void rodarcarta(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                MIplImage m = img.MIplImage;
                byte* dataPtrImg = (byte*)m.imageData.ToPointer(); // Pointer to the image

                int width = img.Width;
                int height = img.Height;

                double width_t = img.Width;
                double height_t = img.Height;

                double proporcao = (width_t / height_t);

                if (proporcao < 0.72) return;

                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int dx = 0, dy = 0;
                //specific to 

                byte blue, green, red;

                int[,] labels = new int[height, width];
                int etiqueta = 1;
                bool alarme;

                int x1, y1, x2, y2;
                x1 = x2 = y2 = y1 = 0;
                int x, y;
                double d1 = 0, d2 = 0;
                blue = (dataPtrImg + 1 * nChan + 1 * m.widthStep)[0];
                green = (dataPtrImg + 1 * nChan + 1 * m.widthStep)[1];
                red = (dataPtrImg + 1 * nChan + 1 * m.widthStep)[2];
                alarme = false;
                int conter = 0;
                int conter2 = 0;

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        blue = (dataPtrImg + x * nChan + y * m.widthStep)[0];
                        green = (dataPtrImg + x * nChan + y * m.widthStep)[1];
                        red = (dataPtrImg + x * nChan + y * m.widthStep)[2];

                        if (conter!= 1 && blue == 255 && red == 255 && green == 255)
                        {
                            x1 = x;
                            y1 = y;
                            conter = 1;
                        }
                        if (blue == 255 && red == 255 && green == 255)
                        {
                            x2 = x;
                            y2 = y;
                        }
                    }
                    
                }
                d1 = Math.Abs(x1 - x2);
                d2 = Math.Abs(y1 - y2);
                //float resultado = (float)Math.Atan((d2 / d1));
                //resultado = (float)Math.Abs(45.0 - resultado);
                float resultado = (float)Math.Atan2(d2, d1);
                resultado = Math.Abs(resultado - 45);
                //Translation(img,imgCopy,(int)(-img.Width/2),(int)(-img.Height/2));
                //imgCopy = img;
                Rotation(img, imgCopy, resultado);
                //imgCopy = img;
                //Translation(img,imgCopy,(int)(img.Width/2),(int)(img.Height/2));
            }

        }

    }

}
