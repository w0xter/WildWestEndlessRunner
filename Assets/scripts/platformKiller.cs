using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformKiller : MonoBehaviour
{
    public float lifetime;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
