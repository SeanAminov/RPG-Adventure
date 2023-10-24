using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject

{

    private bool z_Interacted = false;
    // Start is called before the first frame update
     protected override void OnCollided(GameObject collidedObject) {
       

        if (Input.GetKey(KeyCode.E)) {
            OnInteract();
        }
    }

    private void OnInteract() {
        if (!z_Interacted) {
            z_Interacted = true;
            Debug.Log("INTERACT WITH " + name);
        } 
    }
}
