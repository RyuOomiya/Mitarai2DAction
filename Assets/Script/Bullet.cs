using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    enum Infor
    { 
        Player,
        Enemy
    }

    Infor _infor;

    [SerializeField] float _speed = 2f;
    [SerializeField] float _lifeTime = 5f;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _enemy;

    int _bulletdir;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }
    public void SetBulletDirection(int dir)
    {
        if(dir == 1) _infor = Infor.Player;
        if(dir == -1) _infor = Infor.Enemy;
        _bulletdir = dir;
    }
    void Update()
    {
        if (_infor == Infor.Player) 
        {
            if(Collision.BoxCollision(transform.position, _enemy.transform.position,
                                                            transform.localScale, _enemy.transform.localScale))
            {

            }
        } 
        if (_infor == Infor.Enemy)
        {
            if(Collision.BoxCollision(transform.position, _player.transform.position,
                                                            transform.localScale, _player.transform.localScale))
            {
                _player.GetComponent<PlayerController>().Damage();
                Destroy(this.gameObject);
            }
        }
        LifeTime();  
        transform.position = new Vector2(transform.position.x + (_speed * Time.deltaTime) * _bulletdir,
            transform.position.y);
    }

    void LifeTime()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0) Destroy(this.gameObject);
    }
}
