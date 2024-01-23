using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest : MonoBehaviour
{
    public Material[] materials;
    private FileReader fl;
    public int x;
    public int y;
    [SerializeField]
    private int a;

    void Start()
    {
        fl = FindObjectOfType<FileReader>();
        Renderer rend = GetComponent<Renderer>();
        rend.material = materials[0];
        
    }

    private void Update()
    {
        a = int.Parse(fl._data[x, y].ToString())-1;
        gameObject.GetComponent<MeshRenderer>().material = materials[a];
        
    }


}
