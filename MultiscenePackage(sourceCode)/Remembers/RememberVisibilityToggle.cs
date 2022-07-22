using UnityEngine;
using System.Collections;

namespace AC {

	[RequireComponent(typeof(VisibilityToggle))]
	public class RememberVisibilityToggle : Remember {

		public override string SaveData() {
			VisibilityToggleData visibilityToggleData = new VisibilityToggleData();
			visibilityToggleData.negateEffect = GetComponent<VisibilityToggle>().negateEffect;
			visibilityToggleData.objectID = constantID;

			return Serializer.SaveScriptData<VisibilityToggleData>(visibilityToggleData);
		}


		public override void LoadData(string stringData) {
			VisibilityToggleData data = Serializer.LoadScriptData<VisibilityToggleData>(stringData);
			if (data == null) return;
			GetComponent<VisibilityToggle>().negateEffect = data.negateEffect;
			GetComponent<VisibilityToggle>().LoadSet(GetComponent<VisibilityToggle>().negateEffect);
		}

	}

	[System.Serializable]
	public class VisibilityToggleData : RememberData {
		public bool negateEffect;
		public VisibilityToggleData() { }
	}

}