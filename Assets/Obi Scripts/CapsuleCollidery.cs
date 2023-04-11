using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class CapsuleCollidery : MonoBehaviour
{
    //stole code from XR Orgin, gathers players head height, hacked it to track my head pos and make the capsule collider taller or shorter depending on my pos
    public XROrigin m_XROrigin;
    public float m_MinHeight;
    public float m_MaxHeight;
    public CapsuleCollider m_Collider;
    void Update()
    {
        //this is like basically literally ripped from XR
        var height = Mathf.Clamp(m_XROrigin.CameraInOriginSpaceHeight, m_MinHeight, m_MaxHeight);

        Vector3 center = m_XROrigin.CameraInOriginSpacePos;
        center.y = height / 2f + m_Collider.radius;

        m_Collider.height = height;
        m_Collider.center = center;
    }
}
