using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    float _radian;
    private Quaternion _playerDir;
    public Quaternion PlayerDir => _playerDir;
    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 tmp = mouseWorldPos - transform.position;
        _radian = Mathf.Atan2(tmp.y, tmp.x);
        _playerDir = Quaternion.AngleAxis(_radian * 180 / Mathf.PI, new Vector3(0, 0, 1));
        transform.rotation = _playerDir;
    }
}
