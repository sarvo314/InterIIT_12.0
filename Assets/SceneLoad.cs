using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private float sceneLoadTime;
    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScene", sceneLoadTime);
    }

    private void ChangeScene()
    {
        StartCoroutine(LoadScene()); 
    }

    IEnumerator LoadScene()
    {
        animator.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
