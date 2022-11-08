using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LSB
{
    public class KJB : IDisposable 
    {

        private int xPos, yPos;
        public Bitmap encode(String text, Bitmap bitmap)
        {
            byte[] message = prepareTextToEncode(text);
            xPos = yPos = 3;
            Bitmap result = new Bitmap(bitmap);

            if ((message.Length * 8) > ((bitmap.Width / 4 - 1) * (bitmap.Height / 4 - 1)))
            {

                throw new Exception("Изображение слишком мало для заданного текста.");
            }

            for (int i = 0; i < message.Length; i++)
            {
                writeByte(result, message[i]);
            }

            return result;
        }
        byte[] prepareTextToEncode(String text)
        {
            byte[] msgBytes = Encoding.ASCII.GetBytes(text);

            byte[] lenBytes = getByteArrayLength(msgBytes);

            byte[] message = new byte[msgBytes.Length + 4];
            Array.Copy(lenBytes, 0, message, 0, lenBytes.Length);
            Array.Copy(msgBytes, 0, message, lenBytes.Length, msgBytes.Length);

            return message;
        }

        private void writeByte(Bitmap img, byte byteVal)
        {
            for (int j = 7; j >= 0; j--)
            {
                int bitVal = (byteVal >> j) & 1;
                writeBit(img, bitVal);
            }
        }
        private void writeBit(Bitmap img, int bit)
        {
            if (xPos + 4 > img.Width)
            {
                xPos = 3;
                yPos += 4;
            }
            writeIntoPixel(img, xPos, yPos, bit, 0.25);
            xPos += 4;
        }
        private static int writeIntoPixel(Bitmap image, int x, int y, int bit, double energy)
        {

            Color pixel = image.GetPixel(x, y);
            int red = pixel.R;
            int green = pixel.G;
            int blue = pixel.B;

            int pixelBrightness = (int)(0.29890 * red + 0.58662 * green + 0.11448 * blue);

            int modifiedBlueComponent;
            if (bit > 0)
            {
                modifiedBlueComponent = (int)(blue + energy * pixelBrightness);
            }
            else
            {
                modifiedBlueComponent = (int)(blue - energy * pixelBrightness);
            }
            if (modifiedBlueComponent > 255)
            {
                modifiedBlueComponent = 255;
            }
            if (modifiedBlueComponent < 0)
            {
                modifiedBlueComponent = 0;
            }

            Color pixelModified = Color.FromArgb(red, green, modifiedBlueComponent);
            image.SetPixel(x, y, pixelModified);

            return modifiedBlueComponent;
        }

        public String decode(Bitmap bitmap)
        {

            xPos = yPos = 3;

            byte lenByte0 = readByte(bitmap);
            byte lenByte1 = readByte(bitmap);
            byte lenByte2 = readByte(bitmap);
            byte lenByte3 = readByte(bitmap);

            int msgLen = ((lenByte0 & 0xff) << 24) | ((lenByte1 & 0xff) << 16) | ((lenByte2 & 0xff) << 8) | (lenByte3 & 0xff);

            byte[] msgBytes = new byte[msgLen];
            for (int i1 = 0; i1 < msgLen; i1++)
            {
                msgBytes[i1] = readByte(bitmap);
            }

            String msg = Encoding.ASCII.GetString(msgBytes);
            return msg;
        }

        private byte readByte(Bitmap img)
        {
            byte byteVal = 0;

            for (int i = 0; i < 8; i++)
            {
                byteVal = (byte)((byteVal << 1) | (readBit(img) & 1));
            }

            return byteVal;
        }

        private int readBit(Bitmap img)
        {
            if (xPos + 4 > img.Width)
            {
                xPos = 3;
                yPos += 4;
            }

            int bitEstimate = (int)readFromPixel(img, xPos, yPos);
            xPos += 4;
            return bitEstimate;

        }

        private int readFromPixel(Bitmap image, int x, int y)
        {
            int estimate = 0;
            Color pixel;
            for (int i1 = 1; i1 <= 3; i1++)
            {

                pixel = image.GetPixel(x + i1, y);
                estimate += pixel.B;
            }

            for (int i1 = 1; i1 <= 3; i1++)
            {

                pixel = image.GetPixel(x - i1, y);
                estimate += pixel.B;
            }

            for (int i1 = 1; i1 <= 3; i1++)
            {

                pixel = image.GetPixel(x, y + i1);
                estimate += pixel.B;
            }

            for (int i1 = 1; i1 <= 3; i1++)
            {

                pixel = image.GetPixel(x, y - i1);
                estimate += pixel.B;
            }

            estimate /= 12;

            pixel = image.GetPixel(x, y);
            int blue = pixel.B;

            if (blue > estimate)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static byte[] getByteArrayLength(byte[] array)
        {

            byte[] lenBytes = new byte[4];

            lenBytes[0] = (byte)((array.Length >> 24) & 0xFF);
            lenBytes[1] = (byte)((array.Length >> 16) & 0xFF);
            lenBytes[2] = (byte)((array.Length >> 8) & 0xFF);
            lenBytes[3] = (byte)(array.Length & 0xFF);

            return lenBytes;
        }

        // реализуем метод Dispose()
        public void Dispose()
        {
            MessageBox.Show("Успех!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}