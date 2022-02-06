using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Variables
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    #endregion
    void Update()
    {
        ProjectileMovement();
    }

    private void ProjectileMovement() 
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
