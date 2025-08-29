using UnityEngine;

[System.Serializable]
public class Settings
{
    [Header("base settings")]
    public int NumberOfBullets = 12;
    public float BulletSpeed = 10f;
    public float CooldownAfterShot = 0.5f;

    [Header("offsets")]
    [Range(-1f,1f)] public float PhaseOffset = 0f;
    [Range(-180f, 180f)]public float AngleOffset = 0f;

    [Header("mask")]
    public bool RadialMask;
    [Range(0f, 360f)]public float MaskAngle = 360f;
}
