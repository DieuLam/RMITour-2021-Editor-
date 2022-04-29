using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
// using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine.UI;
using UnityEngine;
using ZXing;

public class ScanRoom : MonoBehaviour
{
    [SerializeField]
    private ARCameraManager cameraManager;

    [SerializeField]
    private List<Target> target = new List<Target>();

    private Texture2D texture;

    private IBarcodeReader reader = new BarcodeReader();
    
    [SerializeField]
    private Image roomInfo;

    private void OnEnable() {
        cameraManager.frameReceived += OnCameraFrameReceived;
    }

    private void OnDisable() {
        cameraManager.frameReceived -= OnCameraFrameReceived;
    }

    // ------------------------ Scan and get QR Code data -----------------------------

    private void OnCameraFrameReceived(ARCameraFrameEventArgs args) {

        if (!cameraManager.TryAcquireLatestCpuImage(out XRCpuImage image)) {
            return;
        }

        var conversionParams = new XRCpuImage.ConversionParams {

            // Get the entire image
            inputRect = new RectInt(0, 0, image.width, image.height),

            // Down scale by 2
            outputDimensions = new Vector2Int(image.width / 2, image.height / 2),

            // RGBA format
            outputFormat = TextureFormat.RGBA32,

            // Flip image vertical axis
            transformation = XRCpuImage.Transformation.MirrorY
        };

        // Check how many bytes to store image
        int size = image.GetConvertedDataSize(conversionParams);

        // Allocate a buffer to store image
        var buffer = new NativeArray<byte>(size, Allocator.Temp);

        // Extract image data
        image.Convert(conversionParams, buffer);

        // Since image is already store -> delete XR CPU image
        image.Dispose();

        // ------------------------ Put the image to a texture --------------------------

        texture = new Texture2D(
            conversionParams.outputDimensions.x,
            conversionParams.outputDimensions.y,
            conversionParams.outputFormat,
            false
        );

        texture.LoadRawTextureData(buffer);
        texture.Apply();

        // Dispose temporary data
        buffer.Dispose();

        // Detect and decode the barcode inside the bitmap
        var result = reader.Decode(texture.GetPixels32(), texture.width, texture.height);

        // Do something with result
        if (result != null) {
            covertRoomNumber(result.Text);
        }
    }

    // ------------------------ Convert QR code link to room number ------------------

    private void covertRoomNumber(string targetText) {

        var result = targetText.Split("0");  // split the link
        var room = result[1] + "." + result[2] + ".0" + result[4]; // -> 2.4.01
        doSomething(room);
    }

    // ------------------------ Do Something --------------------------

    private void doSomething(string targetText) {

        // compare QrCode name with object name
        Target currentTarget = target.Find(x => x.Name.ToLower().Equals(targetText.ToLower()));
 
        if (currentTarget != null) {  // valid result

           // Change scene
           // SceneManager.LoadScene(targetText);

        }
    }
}