using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
	[SerializeField] int breakableBlocks; // serialized for debugging purposes
	
	// cached scene loader
	SceneLoader sceneLoader;
	
	public void Start()
	{
		sceneLoader = FindObjectOfType<SceneLoader>();
	}	
	
	public void AddBreakableBlock()
	{
		breakableBlocks ++ ;
	}
	
	public void DestroyOneBreakableBlock()
	{
		breakableBlocks -- ;
		if(breakableBlocks <= 0)
		{
			sceneLoader.LoadNextScene();
		}
	}
}
