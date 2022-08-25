using UnityEngine;
using System.Collections;

namespace AC {

	[RequireComponent(typeof(VisibilityToggle3D))]
	public class RememberVisibilityToggle3D : Remember {

		public override string SaveData() {
            VisibilityToggle3DData visibilityToggle3DData = new VisibilityToggle3DData();
            visibilityToggle3DData.negateEffect = GetComponent<VisibilityToggle3D>().negateEffect;
            visibilityToggle3DData.objectID = constantID;

			return Serializer.SaveScriptData<VisibilityToggle3DData>(visibilityToggle3DData);
		}


		public override void LoadData(string stringData) {
            VisibilityToggle3DData data = Serializer.LoadScriptData<VisibilityToggle3DData>(stringData);
			if (data == null) return;
			GetComponent<VisibilityToggle3D>().negateEffect = data.negateEffect;
			GetComponent<VisibilityToggle3D>().LoadSet(GetComponent<VisibilityToggle3D>().negateEffect);
		}

	}

	[System.Serializable]
	public class VisibilityToggle3DData : RememberData {
		public bool negateEffect;
		public VisibilityToggle3DData() { }
	}

}