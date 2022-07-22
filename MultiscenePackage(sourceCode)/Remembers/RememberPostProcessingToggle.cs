using UnityEngine;
using System.Collections;

namespace AC {

	[RequireComponent(typeof(PostProcessingToggle))]
	public class RememberPostProcessingToggle : Remember {

		public override string SaveData() {
			PostProcessingToggleData postProcessingToggleData = new PostProcessingToggleData();
			postProcessingToggleData.negateEffect = GetComponent<PostProcessingToggle>().negateEffect;
			postProcessingToggleData.objectID = constantID;

			return Serializer.SaveScriptData<PostProcessingToggleData>(postProcessingToggleData);
		}


		public override void LoadData(string stringData) {
			PostProcessingToggleData data = Serializer.LoadScriptData<PostProcessingToggleData>(stringData);
			if (data == null) return;
			GetComponent<PostProcessingToggle>().negateEffect = data.negateEffect;
			GetComponent<PostProcessingToggle>().LoadSet(GetComponent<PostProcessingToggle>().negateEffect);
		}

	}

	[System.Serializable]
	public class PostProcessingToggleData : RememberData {
		public bool negateEffect;
		public PostProcessingToggleData() { }
	}

}