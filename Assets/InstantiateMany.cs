using UnityEngine;

namespace DefaultNamespace {
	public class InstantiateMany : MonoBehaviour{
		public GameObject prefab;
		public int count;

		public void Awake() {
			for (int i = 0; i < count; i++) {
				Instantiate(prefab, transform);
			}
		}
	}
}