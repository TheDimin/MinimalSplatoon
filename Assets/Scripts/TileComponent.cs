using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileComponent : MonoBehaviour
{
    //ColorCell
    [SerializeField] Color defaultColor;
    private Color color;
    private PlayerComponent owner;

    public void ClaimLand(PlayerComponent player)
    {
        owner = player;
        color = owner.GetTeamColor();
    }
}
