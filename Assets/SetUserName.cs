using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetUserName : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    private TextMeshProUGUI nameField;
    // Start is called before the first frame update
    void Start()
    {
        nameField = GetComponent<TextMeshProUGUI>();
        nameField.text = "Your name: " + gameManager.userName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
