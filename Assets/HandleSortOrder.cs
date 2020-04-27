using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSortOrder : MonoBehaviour
{
    public int sortOrder = 3;
    void Start ()
    {
        GetComponent<Renderer>().sortingOrder = sortOrder;
	}
}
