using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private float cooldown = 0.5f;
    [SerializeField] private float speed = 20f;

    private float timer = 0f;

    private void Update(){
        timer -= Time.deltaTime;

        if(timer <= 0f){
            Shoot(transform.position, transform.up * speed);
            timer += cooldown;
        }
    }

    private void Shoot(Vector2 origin, Vector2 velocity){
        Bullet bullet = BulletPool.Instance.RequestBullet();
        bullet.transform.position = origin;
        bullet.Velocity = velocity;
    }

}
