using UnityEngine;
using UnityEditor;

public class HashCalculatorTool : EditorWindow
{
    string inputText = "12345";

    [MenuItem("Tools/Calcular Hash...")]
    static void OpenWindow()
    {
        var w = GetWindow<HashCalculatorTool>("Hash Calculator");
        w.minSize = new Vector2(300, 60);
    }

    void OnGUI()
    {
        GUILayout.Label("Digite o texto para calcular o hash:", EditorStyles.boldLabel);
        inputText = EditorGUILayout.TextField("Texto", inputText);

        if (GUILayout.Button("Calcular"))
        {
            int hash = Animator.StringToHash(inputText);
            EditorUtility.DisplayDialog("Resultado", $"Hash de '{inputText}' = {hash}", "OK");
        }
    }
}
