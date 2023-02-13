
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileComponent : MonoBehaviour
{
    //ColorCell
    [SerializeField] Color defaultColor;
    private Color color;
    private PlayerComponent owner;
    public BoxCollider2D Collider2D;

    private void Awake()
    {
        Collider2D = GetComponent<BoxCollider2D>();
        transform.GetComponentInChildren<MeshRenderer>().material.color = defaultColor;
    }

    public void ClaimLand(PlayerComponent player)
    {
        owner = player;
        color = owner.GetTeamColor();

        transform.GetComponentInChildren<MeshRenderer>().material.color = color;
    }
}
