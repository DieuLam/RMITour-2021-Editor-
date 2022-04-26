using UnityEngine.XR.ARFoundation;
using UnityEngine;
using ZXing;
using TMPro;

public class QrCode : MonoBehaviour
{
    [SerializeField]
    private ARCameraBackground cameraBackground;

    [SerializeField]
    private RenderTexture targetRenderTexture;

    [SerializeField]
    private TextMeshProUGUI qrCodeText;

    private Texture2D cameraImageTexture;
    private IBarcodeReader reader = new BarcodeReader();

    private void Update() {

        Graphics.Blit(null, targetRenderTexture, cameraBackground.material);
        cameraImageTexture = new Texture2D(targetRenderTexture.width, targetRenderTexture.height, TextureFormat.RGBA32, false);

        // Detect and decode barcode inside the bitmap
        var result = reader.Decode(cameraImageTexture.GetPixels32(), cameraImageTexture.width, cameraImageTexture.height);

        // Do something with the result
        if (result != null) {
            qrCodeText.text = result.Text;
        }
    }
}
