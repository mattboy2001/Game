﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (BoxCollider2D))]
public class RaycastController : MonoBehaviour
{
    [HideInInspector]
     public BoxCollider2D collider2D;
     [HideInInspector]

    public RaycastOrigins raycastOrigins;


     public LayerMask collisionMask;

    public const float skinWidth = 0.15f;


    
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;
    [HideInInspector]
   public  float horizontalRaySpacing;
   [HideInInspector]
    public float verticalRaySpacing;
 public struct RaycastOrigins {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }




    public void setLayerMask(LayerMask collisionLayer)
    {
        collisionMask = collisionLayer;
    }




       public virtual void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
        
    }

    public void UpdateRaycastOrigins() {
        Bounds bounds = collider2D.bounds;
        bounds.Expand (skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    public void CalculateRaySpacing() {
        Bounds bounds = collider2D.bounds;
        bounds.Expand (skinWidth * -2);
        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);
        horizontalRaySpacing = bounds.size.y / (horizontalRayCount -1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);

    }

}
