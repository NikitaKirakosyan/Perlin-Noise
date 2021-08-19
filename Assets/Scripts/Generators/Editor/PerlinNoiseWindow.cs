/* 
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using UnityEditor;

namespace NikitaKirakosyan.Generators
{
    public class PerlinNoiseWindow : EditorWindow
    {
        private const string _menuItemName = "Generators/Generate Perlin Noise";

        private Texture2D _textureSource = null;

        private int _width = 32;
        private int _height = 32;

        private float _noiseScale = 8.0f;

        private float _offsetX = 0.0f;
        private float _offsetY = 0.0f;

        #region Unity Methods
        private void OnGUI()
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PrefixLabel("Texture source in Assets/:");
            _textureSource = (Texture2D)EditorGUILayout.ObjectField(_textureSource, typeof(Texture2D), false);

            EditorGUILayout.Space();
            EditorGUILayout.PrefixLabel("Noise width:");
            _width = EditorGUILayout.IntField(_width);

            EditorGUILayout.Space();
            EditorGUILayout.PrefixLabel("Noise height:");
            _height = EditorGUILayout.IntField(_height);

            EditorGUILayout.Space();
            EditorGUILayout.PrefixLabel("Noise scale:");
            _noiseScale = EditorGUILayout.FloatField(_noiseScale);

            EditorGUILayout.Space();
            EditorGUILayout.PrefixLabel("Noise offset X:");
            _offsetX = EditorGUILayout.FloatField(_offsetX);

            EditorGUILayout.Space();
            EditorGUILayout.PrefixLabel("Noise offset Y:");
            _offsetY = EditorGUILayout.FloatField(_offsetY);

            EditorGUILayout.Space();
            EditorGUI.EndChangeCheck();

            GUI.color = Color.green;
            if (GUILayout.Button("Generate", GUILayout.Height(EditorGUIUtility.singleLineHeight * 2f)))
            {
                _textureSource = PerlinNoiseGenerator.GeneratePerlinNoise(_textureSource, _width, _height, _noiseScale, _offsetX, _offsetY);
            }
            GUI.color = Color.white;
        }
        #endregion

        #region Public Methods
        [MenuItem(_menuItemName)]
        public static void DisplayWindow()
        {
            var window = GetWindow<PerlinNoiseWindow>(true, "Perlin Noise");
            var position = window.position;
            position.size = new Vector2(position.size.x, 512);
            position.center = new Rect(0f, 0f, Screen.currentResolution.width, Screen.currentResolution.height).center;
            window.position = position;
            window.Show();
        }
        #endregion
    }
}