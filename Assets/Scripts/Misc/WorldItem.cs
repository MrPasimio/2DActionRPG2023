using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField] private float spawnForce;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioClip pickupSFX;

    private ItemData itemToGive;

    void Start ()
    {
        Rigidbody2D rig = GetComponent<Rigidbody2D>();
        rig.AddForce(Random.insideUnitCircle * spawnForce, ForceMode2D.Impulse);
    }

    // Continues here tomorrow
}