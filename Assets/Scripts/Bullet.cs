using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float lifeTime = 5f;
    private float currentLife = 0f;

    public Vector2 Velocity;

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)Velocity * Time.deltaTime;
        currentLife += Time.deltaTime;
        if (currentLife >= lifeTime)
        {
            Disable();
        }
    }

    private void Disable()
    {
        currentLife = 0f;
        gameObject.SetActive(false);
    }
}
