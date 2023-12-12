using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

	public enum CollectibleTypes {NoType, Star}; // you can replace this with your own labels for the types of collectibles in your game!

	public CollectibleTypes CollectibleType; // this gameObject's type

	public bool rotate; // do you want it to rotate?

	public float rotationSpeed;

	public AudioClip collectSound;

	public GameObject collectEffect;

	private Player player;
	private bool canTrigger = true;
	private float debounceTime = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		if (canTrigger && other.tag == "Player")
		{
			Collect ();
			
			canTrigger = false;
			StartCoroutine(ResetTrigger());
			
		}
	}
	IEnumerator ResetTrigger() {
		yield return new WaitForSeconds(debounceTime);
		canTrigger = true;
	}
	public void Collect()
	{
		if (collectSound)
		{
			AudioManager.Instance.PlayAudio(collectSound);
		}
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		switch (CollectibleType)
		{
			case CollectibleTypes.Star:
			{
				player = FindObjectOfType<Player>();
				player.CountStars++;
				Debug.Log("Incremented CountStars");
			}
				//Add in code here;
				break;
		}

		Destroy (gameObject);
	}
}
