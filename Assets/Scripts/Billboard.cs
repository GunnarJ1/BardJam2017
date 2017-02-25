using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Taken from Wizard's Guild
//Created by Gunnar Jessee
public class Billboard : MonoBehaviour
{
    
    private GameObject transformLookat;
    private Quaternion tempRotation;
    [Header("Material needs to be \"Particles /Alpha Blended\"")]
    [SerializeField]
    private string lookAtTag;


    private void Start()
    {
        transformLookat = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        //Billboard sprite always faces player
        //Needs to be implemented into another script
        tempRotation = transformLookat.transform.rotation;
        tempRotation.x = 0;
        tempRotation.z = 0;
        transform.localRotation = tempRotation;
    }

}