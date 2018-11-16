
using System.Drawing;


namespace libnoise_demo {

    public class ImageGenerator {

        private int width;
        private int height;
        private Bitmap bitmap;

        public ImageGenerator(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.bitmap = new Bitmap(width, height);
        }

        public void Draw(Color[,] colors) {
            for (var y = 0; y < this.height; y++)
            {
                for (var x = 0; x < this.width; x++)
                {
                    bitmap.SetPixel(x, y, colors[x,y]);
                }
            }
        }

        public void SaveToFile(string filename) {
            this.bitmap.Save(filename);
        }
    }
}