using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _fireDis;
    [SerializeField] private float _rate;
    private float Rate;

    private void Start()
    {
        Rate = 0;
    }
    void Update()
    {
        if(Vector3.Distance(_player.transform.position,transform.position) <= _fireDis)
        {
            Rate -= Time.deltaTime;
            if(Rate < 0)
            {
                Instantiate(_bullet, transform.position, Quaternion.identity).
                GetComponent<Bullet>().SetBulletDirection(-1);
                Debug.Log("bang");
                Rate = _rate;
            }
        }
    }
}
