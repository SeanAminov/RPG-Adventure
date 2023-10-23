using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    private Collider2D z.Collider;
    private ContactFilter2D z_Filter;
    private List<Collider2D> z_CollidedObjects;
    // Start is called before the first frame update
    void Start()
    {
        z_Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        z_Collider.OverlapCollider(z_Filter, z_CollidedObjects);
        foreach(var o in z_CollidedObjects) {
            Debug.Log("Collided with " + o.name);
        }
    }
}
