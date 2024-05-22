using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponSpirit : MonoBehaviour
{
    public float rotateSpeed;


    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime));
    }
}
