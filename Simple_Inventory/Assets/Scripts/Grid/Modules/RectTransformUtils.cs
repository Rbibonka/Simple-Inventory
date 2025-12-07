using UnityEngine;

public static class RectTransformUtils
{
    public static bool IsRectTransformTouching(RectTransform rect1, RectTransform rect2)
    {
        Vector3[] corners1 = new Vector3[4];
        Vector3[] corners2 = new Vector3[4];

        rect1.GetWorldCorners(corners1);
        rect2.GetWorldCorners(corners2);

        float minX1 = corners1[0].x;
        float maxX1 = corners1[2].x;
        float minY1 = corners1[0].y;
        float maxY1 = corners1[2].y;

        float minX2 = corners2[0].x;
        float maxX2 = corners2[2].x;
        float minY2 = corners2[0].y;
        float maxY2 = corners2[2].y;

        bool overlapsX = maxX1 >= minX2 && maxX2 >= minX1;
        bool overlapsY = maxY1 >= minY2 && maxY2 >= minY1;

        return overlapsX && overlapsY;
    }
}