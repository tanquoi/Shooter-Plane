using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 4;


    ScoreBoard scoreBoard;
    GameObject parent;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parent = GameObject.FindWithTag("SpawnAtRuntime");
        //Addrigidbody();
    }

    //private void Addrigidbody()
    //{
    //    Rigidbody rb = gameObject.AddComponent<Rigidbody>();
    //    rb.useGravity = false;
    //}

    public void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints < 1)
        {
           KillEnemy();
        }    
        
    }
    public void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
        hitPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
    }
    public void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent.transform;
        Destroy(gameObject);
    }
}
