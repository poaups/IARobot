using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientedTxt : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(Gamemanager.instance.PlayerGO.transform);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180, 0);
    }
}
