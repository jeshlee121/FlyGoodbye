using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public OVRInput.Controller controller;

    // Use this for initialization
    private float indexTriggerState = 0;
    private float handTriggerState = 0;
    private float oldIndexTriggerState = 0;

    private bool holdingPan = false;
    private GameObject Pan = null;

    public Vector3 holdPosition = new Vector3(0.0f, -0.025f, 0.03f);
    public Vector3 holdRotation = new Vector3(0, 180, 0);

    // Update is called once per frame
    void Update () {
        oldIndexTriggerState = indexTriggerState;
        indexTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        handTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pan"))
        {
            if (handTriggerState > 0.9f && !holdingPan)
            {
               
                Grab(other.gameObject);
            }
        }
    }

    void Grab(GameObject obj)
    {

        holdingPan = true;
        Pan = obj;

        Pan.transform.parent = transform;

        Pan.transform.localPosition = holdPosition;
        Pan.transform.localEulerAngles = holdRotation;

        Pan.GetComponent<Rigidbody>().useGravity = false;
        Pan.GetComponent<Rigidbody>().isKinematic = true;

    }
}
