using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECG_reader
{
    public struct EcgModel
    {
        public int YStart;
        public int YInterval;
        public int XStart;
        public int XInterval;
        public Bitmap MeshBitmap;
        public Bitmap MeshWithModelLines;
        public Bitmap Curve;
        public Bitmap CurveWithModelLines;
        public Bitmap OriginalBitmap;
        public Bitmap CalculatedCurve;
        public Bitmap CalculatedCurveWithMesh;
        public int[] CurvePoints;
    }

    public class EcgProcessor
    {
        private EcgModel InitializeEcgModel(Bitmap original)
        {
            EcgModel model = new EcgModel();
            model.YStart = -1;
            model.YInterval = -1;
            model.XStart = -1;
            model.XInterval = -1;
            model.OriginalBitmap = new Bitmap(original);
            model.CurvePoints = new int[original.Width];
            return model;
        }

        public EcgModel ProcessEcg()
        {
            Bitmap bitmap = new Bitmap(@"C:\Users\crgar\Desktop\ECG3.bmp");

            EcgModel model = InitializeEcgModel(bitmap);
            model.Curve = GetEcgData(bitmap);
            model.MeshBitmap = CreateCleanMeshBitmap(bitmap);
            CalculateTimeInterval(ref model);
            CalculateCurvePoints(ref model);
            CreateBitmapsBasedOnIntervals(ref model);
            return model;
        }

        public void CreateBitmapsBasedOnIntervals(ref EcgModel model)
        {
            model.MeshWithModelLines = CreateIntervalLinesOnTopOfBaseImage(model, model.MeshBitmap);
            model.CalculatedCurveWithMesh = CreateIntervalLinesOnTopOfBaseImage(model, model.CalculatedCurve);
            CreateCurveWithIntervalLines(ref model);
        }

        private void CalculateCurvePoints(ref EcgModel model)
        {
            Bitmap bitmap = model.Curve;
            model.CalculatedCurve = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = 0; x < bitmap.Width; x++)
            {
                bool foundAPoint = false;
                for (int y = 0; y < bitmap.Width; y++)
                {
                    if( bitmap.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
                    {
                        model.CurvePoints[x] = y;

                        // If line was vertical we need to "complete" it
                        if (x > 0)
                        {
                            int previousY = model.CurvePoints[x - 1];
                            int currentY = model.CurvePoints[x];
                            if (previousY > 0 && currentY > 0)
                            {
                                for (int gapY = Math.Min(previousY, currentY); gapY < Math.Max(previousY, currentY); gapY++)
                                {
                                    model.CalculatedCurve.SetPixel(x, gapY, Color.Green);
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void CreateCurveWithIntervalLines(ref EcgModel model)
        {
            model.CurveWithModelLines = CreateIntervalLinesOnTopOfBaseImage(model, model.Curve);
        }

        private Bitmap CreateIntervalLinesOnTopOfBaseImage(EcgModel model, Bitmap baseImage)
        {
            var bitmap = new Bitmap(baseImage);

            for (var y = model.YStart; y < bitmap.Height; y += model.YInterval)
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    bitmap.SetPixel(x, y, Color.Blue);
                }
            }

            for (var x = model.XStart; x < bitmap.Width; x += model.XInterval)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    bitmap.SetPixel(x, y, Color.Blue);
                }
            }

            return bitmap;
        }

        private Bitmap GetEcgData(Bitmap bitmap)
        {
            bitmap = new Bitmap(bitmap);
            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    var pixelColor = bitmap.GetPixel(x, y);

                    if (pixelColor.R > 50
                        && pixelColor.G > 50
                        && pixelColor.B > 50
                        )
                    {
                        bitmap.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        bitmap.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return bitmap;
        }

        private void CalculateTimeInterval(ref EcgModel ecgModel)
        {
            int SearchingIndex = 0;

            Bitmap meshBitmap = ecgModel.MeshBitmap;

            while (ecgModel.YInterval < 0)
            {
                SearchingIndex += 20;
                for (var y = 0; y < meshBitmap.Height; y++)
                {
                    Color pixelColor = meshBitmap.GetPixel(SearchingIndex, y);
                    if (pixelColor.ToArgb() == Color.Black.ToArgb())
                    {
                        if (ecgModel.YInterval == -1)
                        {
                            ecgModel.YInterval = y;
                            ecgModel.YStart = y;
                        }
                        else
                        {
                            ecgModel.YInterval = y - ecgModel.YInterval;
                            break;
                        }
                    }
                }
            }

            // Calculate X intervals (Columns)
            SearchingIndex = 20;
            while (ecgModel.XInterval < 0)
            {
                SearchingIndex += 20;
                for (var x = 0; x < meshBitmap.Width; x++)
                {
                    Color pixelColor = meshBitmap.GetPixel(x, SearchingIndex);
                    if (pixelColor.ToArgb() == Color.Black.ToArgb())
                    {
                        if (ecgModel.XInterval == -1)
                        {
                            ecgModel.XInterval = x;
                            ecgModel.XStart = x;
                            x += 5; //Skipping some lines in case the mesh is too width
                        }
                        else
                        {
                            ecgModel.XInterval = x - ecgModel.XInterval;
                            return;
                        }
                    }
                }
            }
            throw new Exception("Could not figure out the mesh");
        }

        private Bitmap CreateCleanMeshBitmap(Bitmap bitmap)
        {
            bitmap = new Bitmap(bitmap);
            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    var pixelColor = bitmap.GetPixel(x, y);

                    if (pixelColor.G > 200
                        || pixelColor.R < 170)
                    {
                        bitmap.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        bitmap.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return bitmap;
        }

        // Using unsafe direct memory access we gain performance
        /// <summary>
        /// DEPRECATED
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="originalColor"></param>
        /// <param name="replacementColor"></param>
        /// <param name="colorDiff"></param>
        /// <returns></returns>
        [Obsolete()]
        private unsafe Bitmap GetEcgDataUnsafe(Bitmap bitmap, byte[] originalColor, byte[] replacementColor, int colorDiff)
        {
            if (originalColor.Length != replacementColor.Length)
            {
                throw new ArgumentException("Original and Replacement arguments are in different pixel formats.");
            }

            if (originalColor.SequenceEqual(replacementColor))
            {
                return bitmap;
            }

            var data = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size),
                                       ImageLockMode.ReadWrite,
                                       bitmap.PixelFormat);

            // bits per point
            var bpp = Image.GetPixelFormatSize(data.PixelFormat) / 8;

            if (originalColor.Length != bpp)
            {
                throw new ArgumentException("Original and Replacement arguments and the bitmap are in different pixel format.");
            }

            byte* start = (byte*)data.Scan0;
            byte* end = start + data.Height * data.Width * bpp;  //start + data.Stride;

            for (var px = start; px < end; px += bpp)
            {
                var match = true;

                for (var bit = 0; bit < bpp; bit++)
                {
                    if (Math.Abs(px[bit] - originalColor[bit]) > colorDiff)
                    {
                        match = false;
                        break;
                    }
                }

                if (!match)
                {
                    continue;
                }

                for (var bit = 0; bit < bpp; bit++)
                {
                    px[bit] = replacementColor[bit];
                }
            }

            bitmap.UnlockBits(data);

            return bitmap;
        }
    }
}
