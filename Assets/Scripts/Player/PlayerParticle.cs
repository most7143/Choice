using System.Collections;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    public ParticleSystem DashParticle;

    public void StartDashParticle()
    {
        StartCoroutine(StartDashtime());
    }

    public void StopDashParticle()
    {
        //DashParticle.Stop();
    }

    private IEnumerator StartDashtime()
    {
        DashParticle.Play();
        yield return new WaitForSeconds(0.2f);
        DashParticle.Stop();
    }
}