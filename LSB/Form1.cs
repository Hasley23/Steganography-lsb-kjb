using System;
using System.Collections;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

/*
 * Кащенко В. А. | Мультимедиа технологии | Лабораторная работв №1
 */

namespace LSB
{
    public partial class Form1 : Form
    {
        // контейнер оригинального изображения
        Bitmap bmpOriginal;
        // контейнер модифицированного изображения
        Bitmap bmpModified;

        // конструктор формы
        public Form1()
        {
            InitializeComponent();
        }

        // Открыть файл
        private void openFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (bmpOriginal != null)
                {
                    bmpOriginal.Dispose();
                    srcPic.Image.Dispose();
                }

                if (bmpModified != null)
                {
                    bmpModified.Dispose();
                    if (encodedPic.Image != null)
                        encodedPic.Image.Dispose();
                }

                Image image = Image.FromFile(dialog.FileName);
                int width = image.Width;
                int height = image.Height;

                bmpOriginal = new Bitmap(image, width, height);
                srcPic.Image = bmpOriginal;
            }

            encodedPic.Image = null;
            decText.Text = "";
            clearText.Text = "";
        }

        // конвертация байта в битовый массив
        private BitArray ByteToBit(byte src)
        {
            BitArray bitArray = new BitArray(8);
            bool st = false;
            for (int i = 0; i < 8; i++)
            {
                if ((src >> i & 1) == 1)
                {
                    st = true;
                }
                else st = false;
                bitArray[i] = st;
            }
            return bitArray;
        }

        // конвертация битового массива в байт
        private byte BitToByte(BitArray scr)
        {
            byte num = 0;
            for (int i = 0; i < scr.Count; i++)
                if (scr[i] == true)
                    num += (byte)Math.Pow(2, i);
            return num;
        }

        // Сохранить модифицированное изображение
        private void saveEncoded_Click(object sender, EventArgs e)
        {
            if (bmpModified == null)
                return;

            // сохранение рисунка с внедренным текстом
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
                "Bitmap File(*.bmp)|*.bmp|" +
                "GIF File(*.gif)|*.gif|" +
                "JPEG File(*.jpg)|*.jpg|" +
                "TIF File(*.tif)|*.tif|" +
                "PNG File(*.png)|*.png)";
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = savedialog.FileName;
                bmpModified.Save(fileName);
            }
        }

        // внедрение текста в изображение (наименее значащий бит)
        private void encBtn_Click(object sender, EventArgs e)
        {
            // проверка на "дурака"
            if (clearText.Text.Length == 0 || bmpOriginal == null)
            {
                MessageBox.Show("Недостаточно данных для внедрения!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // копируем оригинальную битовую карту рисунка
            bmpModified = (Bitmap)bmpOriginal.Clone();

            // считывание текста для внедрения
            string txt = clearText.Text;
            int len = Math.Min(txt.Length, 255);

            if (len != 0 && bmpModified != null)
            {
                int n = bmpModified.Height;
                int m = bmpModified.Width;
                for (int i = 0; i < 8; i++)
                {
                    Color p = bmpModified.GetPixel(i, n - 1);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    // внедрение бита в последний бит байта красного цвета
                    r = (r & 254) | ((len & (1 << i)) > 0 ? 1 : 0);
                    p = Color.FromArgb(a, r, g, b);
                    bmpModified.SetPixel(i, n - 1, p);
                }

                int x = 8;
                int y = n - 1;
                for (int i = 0; i < len; i++)
                {
                    int c = txt[i];
                    for (int j = 0; j < 8; j++)
                    {
                        if (x >= m)
                        {
                            y--;
                            x = 0;
                        }
                        Color p = bmpModified.GetPixel(x, y);
                        int a = p.A;
                        int r = p.R;
                        int g = p.G;
                        int b = p.B;
                        r = ((r & 254) | ((c & (1 << j)) > 0 ? 1 : 0));
                        p = Color.FromArgb(a, r, g, b);
                        bmpModified.SetPixel(x, y, p);
                        x++;
                    }
                }
            }

            // отображение закодированного файла
            encodedPic.Image = bmpModified;
            MessageBox.Show("Успех! Количество записанных символов: " + clearText.TextLength.ToString(), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // извлечение текста из изображения (наименее значащий бит)
        private void decBtn_Click(object sender, EventArgs e)
        {
            if (bmpOriginal == null || srcPic.Image == null)
            {
                MessageBox.Show("Отсутствует файл!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string txt = "";
            int len = 0;
            bmpModified = (Bitmap)bmpOriginal.Clone();
            if (bmpOriginal != null)
            {
                int n = bmpOriginal.Height;
                int m = bmpOriginal.Width;
                // вытаскиваем биты текста
                for (int i = 0; i < 8; i++)
                {
                    Color p = bmpOriginal.GetPixel(i, n - 1);
                    int r = p.R;

                    len = len | ((r & 1) << i);
                }

                int x = 8;
                int y = n - 1;
                for (int i = 0; i < len; i++)
                {
                    int c = 0;

                    for (int j = 0; j < 8; j++)
                    {
                        if (x >= m)
                        {
                            y--;
                            x = 0;
                        }
                        Color p = bmpOriginal.GetPixel(x, y);
                        int r = p.R;

                        c = c | ((r & 1) << j);
                        x++;
                    }
                    txt += (char)(c);
                }

                txt.Reverse();

                MessageBox.Show("Найдено символов: " + len.ToString(), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                decText.Text = txt;
            }
        }
        
        // Необходимые величины для КДБ алгоритма
        private const double LAMDA = 0.1;
        private const int SIGMA = 2;

        // в двоичную строку
        static string ToBinaryString(Encoding encoding, string text)
        {
            return string.Join("", encoding.GetBytes(text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
        }

        // Конвертер из бит в байт
        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }

        // список-ключ
        List<Point> key = new List<Point>();

        // Куттер-Джордан-Боссен (внедрение текста в изображение)
        private void KDB_encode_Click(object sender, EventArgs e)
        {
            // проверка на "дурака"
            if (clearText.Text.Length == 0 || bmpOriginal == null)
            {
                MessageBox.Show("Недостаточно данных для внедрения!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // алгоритм Куттера-Джордана-Боссена
            KJB kjb_instance = new KJB();

            try
            {
                // внедрение текста
                bmpModified = kjb_instance.encode(clearText.Text, bmpOriginal);
            } catch (Exception)
            {
                MessageBox.Show("Кодирование не удалось", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // отображение закодированного файла
            encodedPic.Image = bmpModified;

            // удаление сущности алгоритма
            kjb_instance.Dispose();
        }

        // Куттер-Джордан-Боссен (извлечение текста из изображения)
        private void KDB_decode_Click(object sender, EventArgs e)
        {
            if (bmpOriginal == null || srcPic.Image == null)
            {
                MessageBox.Show("Отсутствует файл!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // алгоритм Куттера-Джордана-Боссена
            KJB kjb_instance = new KJB();

            try
            {
                // декодирование и вывод
                decText.Text = kjb_instance.decode(bmpOriginal);
            } catch (Exception)
            {
                MessageBox.Show("Декодирование не удалось", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            kjb_instance.Dispose();
        }
    }
}
