using UnityEngine;

public static class Noise
{
	public static Texture2D PerlinTexture(int resolution, float frequency, int octaves, float lacunarity, float persistance, int rseed, int bseed, int gseed) {
		Texture2D retVal = new Texture2D(resolution, resolution, TextureFormat.RGB24, true);

		for (int y = 0; y < resolution; y++) {
			for (int x = 0; x < resolution; x++) {
				float freq = frequency;
				float r = Mathf.PerlinNoise(x+rseed/freq, y+rseed/freq);
				float g = Mathf.PerlinNoise(x+gseed/freq, y+gseed/freq);
				float b = Mathf.PerlinNoise(x+bseed/freq, y+bseed/freq);
				float amplitude = 1f;
				float range = 1f;
				for (int o=1; o < octaves; o++) {
					freq *= lacunarity;
					amplitude *= persistance;
					range += amplitude;
					r += Mathf.PerlinNoise(x+rseed/freq, y+rseed/freq) * amplitude;
					g += Mathf.PerlinNoise(x+gseed/freq, y+gseed/freq) * amplitude;
					b += Mathf.PerlinNoise(x+bseed/freq, y+bseed/freq) * amplitude;
				}
				r = r / range;
				g = g / range;
				b = b / range;
				retVal.SetPixel(y,x, new Color(r,g,b));
			}
		}

		return retVal;
	}
}