using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiCube : Ennemi
{
    GameObject player;
    public float speed = 5;
    Rigidbody rbd;
    AudioSource audioSource;
    public AudioMusic audioMusic;
    public override void Die()
    {
        audioSource.PlayOneShot(audioMusic.soundToPlay);
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rbd = GetComponent<Rigidbody>();
        audioSource = GameObject.FindGameObjectWithTag("SounPlayer").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
        FollowPlayer();


    }
    private void FollowPlayer()
    {
        rbd.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime));
    }
}
