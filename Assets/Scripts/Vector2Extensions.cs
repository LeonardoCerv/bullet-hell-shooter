using UnityEngine;

public static class Vector2Extensions
{
    public static Vector2 Rotate(this Vector2 vector, float angle){
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        return rotation * vector;
    }
}
