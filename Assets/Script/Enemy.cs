using System.Collections;
using UniRx;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _fireDis;
    [SerializeField] private IntReactiveProperty _lifeCount = new IntReactiveProperty();
    public IntReactiveProperty LifeCount => _lifeCount;
    [SerializeField] private float _rate;
    private float Rate;

    private void Start()
    {
        Rate = 0;
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        if (_player != null) 
        {
            if (Vector3.Distance(_player.transform.position, transform.position) <= _fireDis)
            {
                Rate -= Time.deltaTime;
                if (Rate < 0)
                {
                    Instantiate(_bullet, transform.position, Quaternion.identity).
                    GetComponent<Bullet>().SetBulletDirection(new Vector2(-1,0));
                    Debug.Log("bang");
                    Rate = _rate;
                }
            }
        }
        
    }

    public void Damage()
    {
        _lifeCount.Value--;
    }
}
