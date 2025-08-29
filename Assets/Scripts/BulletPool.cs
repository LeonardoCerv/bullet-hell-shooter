
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class BulletPool : MonoBehaviour
{
    private static BulletPool _instance;
    public static BulletPool Instance{
        get{
            if (_instance == null)
                Debug.LogError("No instance found");
            return _instance;
        }
    }

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int initialPoolSize = 20;
    [SerializeField] private TextMeshProUGUI bulletCounterText;

    private List<Bullet> _bulletPool = new List<Bullet>();

    private void Awake(){
        if (_instance != null && _instance != this){
            Destroy(gameObject);
            return;
        }
        _instance = this;
        AddBullets(initialPoolSize);
    }

    private void AddBullets(int count){
        for (int i = 0; i < count; i++){
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            _bulletPool.Add(bullet);
            bullet.transform.parent = transform;
        }
    }

    public Bullet RequestBullet(){
        for(int i = 0; i < _bulletPool.Count; i++){
            if (!_bulletPool[i].gameObject.activeSelf){
                _bulletPool[i].gameObject.SetActive(true);
                return _bulletPool[i];
            }
        }
        AddBullets(1);
        _bulletPool[_bulletPool.Count - 1].gameObject.SetActive(true);
        return _bulletPool[_bulletPool.Count - 1];
    }

    private void Update() {
        UpdateBulletCounter();
    }

    private void UpdateBulletCounter() {
        if (bulletCounterText == null) return;

        int active = 0;
        for (int i = 0; i < _bulletPool.Count; i++) {
            if (_bulletPool[i].gameObject.activeSelf)
                active++;
        }
        bulletCounterText.text = $"Balas en pantalla: {active}";
    }
}
