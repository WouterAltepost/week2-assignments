using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ConwayGameOfLife
{
    public class ConwayGameOfLifeDrawer
    {
        private ConwayGameOfLife game;
        private Image image;
        private int stretch;
        private WriteableBitmap writeableBitmap;
        private byte[] pixels1d;

        public ConwayGameOfLifeDrawer()
        {
            this.game = null;
        }

        public void Initialize(ConwayGameOfLife game, Image image, int stretch)
        {
            this.game = game;
            this.image = image;
            this.stretch = stretch;

            int width = this.game.Space.GetLength(1);
            int height = this.game.Space.GetLength(0);

            pixels1d = new byte[height * stretch * width * stretch];
            writeableBitmap = new WriteableBitmap(width * stretch, height * stretch,
                            96, 96, PixelFormats.Gray8, null);
        }

        public void Draw()
        {
            if (this.game == null)
                return;

            int width = this.game.Space.GetLength(1);
            int height = this.game.Space.GetLength(0);

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    byte color = this.game.Space[row, col] ? (byte)0 : (byte)255;

                    // position of space cell in 1d array
                    int index = stretch * row * width * stretch + col * stretch;

                    for (int r = 0; r < stretch; r++)
                    {
                        int index2 = index + r * width * stretch;
                        for (int c = 0; c < stretch; c++)
                        {
                            pixels1d[index2 + c] = color;
                        }
                    }
                }
            }

            // update writeable bitmap with the colorArray to the image
            Int32Rect rect = new Int32Rect(0, 0, width * stretch, height * stretch);
            int stride = width * stretch;
            writeableBitmap.WritePixels(rect, pixels1d, stride, 0);

            // set the image source
            image.Source = writeableBitmap;
        }
    }
}