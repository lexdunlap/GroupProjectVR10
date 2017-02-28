using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharController : MonoBehaviour
{
    public List<Collider> nearMe = new List<Collider>();
    public Text localToMe;
    public float walkSpeed = 2.5f;
    public float runSpeed = 5.0f;
    public float smoothing = 1.0f;
    public Button ForwardButton;

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
            }
        }
        localToMe.text = "Objects: \n" + listNearMe;
    }

    private Vector3 SetTarget()
    {
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        float z = gameObject.transform.position.z;
        return new Vector3(x, y, z + 5.0f);
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
