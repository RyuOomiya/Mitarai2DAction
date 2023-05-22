using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _fireDis;

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }
    void Update()
    {
        if(Vector3.Distance(_player.transform.position,transform.position) <= _fireDis)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);

        Instantiate(_bullet, transform.position, Quaternion.identity).
            GetComponent<Bullet>().SetBulletDirection(-1);
    }
}
