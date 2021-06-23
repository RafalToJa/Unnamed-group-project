using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    public Transform parentTransform;
    public Transform playerTransform;
    private void Update()
    {
        #region RotateLogic
        float angle;
        Vector2 dir = playerTransform.position - transform.position;
        angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(-angle + 90, Vector3.forward);
        transform.rotation = rotation;
        
        #endregion
    }
    
}
