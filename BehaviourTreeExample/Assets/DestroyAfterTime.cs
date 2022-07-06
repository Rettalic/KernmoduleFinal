using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] public int delay = 3;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(destroy());
        
    }


    private IEnumerator destroy()
    {
        yield return new WaitForSeconds(delay);
        this.destroy();
    }
}
