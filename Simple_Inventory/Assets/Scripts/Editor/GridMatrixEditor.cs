using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridConfig))]
public sealed class GridMatrixEditor : Editor
{
    private const int Rows = 4;
    private const int Columns = 4;

    public override void OnInspectorGUI()
    {
        GridConfig matrixExample = (GridConfig)target;

        if (matrixExample.Grid != null)
        {
            for (int i = 0; i < matrixExample.Grid.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                BoolRow row = matrixExample.Grid[i];
                if (row.row == null || row.row.Length != matrixExample.Columns)
                {
                    row.row = new bool[matrixExample.Columns];
                }
                for (int j = 0; j < row.row.Length; j++)
                {
                    row.row[j] = EditorGUILayout.Toggle(row.row[j], GUILayout.Width(20));
                }
                EditorGUILayout.EndHorizontal();
            }
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(matrixExample);
        }
    }
}