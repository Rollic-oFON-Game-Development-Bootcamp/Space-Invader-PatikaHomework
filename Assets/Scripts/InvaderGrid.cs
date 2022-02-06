using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderGrid : MonoBehaviour
{
    [SerializeField] private Invader[] prefabs;

    [SerializeField] private int rows = 5;
    [SerializeField] private int columns = 11;

    [SerializeField] private float speed;

    [SerializeField] private Camera mainCamera;

    private Vector3 direction = Vector2.right;
    private void Awake()
    {
        CreateGrid();
    }
    private void CreateGrid()
    {
        for (int i = 0; i < rows; i++)
        {
            float width = 1.3f * (columns - 1);
            float height = 0.02f * (rows - 1);

            Vector2 centering = new Vector2(-width / 2, height / 2);

            Vector3 rowPosition = new Vector3(centering.x, centering.y + i * .75f, 0);
            for (int j = 0; j < columns; j++)
            {
                Invader invader = Instantiate(prefabs[i], this.transform);
                Vector3 position = rowPosition;
                position.x += j + .5f;
                invader.transform.position = position;
            }
        }
    }
}
