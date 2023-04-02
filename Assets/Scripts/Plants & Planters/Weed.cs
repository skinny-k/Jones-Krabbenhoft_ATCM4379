using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weed : MonoBehaviour
{
    [SerializeField] float _fadeOutSpeed = 0.5f;
    
    public Plant AffectedPlant = null;
    bool _pulled = false;
    
    public void PullWeed()
    {
        AffectedPlant?.PullWeed();
        _pulled = true;
    }

    void Update()
    {
        if (_pulled)
        {
            transform.localScale -= new Vector3(_fadeOutSpeed * Time.deltaTime, _fadeOutSpeed * Time.deltaTime, _fadeOutSpeed * Time.deltaTime);
            if (transform.localScale.x <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
