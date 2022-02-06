using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Starfield : MonoBehaviour
{
    private ParticleSystem.Particle[] points;
    public int starMax = 100;
    public float starSize = 1f;
    public float starDistance = 10f;
    public float starClipDistance = 1f;

    private float starDistanceSqr;
    private float starClipDistanceSqr;
    private ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        starDistanceSqr = starDistance * starDistance;
        starClipDistanceSqr = starClipDistance *starClipDistance;
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(points == null)
        {
            CreateStars();
        }
        for (int i = 0; i < starMax; i++)
        {
            if ((points[i].position - transform.position).sqrMagnitude >starDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere * starDistance + transform.position;
            }
            if((points[i].position - transform.position).sqrMagnitude <= starClipDistanceSqr)
            {
                float percent = (points[i].position - transform.position).sqrMagnitude / starClipDistanceSqr;
                points[i].startColor = new Color(1,1,1,percent);
                points[i].startSize = starSize * percent;
            }
            particles.SetParticles(points, points.Length);
        }
    }

    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starMax];
        for(int i=0;i<starMax;i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + transform.position;
            points[i].startColor = Color.white;
            points[i].startSize = starSize;
        }
    }
}
