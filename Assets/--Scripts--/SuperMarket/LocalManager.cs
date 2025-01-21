using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalManager : MonoBehaviour
{
    public static LocalManager instance;
    private void Awake()
    {
        instance = this;
    }

}
