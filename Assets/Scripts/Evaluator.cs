using UnityEngine;
public class Evaluator : MonoBehaviour
{
    public Mono.CSharp.Evaluator evaluator;

    void Start()
    {
        //Mono.CSharp.Evaluatorの設定
        var settings = new Mono.CSharp.CompilerSettings();
        foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies())
        {
            if (assembly == null) continue;
            settings.AssemblyReferences.Add(assembly.FullName);
        }
        var printer = new Mono.CSharp.ConsoleReportPrinter();
        var ctx = new Mono.CSharp.CompilerContext(settings, printer);
        evaluator = new Mono.CSharp.Evaluator(ctx);
        //名前空間の指定
        evaluator.Run("using UnityEngine;");
    }

    //後々呼び出せるようにEval関数を作っておく
    public string Eval(string cmd)
    {
        object obj;
        bool hasobj;
        evaluator.Evaluate(cmd, out obj, out hasobj);
        string result = hasobj ? obj.ToString() : "";
        return result;
    }
}