using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    bool _fire = true;
    
    void OnFire(InputValue value)
    {
        //�������ɑΉ����������������ǂ܂����x
        if(_fire) StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        _fire = false;
        Instantiate(_bullet, new Vector2(transform.position.x + transform.localScale.x, 1), Quaternion.identity).
            GetComponent<Bullet>().SetBulletDirection(1);
        yield return new WaitForSeconds(0.5f);
        _fire = true;
    }
}
