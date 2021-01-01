using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject thePlayer;
    private Vector3 offSet = new Vector3(0, 1, -15f);
    private void Awake()
    {
    }
    void Start()
    {
    }
    private void Update()
    {
        this.transform.position = thePlayer.transform.position + offSet;
    }
}
