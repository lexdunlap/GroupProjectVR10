using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
    public List<Collider> nearMe = new List<Collider>();
    public Text localToMe;

    private StringBuilder listNearMe = new StringBuilder();

    void Start()
    {
        updateLocals();

    }

    void Update()
    {
        
    }

    public void TurnTo(GameObject obj)
    {
        transform.LookAt(obj.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Boom, entered!");
        if (!nearMe.Contains(other))
        {
            nearMe.Add(other);
        }
        updateLocals();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Boom, exited!");
        if (nearMe.Contains(other))
        {
            nearMe.Remove(other);
        }
        updateLocals();
    }

    private void updateLocals()
    {
        listNearMe.Remove(0, listNearMe.Length);
        for(int i = 0; i < nearMe.Count; i++)
        {
            if (nearMe[i].tag != "Untagged")
            {
                listNearMe.Append(nearMe[i] + "\n");
            }
        }
        localToMe.text = "Objects: \n" + listNearMe;
    }


}
