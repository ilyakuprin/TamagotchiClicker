#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace TamagotchiClicker
{
    [CustomEditor(typeof(SettingLanguage))]
    public class SettingLanguageGUI : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var settingLanguage = (SettingLanguage)target;

            if (GUILayout.Button("FindAllLanguageText"))
            {
                settingLanguage.FindAllLanguageText();
            }

        }
    }
}
#endif