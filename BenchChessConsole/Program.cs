using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Chess.Utils;
using Chess2Console;
using System;
using System.Collections.Generic;
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


      [Benchmark]
      public string Livel4Bech()
      {


        //Données de best pour le bench

        var bord = new Board();
        // bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\T87BlackInChessInL2");
        //bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\T41LaReineBlancheDoitMenacerLeRoiEnH5");
        bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\T35LePoinNoirNeDoitPasSeMettreEnG5");
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
