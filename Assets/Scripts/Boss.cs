using UnityEngine;
using System.Collections;

public class Penguin : MonoBehaviour
{
    [SerializeField] private Pattern pattern1;
    [SerializeField] private Pattern pattern2;
    [SerializeField] private Pattern pattern3;
    private bool _onShotPattern = false;
    private int _currentPatternIndex = 0;

    void Update(){
        if (_onShotPattern){
            return;
        }
        StartCoroutine(ShotCyclePatternsCoroutine());
    }

    private IEnumerator ShotCyclePatternsCoroutine()
    {
        _onShotPattern = true;

        Pattern currentPattern = GetCurrentPattern();
        if (currentPattern == null){
            _onShotPattern = false;
            yield break;
        }
        yield return StartCoroutine(ShotPatternCoroutine(currentPattern));

        _currentPatternIndex = (_currentPatternIndex + 1) % 3;

        _onShotPattern = false;
    }

    private Pattern GetCurrentPattern()
    {
        switch (_currentPatternIndex){
            case 0: return pattern1;
            case 1: return pattern2;
            case 2: return pattern3;
            default: return null;
        }
    }

    private IEnumerator ShotPatternCoroutine(Pattern pattern)
    {
        int lap = 0;
        Vector2 direction = transform.up;
        Vector2 center = transform.position;

        yield return new WaitForSeconds(pattern.StartWait);

        while(lap < pattern.Repetitions){
            if (lap > 0 && pattern.AngleOffsetBetweenreps != 0f)
            {
                direction = direction.Rotate(pattern.AngleOffsetBetweenreps);
            }

            for(int i = 0; i < pattern.settings.Length; i++)
            {
                Shooting.Radial(center, direction, pattern.settings[i]);
                yield return new WaitForSeconds(pattern.settings[i].CooldownAfterShot);
            }
            lap++;
        }

        yield return new WaitForSeconds(pattern.EndWait);
    }
}
