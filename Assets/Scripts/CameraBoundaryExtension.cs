using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu
public class CameraBoundaryExtension : CinemachineExtension
{
    public float minX, maxX, minY, maxY;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            // 获取当前摄像机位置
            var pos = state.RawPosition;

            // 限制摄像机位置在边界内
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            // 更新摄像机位置
            state.RawPosition = pos;
        }
    }
}
