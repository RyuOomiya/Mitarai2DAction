using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 2f;
    int _bulletdir;

    public void SetBulletDirection(int dir)
    {
        _bulletdir = dir;
    }
    void Update()
    {
        transform.position = new Vector2((transform.position.x + _speed * Time.deltaTime) * _bulletdir,
            transform.position.y);
    }
}
