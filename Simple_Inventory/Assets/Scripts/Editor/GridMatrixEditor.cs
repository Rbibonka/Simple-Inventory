using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridConfig))]
public sealed class GridMatrixEditor : Editor
{
    private const string Rows = "Rows";
    private const string Columns = "Columns";

    public override void OnInspectorGUI()
    {
        GridConfig matrixExample = (GridConfig)target;

        int newRows = EditorGUILayout.IntField(Rows, matrixExample.Rows);
        int newCols = EditorGUILayout.IntField(Columns, matrixExample.Columns);

        if (newRows < 1) newRows = 1;
        if (newCols < 1) newCols = 1;

        if (newRows != matrixExample.Rows || newCols != matrixExample.Columns)
        {
            matrixExample.Rows = newRows;
            matrixExample.Columns = newCols;
            ResizeMatrix(matrixExample, newRows, newCols);
            EditorUtility.SetDirty(matrixExample);
        }

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

    private void ResizeMatrix(GridConfig matrixExample, int rows, int cols)
    {
        BoolRow[] oldMatrix = matrixExample.Grid;
        BoolRow[] newMatrix = new BoolRow[rows];

        for (int i = 0; i < rows; i++)
        {
            newMatrix[i] = new BoolRow();
            newMatrix[i].row = new bool[cols];

            if (oldMatrix != null && i < oldMatrix.Length && oldMatrix[i].row != null)
            {
                int copyCount = Mathf.Min(cols, oldMatrix[i].row.Length);
                Array.Copy(oldMatrix[i].row, newMatrix[i].row, copyCount);
            }
        }

        matrixExample.Grid = newMatrix;
    }
}