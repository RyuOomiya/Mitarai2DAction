using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    float _inputValueX;
    bool _fire = true;

    void OnFire(InputValue value)
    {
        //í∑âüÇµÇ…ëŒâûÇ≥ÇπÇΩÇ©Ç¡ÇΩÇØÇ«Ç‹ÇΩç°ìx
        if(_fire) StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        _fire = false;
        Instantiate(_bullet, new Vector2(transform.position.x + transform.localScale.x, 1), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        _fire = true;
    }
}
