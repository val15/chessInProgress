using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2Console
{
  class Program
  {
    static void Main(string[] args)
    {

      /* Console.WriteLine("Main");

       Board mainBord = new Board();
       mainBord.Init();
       mainBord.Move(1, 42,1);
       mainBord.Move(6, 45,1);
       mainBord.CalculeScores();
       //mainBord.Move(8, 16);
       Console.WriteLine($"MainBord=> White Score:{mainBord.WhiteScore};\tBlack Score:{mainBord.BlackScore}");
       mainBord.Print();
       var engine = new Engine(3,"W",false);
       var watch = new System.Diagnostics.Stopwatch();
       watch.Start();




       Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
       Console.WriteLine("EMULATION : ");
       //Console.WriteLine("===============");
       //engine.EmulAllPossibleMovesFor(null,mainBord,"B",0,false);
       ////Console.Clear();
       //Console.WriteLine("EMULATION DONE");
       //Console.WriteLine("===============");
       //Console.WriteLine("NODES LIST : ");
       //engine.PrintAllNode();
       //engine.MinMax();
       //Console.WriteLine("AFTER MINMAX :");
       //engine.PrintAllNode();
       //Console.WriteLine($"L ZEZO : {engine.Nodes[0].Level};{engine.Nodes[0].Weight};{engine.Nodes[0].Color}\t\t{engine.Nodes[0].FromIndex}=>{engine.Nodes[0].ToIndex}");
       var bestNode = engine.Search(mainBord,"5");


       //var levelTBoard  = Utils.CloneAndMove(bestNode.Board, bestNode.FromIndex, bestNode.ToIndex);

       //var engine2 = new Engine(2);
       //engine2.ComputerColore = "B";
       //var bestNode2= engine2.Search(levelTBoard);


       watch.Stop();
       Console.WriteLine($"BEST Node = {bestNode.Weight}");
       //Console.WriteLine($"BEST Node = {bestNode2.Weight}");
       Console.WriteLine($"DURATION => {watch.ElapsedMilliseconds} ");
       //Console.WriteLine("MainBord:");
       //mainBord.Print();
       Console.ReadLine();*/

      var summary = BenchmarkRunner.Run<BenchmarkerChess>();
      Console.ReadLine();

    }
  }


  #region Bench


  
  [MemoryDiagnoser]
  [LegacyJitX86Job, LegacyJitX64Job, RyuJitX64Job]

  public class BenchmarkerChess
  {

  /*  [Benchmark]
    public string Livel1Bech()
    {
      Board mainBord = new Board();
      mainBord.Init();
      mainBord.Move(1, 42, 1);
      mainBord.Move(6, 45, 1);
      mainBord.CalculeScores();
      //mainBord.Move(8, 16);
      Console.WriteLine($"MainBord=> White Score:{mainBord.WhiteScore};\tBlack Score:{mainBord.BlackScore}");
      mainBord.Print();
      var engine = new Engine(1, "W", false);
      var watch = new System.Diagnostics.Stopwatch();
      watch.Start();




      Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
      Console.WriteLine("EMULATION : ");
      //Console.WriteLine("===============");
      //engine.EmulAllPossibleMovesFor(null,mainBord,"B",0,false);
      ////Console.Clear();
      //Console.WriteLine("EMULATION DONE");
      //Console.WriteLine("===============");
      //Console.WriteLine("NODES LIST : ");
      //engine.PrintAllNode();
      //engine.MinMax();
      //Console.WriteLine("AFTER MINMAX :");
      //engine.PrintAllNode();
      //Console.WriteLine($"L ZEZO : {engine.Nodes[0].Level};{engine.Nodes[0].Weight};{engine.Nodes[0].Color}\t\t{engine.Nodes[0].FromIndex}=>{engine.Nodes[0].ToIndex}");
      var bestNode = engine.Search(mainBord, "5");



      watch.Stop();
      Console.WriteLine($"BEST Node = {bestNode.Weight}");
      //Console.WriteLine($"BEST Node = {bestNode2.Weight}");
      Console.WriteLine($"DURATION => {watch.ElapsedMilliseconds} ");
      //Console.WriteLine("MainBord:");
      //mainBord.Print();
      return $"{bestNode.FromIndex} => {bestNode.ToIndex}";  


    }
   */

    [Benchmark]
    public string Livel4Bech()
    {


      //Données de best pour le bench
      //WHITEList
      var whiteListString = "" +
"King;f1;White;False;True;True;True" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;e2;White;False;False;False;False" +
"\nKnight;g6;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var pawnListString = whiteListString.Split('\n').ToList();


      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;False;False;True" +
"\nQueen;b5;Black;False;False;False;False" +
"\nRook;a3;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;f4;Black;False;False;False;False" +
"\nKnight;f8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      pawnListString.AddRange(blackListString.Split('\n').ToList());

      var mainBord = Utils.GenerateBoardFormPawnListString(pawnListString);


      mainBord.CalculeScores();
      //mainBord.Move(8, 16);
      Console.WriteLine($"MainBord=> White Score:{mainBord.WhiteScore};\tBlack Score:{mainBord.BlackScore}");
      mainBord.Print();
      var engine = new Engine(4, "B", false);
      var watch = new System.Diagnostics.Stopwatch();
      watch.Start();




      Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
      Console.WriteLine("EMULATION : ");
     var bestNode = engine.Search(mainBord, "5");



      watch.Stop();
      Console.WriteLine($"BEST Node = {bestNode.Weight}");
      //Console.WriteLine($"BEST Node = {bestNode2.Weight}");
      Console.WriteLine($"DURATION => {watch.ElapsedMilliseconds} ");
      //Console.WriteLine("MainBord:");
      //mainBord.Print();
      return $"{bestNode.FromIndex} => {bestNode.ToIndex}";


    }
   
    /*
    [Benchmark]
    public string Livel4Bech()
    {
      Board mainBord = new Board();
      mainBord.Init();
      mainBord.Move(1, 42, 1);
      mainBord.Move(6, 45, 1);
      mainBord.CalculeScores();
      //mainBord.Move(8, 16);
      Console.WriteLine($"MainBord=> White Score:{mainBord.WhiteScore};\tBlack Score:{mainBord.BlackScore}");
      mainBord.Print();
      var engine = new Engine(4, "W", false);
      var watch = new System.Diagnostics.Stopwatch();
      watch.Start();




      Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
      Console.WriteLine("EMULATION : ");
      var bestNode = engine.Search(mainBord, "5");



      watch.Stop();
      Console.WriteLine($"BEST Node = {bestNode.Weight}");
      //Console.WriteLine($"BEST Node = {bestNode2.Weight}");
      Console.WriteLine($"DURATION => {watch.ElapsedMilliseconds} ");
      //Console.WriteLine("MainBord:");
      //mainBord.Print();
      return $"{bestNode.FromIndex} => {bestNode.ToIndex}";


    }
    */
    /*  [Benchmark]
      public string Livel5Bech()
      {
        Board mainBord = new Board();
        mainBord.Init();
        mainBord.Move(1, 42, 1);
        mainBord.Move(6, 45, 1);
        mainBord.CalculeScores();
        //mainBord.Move(8, 16);
        Console.WriteLine($"MainBord=> White Score:{mainBord.WhiteScore};\tBlack Score:{mainBord.BlackScore}");
        mainBord.Print();
        var engine = new Engine(5, "W", false);
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();




        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        Console.WriteLine("EMULATION : ");
        var bestNode = engine.Search(mainBord, "5");



        watch.Stop();
        Console.WriteLine($"BEST Node = {bestNode.Weight}");
        //Console.WriteLine($"BEST Node = {bestNode2.Weight}");
        Console.WriteLine($"DURATION => {watch.ElapsedMilliseconds} ");
        //Console.WriteLine("MainBord:");
        //mainBord.Print();
        return $"{bestNode.FromIndex} => {bestNode.ToIndex}";


      }
      */


  }
  #endregion
}
