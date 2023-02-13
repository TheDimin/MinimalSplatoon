
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileComponent : MonoBehaviour
{
    //ColorCell
    [SerializeField] Color defaultColor;
    private Color color;
    public PlayerComponent owner { get; private set; }
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
        Material meshMaterial = transform.GetComponentInChildren<MeshRenderer>().material;
        meshMaterial.color = color;
        meshMaterial.SetColor("_EmissiveColor", color);
    }
}
