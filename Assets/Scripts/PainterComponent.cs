using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Collision detection who needs that ?
public class PainterComponent : MonoBehaviour
{
    TileComponent lastTile = null;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameState != state.Play) return;

        TileComponent newTile = TileLevelGenerator.instance.FindTile(transform.position);

        if (!newTile) return;

        //Check if we were on this tile last frame aswell
        if (lastTile == newTile) return;

        lastTile = newTile;
        newTile.ClaimLand(GetComponent<PlayerComponent>());


    }
}
