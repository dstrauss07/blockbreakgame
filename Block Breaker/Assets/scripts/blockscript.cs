using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockscript : MonoBehaviour {

    [SerializeField] AudioClip breakSound;
    Level level;
    [SerializeField] GameObject blockSparklesVFX;


    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
     }

    private void DestroyBlock()
    {
        PlaybockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void PlaybockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        FindObjectOfType<GameStatus>().AddtoScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
    }
}
