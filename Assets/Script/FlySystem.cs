using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlySystem : MonoBehaviour {
	public ParticleSystem flysystem;
	public ParticleSystem splatterParticles;
	public Text collision;
	int numCollisions;

	// Use this for initialization
	void Start () {
		numCollisions = 0;
		collision.text = "collisions: 0";
        //part = GetComponent<ParticleSystem>();
        //collisionEvents = new List<ParticleCollisionEvent>();
    }
	
	// Update is called once per frame
	void Update () {
//		emits one fly every other frame
		if (Input.GetKeyDown("j")) {
			StartCoroutine("SpawnFlies");
           
		}


	}

	void OnParticleCollision(GameObject other) {

        /*int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }
            i++;
        }*/
        Debug.Log ("collided");
		EmitAtLocation ();
		numCollisions += 1;
		collision.text = "collisions: " + numCollisions.ToString() ; 
	}

	void EmitAtLocation() {
		splatterParticles.Emit (1);
	}

	IEnumerator SpawnFlies() {
		for (float f = 1f; f >= 0; f -= 0.1f) {
			flysystem.Emit (1);
       
            yield return new WaitForSeconds(.1f);
		}
	}
		
	
}
