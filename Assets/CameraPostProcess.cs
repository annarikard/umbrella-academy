using UnityEngine;

[ExecuteInEditMode]
public class CameraPostProcess : MonoBehaviour {

  public Material material;

  void OnRenderImage (RenderTexture source, RenderTexture destination) {
    Graphics.Blit(source, destination, material);
    Debug.Log("Hiya");
  }
}