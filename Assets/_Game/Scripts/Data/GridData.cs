using System.Collections.Generic;
using BaseX;
using Google.Protobuf.Collections;
using UnityEngine;

namespace MergeAndServe.Data
{
    [CreateAssetMenu(fileName = nameof(GridData), menuName = Const.SOPath.SO_DATA_MENU_PATH + nameof(GridData))]
    public class GridData : ScriptableObject, IProtoData<ProtoGridData>
    {
        public List<CellData> Cells;
        public List<string> Collections;

        public ProtoGridData GetProtoData()
        {
            RepeatedField<ProtoCellData> cells = new RepeatedField<ProtoCellData>();
            for (int i = 0; i < Cells.Count; i++)
            {
                cells.Add(Cells[i].GetProtoData());
            }

            RepeatedField<string> collections = new RepeatedField<string>();
            for (int i = 0; i < Collections.Count; i++)
            {
                collections.Add(Collections[i]);
            }

            return new ProtoGridData()
            {
                Cells = { cells },
                Collections = { collections }
            };
        }

        public void SetProtoData(ProtoGridData data)
        {
            Collections = new List<string>();
            for (int i = 0; i < data.Collections.Count; i++)
            {
                Collections.Add(data.Collections[i]);
            }
            
            Cells = new List<CellData>();
            for (int i = 0; i < data.Cells.Count; i++)
            {
                var cell = new CellData();
                cell.SetProtoData(data.Cells[i]);
                Cells.Add(cell);
            }
        }
    }
}