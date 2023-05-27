using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 2f;
    [SerializeField] float _lifeTime = 5f;
    int _bulletdir;

    public void SetBulletDirection(int dir)
    {
        _bulletdir = dir;
    }
    void Update()
    {
        LifeTimeScope();
        
        transform.position = new Vector2(transform.position.x + (_speed * Time.deltaTime) * _bulletdir,
            transform.position.y);
    }

    void LifeTimeScope()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0) Destroy(this.gameObject);
    }
}
