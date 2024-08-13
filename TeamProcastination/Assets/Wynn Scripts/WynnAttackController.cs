using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WynnAttackController : MonoBehaviour
{
    public GameObject HitBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitBoxActive()
    {
        HitBox.SetActive(true);
    }

    public void HitBoxOff()
    {
        HitBox.SetActive(false);
    }
}
