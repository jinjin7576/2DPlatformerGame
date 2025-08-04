using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    MovementRigidbody2D movement;

    [SerializeField]
    ParticleSystem footStepEffect;
    ParticleSystem.EmissionModule footEmission;

    [SerializeField]
    ParticleSystem landingEffect;
    bool wasOnGround;

    private void Awake()
    {
        movement = GetComponentInParent<MovementRigidbody2D>();
        footEmission = footStepEffect.emission;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.IsGrounded && movement.Velocity.x != 0)
        {
            footEmission.rateOverTime = 30;
        }
        else
        {
            footEmission.rateOverTime = 0;
        }

        if (!wasOnGround && movement.IsGrounded && movement.Velocity.y <= 0)
        {
            landingEffect.Stop();
            landingEffect.Play();
        }

        wasOnGround = movement.IsGrounded; //ÈÄÄ¡
    }
}
