using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Girl : MonoBehaviour, ISelectable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MyInteraction()
    {
        if (!hints)
        {
            StartDialogue();
        }
        else
        {

        }
    }

}
