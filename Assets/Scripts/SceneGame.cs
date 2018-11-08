using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGame : MonoBehaviour {
    public GameObject target;
    public Material cameraEffectMaterial;
    public float rotateSpeed;

    private void Update() {
        Camera camera = GetComponent<Camera>();
        Vector3 offset = target.transform.position - camera.transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(offset);
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);

        // Constraints
        camera.transform.localEulerAngles = new Vector3(55, camera.transform.localEulerAngles.y, 0);
        if(camera.transform.localEulerAngles.y > 27 && camera.transform.localEulerAngles.y < 180) {
            camera.transform.localEulerAngles = new Vector3(camera.transform.localEulerAngles.x, 27, 0);
        } else if(camera.transform.localEulerAngles.y < 333 && camera.transform.localEulerAngles.y > 180) {
            camera.transform.localEulerAngles = new Vector3(camera.transform.localEulerAngles.x, 333, 0);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        Graphics.Blit(source, destination, cameraEffectMaterial);
    }
}
