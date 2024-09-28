using System.Collections.Generic;
using MergeAndServe.Data;
using Zenject;
using Random = UnityEngine.Random;

namespace MergeAndServe.Game
{
    public class Generator : BaseItem
    {
        #region Fields

        [Inject] private BoardController _boardController;
        public GeneratorData Data { get; private set; }

        #endregion

        #region Public Methods

        public override void Initialize(ItemData itemData)
        {
            base.Initialize(itemData);
            Data = (GeneratorData) itemData;
        }

        public override void Tap()
        {
            Generate();
        }
        
        #endregion

        #region Private Methods

        private void Generate()
        {
            if (Data.ProduceProbabilities is null || Data.ProduceProbabilities.Count == 0)
            {
                return;
            }

            var result = GetRandomItem(Data.ProduceProbabilities);
            _boardController.CreateItemToClosetPoint(CurrentCell, result);
        }

        private string GetRandomItem(List<GeneratorData.ProduceProbabilityData> data)
        {
            float totalRatio = 0f;

            for (int i = 0; i < data.Count; i++)
            {
                totalRatio += data[i].Ratio;
            }

            float randomValue = Random.Range(0, totalRatio);

            float cumulativeRatio = 0f;
            for (int i = 0; i < data.Count; i++)
            {
                cumulativeRatio += data[i].Ratio;

                if (randomValue <= cumulativeRatio)
                {
                    return data[i].ShortCode;
                }
            }

            return string.Empty;
        }

        #endregion

        public class Pool : MonoMemoryPool<Generator>
        {
            protected override void OnCreated(Generator item)
            {
                item.gameObject.name += $"_{NumTotal}";
                base.OnCreated(item);
            }
        }
    }
}