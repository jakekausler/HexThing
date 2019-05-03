using UnityEngine;

public class TextureCreator : MonoBehaviour {
	public int resolution = 255;

	private Texture2D texture;

	public float frequency = 1f;

	[Range(1, 8)]
	public int octaves = 1;

	[Range(1f, 4f)]
	public float lacunarity = 2f;

	[Range(0f, 1f)]
	public float persistance = 0.5f;

	public int seed;

	private void OnEnable () {
		texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, true);
		texture.name = "Procedural Texture";
		GetComponent<MeshRenderer>().material.mainTexture = texture;
		// FillTexture(Noise.PerlinPixels(resolution, frequency, octaves, lacunarity, persistance, Random.Range(0, 100000)));
	}

	private void FillTexture (float[,] pixels) {
		for (int y = 0; y < resolution; y++) {
			for (int x = 0; x < resolution; x++) {
				texture.SetPixel(x, y, new Color(pixels[y,x], pixels[y,x], pixels[y,x]));
			}
		}
		texture.Apply();
	}
}