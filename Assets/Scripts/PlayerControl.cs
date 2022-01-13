using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region Variables
    private float touchPosX;
    [SerializeField] private float swerveSpeed;
    [SerializeField] private float minXPos;
    [SerializeField] private float maxXPos;
    #endregion
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchPosX += Input.mousePosition.x * swerveSpeed * Time.deltaTime;
            Debug.Log("asdsad  " + touchPosX);
            transform.position += new Vector3(touchPosX, transform.position.y, transform.position.z);
        }
        transform.position = new Vector3
                (
                    Mathf.Clamp(transform.position.x, minXPos, maxXPos),
                    -4,
                    0
                );
    }
}
