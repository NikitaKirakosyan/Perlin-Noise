/* 
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using UnityEditor;

namespace NikitaKirakosyan.Generators
{
    public class TerrainGeneratorWindow : EditorWindow
    {
        private const string _menuItemName = "Generators/Generate Terrain";

        private Texture2D _heightMap = null;

        #region Unity Methods
        private void OnGUI()
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PrefixLabel("Height map in Assets/:");
            _heightMap = (Texture2D)EditorGUILayout.ObjectField(_heightMap, typeof(Texture2D), false);

            EditorGUILayout.Space();
            EditorGUI.EndChangeCheck();

            GUI.color = Color.green;
            if (GUILayout.Button("Generate", GUILayout.Height(EditorGUIUtility.singleLineHeight * 2f)))
            {
                TerrainGenerator.Generate(_heightMap);
            }
            GUI.color = Color.white;
        }
        #endregion

        #region Public Methods
        [MenuItem(_menuItemName)]
        public static void DisplayWindow()
        {
            var window = GetWindow<TerrainGeneratorWindow>(true, "Terrain Generator");
            var position = window.position;
            position.size = new Vector2(position.size.x, 128);
            position.center = new Rect(0f, 0f, Screen.currentResolution.width, Screen.currentResolution.height).center;
            window.position = position;
            window.Show();
        }
        #endregion
    }
}