using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Transform playerSpawnPoint;

    [SerializeField]
    private float activatedScale;
    [SerializeField]
    private float deactivatedScale;
    [SerializeField]
    private Color activatedColor;
    [SerializeField]
    private Color deactivatedColor;

    private bool isActive = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = deactivatedColor;

        transform.localScale *= deactivatedScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isActive)
        {

            ActivateCheckpoint();
            //playerSpawnPoint.position = transform.position;
            //isActive = true;
        }
    }

    private void ActivateCheckpoint()
    {
        isActive = true;
        playerSpawnPoint = gameObject.transform;
        transform.localScale = transform.localScale * activatedScale;
        spriteRenderer.color = activatedColor;
    }
}
