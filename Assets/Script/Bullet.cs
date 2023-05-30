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
    GameObject _player;
    EnemyManager _enemyManager;

    Vector2 _bulletdir;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _enemyManager = GameObject.FindObjectOfType<EnemyManager>();
    }

    public void SetBulletDirection(Vector2 dir)
    {
        if (dir.x == -1) _infor = Infor.Enemy;
        else _infor = Infor.Player;
        _bulletdir = dir;
    }

    void Update()
    {
        IsCollision();
        LifeTime();
        transform.position = new Vector2(transform.position.x + (_bulletdir.x * Time.deltaTime),
            transform.position.y + (_bulletdir.y * Time.deltaTime));
    }

    void LifeTime()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0) Destroy(this.gameObject);
    }

    void IsCollision()
    {
        if (_infor == Infor.Player)
        {
            for (int i = 0; i < _enemyManager.Enemies.Count; i++)
            {
                if (_enemyManager.Enemies[i] != null && Collision.BoxCollision(transform.position, _enemyManager.Enemies[i].transform.position,
                                                                transform.localScale, _enemyManager.Enemies[i].transform.localScale))
                {
                    _enemyManager.Enemies[i].GetComponent<Enemy>().Damage();
                    Destroy(this.gameObject);
                }
            }
        }
        if (_infor == Infor.Enemy)
        {
            if (_player != null && Collision.BoxCollision(transform.position, _player.transform.position,
                                                            transform.localScale, _player.transform.localScale))
            {
                _player.GetComponent<PlayerController>().Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
