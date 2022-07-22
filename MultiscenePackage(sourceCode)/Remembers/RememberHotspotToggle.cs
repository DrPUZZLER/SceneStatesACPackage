using UnityEngine;
using System.Collections;

namespace AC {

	[RequireComponent(typeof(HotspotToggle))]
	public class RememberHotspotToggle : Remember {

		public override string SaveData() {
			HotspotToggleData hotspotToggleData = new HotspotToggleData();
			hotspotToggleData.negateEffect = GetComponent<HotspotToggle>().negateEffect;
			hotspotToggleData.objectID = constantID;

			return Serializer.SaveScriptData<HotspotToggleData>(hotspotToggleData);
		}


		public override void LoadData(string stringData) {
			HotspotToggleData data = Serializer.LoadScriptData<HotspotToggleData>(stringData);
			if (data == null) return;
			GetComponent<HotspotToggle>().negateEffect = data.negateEffect;
			GetComponent<HotspotToggle>().LoadSet(GetComponent<HotspotToggle>().negateEffect);
		}

	}

	[System.Serializable]
	public class HotspotToggleData : RememberData {
		public bool negateEffect;
		public HotspotToggleData() { }
	}

}