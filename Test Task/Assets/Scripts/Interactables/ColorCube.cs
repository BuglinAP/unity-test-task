using UnityEngine;
using Photon.Pun;

public class ColorCube : Interactable
{
    private Renderer cubeRenderer;
    private PhotonView photonView;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        photonView = GetComponent<PhotonView>();
    }

    protected override void Interact()
    {
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        photonView.RPC("ChangeCubeColor", RpcTarget.AllBuffered, r, g, b);
    }

    [PunRPC]
    public void ChangeCubeColor(float r, float g, float b)
    {
        Color cubeColor = new Color(r, g, b);
        cubeRenderer.material.color = cubeColor;
    }
}
