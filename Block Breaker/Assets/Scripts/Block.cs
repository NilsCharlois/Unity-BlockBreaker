using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] AudioClip audioClip;
	[SerializeField] GameObject blockSparkleEffect;
	
	// Cached reference
	Level level;
	
	private void Start()
	{
		level = FindObjectOfType<Level>();
		level.AddBreakableBlock();
	}
	
    private void OnCollisionEnter2D(Collision2D collision)
	{
		DestroyBlock();
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
