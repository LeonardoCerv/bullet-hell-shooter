using UnityEngine;

public static class Shooting
{
    public static void Simple(Vector2 origin, Vector2 velocity)
    {
        Bullet bullet = BulletPool.Instance.RequestBullet();
        bullet.transform.position = origin;
        bullet.Velocity = velocity;
    }

    public static void Radial(Vector2 origin, Vector2 direction, Settings settings){
        float angle = 360f / settings.NumberOfBullets;

        if (settings.AngleOffset != 0f && settings.PhaseOffset != 0f){
            direction = direction.Rotate(settings.AngleOffset + (settings.PhaseOffset * angle));
        }

        for (int i = 0; i < settings.NumberOfBullets; i++){
            float bulletAngle = i * angle;

            if(settings.RadialMask && bulletAngle > settings.MaskAngle){
                break;
            }

            Vector2 bulletDirection = direction.Rotate(bulletAngle);
            Simple(origin, bulletDirection * settings.BulletSpeed * 3);
        }
    }
}
