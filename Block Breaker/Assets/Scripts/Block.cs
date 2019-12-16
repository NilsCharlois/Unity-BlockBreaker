using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] AudioClip audioClip;
	
	// Cached reference
	Level level;
	
	private void Start()
	{
		level = FindObjectOfType<Level>();
		level.AddBreakableBlock();
	}
	
    private void OnCollisionEnter2D(Collision2D collision)
	{
		AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
		Destroy(gameObject);
		level.DestroyOneBreakableBlock();
	}
}
