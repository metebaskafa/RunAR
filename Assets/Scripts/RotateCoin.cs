using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    [SerializeField]
    private float rotatecoinSpeed = 1000f;

    // Start is called before the first frame update
    private void Update()
    {
        transform.Rotate(0, 0, rotatecoinSpeed * Time.deltaTime);

    }

}
