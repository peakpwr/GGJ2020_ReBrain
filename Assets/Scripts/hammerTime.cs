﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Photon.Pun.Demo.PunBasics
{
    public class hammerTime : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private GameObject myDemolitionPreFab;       

        // Start is called before the first frame update
        void Start()
        {
                   
                  
                
            
        }

        // Update is called once per frame
        void Update()
        {
            Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position,new Vector2(2,2), 1 << LayerMask.NameToLayer("GroundLayer"));
            
            foreach (var hit in hits)
            {
                var tilemap = hit.GetComponent<Tilemap>();

                if(tilemap != null)
                {                    
                    tilemap.SetTile(tilemap.WorldToCell(tilemap.transform.position), null);
                    Vector3Int v3 = tilemap.WorldToCell(tilemap.transform.position);
                    Instantiate(myDemolitionPreFab, new Vector3(v3.x+0.5f,v3.y+0.5f), myDemolitionPreFab.transform.rotation);
                }

                //Destroy(hits[i].gameObject);
                //Debug.Log(hits[i]);
            }
        }

     
    }
}