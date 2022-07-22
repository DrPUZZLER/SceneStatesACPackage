using UnityEngine;
using System.Collections;

namespace AC {

	[RequireComponent(typeof(TintToggle))]
	public class RememberTintToggle : Remember {

		public override string SaveData() {
			TintToggleData tintToggleData = new TintToggleData();
			tintToggleData.negateEffect = GetComponent<TintToggle>().negateEffect;
			tintToggleData.objectID = constantID;

			return Serializer.SaveScriptData<TintToggleData>(tintToggleData);
		}


		public override void LoadData(string stringData) {
			TintToggleData data = Serializer.LoadScriptData<TintToggleData>(stringData);
			if (data == null) return;
			GetComponent<TintToggle>().negateEffect = data.negateEffect;
			GetComponent<TintToggle>().LoadSet(GetComponent<TintToggle>().negateEffect);
		}

	}

	[System.Serializable]
	public class TintToggleData : RememberData {
		public bool negateEffect;
		public TintToggleData() { }
	}

}