using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject dirtBlockPrefab;

    private PlayerMovement playerMovement;
    private List<GameObject> dirtBlocks = new();
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 playerPosition = transform.position;
            Vector2 diff = mousePosition - playerPosition;

            Vector3 direction = diff.normalized;
            Vector3 roundedDirection = new Vector3(
                Mathf.RoundToInt(direction.x),
                Mathf.RoundToInt(direction.y),
                0f
            );

            // Do something with the rounded direction
            Debug.Log("Rounded Direction: " + roundedDirection);

            GameObject spawnedDirtBlock = Instantiate(dirtBlockPrefab);
            Vector3 newPosition = transform.position + roundedDirection * 1.5f;
            newPosition = GameManager.Instance.RoundVectorToInt(newPosition);
            spawnedDirtBlock.transform.position = newPosition;
            dirtBlocks.Add(spawnedDirtBlock);
        }
    }
}
