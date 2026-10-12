using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    public void EndGame()
    {
        ScoreManager.Instance.EvaluateScores();
        // 进行其他游戏结束处理，例如显示总成绩或返回主菜单
    }
}