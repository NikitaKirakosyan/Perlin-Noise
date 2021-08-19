/* 
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

namespace NikitaKirakosyan.Generators
{
    public class PerlinNoiseGenerator
    {
        private static PerlinNoiseGenerator s_Instance = null;
        public static PerlinNoiseGenerator Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new PerlinNoiseGenerator();
                }

                return s_Instance;
            }
        }

        private Texture2D _textureSource = null;

        private int _width = 32;
        private int _height = 32;

        private float _noiseScale = 8.0f;

        private float _offsetX = 0.0f;
        private float _offsetY = 0.0f;

        #region Public Methods
        /// <summary>
        /// Используя источник в качестве текстуры, изменяет ее с учетом
        /// параметров, указанных при вызове метода и возвращает измененную текстуру.
        /// </summary>
        /// <param name="textureSource">Текстура, которая будет изменена.</param>
        /// <param name="width">Новая ширина текстуры.</param>
        /// <param name="height">Новая высота текстуры.</param>
        /// <param name="scale">Размер шума Перлина.</param>
        /// <param name="offsetX">Смещение шума по оси X.</param>
        /// <param name="offsetY">Смещение шума по оси Y.</param>
        public static Texture2D GeneratePerlinNoise(Texture2D textureSource, int width, int height, float scale, float offsetX, float offsetY)
        {
            textureSource.Resize(width, height); // Изменяем размер текстуры под указанные параметры.

            for (int x = 0; x < width; x++) // Проходимся по пикселям ширины.
            {
                for (int y = 0; y < height; y++) // Проходимся по пикселя высоты.
                {
                    // Просчитывает и возвращаем цвет пикселя на позиции X,Y.
                    Color color = CalculateColor(width, height, x, y, scale, offsetX, offsetY);
                    textureSource.SetPixel(x, y, color); // Устанавливаем пиксель в текстуре.
                }
            }

            textureSource.Apply(); // Применяем все изменения в текстуре.
            return textureSource;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Возвращает цвет для пикселя по указанным координатам от белого до черного оттенков.
        /// </summary>
        /// /// <param name="width">Ширина текстуры.</param>
        /// <param name="height">Высота текстуры.</param>
        /// <param name="x">Позиция пикселя по X.</param>
        /// <param name="y">Позиция пикселя по Y.</param>
        /// <param name="scale">Размер шума Перлина.</param>
        /// <param name="offsetX">Смещение шума по оси X.</param>
        /// <param name="offsetY">Смещение шума по оси Y.</param>
        /// <returns></returns>
        private static Color CalculateColor(int width, int height, int x, int y, float scale, float offsetX, float offsetY)
        {
            float xCoord = (float)x / width * scale + offsetX; // Координата по X.
            float yCoord = (float)y / height * scale + offsetY; // Координата по Y.

            float sample = Mathf.PerlinNoise(xCoord, yCoord); // Сэмпл, который и станет цветом пикселя.
            return new Color(sample, sample, sample);
        }
        #endregion
    }
}