using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUseableObject
{
    bool isDirectUse 
    {
        get;
    }
    void Used();
}
