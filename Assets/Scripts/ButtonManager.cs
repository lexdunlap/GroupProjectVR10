using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour {

    public GameObject Character;
    public GameObject[] ButtonArray;
    public GameObject ButtonPrefab;
    public GameObject canvas;


    private StringBuilder ButtonString;

    // Use this for initialization
    static void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateButton(string action, Collider other)
    {
        int yOffset = ButtonArray.Length * 30;
        ButtonString.Append(action);
        ButtonString.Append(" ");
        ButtonString.Append(other.tag);
        GameObject newButton = Instantiate(ButtonPrefab) as GameObject;
    }
}
