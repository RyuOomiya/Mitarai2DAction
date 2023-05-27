using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    float _radian;

    // Update is called once per frame
    void Update()
    {
        Vector2 tmp = Input.mousePosition - transform.position;
        _radian = Mathf.Atan2(tmp.y, tmp.x);
        transform.rotation = Quaternion.AngleAxis(_radian * 180 / Mathf.PI, new Vector3(0, 0, 1));
    }
}
