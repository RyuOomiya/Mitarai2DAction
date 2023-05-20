using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _fireDis;
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(_player.transform.position,transform.position) <= _fireDis)
        {
            
        }
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);

        Instantiate(_bullet, new Vector2(transform.position.x, 1), Quaternion.identity).
            GetComponent<Bullet>().SetBulletDirection(-1);
    }
}
