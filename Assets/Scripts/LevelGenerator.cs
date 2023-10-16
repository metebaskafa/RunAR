using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] selection;
    public int zpos = 500;
    public bool creatingSelection;
    public int secNum;

    private void Update()
    {
        if (creatingSelection == false)
        {
            creatingSelection = true;
            StartCoroutine(GenerateSection());
        }
    }
    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 4);
        Instantiate(selection[secNum], new Vector3(0, 0, zpos), Quaternion.identity);
        zpos += 1000;
        yield return new WaitForSeconds(5);
        creatingSelection = false;
    }
}
