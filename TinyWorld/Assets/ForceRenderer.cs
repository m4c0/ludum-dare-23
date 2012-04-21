using UnityEngine;
using System.Collections;

public class ForceRenderer : MonoBehaviour {

	public Transform first;
	public Transform other;
	
	public Material material;

	public float randomness = 0.4f;
	
	private LineRenderer line;
	
	private float width = 0.2f;
	private int count = 5;
	
	public void Start() {
		line = (LineRenderer) gameObject.AddComponent(typeof(LineRenderer));
		line.material = material; //new Material(Shader.Find("Particles/Additive"));
		line.useWorldSpace = true;
		line.SetColors(Color.white, Color.white);
		line.SetWidth(width, width);
		line.SetVertexCount(count);
	}
	
	public void Update() {
		var a = first.position;
		var b = other.position;
		
		for (int i = 0; i < count; i++) {
			var pos = Vector3.Lerp(a, b, (float) i / (float) (count - 1));
			pos += Random.insideUnitSphere * randomness;
			line.SetPosition(i, pos);
		}
	}
}
