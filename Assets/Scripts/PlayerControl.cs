using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform sideMovementRoot;
    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;

    [SerializeField] private float sideMovementSensitivity;
    [SerializeField] private float sideMovementLerpSpeed;

    [SerializeField] private Projectile laserPrefab;


    private Vector2 inputDrag;
    private Vector2 previousMousePosition;

    private float leftLimitX => leftLimit.localPosition.x;
    private float rightLimitX => rightLimit.localPosition.x;

    private float sideMovementTarget = 0;
    private Vector2 mousePositionCM // Providing the same experience to everyone
    {
        get
        {
            Vector2 pixels = Input.mousePosition;
            var inches = pixels / Screen.dpi;
            var centimetres = inches * 2.54f; // 1 inch = 2.54 cm

            return centimetres;
        }
    }
    #endregion
    void Update()
    {
        HandleInput();
        HandleSideMovement();
    }

    private void HandleSideMovement()
    {
        sideMovementTarget += inputDrag.x * sideMovementSensitivity;
        sideMovementTarget = Mathf.Clamp(sideMovementTarget, leftLimitX, rightLimitX);

        var localPos = sideMovementRoot.localPosition;

        localPos.x = Mathf.Lerp(localPos.x, sideMovementTarget, Time.deltaTime * sideMovementLerpSpeed);

        sideMovementRoot.localPosition = localPos;
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousMousePosition = mousePositionCM;
        }
        if (Input.GetMouseButton(0))
        {
            var deltaMouse = (Vector2)mousePositionCM - previousMousePosition;
            inputDrag = deltaMouse;
            previousMousePosition = mousePositionCM;
        }
        else
        {
            inputDrag = Vector2.zero;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(laserPrefab, transform.position, Quaternion.identity);
    }
}
