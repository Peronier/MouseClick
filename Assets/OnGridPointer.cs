using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class OnGridPointer : MonoBehaviour
{
    [SerializeField]
    private GameObject selectPlane;
    [SerializeField]
    private Tilemap tilemap;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            OnEnter(); // グリッド位置の計算を実行

            // グリッド位置を取得してプレイヤーを移動させる
            Vector3Int gridPos = tilemap.WorldToCell(selectPlane.transform.position);
            Vector3 complementPos = new Vector3(tilemap.cellSize.x / 2, 0.0f, tilemap.cellSize.y / 2);
            Vector3 playerWorldPos = tilemap.GetCellCenterWorld(gridPos) + complementPos;

            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.MoveToPosition(playerWorldPos);
            }

        }
    }

    private void OnEnter()
    {
        if (Camera.main == null) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3Int gridPos = tilemap.WorldToCell(hit.point);
            Vector3 complemantPos = new Vector3(tilemap.cellSize.x / 2, 0.01f, tilemap.cellSize.y / 2);
            Vector3 worldPos = tilemap.CellToWorld(gridPos) + complemantPos;
            selectPlane.transform.position = worldPos;

            PlayerController playerController = FindObjectOfType<PlayerController>();
            if(playerController != null)
            {
                playerController.MoveToGridPosition(worldPos);
            }
        }
    }

    private void OnMouseOver()
    {
        OnEnter();
    }
    private void OnMouseEnter()
    {
        selectPlane.SetActive(true);
        OnEnter();
    }

    private void OnMouseExit()
    {
        selectPlane.SetActive(false);
    }
}
