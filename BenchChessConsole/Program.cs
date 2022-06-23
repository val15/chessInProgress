using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Chess.Utils;
using Chess2Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchChessConsole
{
  public class Program
  {
     static void Main(string[] args)
    {

      var summary = BenchmarkRunner.Run<Benchmarker>();
      Console.ReadLine();
    }

    #region Bench

   

    [MemoryDiagnoser]
    [LegacyJitX86Job, LegacyJitX64Job, RyuJitX64Job]

    public class Benchmarker
    {
            private string testsDirrectory = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.Combine(Environment.CurrentDirectory)).ToString()).ToString()).ToString(), "TESTS");


            [Benchmark]
      public string Livel4Bench()
      {


        //Données de best pour le bench

        var bord = new Board();
                // bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\T87BlackInChessInL2");
                //bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\T41LaReineBlancheDoitMenacerLeRoiEnH5");
                // var testName = "T35LePoinNoirNeDoitPasSeMettreEnG5";
               // var testName = "T85LaToureNoirDoitPrendreLePionEnA5";//le moin long
                var testName = "T92ALaReineNoirNeDoitPasSeMettreEnC3";//le plus long
                var testPath = Path.Combine(testsDirrectory, testName);
                bord.LoadFromDirectorie(testPath);
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
        {
          var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading("B", bord, true, null);








          Console.WriteLine("EMULATION : ");



          watch.Stop();
          Console.WriteLine($"BEST Node = {nodeResult.Weight}");
          Console.WriteLine($"DURATION => {watch.ElapsedMilliseconds} ");
          Console.WriteLine($"{nodeResult.Location} => {nodeResult.BestChildPosition}");
          //mainBord.Print();
          return $"{nodeResult.Location} => {nodeResult.BestChildPosition}";

        }
      }
    }
    #endregion
  }
}
