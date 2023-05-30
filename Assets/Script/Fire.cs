using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] PlayerRotation _pRot;
    bool _fire = true;
    
    void OnFire(InputValue value)
    {
        //�������ɑΉ����������������ǂ܂����x
        if(_fire) StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        _fire = false;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shotDir = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;
        Instantiate(_bullet, new Vector2(transform.position.x + shotDir.x, transform.position.y), _pRot.PlayerDir).
            GetComponent<Bullet>().SetBulletDirection(shotDir);
        yield return new WaitForSeconds(0.5f);
        _fire = true;
    }
}
