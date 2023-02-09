using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class LookInteraction : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject currentTarget;
    public ParticleSystem hoverEffect;
    public GameObject selectEffect;
    public float timeToSelect = 3.0f;
    Transform camera;
    private float countDown;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        countDown = timeToSelect;
    }

    // Update is called once per frame
    void Update()
    {
        bool isHitting = false;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (targets.Contains<GameObject>(hit.collider.gameObject))
            {
                currentTarget = hit.collider.gameObject;
                isHitting = true;
            }
        }

        if (isHitting)
        {
            if (countDown > 0.0f)
            {
                // on target 
                countDown -= Time.deltaTime;
                // print (countDown); 
                hoverEffect.transform.position = hit.point;
                if (hoverEffect.isStopped)
                {
                    hoverEffect.Play();
                }
            }
            else
            {
                // killed 
                Instantiate(selectEffect, currentTarget.transform.position, currentTarget.transform.rotation);
                currentTarget.GetComponent<ISelectable>().MyInteraction();

                countDown = timeToSelect;
            }
        }
        else
        {
            // reset 
            countDown = timeToSelect;
            hoverEffect.Stop();
        }
    }
}
