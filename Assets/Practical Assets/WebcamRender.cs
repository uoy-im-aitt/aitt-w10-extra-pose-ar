/*
 * Script based on code from:
 * http://answers.unity3d.com/questions/909967/getting-a-web-cam-to-play-on-ui-texture-image.html
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class WebcamRender : MonoBehaviour 
{
	private RawImage img;
	private WebCamTexture cam;

	void Start () 
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;			
		img = GetComponent<RawImage> ();
		InitWebcamTexture ();
	}

	private void InitWebcamTexture()
	{
		cam = new WebCamTexture ();
		img.texture = cam;
		img.material.mainTexture = cam;
		cam.Play();
	}
}
