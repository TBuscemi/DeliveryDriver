using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,0,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
    [SerializeField] float destroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;
    bool hasPackage = false;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Boooooop!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Package" && hasPackage == false){
            Debug.Log("Got The Package!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
            
        }
        if(other.tag == "Customer" && hasPackage){
            Debug.Log("Package is dropped off!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        
    }
}
