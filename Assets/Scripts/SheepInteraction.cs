using UnityEngine;

public class SheepInteraction : MonoBehaviour
{
    public GameObject particleEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carrot"))
        {
            Destroy(other.gameObject);

            if (particleEffect != null)
            {
                GameObject particles = Instantiate(particleEffect, transform.position + Vector3.up * 2, Quaternion.identity);

                ParticleSystem ps = particles.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Play();
                }

                Destroy(particles, 3f);
            }
        }
    }
}
