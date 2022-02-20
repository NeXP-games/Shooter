using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPL : MonoBehaviour
{
    private Transform playerTransform;
    public string playerTag;
    public float moveSpeed = 5.0f;

    public void Awake()
    {
        if (this.playerTransform == null)
        {
            if (this.playerTag == "")
            {
                this.playerTag = "Player";
            }
            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }
        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x,
            y = this.playerTransform.position.y,
            z = this.playerTransform.position.z - 10
        };
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (this.playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x,
                y = this.playerTransform.position.y,
                z = this.playerTransform.position.z - 10
            };
            Vector3 pos = Vector3.Lerp(this.transform.position, target, this.moveSpeed * Time.deltaTime);

            this.transform.position = pos;
        }
    }
}
