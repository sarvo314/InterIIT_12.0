using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetUserName : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    private TextMeshProUGUI nameField;
    private const string USERNAME = "USERNAME";
    // Start is called before the first frame update
    void Start()
    {
        nameField = GetComponent<TextMeshProUGUI>();
        nameField.text = "N A M E : " + PlayerPrefs.GetString(USERNAME);
    }
    public void SetName()
    {
        // gameManager.userName = nameField.text;
        nameField.text = "N A M E : " + PlayerPrefs.GetString(USERNAME);
        // PlayerPrefs.SetString("USERNAME", gameManager.userName);
        Debug.Log("Player name is " + nameField.text);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
