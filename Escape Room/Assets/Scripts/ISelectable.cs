using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
 
    public virtual void MyInteraction()
    {
        Debug.Log("I am doing a thing.");
    }
}
