using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehaviour : MonoBehaviour
{
    [SerializeField]
    private BoxCollider trigger;
    [SerializeField]
    private GameObject particlesSpawnPoint;
    [SerializeField]
    private ParticleSystem particlesSystem;
    [SerializeField]
    private string cubeName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == cubeName)
        {
            ParticleSystem particles = Instantiate(particlesSystem);
            particles.transform.position = particlesSpawnPoint.transform.position;
            particles.transform.parent = null;
        }
    }
}
