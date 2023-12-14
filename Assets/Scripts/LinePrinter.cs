using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransitionAnims : MonoBehaviour
{
    public Text text;
    public string[] lines;
    [SerializeField] private float textSpeed;
    private int index;
    void Start()
    {
        text.text = string.Empty;
        startDialogue();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(text.text == lines[index]){
                nextLine();
            }
            else{
                StopAllCoroutines();
                text.text = lines[index];
            }
        }
    }

    void startDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in lines[index].ToCharArray()){
            text.text += c;
            yield return new WaitForSeconds(textSpeed);        }
    }

    void nextLine(){
        if(index < lines.Length - 1){
            index ++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            gameObject.SetActive(false);
        }
    }
}
