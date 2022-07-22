using UnityEngine;
using System.Collections;

namespace AC {

	[RequireComponent(typeof(TransformToggle))]
	public class RememberTransformToggle : Remember {

		public override string SaveData() {
			TransformToggleData transformToggleData = new TransformToggleData();
			transformToggleData.negateEffect = GetComponent<TransformToggle>().negateEffect;
			transformToggleData.objectID = constantID;

			return Serializer.SaveScriptData<TransformToggleData>(transformToggleData);
		}


		public override void LoadData(string stringData) {
			TransformToggleData data = Serializer.LoadScriptData<TransformToggleData>(stringData);
			if (data == null) return;
			GetComponent<TransformToggle>().negateEffect = data.negateEffect;
		}

	}

	[System.Serializable]
	public class TransformToggleData : RememberData {
		public bool negateEffect;
		public TransformToggleData() { }
	}

}