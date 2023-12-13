using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Music : MonoBehaviour
{
    [SerializeField]
    private AudioClip bgMusic_calm;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic(bgMusic_calm);
        DontDestroyOnLoad(gameObject);
    }
}
