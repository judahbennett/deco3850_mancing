using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class BodyIndexView : MonoBehaviour {

	public bool BodyIndexActive { get; private set; }
	
	public int BodyIndexWidth { get; private set; }
	public int BodyIndexHeight { get; private set; }

	private KinectSensor sensor;
	private BodyIndexFrameReader reader;
	private Texture2D texture;
	private byte[] data;
	private byte[] rawData;

	public GameObject bodyIndexPlane;

	// Use this for initialization
	void Start () {
		BodyIndexActive = true;
        ShowAndStart();
    }
	
	// Update is called once per frame
	void Update () {
		if (BodyIndexActive == true && reader != null) {
			var frame = reader.AcquireLatestFrame();

			if (frame != null) {
				frame.CopyFrameDataToArray(rawData);

				frame.Dispose();
				frame = null;

				int index = 0;
				foreach (byte bi in rawData) {
					if (bi < 6) {

						switch (bi) {
							case 0:
								data[index++] = 255; data[index++] = 0; data[index++] = 0; data[index++] = 255;
								break;
							case 1:
								data[index++] = 0; data[index++] = 255; data[index++] = 0; data[index++] = 255;
								break;
							case 2:
								data[index++] = 0; data[index++] = 0; data[index++] = 255; data[index++] = 255;
								break;
							case 3:
								data[index++] = 255; data[index++] = 255; data[index++] = 0; data[index++] = 255;
								break;
							case 4:
								data[index++] = 255; data[index++] = 0; data[index++] = 255; data[index++] = 255;
								break;
							case 5:
								data[index++] = 0; data[index++] = 255; data[index++] = 255; data[index++] = 255;
								break;
							default: 
								break;
						}

					} else {
						data[index++] = 0; data[index++] = 0; data[index++] = 0; data[index++] = 0; 
					}
				}

				texture.LoadRawTextureData(data);
				texture.Apply();

				bodyIndexPlane.GetComponent<MeshRenderer>().material.mainTexture = texture;
                //flips the view
                bodyIndexPlane.GetComponent<MeshRenderer>().material.SetTextureScale("_MainTex", new Vector2(-1, 1));
            }
		}
	}

	public void ShowAndStart() {
		sensor = KinectSensor.GetDefault();

		if (sensor != null) {
			reader = sensor.BodyIndexFrameSource.OpenReader();
			
			var frameDesc = sensor.BodyIndexFrameSource.FrameDescription;
			BodyIndexWidth = frameDesc.Width;
			BodyIndexHeight = frameDesc.Height;

			texture = new Texture2D(BodyIndexWidth, BodyIndexHeight, TextureFormat.BGRA32, false);
			data = new byte[frameDesc.LengthInPixels * 4];
			rawData = new byte[frameDesc.LengthInPixels];

			if (sensor.IsOpen == false) {
				sensor.Open();

				bodyIndexPlane.GetComponent<MeshRenderer>().enabled = true;
				BodyIndexActive = true;
			}
		}
	}

	public void HideAndStop() {
		bodyIndexPlane.GetComponent<MeshRenderer>().enabled = false;
		CloseKinect();
		BodyIndexActive = false;
	}

	private void CloseKinect() {
		if (reader != null) {
			reader.Dispose();
			reader = null;
		}
		if (sensor != null) {
			if (sensor.IsOpen) {
				sensor.Close();
			}
			sensor = null;
		}
	}

	void OnApplicationQuit() {
		CloseKinect();
	}

	public void ToggleSensor() {
		if (BodyIndexActive == false) {
			ShowAndStart();
		} else {
			HideAndStop();
		}
	}
}
