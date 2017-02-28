using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
    public List<Collider> nearMe = new List<Collider>();
    public Text localToMe;
    public ButtonManager btnMgr;

    private StringBuilder listNearMe = new StringBuilder();
    private Vector3 target;
    private NavMeshAgent me;

    void Start()
    {
        me = GetComponent<NavMeshAgent>();
        UpdateLocals();
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
        if (!nearMe.Contains(other))
        {
            nearMe.Add(other);
        }
        UpdateLocals();
    }

    private void OnTriggerExit(Collider other)
    {
        if (nearMe.Contains(other))
        {
            nearMe.Remove(other);
        }
        UpdateLocals();
    }

    private void UpdateLocals()
    {
        listNearMe.Remove(0, listNearMe.Length);
        for(int i = 0; i < nearMe.Count; i++)
        {
            if (nearMe[i].tag != "Untagged")
            {
                listNearMe.Append(nearMe[i] + "\n");
                //I put this here instead of OnTriggerEnter because the
                //very convenient "Untagged" filter is already here.
                //Have no idea why it's okay to add a collider to that list
                //but not pass it to the ButtonManager
                //btnMgr.CreateButton("Look at", nearMe[i]);
            }
        }
        localToMe.text = "Objects: \n" + listNearMe;
    }

    private Vector3 SetTarget()
    {
        Ray myRay = new Ray(gameObject.transform.position, transform.forward);
        Vector3 target = myRay.GetPoint(5.0f);
        return target;
    }

    private Vector3 SetTarget(Collider other)
    {
        float x = other.transform.position.x;
        float y = other.transform.position.y;
        float z = other.transform.position.z;
        return new Vector3(x, y, z);
    }

    public void MoveForward()
    {
        me.SetDestination(SetTarget());
    }

}
