using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace riverOx_barcode128
{
    public static class Barcode128
    {
        /// <summary>
        /// Generate Barcode 128 from string
        /// </summary>
        /// <param name="barcodeString">Barcode String</param>
        /// <param name="isHumanReadable">Is Human Readable barcode</param>
        /// <returns>Base64 Encoded Barcode image string. dataType = PNG</returns>
        public static string generateBarcode(string barcodeString, bool isHumanReadable)
        {
            #region BarcodeValues_initialize
            List<string> barcodeValues = new List<string> { 
            "32 2|1|2|2|2|2",
            "33 2|2|2|1|2|2",
            "34 2|2|2|2|2|1",
            "35 1|2|1|2|2|3",
            "36 1|2|1|3|2|2",
            "37 1|3|1|2|2|2",
            "38 1|2|2|2|1|3",
            "39 1|2|2|3|1|2",
            "40 1|3|2|2|1|2",
            "41 2|2|1|2|1|3",
            "42 2|2|1|3|1|2",
            "43 2|3|1|2|1|2",
            "44 1|1|2|2|3|2",
            "45 1|2|2|1|3|2",
            "46 1|2|2|2|3|1",
            "47 1|1|3|2|2|2",
            "48 1|2|3|1|2|2",
            "49 1|2|3|2|2|1",
            "50 2|2|3|2|1|1",
            "51 2|2|1|1|3|2",
            "52 2|2|1|2|3|1",
            "53 2|1|3|2|1|2",
            "54 2|2|3|1|1|2",
            "55 3|1|2|1|3|1",
            "56 3|1|1|2|2|2",
            "57 3|2|1|1|2|2",
            "58 3|2|1|2|2|1",
            "59 3|1|2|2|1|2",
            "60 3|2|2|1|1|2",
            "61 3|2|2|2|1|1",
            "62 2|1|2|1|2|3",
            "63 2|1|2|3|2|1",
            "64 2|3|2|1|2|1",
            "65 1|1|1|3|2|3",
            "66 1|3|1|1|2|3",
            "67 1|3|1|3|2|1",
            "68 1|1|2|3|1|3",
            "69 1|3|2|1|1|3",
            "70 1|3|2|3|1|1",
            "71 2|1|1|3|1|3",
            "72 2|3|1|1|1|3",
            "73 2|3|1|3|1|1",
            "74 1|1|2|1|3|3",
            "75 1|1|2|3|3|1",
            "76 1|3|2|1|3|1",
            "77 1|1|3|1|2|3",
            "78 1|1|3|3|2|1",
            "79 1|3|3|1|2|1",
            "80 3|1|3|1|2|1",
            "81 2|1|1|3|3|1",
            "82 2|3|1|1|3|1",
            "83 2|1|3|1|1|3",
            "84 2|1|3|3|1|1",
            "85 2|1|3|1|3|1",
            "86 3|1|1|1|2|3",
            "87 3|1|1|3|2|1",
            "88 3|3|1|1|2|1",
            "89 3|1|2|1|1|3",
            "90 3|1|2|3|1|1",
            "91 3|3|2|1|1|1",
            "92 3|1|4|1|1|1",
            "93 2|2|1|4|1|1",
            "94 4|3|1|1|1|1",
            "95 1|1|1|2|2|4",
            "96 1|1|1|4|2|2",
            "97 1|2|1|1|2|4",
            "98 1|2|1|4|2|1",
            "99 1|4|1|1|2|2",
            "100 1|4|1|2|2|1",
            "101 1|1|2|2|1|4",
            "102 1|1|2|4|1|2",
            "103 1|2|2|1|1|4",
            "104 1|2|2|4|1|1",
            "105 1|4|2|1|1|2",
            "106 1|4|2|2|1|1",
            "107 2|4|1|2|1|1",
            "108 2|2|1|1|1|4",
            "109 4|1|3|1|1|1",
            "110 2|4|1|1|1|2",
            "111 1|3|4|1|1|1",
            "112 1|1|1|2|4|2",
            "113 1|2|1|1|4|2",
            "114 1|2|1|2|4|1",
            "115 1|1|4|2|1|2",
            "116 1|2|4|1|1|2",
            "117 1|2|4|2|1|1",
            "118 4|1|1|2|1|2",
            "119 4|2|1|1|1|2",
            "120 4|2|1|2|1|1",
            "121 2|1|2|1|4|1",
            "122 2|1|4|1|2|1",
            "123 4|1|2|1|2|1",
            "124 1|1|1|1|4|3",
            "125 1|1|1|3|4|1",
            "126 1|3|1|1|4|1",
            "127 1|1|4|1|1|3",
            "128 1|1|4|3|1|1",
            "129 4|1|1|1|1|3",
            "130 4|1|1|3|1|1",
            "131 1|1|3|1|4|1",
            "132 1|1|4|1|3|1",
            "133 3|1|1|1|4|1",
            "134 4|1|1|1|3|1",
            "135 2|1|1|4|1|2",
            "136 2|1|1|2|1|4",
            "137 2|1|1|2|3|2",
            "138 2|3|3|1|1|1|2"
            };
            #endregion BarcodeValues_initialize

            List<byte> ASCIIValues = Encoding.ASCII.GetBytes(barcodeString).ToList();
            // Check Bit Calculation
            int totalStringCheckSum = 0;

            for (int i = 1; i <= ASCIIValues.Count; i++)
            {
                totalStringCheckSum += (ASCIIValues[i - 1] - 32) * i;
            }
            ASCIIValues.Insert(0, 136); // For Start of the Barcode
            totalStringCheckSum += ASCIIValues[0] - 32;
            ASCIIValues.Add(Convert.ToByte(totalStringCheckSum % 103 + 32)); // For Check Charecter
            ASCIIValues.Add(106 + 32); // For Stop of the Barcode


            List<int> eachCharecterCode = new List<int>();
            foreach (var item in ASCIIValues)
            {
                eachCharecterCode.AddRange(barcodeValues[item - 32].Split(' ')[1].Split('|').Select(c => Convert.ToInt32(c)).ToList());
            }
            List<Image> images = new List<Image>();
            //List<byte> byteImage = new List<byte>();
            for (int i = 0; i < eachCharecterCode.Count; i++)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap bitMap = new Bitmap(5 * eachCharecterCode[i], 150))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitMap))
                        {
                            if (i % 2 == 0)
                                graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, bitMap.Width, bitMap.Height);
                            else
                                graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, bitMap.Width, bitMap.Height);
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            images.Add(System.Drawing.Image.FromStream(ms));
                        }

                    }
                }
            }
            int width = 0;
            int height = 0;
            foreach (Image image in images)
            {
                width += image.Width;
                height = image.Height > height ? image.Height : height;
            }
            var totalBitmap = new Bitmap(width, height + (isHumanReadable ? 40 : 0));
            using (var g = Graphics.FromImage(totalBitmap))
            {
                var localWidth = 0;
                foreach (var image in images)
                {
                    g.DrawImage(image, localWidth, 0);
                    localWidth += image.Width;
                }
                if (isHumanReadable)
                    g.DrawString(barcodeString, new Font(FontFamily.GenericSansSerif, 16), new SolidBrush(Color.Black), width / 2 - (16 * barcodeString.Length) / 2, height + 5);
            }
            string ImageUrl = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                totalBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                Convert.ToBase64String(byteImage);
                ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
            return ImageUrl;
        }

    }
}
