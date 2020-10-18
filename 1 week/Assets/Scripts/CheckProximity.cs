using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CheckProximity : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnProxiEnter;

    [SerializeField]
    private float radius = 0;

    private Collider[] cols;

    [SerializeField]
    private LayerMask interactableLayer = 0;

    private void Update ()
    {
        int count = Physics.OverlapSphereNonAlloc (transform.position, radius, cols, interactableLayer);
        if (count > 0)
        {
            OnProxiEnter?.Invoke ();
            StartCoroutine (ReloadScene ());
            enabled = false;
            
        }
    }
   IEnumerator ReloadScene ()
    {
        yield return new WaitForSeconds (1);
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }
    private void Start ()
    {
        cols = new Collider[1];
    }
    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere (transform.position, radius);
    }
}