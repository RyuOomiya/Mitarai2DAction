using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _fireDis;
    bool _fire = true;

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }
    void Update()
    {
        if(Vector3.Distance(_player.transform.position,transform.position) <= _fireDis && _fire)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        _fire = false;
        Instantiate(_bullet, transform.position, Quaternion.identity).
            GetComponent<Bullet>().SetBulletDirection(-1);
        yield return new WaitForSeconds(3f);
        _fire = true;
    }
}
