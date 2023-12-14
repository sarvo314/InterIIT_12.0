using MimicSpace;
using System;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;
    private Renderer rend;
    private Material lavaMaterial;
    private Vector2 offset;
    [SerializeField] private float lavaSpeed;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            lavaMaterial = rend.material;
        }
        else
        {
            Debug.LogError("Renderer or material not found!");
            enabled = false;
            return;
        }
        
        offset = new Vector2(0f, 0f);
    }

    void Update()
    {
        transform.localScale += new Vector3(0f, 1f, 0f) * lavaSpeed * Time.deltaTime;
        // Calculate the new offset based on time and scrollSpeed
        float offsetX = Time.time * scrollSpeed;
        float offsetY = Mathf.Sin(Time.time) * scrollSpeed * 0.1f; // Adjust Y offset for additional effect
        offset.x = offsetX;
        offset.y = offsetY;

        // Apply the new offset to the material
        lavaMaterial.SetTextureOffset("_MainTex", offset);
    }
    public void SetLavaSpeed(float speed)
    {
        lavaSpeed = speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Die();
            
        }

        else if(other.gameObject.TryGetComponent<Mimic>(out Mimic mimic))
        {
            Debug.Log("Gottem");
            mimic.Death();
        }
    }
}