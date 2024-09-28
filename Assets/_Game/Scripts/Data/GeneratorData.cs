using System;
using System.Collections.Generic;
using UnityEngine;

namespace MergeAndServe.Data
{
    [CreateAssetMenu(fileName = nameof(GeneratorData), menuName = Const.SOPath.SO_DATA_MENU_PATH + nameof(GeneratorData))]
    public class GeneratorData : ItemData
    {
        public List<ProduceProbabilityData> ProduceProbabilities;

        [Serializable]
        public struct ProduceProbabilityData
        {
            public string ShortCode;
            public float Ratio;
        }
    }
}