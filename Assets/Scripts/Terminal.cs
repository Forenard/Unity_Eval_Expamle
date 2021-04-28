using UnityEngine;
using UnityEngine.UI;
public class Terminal : MonoBehaviour
{
    [SerializeField] Evaluator evaluator;
    [SerializeField] InputField terminal;
    [SerializeField] InputField log;
    //コード実行&ログに表示
    public void EvalCode()
    {
        string obj = evaluator.Eval(terminal.text);
        if (obj == "") return;
        log.text += obj + "\n";
    }
}