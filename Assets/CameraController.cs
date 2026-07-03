using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public BoxCollider2D Collider2D;
    public bool isWall;
    private Vector3 lockedX;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Parede"))
        {
            lockedX = this.gameObject.transform.position ;
            isWall = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Parede"))
        {
            isWall = false;
        }
    }
    void Start(){
        
    }
      void Update(){
        while(isWall){
            this.gameObject.transform.position = lockedX;
        }
}
}