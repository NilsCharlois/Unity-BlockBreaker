using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	// config params
	[SerializeField] AudioClip audioClip;
	[SerializeField] GameObject blockSparkleEffect;
	[SerializeField] int timesHits;
	[SerializeField] Sprite[] hitSprites;
	
	// Cached reference
	Level level;
	
	private void Start()
	{
		level = FindObjectOfType<Level>();
		if(tag == "Breakable")
		{
			level.AddBreakableBlock();			
		}
	}
	
    private void OnCollisionEnter2D(Collision2D collision)
	{
		if(tag == "Breakable")
		{	
			timesHits++;
			int maxHits = hitSprites.Length + 1;
			if(timesHits >= maxHits)
			{
				DestroyBlock();
			}
			else
			{
				ShowNextHitSprite();
			}
		}
	}
	
	private void ShowNextHitSprite()
	{
		int spriteIndex = timesHits - 1;
		if(hitSprites[spriteIndex] != null)
		{
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
		{
			Debug.LogError("Block Sprite is missing from array");
		}
	}
	
	private void DestroyBlock()
	{
		PlayBlockDestroySFX();
		Destroy(gameObject);
		level.DestroyOneBreakableBlock();
		TriggerSparklesVFX();
	}
	
	private void PlayBlockDestroySFX()
	{		
		FindObjectOfType<GameStatus>().AddToScore();
		AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
	}
	
	private void TriggerSparklesVFX()
	{
		GameObject sparkles = Instantiate(blockSparkleEffect, transform.position, transform.rotation);
		Destroy(sparkles,1f);
	}
}
