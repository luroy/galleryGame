using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{

    public AudioSource walkSound;

    private CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        walkSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (charController.isGrounded == true && charController.velocity.magnitude > 2f && !walkSound.isPlaying) {
            walkSound.Play();
        }
    }
}
