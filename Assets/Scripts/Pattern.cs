using UnityEngine;

[CreateAssetMenu(menuName = "Shoot Pattern")]
public class Pattern : ScriptableObject
{
    public int Repetitions;
    [Range(-180f, 180f)] public float AngleOffsetBetweenreps = 0f;
    public float StartWait = 0f;
    public float EndWait = 0f;
    public Settings[] settings;

}

