using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public CircleCollider2D Collider2D;
    public PersonagemController  personagemController;
    public GameObject coinParticle;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            personagemController.AddToPoints(1);
            Instantiate(coinParticle, this.transform.position, UnityEngine.Quaternion.Euler(-90,0,0));
            Destroy(this.gameObject);
            
        }
    }

}
