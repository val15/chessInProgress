using Chess;
using Chess2Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Chess2ConsoleTest
{
  [TestClass]
  public class MovingRookTests
  {
    [TestMethod]
    public void MRT01RookHorizontalGetPossiblesMovesIn32_a4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(32, "T", "W");
      var possiblesIndex = bord.GetPossibleMoves(32,0).Select(x => x.Index);
      var iscontent35 = possiblesIndex.Contains(35);
      Assert.IsTrue(iscontent35);
    }

    [TestMethod]
    public void MRT02RookHorizontalGetPossiblesMovesIn33_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(33, "T", "W");
      var possiblesIndex = bord.GetPossibleMoves(33,0).Select(x => x.Index);
      var iscontent35 = possiblesIndex.Contains(35);
      Assert.IsTrue(iscontent35);
      var iscontent32 = possiblesIndex.Contains(32);
      Assert.IsTrue(iscontent32);
      var iscontent31 = possiblesIndex.Contains(31);
      Assert.IsFalse(iscontent31);
    }

    [TestMethod]
    public void MRT03RookVerticalGetPossiblesMovesIn33_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(33, "T", "W");
      var possiblesIndex = bord.GetPossibleMoves(33,0).Select(x => x.Index);
      var iscontent9 = possiblesIndex.Contains(9);
      Assert.IsTrue(iscontent9);
    }
    [TestMethod]
    public void MRT04RookVerticalGetPossiblesMovesIn33_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(33, "T", "W");
      var possiblesIndex = bord.GetPossibleMoves(33,0).Select(x => x.Index);
      var iscontent57 = possiblesIndex.Contains(57);
      Assert.IsTrue(iscontent57);
    }


    [TestMethod]
    public void MRT05RookHorizontalWhitheOpinionGetPossiblesMovesIn36_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(36, "T", "W");
      bord.InsertPawn(38, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(36,0).Select(x => x.Index);
      var iscontent38 = possiblesIndex.Contains(38);
      Assert.IsTrue(iscontent38);
      var iscontent39 = possiblesIndex.Contains(39);
      Assert.IsFalse (iscontent39);
    }

    [TestMethod]
    public void MRT06RookHorizontalWhitheAlierGetPossiblesMovesIn36_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(36, "T", "W");
      bord.InsertPawn(38, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(36,0).Select(x => x.Index);
      var iscontent38 = possiblesIndex.Contains(38);
      Assert.IsFalse(iscontent38);
      var iscontent39 = possiblesIndex.Contains(39);
      Assert.IsFalse(iscontent39);
    }

    [TestMethod]
    public void MRT07RookHorizontalWhitheAlierGetPossiblesMovesIn36_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(36, "T", "W");
      bord.InsertPawn(35, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(36,0).Select(x => x.Index);
      var iscontent35 = possiblesIndex.Contains(35);
      Assert.IsFalse(iscontent35);
      var iscontent33 = possiblesIndex.Contains(33);
      Assert.IsFalse(iscontent33);
    }

   

    [TestMethod]
    public void MRT07RookVerticalGetPossiblesMovesIn62_g1_Test()
    {
      var bord = new Board();
      bord.InsertPawn(62, "T", "W");
      var possiblesIndex = bord.GetPossibleMoves(62,0).Select(x => x.Index);
      var iscontent6 = possiblesIndex.Contains(6);
      Assert.IsTrue(iscontent6);
    }

    [TestMethod]
    public void MRT08RookVerticalWhitheAlierGetPossiblesMovesIn51_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(51, "T", "W");
      bord.InsertPawn(59, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(51,0).Select(x => x.Index);
      var iscontent59 = possiblesIndex.Contains(59);
      Assert.IsFalse(iscontent59);
      var iscontent3 = possiblesIndex.Contains(3);
      Assert.IsTrue(iscontent3);
    }


    [TestMethod]
    public void MRT09RookExtreGetPossiblesMovesIn0_a8_Test()
    {
      var bord = new Board();
      bord.InsertPawn(0, "T", "W");
      var possiblesIndex = bord.GetPossibleMoves(0,0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(56);
      Assert.IsTrue(iscontent);
      var iscontent1 = possiblesIndex.Contains(7);
      Assert.IsTrue(iscontent1);
    }

    [TestMethod]
    public void MRT10RookExtreGetPossiblesMovesIn0_h1_Test()
    {
      var bord = new Board();
      bord.InsertPawn(63, "T", "W");
      var possiblesIndex = bord.GetPossibleMoves(63,0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(56);
      Assert.IsTrue(iscontent);
      var iscontent1 = possiblesIndex.Contains(7);
      Assert.IsTrue(iscontent1);
    }

    [TestMethod]
    public void MRT11G8NeDoitPasEstreInPossibleMoveDuRoiEnE7()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var bord = new Board();

      bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\T60leRoisNoirDoitEvierDeMourirDoitSeDeplacerEnF8");

      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition
      var possiblesIndex = bord.GetPossibleMoves(12, 0).Select(x => x.Index);
      var iscontent1 = possiblesIndex.Contains(6);
      Assert.IsFalse(iscontent1);




    }
  }

  [TestClass]
  public class MovingBishopTests
  {
    [TestMethod]
    public void MRT00BishopDiagonalPlusPlusGetPossiblesMovesIn_a8_Test()
    {
      var bord = new Board();
      bord.InsertPawn(0, "B", "B");
      var possiblesIndex = bord.GetPossibleMoves(0,0).Select(x => x.Index);
      var iscontent36 = possiblesIndex.Contains(36);
      Assert.IsTrue(iscontent36);
    }

    [TestMethod]
    public void MRT01BishopDiagonalPlusPlusGetPossiblesMovesIn_a8_Test()
    {
      var bord = new Board();
      bord.InsertPawn(18, "B", "B");
      var possiblesIndex = bord.GetPossibleMoves(18,0).Select(x => x.Index);
      var iscontent36 = possiblesIndex.Contains(36);
      Assert.IsTrue(iscontent36);
    }

    [TestMethod]
    public void MRT02BishopDiagonalPlusMoinsGetPossiblesMovesIn_e1_Test()
    {
      var bord = new Board();
      bord.InsertPawn(60, "B", "B");
      var possiblesIndex = bord.GetPossibleMoves(60,0).Select(x => x.Index);
      var iscontent51 = possiblesIndex.Contains(51);
      Assert.IsTrue(iscontent51);
    }

    [TestMethod]
    public void MRT03BishopDiagonalMoinsPlusGetPossiblesMovesIn_d5_Test()
    {
      var bord = new Board();
      bord.InsertPawn(27, "B", "B");
      var possiblesIndex = bord.GetPossibleMoves(27,0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(41);
      Assert.IsTrue(iscontent);
    }


    [TestMethod]
    public void MRT04BishopDiagonalMoinsMoinsGetPossiblesMovesIn_g5_Test()
    {
      var bord = new Board();
      bord.InsertPawn(30, "B", "B");
      var possiblesIndex = bord.GetPossibleMoves(30,0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(3);
      Assert.IsTrue(iscontent);
    }


    [TestMethod]
    public void MRT05BishopDiagonalMoinsMoinsGetPossiblesMovesIn_h8_Test()
    {
      var bord = new Board();
      bord.InsertPawn(63, "B", "B");
      var possiblesIndex = bord.GetPossibleMoves(63,0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(0);
      Assert.IsTrue(iscontent);
    }

    [TestMethod]
    public void MRT06BishopDiagonalWhithAlierGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(50, "B", "B");
      bord.InsertPawn(36, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(50,0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(36);
      Assert.IsFalse(iscontent);
    }

    [TestMethod]
    public void MRT07BishopDiagonalWhithAlierGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(50, "B", "B");
      bord.InsertPawn(36, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(50,0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(36);
      Assert.IsFalse(iscontent);
    }

    [TestMethod]
    public void MRT08BishopDiagonalWhithOpinionGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(50, "B", "B");
      bord.InsertPawn(36, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(50,0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(36);
      Assert.IsTrue(iscontent);
    }

    [TestMethod]
    public void MRT09BishopDiagonalOtherPawnGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(29, "B", "W");
      bord.InsertPawn(38, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(29, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(47);
      Assert.IsFalse(iscontent);
    }

  }


  [TestClass]
  public class MovingQueenTests
  {



    [TestMethod]
    public void MRT00QueenDiagonalPlusPlusGetPossiblesMovesIn_a8_Test()
    {
      var bord = new Board();
      bord.InsertPawn(0, "Q","B");
      var possiblesIndex = bord.GetPossibleMoves(0, 0).Select(x => x.Index);
      var iscontent36 = possiblesIndex.Contains(36);
      Assert.IsTrue(iscontent36);
    }

    [TestMethod]
    public void MRT01QueenDiagonalPlusPlusGetPossiblesMovesIn_a8_Test()
    {
      var bord = new Board();
      bord.InsertPawn(18, "Q","B");
      var possiblesIndex = bord.GetPossibleMoves(18, 0).Select(x => x.Index);
      var iscontent36 = possiblesIndex.Contains(36);
      Assert.IsTrue(iscontent36);
    }

    [TestMethod]
    public void MRT02QueenDiagonalPlusMoinsGetPossiblesMovesIn_e1_Test()
    {
      var bord = new Board();
      bord.InsertPawn(60, "Q","B");
      var possiblesIndex = bord.GetPossibleMoves(60, 0).Select(x => x.Index);
      var iscontent51 = possiblesIndex.Contains(51);
      Assert.IsTrue(iscontent51);
    }

    [TestMethod]
    public void MRT03QueenDiagonalMoinsPlusGetPossiblesMovesIn_d5_Test()
    {
      var bord = new Board();
      bord.InsertPawn(27, "Q","B");
      var possiblesIndex = bord.GetPossibleMoves(27, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(41);
      Assert.IsTrue(iscontent);
    }


    [TestMethod]
    public void MRT04QueenDiagonalMoinsMoinsGetPossiblesMovesIn_g5_Test()
    {
      var bord = new Board();
      bord.InsertPawn(30, "Q","B");
      var possiblesIndex = bord.GetPossibleMoves(30, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(3);
      Assert.IsTrue(iscontent);
    }


    [TestMethod]
    public void MRT05QueenDiagonalMoinsMoinsGetPossiblesMovesIn_h8_Test()
    {
      var bord = new Board();
      bord.InsertPawn(63, "Q","B");
      var possiblesIndex = bord.GetPossibleMoves(63, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(0);
      Assert.IsTrue(iscontent);
    }

    [TestMethod]
    public void MRT06QueenDiagonalWhithAlierGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(50, "Q","B");
      bord.InsertPawn(36, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(50, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(36);
      Assert.IsFalse(iscontent);
    }

    [TestMethod]
    public void MRT07QueenDiagonalWhithAlierGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(50, "Q","B");
      bord.InsertPawn(36, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(50, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(36);
      Assert.IsFalse(iscontent);
    }

    [TestMethod]
    public void MRT08QueenDiagonalWhithOpinionGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(50, "Q","B");
      bord.InsertPawn(36, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(50, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(36);
      Assert.IsTrue(iscontent);
    }

    [TestMethod]
    public void MRT09QueenDiagonalOtherPawnGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(29, "B", "W");
      bord.InsertPawn(38, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(29, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(47);
      Assert.IsFalse(iscontent);
    }



    [TestMethod]
    public void MRT01QueenHorizontalGetPossiblesMovesIn32_a4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(32, "Q", "W");
      var possiblesIndex = bord.GetPossibleMoves(32, 0).Select(x => x.Index);
      var iscontent35 = possiblesIndex.Contains(35);
      Assert.IsTrue(iscontent35);
    }

    [TestMethod]
    public void MRT02QueenHorizontalGetPossiblesMovesIn33_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(33, "Q", "W");
      var possiblesIndex = bord.GetPossibleMoves(33, 0).Select(x => x.Index);
      var iscontent35 = possiblesIndex.Contains(35);
      Assert.IsTrue(iscontent35);
      var iscontent32 = possiblesIndex.Contains(32);
      Assert.IsTrue(iscontent32);
      var iscontent31 = possiblesIndex.Contains(31);
      Assert.IsFalse(iscontent31);
    }

    [TestMethod]
    public void MRT03QueenVerticalGetPossiblesMovesIn33_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(33, "Q", "W");
      var possiblesIndex = bord.GetPossibleMoves(33, 0).Select(x => x.Index);
      var iscontent9 = possiblesIndex.Contains(9);
      Assert.IsTrue(iscontent9);
    }
    [TestMethod]
    public void MRT04QueenVerticalGetPossiblesMovesIn33_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(33, "Q", "W");
      var possiblesIndex = bord.GetPossibleMoves(33, 0).Select(x => x.Index);
      var iscontent57 = possiblesIndex.Contains(57);
      Assert.IsTrue(iscontent57);
    }


    [TestMethod]
    public void MRT05QueenHorizontalWhitheOpinionGetPossiblesMovesIn36_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(36, "Q", "W");
      bord.InsertPawn(38, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(36, 0).Select(x => x.Index);
      var iscontent38 = possiblesIndex.Contains(38);
      Assert.IsTrue(iscontent38);
      var iscontent39 = possiblesIndex.Contains(39);
      Assert.IsFalse(iscontent39);
    }

    [TestMethod]
    public void MRT06QueenHorizontalWhitheAlierGetPossiblesMovesIn36_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(36, "Q", "W");
      bord.InsertPawn(38, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(36, 0).Select(x => x.Index);
      var iscontent38 = possiblesIndex.Contains(38);
      Assert.IsFalse(iscontent38);
      var iscontent39 = possiblesIndex.Contains(39);
      Assert.IsFalse(iscontent39);
    }

    [TestMethod]
    public void MRT07QueenHorizontalWhitheAlierGetPossiblesMovesIn36_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(36, "Q", "W");
      bord.InsertPawn(35, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(36, 0).Select(x => x.Index);
      var iscontent35 = possiblesIndex.Contains(35);
      Assert.IsFalse(iscontent35);
      var iscontent33 = possiblesIndex.Contains(33);
      Assert.IsFalse(iscontent33);
    }



    [TestMethod]
    public void MRT07QueenVerticalGetPossiblesMovesIn62_g1_Test()
    {
      var bord = new Board();
      bord.InsertPawn(62, "Q", "W");
      var possiblesIndex = bord.GetPossibleMoves(62, 0).Select(x => x.Index);
      var iscontent6 = possiblesIndex.Contains(6);
      Assert.IsTrue(iscontent6);
    }

    [TestMethod]
    public void MRT08QueenVerticalWhitheAlierGetPossiblesMovesIn51_b4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(51, "Q", "W");
      bord.InsertPawn(59, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(51, 0).Select(x => x.Index);
      var iscontent59 = possiblesIndex.Contains(59);
      Assert.IsFalse(iscontent59);
      var iscontent3 = possiblesIndex.Contains(3);
      Assert.IsTrue(iscontent3);
    }


    [TestMethod]
    public void MRT09QueenExtreGetPossiblesMovesIn0_a8_Test()
    {
      var bord = new Board();
      bord.InsertPawn(0, "Q", "W");
      var possiblesIndex = bord.GetPossibleMoves(0, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(56);
      Assert.IsTrue(iscontent);
      var iscontent1 = possiblesIndex.Contains(7);
      Assert.IsTrue(iscontent1);
    }

    [TestMethod]
    public void MRT10QueenExtreGetPossiblesMovesIn0_h1_Test()
    {
      var bord = new Board();
      bord.InsertPawn(63, "Q", "W");
      var possiblesIndex = bord.GetPossibleMoves(63, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(56);
      Assert.IsTrue(iscontent);
      var iscontent1 = possiblesIndex.Contains(7);
      Assert.IsTrue(iscontent1);
    }


  }

  [TestClass]
  public class MovingKingTests
  {



    [TestMethod]
    public void MRT00KingDiagonalPlusPlusGetPossiblesMovesIn_a8_Test()
    {
      var bord = new Board();
      bord.InsertPawn(0, "K", "B");
      var possiblesIndex = bord.GetPossibleMoves(0, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(9);
      Assert.IsTrue(iscontent);

      var iscontent1 = possiblesIndex.Contains(18);
      Assert.IsFalse(iscontent1);
    }


    [TestMethod]
    public void MRT01KingDiagonalPlusPlusGetPossiblesMovesIn_a8_Test()
    {
      var bord = new Board();
      bord.InsertPawn(49, "K", "W");
      var possiblesIndex = bord.GetPossibleMoves(49, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(40);
      Assert.IsTrue(iscontent);
       iscontent = possiblesIndex.Contains(41);
      Assert.IsTrue(iscontent);
       iscontent = possiblesIndex.Contains(42);
      Assert.IsTrue(iscontent);
       iscontent = possiblesIndex.Contains(48);
      Assert.IsTrue(iscontent);
       iscontent = possiblesIndex.Contains(50);
      Assert.IsTrue(iscontent);
       iscontent = possiblesIndex.Contains(56);
      Assert.IsTrue(iscontent);
       iscontent = possiblesIndex.Contains(57);
      Assert.IsTrue(iscontent);
       iscontent = possiblesIndex.Contains(58);
      Assert.IsTrue(iscontent);

      iscontent = possiblesIndex.Contains(25);
      Assert.IsFalse(iscontent);
      iscontent = possiblesIndex.Contains(14);
      Assert.IsFalse(iscontent);
      iscontent = possiblesIndex.Contains(61);
      Assert.IsFalse(iscontent);

    }


    [TestMethod]
    public void MRT02KingRocWhiteRight_Test_IsTrue()
    {
      var bord = new Board();
     // bord.Init();
      bord.InsertPawn(60, "K", "W");
      bord.InsertPawn(56, "T", "W");
      bord.InsertPawn(63, "T", "W");
      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(60, 0).Select(x => x.Index);

     /* var iscontent = possiblesIndex.Contains(57);
      Assert.IsTrue(iscontent);*/
      var iscontent = possiblesIndex.Contains(62);
      Assert.IsTrue(iscontent);
    
    }

    [TestMethod]
    public void MRT04KingRocWhiteLeft_Test_IsTrue()
    {
      var bord = new Board();
      //bord.Init();
      bord.InsertPawn(60, "K", "W");
      bord.InsertPawn(56, "T", "W");
      bord.InsertPawn(63, "T", "W");
      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(60, 0).Select(x => x.Index);

       var iscontent = possiblesIndex.Contains(58);
       Assert.IsTrue(iscontent);
    }

    [TestMethod]
    public void MRT05KingRocWhiteRight_Test_IsFalseRookLefttMove()
    {
      var bord = new Board();
      bord.InsertPawn(60, "K", "W");
      bord.InsertPawn(56, "T", "W");
      bord.InsertPawn(63, "T", "W");
      bord.Move(56, 58, 0);
      bord.Move(58, 56, 0);
      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(60, 0).Select(x => x.Index);

      var iscontent = possiblesIndex.Contains(58);

      Assert.IsFalse(iscontent);

    }

    [TestMethod]
    public void MRT03KingRocWhiteRight_Test_IsFalseRookRightMove()
    {
      var bord = new Board();
      bord.InsertPawn(60, "K", "W");
      bord.InsertPawn(56, "T", "W");
      bord.InsertPawn(63, "T", "W");
      bord.Move(63, 55, 0);
      bord.Move(55, 63, 0);
      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(60, 0).Select(x => x.Index);

      /* var iscontent = possiblesIndex.Contains(57);
       Assert.IsTrue(iscontent);*/
      var iscontent = possiblesIndex.Contains(62);
      Assert.IsFalse(iscontent);

    }


    [TestMethod]
    public void MRT06KingRocWhiteRight_Test_IsTrue()
    {
      var bord = new Board();
      bord.InsertPawn(4, "K", "B");
      bord.InsertPawn(0, "T", "B");
      bord.InsertPawn(7, "T", "B");
      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(4, 0).Select(x => x.Index);

      /* var iscontent = possiblesIndex.Contains(57);
       Assert.IsTrue(iscontent);*/
      var iscontent = possiblesIndex.Contains(2);
      Assert.IsTrue(iscontent);

    }

    [TestMethod]
    public void MRT07KingRocWhiteLeft_Test_IsTrue()
    {
      var bord = new Board();
      bord.InsertPawn(4, "K", "B");
      bord.InsertPawn(0, "T", "B");
      bord.InsertPawn(7, "T", "B");
      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(4, 0).Select(x => x.Index);

      var iscontent = possiblesIndex.Contains(6);
      Assert.IsTrue(iscontent);
    }

    [TestMethod]
    public void MRT08KingRocWhiteRight_Test_IsFalseRookLefttMove()
    {
      var bord = new Board();
      bord.InsertPawn(4, "K", "B");
      bord.InsertPawn(0, "T", "B");
      bord.InsertPawn(7, "T", "B");
      bord.Move(0, 2, 0);
      bord.Move(2, 0, 0);
      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(4, 0).Select(x => x.Index);

      var iscontent = possiblesIndex.Contains(1);

      Assert.IsFalse(iscontent);

    }

    [TestMethod]
    public void MRT09KingRocWhiteRight_Test_IsFalseRookRightMove()
    {
      var bord = new Board();
      bord.InsertPawn(4, "K", "B");
      bord.InsertPawn(0, "T", "B");
      bord.InsertPawn(7, "T", "B");
      bord.Move(7, 47, 0);
      bord.Move(47, 7, 0);
      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(4, 0).Select(x => x.Index);

      /* var iscontent = possiblesIndex.Contains(57);
       Assert.IsTrue(iscontent);*/
      var iscontent = possiblesIndex.Contains(6);
      Assert.IsFalse(iscontent);

    }



    [TestMethod]
    public void MRT10KingRocWhiteRight_Test_IsFalseKingMove()
    {
      var bord = new Board();
      bord.InsertPawn(60, "K", "W");
      bord.InsertPawn(56, "T", "W");
      bord.InsertPawn(63, "T", "W");
      bord.Move(60, 61, 0);
      bord.Move(61, 60, 0);
      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(60, 0).Select(x => x.Index);

      /* var iscontent = possiblesIndex.Contains(57);
       Assert.IsTrue(iscontent);*/
      var iscontent = possiblesIndex.Contains(62);
      Assert.IsFalse(iscontent);

    }
   
    
    [TestMethod]
    public void MRT11KingRocWhiteToRigthTowMove_Test()
    {
      var bord = new Board();
      bord.InsertPawn(60, "K", "W");
      bord.InsertPawn(56, "T", "W");
      bord.InsertPawn(63, "T", "W");
      
      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(60, 0);
      bord.Move(60, 62, 0);
      bord.PrintInDebug();
      /* var iscontent = possiblesIndex.Contains(57);
       Assert.IsTrue(iscontent);*/
      var isCorrect = bord.GetCases()[61]=="T|W";
      Assert.IsTrue(isCorrect);

    }

    [TestMethod]
    public void MRT12KingRocWhiteToLeftTowMove_Test()
    {
      var bord = new Board();
      bord.InsertPawn(60, "K", "W");
      bord.InsertPawn(56, "T", "W");
      bord.InsertPawn(63, "T", "W");

      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(60, 0);
      bord.Move(60, 58, 0);
      bord.PrintInDebug();
      /* var iscontent = possiblesIndex.Contains(57);
       Assert.IsTrue(iscontent);*/
      var isCorrect = bord.GetCases()[59] == "T|W";
      Assert.IsTrue(isCorrect);

    }


    [TestMethod]
    public void MRT13KingRocBlackToRigthTowMove_Test()
    {
      var bord = new Board();
      bord.InsertPawn(4, "K", "B");
      bord.InsertPawn(0, "T", "B");
      bord.InsertPawn(7, "T", "B");

      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(4, 0);
      bord.Move(4, 2, 0);
      bord.PrintInDebug();
      /* var iscontent = possiblesIndex.Contains(57);
       Assert.IsTrue(iscontent);*/
      var isCorrect = bord.GetCases()[3] == "T|B";
      Assert.IsTrue(isCorrect);

    }

    [TestMethod]
    public void MRT14KingRocWhiteToLeftTowMove_Test()
    {
      var bord = new Board();
      bord.InsertPawn(4, "K", "B");
      bord.InsertPawn(0, "T", "B");
      bord.InsertPawn(7, "T", "B");

      bord.PrintInDebug();
      var possiblesIndex = bord.GetPossibleMoves(4, 0);


      bord.Move(4, 6, 0);
      bord.PrintInDebug();
      /* var iscontent = possiblesIndex.Contains(57);
       Assert.IsTrue(iscontent);*/
      var isCorrect = bord.GetCases()[5] == "T|B";
      Assert.IsTrue(isCorrect);

    }

  }

  [TestClass]
  public class MovingKnightTests
  {
    [TestMethod]
    public void MKnT00KnightGetPossiblesMovesIn_d4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(42, "C", "W");
      var possiblesIndex = bord.GetPossibleMoves(42, 0).Select(x => x.Index);

      var iscontent = possiblesIndex.Contains(32);
      Assert.IsTrue(iscontent);
      iscontent = possiblesIndex.Contains(25);
      Assert.IsTrue(iscontent);
      iscontent = possiblesIndex.Contains(27);
      Assert.IsTrue(iscontent);
      iscontent = possiblesIndex.Contains(36);
      Assert.IsTrue(iscontent);
      iscontent = possiblesIndex.Contains(52);
      Assert.IsTrue(iscontent);
      //iscontent = possiblesIndex.Contains(59);
      //Assert.IsTrue(iscontent);
      iscontent = possiblesIndex.Contains(57);
      Assert.IsTrue(iscontent);
      //iscontent = possiblesIndex.Contains(48);
      //Assert.IsTrue(iscontent);


    }


    [TestMethod]
    public void MKnT01KnightGetPossiblesMovesIn_a1_Test()
    {
      var bord = new Board();
      bord.InsertPawn(56, "C", "W");
      var possiblesIndex = bord.GetPossibleMoves(56, 0).Select(x => x.Index);

      var iscontent = possiblesIndex.Contains(41);
      Assert.IsTrue(iscontent);
      iscontent = possiblesIndex.Contains(50);
      Assert.IsTrue(iscontent);
      


    }


    [TestMethod]
    public void MKnT02KnightWhitOtherGetPossiblesMovesIn_f4_Test()
    {
      var bord = new Board();
      bord.InsertPawn(37, "C", "W");
      bord.InsertPawn(20, "C", "W");
      bord.InsertPawn(54, "C", "B");
      var possiblesIndex = bord.GetPossibleMoves(37, 0).Select(x => x.Index);

      var iscontent = possiblesIndex.Contains(20);
      Assert.IsFalse(iscontent);
      iscontent = possiblesIndex.Contains(54);
      Assert.IsTrue(iscontent);
    }
  }

  [TestClass]
  public class MovingSimplePawnTests
  {
    [TestMethod]
    public void MSPT00SimplePawnGetPossiblesMovesIn_d7_Test()
    {
      var bord = new Board();
      bord.InsertPawn(11, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(11,0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(19);
      Assert.IsTrue(iscontent);
    }

    [TestMethod]
    public void MSPT02SimplePawnGetPossiblesMovesIn_e3_Test()
    {
      var bord = new Board();
      bord.InsertPawn(44, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(44,0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(52);
      Assert.IsTrue(iscontent);
       iscontent = possiblesIndex.Contains(60);
      Assert.IsFalse(iscontent);
    }

    [TestMethod]
    public void MSPT01SimplePawnGetPossiblesMovesIn_b7_Test()
    {
      var bord = new Board();
      bord.InsertPawn(9, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(9, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(17);
      Assert.IsTrue(iscontent);
       iscontent = possiblesIndex.Contains(25);
      Assert.IsTrue(iscontent);
    }


    [TestMethod]
    public void MSPT03SimplePawnGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(48, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(48, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(40);
      Assert.IsTrue(iscontent);
    }

    [TestMethod]
    public void MSPT04SimplePawnGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(53, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(53, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(45);
      Assert.IsTrue(iscontent);
      iscontent = possiblesIndex.Contains(37);
      Assert.IsTrue(iscontent);
    }

    [TestMethod]
    public void MSPT05SimplePawnGetPossiblesMovesIn__Test()
    {
      var bord = new Board();
      bord.InsertPawn(46, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(46, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(38);
      Assert.IsTrue(iscontent);
      iscontent = possiblesIndex.Contains(30);
      Assert.IsFalse(iscontent);
    }

    [TestMethod]
    public void MSPT06SimplePawnWhitOtherGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(52, "P", "W");
      bord.InsertPawn(44, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(52, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(44);
      Assert.IsFalse(iscontent);
      iscontent = possiblesIndex.Contains(36);
      Assert.IsFalse(iscontent);
    }
    [TestMethod]
    public void MSPT07SimplePawnWhitOtherGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(49, "P", "W");
      bord.InsertPawn(33, "P", "W");
      var possiblesIndex = bord.GetPossibleMoves(49, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(41);
      Assert.IsTrue(iscontent);
      iscontent = possiblesIndex.Contains(33);
      Assert.IsFalse(iscontent);
    }


    [TestMethod]
    public void MSPT08SimplePawnWhitOpinionGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(18, "P", "B");
      bord.InsertPawn(25, "B", "W");
      var possiblesIndex = bord.GetPossibleMoves(18, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(26);
      Assert.IsTrue(iscontent);
      iscontent = possiblesIndex.Contains(25);
      Assert.IsTrue(iscontent);
    }
    [TestMethod]
    public void MSPT09SimplePawnWhitOpinionGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(18, "P", "B");
      bord.InsertPawn(25, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(18, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(26);
      Assert.IsTrue(iscontent);
      iscontent = possiblesIndex.Contains(25);
      Assert.IsFalse(iscontent);
    }

    [TestMethod]
    public void MSPT10SimplePawnWhitOpinionGetPossiblesMovesIn_Test()
    {
      var bord = new Board();
      bord.InsertPawn(20, "P", "W");
      bord.InsertPawn(12, "P", "W");
      bord.InsertPawn(11, "P", "B");
      bord.InsertPawn(13, "P", "B");
      var possiblesIndex = bord.GetPossibleMoves(20, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(12);
      Assert.IsFalse(iscontent);
      iscontent = possiblesIndex.Contains(11);
      Assert.IsTrue(iscontent);
      iscontent = possiblesIndex.Contains(13);
      Assert.IsTrue(iscontent);
    }



    [TestMethod]
    public void MSPT11SimplePawnWhitInitialGetPossiblesMovesIn_h8_Test()
    {
      var bord = new Board();
      bord.Init();
      var possiblesIndex = bord.GetPossibleMoves(7, 0).Select(x => x.Index);
      var iscontent = possiblesIndex.Contains(-1);
      Assert.IsFalse(iscontent);


    }


  }


  [TestClass]
  public class MovingAttackTests
  {
    [TestMethod]
    public void MAT00AttackMove_Black26to35_Test()
    {
      var bord = new Board();
      bord.InsertPawn(26, "P", "B");
      bord.InsertPawn(35, "P", "W");
      bord.CalculeScores();
      var resultBoard = Utils.CloneAndMove(bord,26, 35,1);
      Assert.AreEqual(bord.BlackScore,1);
      Assert.AreEqual(bord.WhiteScore, 1);

      Assert.AreEqual(resultBoard.BlackScore, 1);
      Assert.AreEqual(resultBoard.WhiteScore, 0);

    }
  }


  [TestClass]
  public class EngineSearchTests
  {

    [TestMethod]
    public void IEqualdT00Black0_Test()
    {
      Board bord1 = new Board();
      bord1.Init();
      Board bord2 = new Board();
      bord2.Init();
      //mainBord.Move(1, 42);
      //mainBord.Move(6, 45);
      //mainBord.CalculeScores();
      var engine = new Engine(3, "B",true);
      var isEquals = engine.IsEquals(bord1,bord2) ;

      Assert.IsTrue(isEquals);
    }

    [TestMethod]
    public void IEqualdT01_Test()
    {
      Board bord1 = new Board();
      bord1.Init();
      Board bord2 = new Board();
      bord2.Init();
      bord2.Move(1, 42,1);
      bord2.Move(6, 45,1);
      var engine = new Engine(3, "B", true);
      var isEquals = engine.IsEquals(bord1, bord2);

      Assert.IsFalse(isEquals);





    }

/*
    [TestMethod]
    public void EST00Black45to60_Test()
    {
      Board mainBord = new Board();
      mainBord.Init();
      mainBord.Move(1, 42,1);
      mainBord.Move(6, 45,1);
      mainBord.CalculeScores();
      var engine = new Engine(3,"B", true);
      var bestNode = engine.Search(mainBord,"5");


      Assert.AreEqual(bestNode.FromIndex, 45);
      Assert.AreEqual(bestNode.ToIndex, 60);

    }
    */
    [TestMethod]
    public void EST01White52to45_Test()
    {
      Board mainBord = new Board();
      mainBord.Init();
      mainBord.Move(1, 42,1);
      mainBord.Move(6, 45,1);
      mainBord.CalculeScores();
      var engine = new Engine(3,"W", true);
      var bestNode = engine.Search(mainBord,"5");


     // Assert.AreEqual(bestNode.FromIndex, 52);
      Assert.AreEqual(bestNode.ToIndex, 45);

    }



    [TestMethod]
    public void EST03WhiteFirstTurnRandom_Test()
    {
      Board mainBord = new Board();
      mainBord.Init();
      mainBord.CalculeScores();
      var engine = new Engine(3, "W", true);
      var bestNode = engine.Search(mainBord,"1");


      // Assert.AreEqual(bestNode.FromIndex, 52);
      Assert.IsNotNull(bestNode);

    }

  }


  [TestClass]
  public class BenchTest
  {
    [TestMethod]
    public void PawnsListStringToBoard_Test()
    {



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

      var bord = Utils.GenerateBoardFormPawnListString(pawnListString);

      bord.CalculeScores();


      Assert.AreEqual(bord.BlackScore, 30);
      Assert.AreEqual(bord.WhiteScore, 18);


    }
  }

  [TestClass]
  public class IsInChessTest
  {
    [TestMethod]
    public void WhiteKingIsInChess()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var bord = new Board();

      bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\TWhiteInChess");
      Utils.ComputerColor = "W";
      var result = Utils.KingIsInChess2(bord, Utils.ComputerColor);
      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition
      
      Assert.IsTrue(result);




    }
    [TestMethod]
    public void BlackKingIsNotInChess()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var bord = new Board();

      bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\TWhiteInChess");
      Utils.ComputerColor = "B";
      var result = Utils.KingIsInChess2(bord, Utils.ComputerColor);
      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition

      Assert.IsFalse(result);




    }


    [TestMethod]
    public void WhiteKingNotIsInChess_QuenIsMenaced()//Parceque la reinne noir en 39 est menacée
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var bord = new Board();

      bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\TWhiteNotInChessQueenIsNenaced");
      Utils.ComputerColor = "W";
      var result = Utils.KingIsInChess2(bord, Utils.ComputerColor);
      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition

      Assert.IsFalse(result);




    }
    [TestMethod]
    public void WhiteKingNotIsInChess_SimplePawnIsMenaced()//Parceque le pion noir en 44 est menacée
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var bord = new Board();

      bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\TWhiteNotInChessSiplePawnIsNenaced");
      Utils.ComputerColor = "W";
      var result = Utils.KingIsInChess2(bord, Utils.ComputerColor);
      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition

      Assert.IsFalse(result);




    }

  }


  [TestClass]
  public class IsMenacedTest
  {
    [TestMethod]
    public void BlackQueenIsNotMenaced()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var bord = new Board();

      bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\TWhiteInChess");
      //Utils.ComputerColor = "W";
      var result = Utils.IsMenaced(39, bord, "B");
      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition

      Assert.IsFalse(result);




    }
    [TestMethod]
    public void BlackQueenIsMenaced()
    {
      var bord = new Board();

      bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\TWhiteNotInChessQueenIsNenaced");
      
      var result = Utils.IsMenaced(39,bord,"B");
      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition

      Assert.IsTrue(result);




    }

    [TestMethod]
    public void WhiteD7IsMenaced()
    {
      var bord = new Board();

      bord.LoadFromDirectorie(@"D:\tsiry\RANDRENARIZO\Chess\Chess\TESTS\T32LaReineBlanchDoitAttaquerEnB7");

      var result = Utils.IsMenaced(11, bord, "W");
      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition

      Assert.IsTrue(result);




    }

  }

}
