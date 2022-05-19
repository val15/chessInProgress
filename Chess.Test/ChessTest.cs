using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Chess;
using Chess.Utils;
using System.Windows.Controls;
using System.Linq;
using System.Collections.Generic;
using Chess.Model;
using System.Threading.Tasks;
using Chess2Console;
using System.IO;

namespace Chess.Test
{
  [TestClass]
  public class ChessIATest
  {
    private string testsDirrectory = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.Combine(Environment.CurrentDirectory)).ToString()).ToString()).ToString(), "TESTS");

    [TestMethod]
    public void T00aLeKnigntBlanchNeDoitPasAttaquer()
    {
      /*La cavalier blanch ne doit pas attaquer*/
      //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7" 

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "Rook;a1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nKnight;b5;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nQueen;d1;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nKing;e1;White;False;True;True;True" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
      "SimplePawn;a7;Black;True;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nKing;e8;Black;False;True;True;True" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nBishop;b4;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nRook;h8;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7"
      Assert.AreNotEqual(nodeResult.BestChildPosition, "a7", "c7");
    }


   

    [TestMethod]
    public void T00bLeKnigntNoirNeDoitPasAttaquer()
    {
      /*La cavalier noit ne doit pas attaquer*/
      //Positions final du cavalier noir ne doit pas etre  ni "a2" ni "c2" 

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "Rook;a1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nKnight;b5;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nQueen;d1;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nKing;e1;White;False;True;True;True" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
      "SimplePawn;a7;Black;True;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nKing;e8;Black;False;True;True;True" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nBishop;b4;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nRook;h8;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);



      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //Positions final du cavalier noir ne doit pas etre  ni "a2" ni "c2" 
      Assert.AreNotEqual(nodeResult.BestChildPosition, "a2", "c2");
    }
   


    [TestMethod]
    public void T01QuenLaReineNoirNeDoitPasPrendreLeCavalier()
    {
      /*La reine noir ne doit pas prendre le cavalier*/
      //Position final de la reine Noir ne doit pas etre "g5"

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "King;g1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;f1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g5;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;b3;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b5;Black;False;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d5;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h4;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //Position final de la reine Noir ne doit pas etre "g5"
      Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");
    }


    [TestMethod]
    public void T02aLeRookBlanchNeDoitPasPrendresLePion()
    {
      /*Le Rook blanc ne doit pas prendre le pion*/
      //Position final du Rook blanch  ne doit pas etre "a7"

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nRook;a1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;c4;White;False;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nQueen;h1;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
       "King;d8;Black;False;True;True;True" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;f5;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nQueen;a8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //Position final du rook blanch  ne doit pas etre "a7"
      Assert.AreNotEqual(nodeResult.BestChildPosition, "a7");
    }

  
   

/*
    [TestMethod]
    public void T04LePionBlanchNeDoitPasprendreLeRookNoir()
    {


      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "King;f2;White;False;False;True;False" +
        "\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h2;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
       "King;e8;Black;False;True;False;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a3;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;b7;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;h6;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d5;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //Position final du pion blanch  ne doit pas etre "a3"
      Assert.AreNotEqual(nodeResult.BestChildPosition, "a3");

    }
*/
    [TestMethod]
    public void T05LeFousBlacheDoitSeSaccrifierPourProtegerLeRook()
    {
      /*Le Fous blanc doit attaquer le pion noir
       * les noirs*/
      //Position final du Fous blanch  doit etre "a7"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "Rook;a1;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;e3;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nQueen;d1;White;False;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nKing;e1;White;False;True;True;True" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
       "SimplePawn;a7;Black;True;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nQueen;b2;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nKing;e8;Black;False;True;True;True" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nBishop;d6;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nRook;h8;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      Assert.AreNotEqual(nodeResult.BestChildPosition, "c4");
    }



    [TestMethod]
    public void T07aEchecRookBlancDoitAttaquerLeRoiNoir()
    {
      /*Le Rook blanc doit attaquer le roir noir pout tout de suite mettre en echec 
       * les noirs*/
      //Position final du rook blanch  doit etre "d8"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "King;h4;White;False;False;False;True" +
"\nQueen;e1;White;False;False;False;False" +
"\nRook;d5;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a3;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;g4;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "King;g8;Black;False;False;False;False" +
        "\nQueen;g6;Black;False;False;False;False" +
"\nRook;c6;Black;False;False;False;False" +
"\nKnight;a7;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //rook blanch  doit etre "d8"
      Assert.AreEqual(nodeResult.AssociatePawn.Name, "Rook");
      Assert.AreEqual(nodeResult.BestChildPosition, "d8");
    }


    [TestMethod]
    public void T07bEchecRookOuReineBlancDoitAttaquerLeRoiNoir()
    {
      /*Le Rook ou la reinne blanc doit attaquer le roir noir pout tout de suite mettre en echec 
       * les noirs*/
      //Position final  blanche  doit etre "d8" ou "e8"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "King;h4;White;False;False;False;True" +
"\nQueen;e1;White;False;False;False;False" +
"\nRook;d5;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "King;g8;Black;False;True;False;True" +
        "\nQueen;g6;Black;False;False;False;False" +
"\nRook;c6;Black;False;False;False;False" +
"\nKnight;a7;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //Position final blanche  doit etre "d8" ou "e8"
      //Assert.AreEqual(nodeResult.AssociatePawn.Name, "Rook");
      var isSucces = false;
      if (nodeResult.BestChildPosition == "d8" || nodeResult.BestChildPosition == "e8")
        isSucces = true;
      Assert.IsTrue(isSucces);
    }


    [TestMethod]
    public void T11LaReineBlancNeDoitPasAttaqueLePion()
    {
      /*La reine blanc ne doit pas attaquer le pion noir en g6*/
      //la reine blanche ne doit se mettre sur "g6"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";


      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "Rook;a1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nQueen;c2;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nKing;e1;White;False;True;True;True" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nSimplePawn; h2; White; True; False; False; False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "SimplePawn;a7;Black;True;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nKing;e8;Black;False;True;True;True" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nRook;h8;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //la reine blanche ne doit se mettre sur "g6"
      Assert.AreNotEqual(nodeResult.BestChildPosition, "g6");
    }


    [TestMethod]
    public void T15LaReineBlanchNeDoitPasPrendreLePion()
    {
      /*La reine blanc ne doit pas attaquer le pion noir en a6*/
      ////la reine blanche ne doit se mettre sur "a6"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";


      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "SimplePawn;a2;White;True;False;False;False" +
        "\nSimplePawn;a3;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nBishop;b2;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nQueen;a4;White;False;False;False;False" +
"\nKing;e2;White;False;False;True;True";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "SimplePawn;a6;Black;False;False;False;False" +
        "\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d5;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;f8;Black;False;False;False;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nKing;g8;Black;False;True;True;True";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //la reine blanche ne doit se mettre sur "a6"
      Assert.AreNotEqual(nodeResult.BestChildPosition, "a6");
    }

    [TestMethod]
    public void T16SeulLePionDoitProtegerLeRoiNoir()
    {
      /*seul le poin doit protéger le roi noir*/
      ////le poin noir doit se mettre sur "f6"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;g5;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e7;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      ////le poin noir  doit se mettre sur "f6"
      Assert.AreEqual(nodeResult.AssociatePawn.Name, "SimplePawn");
      Assert.AreEqual(nodeResult.BestChildPosition, "f6");
    }


    [TestMethod]
    public void T17LeRoirNoirNeDoitPasAttaquer()
    {
      /*le roi noir ne doit pas attaquer */
      ////le roi noir ne doit pas se mettre sur "f6"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;f6;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e7;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      ////le roi noir ne doit pas se mettre sur "f6"
      //Assert.AreNotEqual(nodeResult.AssociatePawn.Name, "King");
      Assert.AreNotEqual(nodeResult.BestChildPosition, "f6");
    }

    [TestMethod]
    public void T18suiteDe16LeCavalierNoirDoitPrendreLeFouBlanc()
    {
      /*le cavalier noir  doit  attaquer */
      ////le cavalier noir  doit se mettre sur "f6"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;f6;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e7;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      ////le cavalier noir  doit se mettre sur "f6"
      Assert.AreEqual(nodeResult.AssociatePawn.Name, "Knight");
      Assert.AreEqual(nodeResult.BestChildPosition, "f6");
    }

    /*  [TestMethod]
      public void T19aLeBishopBlanchDoitMenacerLeRoiNoir()
      {

        ////le Bishop blanch doit se mettre sur "b5"




        var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
        mainWindow.ComputerColore = "White";
        
         
        
        mainWindow.CleanPawnList();
        var pawnListWhite = new List<Pawn>();
        var pawnListBlack = new List<Pawn>();



        //WHITEList
        var whiteListString = "" +
          "King;e1;White;False;True;True;True"+
  "\nQueen;d1;White;False;False;False;False"+
  "\nRook;a1;White;False;False;False;False"+
  "\nRook;h1;White;False;False;False;False"+
  "\nBishop;c1;White;False;False;False;False"+
  "\nBishop;f1;White;False;False;False;False"+
  "\nKnight;b1;White;False;False;False;False"+
  "\nKnight;g1;White;False;False;False;False"+
  "\nSimplePawn;a2;White;True;False;False;False"+
  "\nSimplePawn;b3;White;False;False;False;False"+
  "\nSimplePawn;c2;White;True;False;False;False"+
  "\nSimplePawn;d2;White;True;False;False;False"+
  "\nSimplePawn;e3;White;False;False;False;False"+
  "\nSimplePawn;f3;White;False;False;False;False"+
  "\nSimplePawn;g2;White;True;False;False;False"+
  "\nSimplePawn;h3;White;False;False;False;False";
        var whiteList = whiteListString.Split('\n');
        foreach (var line in whiteList)
        {
          var datas = line.Split(';');
          var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnListWhite.Add(newPawn);
        }

        //BLACKList
        var blackListString = "" +
          "King;e8;Black;False;True;True;True"+
  "\nQueen;d6;Black;False;False;False;False"+
  "\nRook;a8;Black;False;False;False;False"+
  "\nRook;h8;Black;False;False;False;False"+
  "\nBishop;c8;Black;False;False;False;False"+
  "\nBishop;g7;Black;False;False;False;False"+
  "\nKnight;b8;Black;False;False;False;False"+
  "\nKnight;g8;Black;False;False;False;False"+
  "\nSimplePawn;a7;Black;True;False;False;False"+
  "\nSimplePawn;b7;Black;True;False;False;False"+
  "\nSimplePawn;c7;Black;True;False;False;False"+
  "\nSimplePawn;d5;Black;False;False;False;False"+
  "\nSimplePawn;e7;Black;True;False;False;False"+
  "\nSimplePawn;f7;Black;True;False;False;False"+
  "\nSimplePawn;g5;Black;False;False;False;False"+
  "\nSimplePawn;h7;Black;True;False;False;False";
        var blackList = blackListString.Split('\n');
        foreach (var line in blackList)
        {
          var datas = line.Split(';');
          var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnListBlack.Add(newPawn);
        }



        mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


        var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
        ////le cavalier noir  doit se mettre sur "f6"
        Assert.AreEqual(nodeResult.AssociatePawn.Name, "Bishop");
        Assert.AreEqual(nodeResult.BestChildPosition, "b5");
      }

      */
    /*   [TestMethod]
       public void T19aLeBishopBlanchDoitNenacerleRoir()
       {
         //le Bishop blanch doit menacer le roi 
         ////le bishop blanch doit se mettre sur "b5"




         var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
         mainWindow.ComputerColore = "White";
         
          
         
         mainWindow.CleanPawnList();
         var pawnListWhite = new List<Pawn>();
         var pawnListBlack = new List<Pawn>();



         //WHITEList
         var whiteListString = "" +
   "King;e1;White;False;True;True;True"+
   "\nQueen;d1;White;False;False;False;False"+
   "\nRook;a1;White;False;False;False;False"+
   "\nRook;h1;White;False;False;False;False"+
   "\nBishop;c1;White;False;False;False;False"+
   "\nBishop;f1;White;False;False;False;False"+
   "\nKnight;b1;White;False;False;False;False"+
   "\nKnight;g1;White;False;False;False;False"+
   "\nSimplePawn;a2;White;True;False;False;False"+
   "\nSimplePawn;b3;White;False;False;False;False"+
   "\nSimplePawn;c3;White;True;False;False;False"+
   "\nSimplePawn;d2;White;True;False;False;False"+
   "\nSimplePawn;e3;White;False;False;False;False"+
   "\nSimplePawn;f3;White;False;False;False;False"+
   "\nSimplePawn;g2;White;True;False;False;False" +
   "\nSimplePawn;h3;White;False;False;False;False";
         var whiteList = whiteListString.Split('\n');
         foreach (var line in whiteList)
         {
           var datas = line.Split(';');
           var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
           //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
           newPawn.IsFirstMove = bool.Parse(datas[3]);
           newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
           newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
           newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
           pawnListWhite.Add(newPawn);
         }

         //BLACKList
         var blackListString = "" +
           "King;e8;Black;False;True;True;True"+
   "\nQueen;d6;Black;False;False;False;False"+
   "\nRook;a8;Black;False;False;False;False"+
   "\nRook;h8;Black;False;False;False;False"+
   "\nBishop;c8;Black;False;False;False;False"+
   "\nBishop;g7;Black;False;False;False;False"+
   "\nKnight;b8;Black;False;False;False;False"+
   "\nKnight;g8;Black;False;False;False;False"+
   "\nSimplePawn;a7;Black;True;False;False;False"+
   "\nSimplePawn;b7;Black;True;False;False;False"+
   "\nSimplePawn;c7;Black;True;False;False;False"+
   "\nSimplePawn;d5;Black;False;False;False;False"+
   "\nSimplePawn;e7;Black;True;False;False;False"+
   "\nSimplePawn;f7;Black;True;False;False;False"+
   "\nSimplePawn;g5;Black;False;False;False;False"+
   "\nSimplePawn;h7;Black;True;False;False;False";
         var blackList = blackListString.Split('\n');
         foreach (var line in blackList)
         {
           var datas = line.Split(';');
           var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
           //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
           newPawn.IsFirstMove = bool.Parse(datas[3]);
           newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
           newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
           newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
           pawnListBlack.Add(newPawn);
         }



         mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


         var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
         ////le bishop blanch doit se mettre sur "b5"
         Assert.AreEqual(nodeResult.BestChildPosition, "b5");
       }
   */
    [TestMethod]
    public void T19bLeFouBlanchDoitnenacerLaReineOulePionDoitProtegerLeTour()
    {
      ////////le poin blanch doit se mettre sur ""




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";


      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b3;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f3;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e8;Black;False;True;True;True" +
"\nQueen;d6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d5;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g5;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      ////////le poin blanch doit se mettre sur "c3"
      var isSucces = false;
      if (nodeResult.BestChildPosition == "d4" || nodeResult.BestChildPosition == "c3" || nodeResult.BestChildPosition == "a3")
        isSucces = true;
      Assert.IsTrue(isSucces);
    }


  
    [TestMethod]
    public void T20LePionDoitPrendreLeCavalier()
    {
      /*le pion blanch doit prendre le cavalier */
      ////le pion blanch doit se mettre sur "d3"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";


      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;d2;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;b3;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;g4;Black;False;False;False;False" +
"\nKnight;d3;Black;False;False;False;False" +
"\nKnight;e4;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      ////le pion blanch doit se mettre sur "d3"
      Assert.AreEqual(nodeResult.AssociatePawn.Name, "SimplePawn");
      Assert.AreEqual(nodeResult.BestChildPosition, "d3");
    }


    [TestMethod]
    public void T21LeRoiBlanchDoitSeMettreEnd3()
    {
      /*La roi blanch doit se mettre en d3*/
      //Positions final du roi blanch doit etre d3 

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";


      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "King;e2;White;False;False;True;False" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h5;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b5;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;d5;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
      "King;e8;Black;False;True;True;False" +
"\nQueen;g2;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;h6;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;e3;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g4;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7"
      //Assert.AreNotEqual(nodeResult.BestChildPosition, "a7", "c7");
      Assert.AreEqual(nodeResult.AssociatePawn.Name, "King");
      Assert.AreEqual(nodeResult.BestChildPosition, "d3");
    }

    [TestMethod]
    public void T22LeBishopOuLeRoiNoirDoitPrendreLePion()
    {
      /*Le Bishop Noir Doit Prendre le pion */
      ////le Bishop noir  doit se mettre sur "e7"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;f1;White;False;False;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;e2;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;e7;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f3;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e8;Black;False;True;True;True" +
        "\nQueen;c4;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
    //  Assert.IsNull(randomList);
      Assert.AreEqual(nodeResult.BestChildPosition, "e7");
    }


    [TestMethod]
    public void T23LeCavalierNoirNeDoitPasMenacerLeRoiBlanch()
    {
      /*Le Cavalier noir ne doit pas menacer le roi blanc*/
      ////le Cavalier noir ne doit pas se mettre sur "b3"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;d2;White;False;False;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;a1;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      ////le Cavalier noir ne doit pas se mettre sur "b3"
      //Assert.AreEqual(nodeResult.AssociatePawn.Name, "Bishop");
      Assert.AreNotEqual(nodeResult.BestChildPosition, "b3");
    }


    [TestMethod]
    public void T24LeCavalierNoirNeDoitPasBouger()
    {
      /*Le Cavalier noir ne doit pas bouger*/




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;d2;White;False;False;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;a1;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      Assert.AreNotEqual(nodeResult.Location, "a1");

    }

    [TestMethod]
    public void T25LeCavalierNoirDoitMenacerLeRoiBlanch()
    {
      /*Le Cavalier noir doit mencer le roi blanc*/




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;d2;White;False;False;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;c2;White;False;False;False;False" +
"\nKnight;d1;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;a1;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


      //TODO A REVERIFIER
      //Assert.AreEqual(nodeResult.AssociatePawn.Name, "Knight");
      // Assert.AreEqual(nodeResult.BestChildPosition, "b3");

      Assert.AreEqual(nodeResult.BestChildPosition, "b3");

    }

    [TestMethod]
    public void T26LeCavalierNoirDoitBouger()
    {
      /*Le Cavalier noir en f6 doit se deplacer*/




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;d3;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;h6;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      /*Le Cavalier noir en f6 doit se deplacer*/
      Assert.AreEqual(nodeResult.AssociatePawn.Name, "Knight");
      Assert.AreEqual(nodeResult.AssociatePawn.Location, "f6");

    }
    

    [TestMethod]
    public void T27LeBishopBlancDoitSeMettreEnA8()
    {
      /*Le Bishop blanc doit attaque le rook en a8 et non pas le cavalier*/
      // Le Bishop blanc doit se mettre en a8



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";


      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c3;White;False;False;False;False" +
"\nBishop;c6;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b3;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;d7;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;f4;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g5;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      // Le Bishop blanc doit se mettre en a8
      var isSucces = false;
      if (nodeResult.BestChildPosition == "g7" || nodeResult.BestChildPosition == "g8")
        isSucces = true;
      Assert.IsTrue(isSucces);

    }

    [TestMethod]
    public void T28LePionNoirDoitPrendreLeCavalier()
    {
      /*Le pion noir doit attaque le cavavier en d6*/
      // Le pion noir doit se mettre en d6



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;d6;White;False;False;False;False" +
"\nKnight;f3;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a6;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      // // Le pion noir doit se mettre en d6
      Assert.AreEqual(nodeResult.BestChildPosition, "d6");


    }

    [TestMethod]
    public void T29PourProtegerDEchec()
    {
      /*Le pion blanch doit se mettre en h4 ou le Bishop doit se mettre en g2 ou reine en c2  pour proder de l'check*/
      // Le pion blanc doit se mettre en h4 ou le Bishop doit se mettre en g2 ou ou reine en c2



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";


      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b3;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;g4;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;f6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;e3;Black;False;False;False;False" +
"\nSimplePawn;e4;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      // Le pion blanc doit se mettre en h4 ou le Bishop doit se mettre en g2 ou reine en c2
      var isSuccess = false;
      if (nodeResult.BestChildPosition == "h4" || nodeResult.BestChildPosition == "g2" || nodeResult.BestChildPosition == "c2" || nodeResult.BestChildPosition == "g5" || nodeResult.BestChildPosition == "d5" || nodeResult.BestChildPosition == "d4" || nodeResult.BestChildPosition == "c1")
        isSuccess = true;
      Assert.IsTrue(isSuccess);


    }

    [TestMethod]
    public void T30LaReineNoirNeDoitPasPrendreLeFouEnG4()
    {
      /*La reinne noir ne doit pas se mettre en g4*/
      // La reinne noir ne doit pas se mettre en g4



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;g1;White;False;False;True;True" +
"\nQueen;h8;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;e3;White;False;False;False;False" +
"\nBishop;g4;White;False;False;False;False" +
"\nKnight;e4;White;False;False;False;False" +
"\nKnight;f2;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;f8;Black;False;False;False;True" +
"\nQueen;g6;Black;False;False;False;False" +
"\nRook;a6;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //La reinne noir ne doit pas se mettre en g4
      Assert.AreNotEqual(nodeResult.BestChildPosition, "g4");


    }


    [TestMethod]
    public void T31LaReineNoirDoitPrendreLaReineBlanch()
    {
      /*La reinne noir ne doit pas se mettre en a8*/



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;g1;White;False;True;True;True" +
"\nQueen;a8;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;a3;White;False;False;False;False" +
"\nKnight;f3;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g4;White;False;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;d7;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f5;Black;False;False;False;False" +
"\nSimplePawn;f4;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //La reinne noir ne doit pas se mettre en g4
      Assert.AreEqual(nodeResult.BestChildPosition, "a8");


    }

    [TestMethod]
    public void T32LaReineBlanchDoitAttaquerEnB7()
    {




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";


      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;b5;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;d7;Black;False;False;False;False" +
"\nBishop;f6;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;h6;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;g5;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      var succes = false;
      if (randomList != null)
      {
        if (randomList.Count == 1)
          succes = true;
      }
      else
        succes = true;

      Assert.IsTrue(succes);
      //La reinne noir  doit se mettre en b7
      Assert.AreEqual(nodeResult.BestChildPosition, "b7");


    }
    [TestMethod]
    public void T33LaReineBlanchDoitAttaquerEnB7()
    {




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;b5;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;d7;Black;False;False;False;False" +
"\nBishop;f6;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;h6;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;g5;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
     // Assert.IsNull(randomList);
      //La reinne noir  doit se mettre en b7
      Assert.AreEqual(nodeResult.BestChildPosition, "b7");


    }

    [TestMethod]
    public void T35LePoinNoirNeDoitPasSeMettreEnG5()
    {




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
        "\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;f4;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;a5;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


     

      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;

   
    /*  foreach (var random in randomList.OrderBy(x => Guid.NewGuid()))
      {
        if(Chess2Console.Utils.IsMenaced(random.ToIndex,"B", random.Board))
        {
          var t_menaced = random;
        }
      }*/



    //  Assert.IsNull(randomList.FirstOrDefault(x => x.ToIndex == 30));
      Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");

   

    }


    [TestMethod]
    public void T36LePoinNoirNeDoitPasSeMettreEnD6()
    {




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;f2;White;False;False;False;False" +
"\nBishop;a8;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;e2;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;e3;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a6;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;f6;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

     

      Assert.AreNotEqual(nodeResult.BestChildPosition, "d6");


    }


    [TestMethod]
    public void T37LaTourDoitEtreProtegE()
    {




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;f4;White;False;False;False;False" +
"\nBishop;d5;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

     
      Assert.AreEqual(nodeResult.BestChildPosition, "c6");


    }

    [TestMethod]
    public void T38LePionNoirNeDoitPasSeMettreSurA3()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c3;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;f5;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;b5;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;d6;White;False;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a7;Black;False;False;False;False" +
"\nRook;h7;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nKnight;h5;Black;False;False;False;False" +
"\nSimplePawn;a4;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
    

      Assert.AreNotEqual(nodeResult.BestChildPosition, "a3");
    }

    [TestMethod]
    public void T39LePionNoirNeDoitPasSeMettreSurC3()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g2;White;False;False;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;f2;White;False;False;False;False" +
"\nBishop;h8;White;False;False;False;False" +
"\nKnight;a2;White;False;False;False;False" +
"\nSimplePawn;f5;White;False;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;True" +
"\nQueen;a5;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;d6;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;b5;Black;False;False;False;False" +
"\nSimplePawn;c4;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e5;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

          Assert.AreNotEqual(nodeResult.BestChildPosition,"c3");
    }


    [TestMethod]
    public void T40LePionNoirNeDoitPasSeMettreSurA2()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g2;White;False;False;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;f2;White;False;False;False;False" +
"\nBishop;h8;White;False;False;False;False" +
"\nKnight;c1;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;True" +
"\nQueen;a5;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;d6;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;a3;Black;False;False;False;False" +
"\nSimplePawn;b5;Black;False;False;False;False" +
"\nSimplePawn;c4;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

       Assert.AreNotEqual(nodeResult, "a2");
    }


    [TestMethod]
    public void T41LaReineBlancheDoitMenacerLeRoiEnH5OuPrendreLaReineD6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f2;White;False;False;True;False" +
"\nQueen;h7;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;g6;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c2;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b3;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;d5;Black;False;False;True;True" +
"\nQueen;d6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nBishop;b7;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b5;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d4;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


      // var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "a2");

      var isSucces =false;
      if (nodeResult.BestChildPosition == "h5" || nodeResult.BestChildPosition == "d6")
        isSucces = true;
      Assert.IsTrue(isSucces);
    }

/*
    [TestMethod]
    public void T43LeCavalierNoirNeDoitPasprendreLePionEnF2()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;e2;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;h3;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;c5;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;e4;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      Assert.IsNull(randomList);

      // var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "a2");
      Assert.AreNotEqual(nodeResult.BestChildPosition, "f2");
    }
    */
    [TestMethod]
    public void T44LePionNoirPasRamdumeB5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;e2;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;f2;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;c5;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      // var t_value = nodeResult.Weight;
      //var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "b5");
      Assert.AreNotEqual(nodeResult.BestChildPosition, "b5");
    }



    [TestMethod]
    public void T45LeChevalierBlacnDoitSeNettreEnG5SpecificPosition0()
    {
      
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      //Pour les SpecificPositions il faut se connecter à la base
      mainWindow.SetIsConnectedDB(true);


      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;f3;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      // var t_value = nodeResult.Weight;
      //var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "b5");
      Assert.AreEqual(nodeResult.BestChildPosition, "g5");
    }



    [TestMethod]
    public void T46LeFouBlacnDoitSeNettreEncC4SpecificPosition0()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      //Pour les SpecificPositions il faut se connecter à la base
      mainWindow.SetIsConnectedDB(true);


      mainWindow.ComputerColore = "White";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;g5;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      // var t_value = nodeResult.Weight;
      //var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "b5");
      Assert.AreEqual(nodeResult.BestChildPosition, "c4");
    }


    [TestMethod]
    public void T47LesNoirsDoiventEviterLeSpecificPosition0()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      //Pour les SpecificPositions il faut se connecter à la base
      mainWindow.SetIsConnectedDB(true);
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;f3;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      var isSucces = false;
      if (nodeResult.BestChildPosition == "g4"  || nodeResult.BestChildPosition == "e6" || nodeResult.BestChildPosition == "h6" || nodeResult.BestChildPosition == "c8")
        isSucces = true;
      Assert.IsTrue(isSucces);
    }

//    [TestMethod]
//    public void T48LaTourNoirDoitSeMetteEnA7OuPionEnF5()
//    {
//      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
//      mainWindow.ComputerColore = "Black";

//      
//       
//      
//      mainWindow.CleanPawnList();
//      var pawnListWhite = new List<Pawn>();
//      var pawnListBlack = new List<Pawn>();



//      //WHITEList
//      var whiteListString = "" +
//"King;g1;White;False;True;True;True" +
//"\nQueen;f4;White;False;False;False;False" +
//"\nRook;f3;White;False;False;False;False" +
//"\nBishop;c4;White;False;False;False;False" +
//"\nKnight;b1;White;False;False;False;False" +
//"\nKnight;h7;White;False;False;False;False" +
//"\nSimplePawn;a2;White;True;False;False;False" +
//"\nSimplePawn;c2;White;True;False;False;False" +
//"\nSimplePawn;e4;White;False;False;False;False" +
//"\nSimplePawn;f2;White;True;False;False;False" +
//"\nSimplePawn;g2;White;True;False;False;False" +
//"\nSimplePawn;h2;White;True;False;False;False";
//      var whiteList = whiteListString.Split('\n');
//      foreach (var line in whiteList)
//      {
//        var datas = line.Split(';');
//        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
//        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
//        newPawn.IsFirstMove = bool.Parse(datas[3]);
//        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
//        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
//        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
//        pawnListWhite.Add(newPawn);
//      }

//      //BLACKList
//      var blackListString = "" +
//"King;e8;Black;False;True;True;False" +
//"\nQueen;d8;Black;False;False;False;False" +
//"\nRook;a8;Black;False;False;False;False" +
//"\nRook;f8;Black;False;False;False;False" +
//"\nBishop;b7;Black;False;False;False;False" +
//"\nBishop;a1;Black;False;False;False;False" +
//"\nKnight;b8;Black;False;False;False;False" +
//"\nSimplePawn;a5;Black;False;False;False;False" +
//"\nSimplePawn;b6;Black;False;False;False;False" +
//"\nSimplePawn;c7;Black;True;False;False;False" +
//"\nSimplePawn;d7;Black;True;False;False;False" +
//"\nSimplePawn;e6;Black;False;False;False;False" +
//"\nSimplePawn;f7;Black;True;False;False;False" +
//"\nSimplePawn;h5;Black;False;False;False;False" +
//"\nSimplePawn;h6;Black;False;False;False;False";
//      var blackList = blackListString.Split('\n');
//      foreach (var line in blackList)
//      {
//        var datas = line.Split(';');
//        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
//        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
//        newPawn.IsFirstMove = bool.Parse(datas[3]);
//        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
//        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
//        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
//        pawnListBlack.Add(newPawn);
//      }



//      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


//      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

//      var isSucces = false;
//      if (nodeResult.BestChildPosition == "a7" || nodeResult.BestChildPosition == "f5" || nodeResult.BestChildPosition == "c8")
//        isSucces = true;
//      Assert.IsTrue(isSucces);
//    }


    [TestMethod]
    public void T49LesNoirsDoiventprotegerLeRoiMenacE()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



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
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

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
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
     // Assert.IsNull(randomList);


      Assert.AreEqual(nodeResult.BestChildPosition, "e2");
    }


    [TestMethod]
    public void T50LaToureNoirDoitSeMettreEnA7()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;c3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;a7;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b4;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;h6;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f6;Black;False;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


      Assert.AreEqual(nodeResult.BestChildPosition, "a7");
    }

    [TestMethod]
    public void T51aLeFouBlanchDoiSeMettreSurH5SecificPosition1()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      //Pour les SpecificPositions il faut se connecter à la base
      mainWindow.SetIsConnectedDB(true);
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;f1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;e2;White;False;False;False;False" +
"\nKnight;h4;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;b7;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;d5;Black;False;False;False;False" +
"\nSimplePawn;f6;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h5;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


      Assert.AreEqual(nodeResult.BestChildPosition, "h5");
    }


    [TestMethod]
    public void T51bLeFouNoirDoitSeMettreSurH4SecificPosition1Symetri()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      //Pour les SpecificPositions il faut se connecter à la base
      mainWindow.SetIsConnectedDB(true);
      mainWindow.ComputerColore = "Black";

      
 


      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;b2;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b3;White;False;False;False;False" +
"\nSimplePawn;c4;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;f3;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;g8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nKnight;h5;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;e5;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


      Assert.AreEqual(nodeResult.BestChildPosition, "h4");
    }


    [TestMethod]
    /*tsiry;26-08-2021*/
    public void T52LaReineNoirNeDoitPasSeMettreEnC2()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h5;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;g6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;d6;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a6;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


      Assert.AreNotEqual(nodeResult.BestChildPosition, "c2");
    }


    [TestMethod]
    /*tsiry;26-08-2021*/
    public void T53LaPositionFinalNoirNeDoitPasEtreE6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;

      var succes = false;
      if (randomList != null)
      {
        if (randomList.Count == 1)
          succes = true;
      }
      else
        succes = true;
      Assert.IsTrue(succes);
      Assert.AreNotEqual(nodeResult.BestChildPosition, "e6");
    }


    [TestMethod]
    /*tsiry;27-08-2021*/
    public void T54ALesBlanchDoiventEviterLEvolutionDuPion()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;d1;White;False;False;True;True" +
"\nQueen;e3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;


      var succes = false;
      if (randomList != null)
      {
        if (randomList.Count == 1)
          succes = true;
      }
      else
        succes = true;

      Assert.IsTrue(succes);

      Assert.AreEqual(nodeResult.BestChildPosition, "b1");
    }


    [TestMethod]
    /*tsiry;27-08-2021*/
    public void T54BLaRaineBlancDoitMenacerLeRoiEtSeMettreEnG6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;d1;White;False;False;True;True" +
"\nQueen;d3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      Assert.AreEqual(nodeResult.BestChildPosition, "g6");
    }


    [TestMethod]
    /*tsiry;27-08-2021*/
    public void T54CLePionNoirDoitEvoluerDoitSeMettreEnC1()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;d1;White;False;False;True;True" +
"\nQueen;e3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      Assert.AreEqual(nodeResult.BestChildPosition, "a1");
    }


    [TestMethod]
    /*tsiry;27-08-2021*/
    public void T54ELePionNoirDoitEvoluerDoitSeMettreEnA1()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e2;White;False;False;True;True" +
"\nQueen;d3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      Assert.AreEqual(nodeResult.BestChildPosition, "a1");
    }
    [TestMethod]
    /*tsiry;14-10-2021*/
    public void T54FLaReineNoirMenaverleRoiBlanchEtSeMettreEnD6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;d1;White;False;False;True;True" +
"\nQueen;e3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);




      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      var isSucces = true;
      if (randomList != null)
      {
        //  Pour tester que T69
        foreach (var item in randomList)
        {
          if (item.ToIndex == 41)
          {
            isSucces = false;
            break;
          }
        }
      }
      Assert.IsTrue(isSucces);
      



       isSucces = false;
      if(nodeResult.BestChildPosition == "d6" || nodeResult.BestChildPosition == "a1" || nodeResult.BestChildPosition == "b3")
      isSucces = true;
        Assert.IsTrue(isSucces);
    }



    [TestMethod]
    /*tsiry;27-08-2021*/
    public void T54DLePionNoirDoitEvoluerETSeMettreEnB1()// T54DLaReinneNoirDoitSeMettreEnC4()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e2;White;False;False;True;True" +
"\nQueen;e3;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
//"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      Assert.AreEqual(nodeResult.BestChildPosition, "b1");
    }


    [TestMethod]
    /*tsiry;27-08-2021*/
    public void T54GLaReinneNoirDoitAttaquerEnC4()// T54DLaReinneNoirDoitSeMettreEnC4()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e2;White;False;False;True;True" +
"\nQueen;e3;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      Assert.AreEqual(nodeResult.BestChildPosition, "c4");
    }

    [TestMethod]
    /*tsiry;30-08-2021*/
    public void T55SecificPositionLeCavalierBlanchDoitSeMettreSurG6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b5;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;h4;White;False;False;False;False" +
"\nSimplePawn;a3;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a4;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f5;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


      Assert.AreEqual(nodeResult.BestChildPosition, "g6");
    }


    [TestMethod]
    /*tsiry;30-08-2021*/
    public void T56ToNotSecificPositionMesNoirDoiventEmpecherLeCavalierBlanchDeSeMettreSurG6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b5;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;h4;White;False;False;False;False" +
"\nSimplePawn;a3;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a4;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f5;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      Assert.AreNotEqual(nodeResult.BestChildPosition, "c6");
      Assert.AreNotEqual(nodeResult.BestChildPosition, "b7");
    }

    [TestMethod]
    /*tsiry;30-08-2021*/
    public void T57SeulLeRookDoitBougerNotRandomD5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f1;White;False;False;True;False" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;g1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;f4;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;f6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b5;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e5;Black;False;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");



     // var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "d5");
     // Assert.IsNull(result);
      Assert.AreNotEqual(nodeResult.BestChildPosition, "d5");
    }

    /*
    [TestMethod]
    //tsiry;30-08-2021
    public void T58PourEviterLeNullSeulLeRookNoirNeDoitSeMettreEnD2()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;b2;White;False;True;True;True"+
"\nRook;c1;White;False;False;False;False"+
"\nSimplePawn;h4;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True"+
"\nRook;a8;Black;False;False;False;False"+
"\nRook;d3;Black;False;False;False;False"+
"\nBishop;c8;Black;False;False;False;False"+
"\nSimplePawn;a7;Black;True;False;False;False"+
"\nSimplePawn;b7;Black;True;False;False;False"+
"\nSimplePawn;e6;Black;True;False;False;False"+
"\nSimplePawn;f7;Black;True;False;False;False"+
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }
      mainWindow.SetDebugTextBlockText("" +
        "" +
        "\nWhite: Pawn  e2 => e4" +
"\nBlack: Knight  b8 => a6" +
"\nWhite: Queen d1 => f3" +
"\nBlack: Knight  a6 => b8" +
"\nWhite: Bishop  f1 => c4" +
"\nBlack: Knight  g8 => f6" +
"\nWhite: Pawn  e4 => e5" +
"\nBlack: Pawn  g7 => g6" +
"\nWhite: Pawn  e5 => f6" +
"\nBlack: Pawn  e7 => e6" +
"\nWhite: Knight  b1 => c3" +
"\nBlack: Rook  h8 => g8" +
"\nWhite: Pawn  b2 => b4" +
"\nBlack: Bishop  f8 => b4" +
"\nWhite: Knight  c3 => b5" +
"\nBlack: Pawn  d7 => d6" +
"\nWhite: Pawn  c2 => c3" +
"\nBlack: Pawn  d6 => d5" +
"\nWhite: Pawn  d2 => d3" +
"\nBlack: Pawn  d5 => c4" +
"\nWhite: Bishop  c1 => f4" +
"\nBlack: Bishop  b4 => a5" +
"\nWhite: Pawn  d3 => c4" +
"\nBlack: Queen d8 => f6" +
"\nWhite: Rook  a1 => d1" +
"\nBlack: Queen f6 => f5" +
"\nWhite: Pawn  c4 => c5" +
"\nBlack: Queen f5 => c5" +
"\nWhite: Queen f3 => d3" +
"\nBlack: Knight  b8 => c6" +
"\nWhite: Bishop  f4 => e3" +
"\nBlack: Queen c5 => e5" +
"\nWhite: Knight  g1 => f3" +
"\nBlack: Queen e5 => h8" +
"\nWhite: Knight  b5 => c7" +
"\nBlack: Bishop  a5 => c7" +
"\nWhite: Knight  f3 => e5" +
"\nBlack: Bishop  c7 => e5" +
"\nWhite: Pawn  f2 => f4" +
"\nBlack: Bishop  e5 => c3" +
"\nWhite: King  e1 => f1" +
"\nBlack: Pawn  g6 => g5" +
"\nWhite: King  f1 => g1" +
"\nBlack: Pawn  g5 => f4" +
"\nWhite: Bishop  e3 => f4" +
"\nBlack: Bishop  c3 => e5" +
"\nWhite: Bishop  f4 => e5" +
"\nBlack: Queen h8 => e5" +
"\nWhite: Pawn  h2 => h4" +
"\nBlack: Queen e5 => c5" +
"\nWhite: King  g1 => f1" +
"\nBlack: Queen c5 => f5" +
"\nWhite: King  f1 => e1" +
"\nBlack: Queen f5 => d3" +
"\nWhite: Rook  d1 => d3" +
"\nBlack: Knight  c6 => b4" +
"\nWhite: Rook  d3 => a3" +
"\nBlack: Knight  b4 => c2" +
"\nWhite: King  e1 => d2" +
"\nBlack: Rook  g8 => g2" +
"\nWhite: King  d2 => c3" +
"\nBlack: Knight  c2 => a3" +
"\nWhite: Rook  h1 => c1" +
"\nBlack: Rook  g2 => a2" +
"\nWhite: King  c3 => b3" +
"\nBlack: Rook  a2 => d2" +
"\nWhite: King  b3 => a3" +
"\nBlack: Rook  d2 => d3" +
"\nWhite: King  a3 => b2" +
"\nBlack: Rook  d3 => d2" +
"\nWhite: King  b2 => a3" +
"\nBlack: Rook  d2 => d3" +
"\nWhite: King  a3 => b2");



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      

      Assert.AreNotEqual(nodeResult.BestChildPosition, "d2");
    }
    */


    /*tsiry;06-10-2021*/
    [TestMethod]
    public void T59FinDePartieEviterMortDuRoiNoir()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;b1;White;False;False;False;False"+
"\nRook;a7;White;False;False;False;False"+
"\nSimplePawn;b2;White;True;False;False;False"+
"\nSimplePawn;c2;White;True;False;False;False"+
"\nSimplePawn;d5;White;False;False;False;False";

;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;c7;Black;False;False;False;False" +
"\nRook;g2;Black;False;False;False;False" +
"\nBishop;h2;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      var isSuccess = true;
      if (randomList != null)
      {
        //  Pour tester que T59
        foreach (var item in randomList)
        {
          if (item.ToIndex == 62)
          {
            isSuccess = false;
            break;
          }
        }
      }
      Assert.IsTrue(isSuccess);
      Assert.AreNotEqual(nodeResult.BestChildPosition, "g1");
    }


    /*tsiry;12-10-2021*/
    [TestMethod]
    public void T60PourBestSpecificPosition3White()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      //Pour les SpecificPositions il faut se connecter à la base
      mainWindow.SetIsConnectedDB(true);
      mainWindow.ComputerColore = "White";

      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True" +
"\nQueen;g4;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;f1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;d2;White;False;False;False;False" +
"\nKnight;g5;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;f7;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e5;Black;False;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      Assert.AreEqual(nodeResult.BestChildPosition, "e6");
    }


    /*tsiry;12-10-2021*/
    [TestMethod]
    public void T61PourEviterBestSpecificPosition3White()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True"+
"\nQueen;g4;White;False;False;False;False"+
"\nRook;a1;White;False;False;False;False"+
"\nRook;f1;White;False;False;False;False"+
"\nKnight;b1;White;False;False;False;False"+
"\nBishop;d2;White;False;False;False;False"+
"\nKnight;g5;White;False;False;False;False"+
"\nSimplePawn;a2;White;True;False;False;False"+
"\nSimplePawn;b2;White;True;False;False;False"+
"\nSimplePawn;c2;White;True;False;False;False"+
"\nSimplePawn;d3;White;False;False;False;False"+
"\nSimplePawn;e4;White;False;False;False;False"+
"\nSimplePawn;f2;White;True;False;False;False"+
"\nSimplePawn;g2;White;True;False;False;False"+
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;False"+
"\nQueen;d8;Black;False;False;False;False"+
"\nRook;a8;Black;False;False;False;False"+
"\nRook;h8;Black;False;False;False;False"+
"\nKnight;b8;Black;False;False;False;False"+
"\nBishop;f8;Black;False;False;False;False"+
"\nKnight;f7;Black;False;False;False;False"+
"\nSimplePawn;a7;Black;True;False;False;False"+
"\nSimplePawn;b7;Black;True;False;False;False"+
"\nSimplePawn;c6;Black;False;False;False;False"+
"\nSimplePawn;d6;Black;False;False;False;False"+
"\nSimplePawn;e5;Black;False;False;False;False"+
"\nSimplePawn;g6;Black;False;False;False;False"+
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      Assert.AreNotEqual(nodeResult.BestChildPosition, "g7");
    }

    /*tsiry;12-10-2021*/
    [TestMethod]
    public void T62LePionNoirDoitAttaqueLaReineBlancEnH5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;h5;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;e2;White;False;False;False;False" +
"\nKnight;g5;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d5;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;f5;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;e4;Black;False;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");



      // var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "d5");
      // Assert.IsNull(result);
      Assert.AreEqual(nodeResult.BestChildPosition, "h5");
    }


    /*tsiry;14-10-2021*/
    [TestMethod]
    public void T65LeRookBlanchNeDoitPasSeMettreEnA6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f3;White;False;True;True;True"+
"\nQueen;d1;White;False;False;False;False"+
"\nRook;a1;White;False;False;False;False"+
"\nRook;h1;White;False;False;False;False"+
"\nKnight;b1;White;False;False;False;False"+
"\nBishop;c1;White;False;False;False;False"+
"\nBishop;f1;White;False;False;False;False"+
"\nKnight;d3;White;False;False;False;False"+
"\nSimplePawn;b2;White;True;False;False;False"+
"\nSimplePawn;c2;White;True;False;False;False"+
"\nSimplePawn;d2;White;True;False;False;False"+
"\nSimplePawn;f2;White;True;False;False;False"+
"\nSimplePawn;g2;White;True;False;False;False"+
"\nSimplePawn;h4;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;g8;Black;False;True;True;True"+
"\nQueen;d6;Black;False;False;False;False"+
"\nRook;a8;Black;False;False;False;False"+
"\nRook;e8;Black;False;False;False;False"+
"\nKnight;b8;Black;False;False;False;False"+
"\nBishop;a6;Black;False;False;False;False"+
"\nKnight;e4;Black;False;False;False;False"+
"\nSimplePawn;a7;Black;True;False;False;False"+
"\nSimplePawn;b6;Black;True;False;False;False"+
"\nSimplePawn;d7;Black;True;False;False;False"+
"\nSimplePawn;f7;Black;True;False;False;False"+
"\nSimplePawn;g7;Black;True;False;False;False"+
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      Assert.AreNotEqual(nodeResult.BestChildPosition, "a6");
    }


    /*tsiry;18-10-2021*/
    [TestMethod]
    public void T67EchecBlancLeRoiBlanchDoitBougerPourNePasPerdre()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f1;White;False;False;True;True"+
"\nQueen;c3;White;False;False;False;False"+
"\nRook;a1;White;False;False;False;False"+
"\nKnight;b1;White;False;False;False;False"+
"\nSimplePawn;a4;White;False;False;False;False"+
"\nSimplePawn;b2;White;True;False;False;False"+
"\nSimplePawn;c4;White;False;False;False;False"+
"\nSimplePawn;h4;White;False;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;c8;Black;False;True;True;False"+
"\nQueen;h2;Black;False;False;False;False"+
"\nRook;d8;Black;False;False;False;False"+
"\nRook;f4;Black;False;False;False;False"+
"\nKnight;d4;Black;False;False;False;False"+
"\nSimplePawn;a7;Black;True;False;False;False"+
"\nSimplePawn;b6;Black;False;False;False;False"+
"\nSimplePawn;c5;Black;False;False;False;False"+
"\nSimplePawn;g7;Black;True;False;False;False"+
"\nSimplePawn;h3;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      Assert.AreEqual(nodeResult.BestChildPosition, "e1");
    }

    /*tsiry;19-10-2021*/
    [TestMethod]
    public void T68LeRoiBlanchNeDoitPasSeMettreEnG6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f5;White;False;False;False;True"+
"\nRook;c5;White;False;False;False;False"+
"\nRook;h1;White;False;False;False;False"+
"\nBishop;b2;White;False;False;False;False"+
"\nBishop;f1;White;False;False;False;False"+
"\nKnight;g1;White;False;False;False;False"+
"\nSimplePawn;e2;White;True;False;False;False"+
"\nSimplePawn;g2;White;True;False;False;False"+
"\nSimplePawn;h5;White;False;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;h7;Black;False;False;False;True"+
"\nRook;e3;Black;False;False;False;False"+
"\nRook;h8;Black;False;False;False;False"+
"\nKnight;a2;Black;False;False;False;False"+
"\nSimplePawn;a7;Black;True;False;False;False"+
"\nSimplePawn;c7;Black;True;False;False;False"+
"\nSimplePawn;g7;Black;True;False;False;False"+
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      Assert.AreNotEqual(nodeResult.BestChildPosition, "g6");
    }


    /*tsiry;21-10-2021*/
    [TestMethod]
    public void T69LeRoiBanchNeDoitPasPrendreLePionEnG2()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f2;White;False;False;False;True"+
"\nRook;a1;White;False;False;False;False"+
"\nKnight;e2;White;False;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;h2;Black;False;False;False;False"+
"\nBishop;d5;Black;False;False;False;False"+
"\nSimplePawn;a2;Black;False;False;False;False"+
"\nSimplePawn;g2;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      var isSuccess = true;
      if(randomList != null)
      {
        //  Pour tester que T69
        foreach (var item in randomList)
        {
          if (item.ToIndex == 54)
          {
            isSuccess = false;
            break;
          }
        }
      }
      Assert.IsTrue(isSuccess);

      Assert.AreNotEqual(nodeResult.BestChildPosition, "g2");
    }





    /*tsiry;25-10-2021*/
    [TestMethod]
    public void T71LeRoisBlantNeDoitPasPrendreLeRookEnF5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e4;White;False;True;True;True" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;d3;White;False;False;False;False" +
"\nKnight;g4;White;False;False;False;False" +
"\nSimplePawn;b4;White;True;False;False;False" +
"\nSimplePawn;b3;White;True;False;False;False" +
"\nSimplePawn;c4;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h4;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e6;Black;False;True;True;True" +
"\nRook;d8;Black;False;False;False;False" +
"\nRook;f5;Black;False;False;False;False" +
"\nSimplePawn;a2;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;True;False;False;False" +
"\nSimplePawn;c5;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      /* var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
       var isSuccess = true;
       if (randomList != null)
       {

         foreach (var item in randomList)
         {
           if (item.ToIndex == 54)
           {
             isSuccess = false;
             break;
           }
         }
       }
       Assert.IsTrue(isSuccess);
       */
      Assert.AreNotEqual(nodeResult.BestChildPosition, "f5");
    }

    /*tsiry;25-10-2021*/
    [TestMethod]
    public void T72LaReineNoirDoitPrendreLePionEnD5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;d5;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;


      var isSuccess = false;
      if (randomList == null || randomList.Count == 1)
        isSuccess = true;
      Assert.IsTrue(isSuccess);

      Assert.AreEqual(nodeResult.BestChildPosition, "d5");
    }

    /*tsiry;25-10-2021*/
    [TestMethod]
    public void T72BLaReineNoirDoitPrendreLePionEnD5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;d4;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      var isSuccess = false;
      if (randomList == null || randomList.Count == 1)
        isSuccess = true;
      Assert.IsTrue(isSuccess);

      Assert.AreEqual(nodeResult.BestChildPosition, "d4");
    }


    /*tsiry;25-10-2021*/
    [TestMethod]
    public void T73LeFouNoirNeDoitPasPrendreLePionEnB2()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;c1;White;False;True;True;True" +
"\nKnight;e8;White;False;False;False;False" +
"\nSimplePawn;a4;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c6;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;f4;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;h8;Black;False;True;True;True" +
"\nBishop;d4;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;True;False;False;False" +
"\nSimplePawn;h4;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);

      Assert.AreNotEqual(nodeResult.BestChildPosition, "b2");
    }

    /*tsiry;28-10-2021*/
    [TestMethod]
    public void T74LesBlanchsDoiventPrendreLePionEnD4()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True"+
"\nQueen;d1;White;False;False;False;False"+
"\nRook;a1;White;False;False;False;False"+
"\nRook;h1;White;False;False;False;False"+
"\nKnight;b1;White;False;False;False;False"+
"\nBishop;c1;White;False;False;False;False"+
"\nBishop;f1;White;False;False;False;False"+
"\nKnight;g1;White;False;False;False;False"+
"\nSimplePawn;a2;White;True;False;False;False"+
"\nSimplePawn;b2;White;True;False;False;False"+
"\nSimplePawn;c3;White;True;False;False;False"+
"\nSimplePawn;e2;White;True;False;False;False"+
"\nSimplePawn;f2;White;True;False;False;False"+
"\nSimplePawn;g2;White;True;False;False;False"+
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True"+
"\nQueen;d8;Black;False;False;False;False"+
"\nRook;a8;Black;False;False;False;False"+
"\nRook;h8;Black;False;False;False;False"+
"\nKnight;b8;Black;False;False;False;False"+
"\nBishop;c8;Black;False;False;False;False"+
"\nBishop;f8;Black;False;False;False;False"+
"\nKnight;g8;Black;False;False;False;False"+
"\nSimplePawn;a7;Black;True;False;False;False"+
"\nSimplePawn;b7;Black;True;False;False;False"+
"\nSimplePawn;c7;Black;True;False;False;False"+
"\nSimplePawn;d7;Black;True;False;False;False"+
"\nSimplePawn;d4;Black;True;False;False;False"+
"\nSimplePawn;f7;Black;True;False;False;False"+
"\nSimplePawn;g7;Black;True;False;False;False"+
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      Assert.IsNull(randomList);

      Assert.AreEqual(nodeResult.BestChildPosition, "d4");
    }

    /*tsiry;28-10-2021*/
    [TestMethod]
    public void T78ProtectionDuRookNoir()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;c2;White;False;True;True;True"+
"\nQueen;a7;White;False;False;False;False"+
"\nRook;a2;White;False;False;False;False"+
"\nRook;h1;White;False;False;False;False"+
"\nKnight;a3;White;False;False;False;False"+
"\nBishop;c1;White;False;False;False;False"+
"\nBishop;f1;White;False;False;False;False"+
"\nSimplePawn;a4;White;True;False;False;False"+
"\nSimplePawn;c5;White;True;False;False;False"+
"\nSimplePawn;d2;White;True;False;False;False"+
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True"+
"\nQueen;d4;Black;False;False;False;False"+
"\nRook;d8;Black;False;False;False;False"+
"\nRook;h8;Black;False;False;False;False"+
"\nBishop;e6;Black;False;False;False;False"+
"\nKnight;e7;Black;False;False;False;False"+
"\nSimplePawn;c6;Black;True;False;False;False"+
"\nSimplePawn;f2;Black;True;False;False;False"+
"\nSimplePawn;f7;Black;True;False;False;False"+
"\nSimplePawn;g5;Black;True;False;False;False"+
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

     // var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
    //  Assert.IsNull(randomList);

      Assert.AreEqual(nodeResult.BestChildPosition, "b2");
    }


    /*tsiry;28-10-2021*/
    [TestMethod]
    public void T79LeRoisBlanchDoitSeMettreEnG1()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f1;White;False;True;True;True"+
"\nRook;g3;White;False;False;False;False"+
"\nBishop;a2;White;False;False;False;False"+
"\nSimplePawn;f2;White;True;False;False;False"+
"\nSimplePawn;g4;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True"+
"\nRook;h2;Black;False;False;False;False"+
"\nBishop;a6;Black;False;False;False;False"+
"\nBishop;a5;Black;False;False;False;False"+
"\nSimplePawn;a7;Black;True;False;False;False"+
"\nSimplePawn;d4;Black;True;False;False;False"+
"\nSimplePawn;f7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        Assert.IsNull(randomList);

      Assert.AreEqual(nodeResult.BestChildPosition, "g1");
    }


    /*tsiry;12-11-2021*/
    [TestMethod]
    public void T80LeRoiNoirDoitBougerEtLaReineNoirNeDoitPasSeMettreEn()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g3;White;False;True;True;True"+
"\nQueen;g8;White;False;False;False;False"+
"\nRook;a1;White;False;False;False;False"+
"\nKnight;b1;White;False;False;False;False"+
"\nBishop;c3;White;False;False;False;False"+
"\nBishop;f1;White;False;False;False;False"+
"\nSimplePawn;a2;White;True;False;False;False"+
"\nSimplePawn;g5;White;True;False;False;False"+
"\nSimplePawn;c4;White;True;False;False;False"+
"\nSimplePawn;d3;White;True;False;False;False"+
"\nSimplePawn;e4;White;True;False;False;False"+
"\nSimplePawn;f2;White;True;False;False;False"+
"\nSimplePawn;g2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;d8;Black;False;True;True;True"+
"\nQueen;d1;Black;False;False;False;False"+
"\nRook;a8;Black;False;False;False;False"+
"\nRook;h4;Black;False;False;False;False"+
"\nKnight;b8;Black;False;False;False;False"+
"\nBishop;c8;Black;False;False;False;False"+
"\nSimplePawn;a7;Black;True;False;False;False"+
"\nSimplePawn;b7;Black;True;False;False;False"+
"\nSimplePawn;c5;Black;True;False;False;False"+
"\nSimplePawn;d7;Black;True;False;False;False"+
"\nSimplePawn;e7;Black;True;False;False;False"+
"\nSimplePawn;g6;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      Assert.IsNull(randomList);

      Assert.AreEqual(nodeResult.BestChildPosition, "c7");
    }


    /*tsiry;12-11-2021*/
    [TestMethod]
    public void T81LeCavalierBlanchNeDoitPasPrendreLaReinEtLesBlanchDoiventEviterLEchec()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True"+
"\nQueen;c1;White;False;False;False;False"+
"\nRook;a1;White;False;False;False;False"+
"\nRook;h1;White;False;False;False;False"+
"\nKnight;e4;White;False;False;False;False"+
"\nBishop;f1;White;False;False;False;False"+
"\nKnight;g1;White;False;False;False;False"+
"\nSimplePawn;a2;White;True;False;False;False"+
"\nSimplePawn;b2;White;True;False;False;False"+
"\nSimplePawn;d3;White;True;False;False;False"+
"\nSimplePawn;e2;White;True;False;False;False"+
"\nSimplePawn;f3;White;True;False;False;False"+
"\nSimplePawn;g2;White;True;False;False;False"+
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;g8;Black;False;True;True;True"+
"\nQueen;f6;Black;False;False;False;False"+
"\nRook;a8;Black;False;False;False;False"+
"\nRook;e8;Black;False;False;False;False"+
"\nKnight;c6;Black;False;False;False;False"+
"\nBishop;c8;Black;False;False;False;False"+
"\nBishop;b4;Black;False;False;False;False"+
"\nSimplePawn;a7;Black;True;False;False;False"+
"\nSimplePawn;b7;Black;True;False;False;False"+
"\nSimplePawn;c7;Black;True;False;False;False"+
"\nSimplePawn;d4;Black;True;False;False;False"+
"\nSimplePawn;f7;Black;True;False;False;False"+
"\nSimplePawn;g7;Black;True;False;False;False"+
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      Assert.IsNotNull(randomList);

      Assert.AreNotEqual(nodeResult.BestChildPosition, "f6");
    }


    [TestMethod]
    public void T82Null2LesNoirDoiventEviterLeNull()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;c5;White;False;False;True;True";

      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;f7;Black;False;False;True;True"+
"\nQueen;f1;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      //ajout des movements
      if (Chess2Console.Utils.MovingList == null)
        Chess2Console.Utils.MovingList = new List<string>();
      Chess2Console.Utils.MovingList.Add("5(K|B)>13(__)");
      Chess2Console.Utils.MovingList.Add("33(K|W)>34(__)");

      Chess2Console.Utils.MovingList.Add("53(Q|B)>61(__)");
      Chess2Console.Utils.MovingList.Add("34(K|W)>26(__)");
      Chess2Console.Utils.MovingList.Add("61(Q|B)>53(__)");
      Chess2Console.Utils.MovingList.Add("26(K|W)>34(__)");
      Chess2Console.Utils.MovingList.Add("53(Q|B)>61(__)");
      Chess2Console.Utils.MovingList.Add("34(K|W)>26(__)");

      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      var notValide = randomList.FirstOrDefault(x => x.FromIndex == 61 && x.ToIndex == 53);
      Assert.IsNull(notValide);

     // Assert.AreNotEqual(nodeResult.BestChildPosition, "f6");
    }

    /*tsiry;12-11-2021*/
    [TestMethod]
    public void T84EchecEtMatNoir()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True"+
"\nQueen;d8;White;False;False;False;False"+
"\nRook;f1;White;False;False;False;False"+
"\nBishop;e3;White;False;False;False;False"+
"\nBishop;c4;White;False;False;False;False"+
"\nSimplePawn;h2;White;True;False;False;False"+
"\nSimplePawn;g2;White;True;False;False;False"+
"\nSimplePawn;f2;White;True;False;False;False"+
"\nSimplePawn;e4;White;True;False;False;False"+
"\nSimplePawn;a3;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;f8;Black;False;True;True;True"+
"\nRook;c7;Black;False;False;False;False"+
"\nRook;h8;Black;False;False;False;False"+
"\nKnight;a6;Black;False;False;False;False"+
"\nBishop;c3;Black;False;False;False;False"+
"\nSimplePawn;h7;Black;True;False;False;False"+
"\nSimplePawn;g7;Black;True;False;False;False"+
"\nSimplePawn;c6;Black;True;False;False;False"+
"\nSimplePawn;a7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition
      Assert.AreEqual(nodeResult.Location, nodeResult.BestChildPosition);
    }


    [TestMethod]
    public void T84BEchecEtMatNoir()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True" +
"\nQueen;d8;White;False;False;False;False" +
"\nRook;f1;White;False;False;False;False" +
"\nBishop;e3;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;e4;White;True;False;False;False" +
"\nSimplePawn;a3;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;f8;Black;False;True;True;True" +
"\nRook;c7;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;a6;Black;False;False;False;False" +
"\nBishop;c3;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;c6;Black;True;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition
      Assert.AreEqual(nodeResult.Location, nodeResult.BestChildPosition);
    }


    /*tsiry;16-12-2021*/
    [TestMethod]
    public void T85LaToureNoirDoitPrendreLePionEnA5()
    {


      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      var testName = "T85LaToureNoirDoitPrendreLePionEnA5";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition
      Assert.AreEqual(nodeResult.BestChildPosition, "a5");
    }


    /*tsiry;28-10-2021*/
    /*[TestMethod]
    public void T75LeCavalierNoirDoitPrendreLePionEnB5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True"+
"\nQueen;f3;White;False;False;False;False"+
"\nRook;a1;White;False;False;False;False"+
"\nRook;d1;White;False;False;False;False"+
"\nKnight;e2;White;False;False;False;False"+
"\nBishop;c1;White;False;False;False;False"+
"\nKnight;e5;White;False;False;False;False"+
"\nSimplePawn;b5;White;True;False;False;False"+
"\nSimplePawn;c2;White;True;False;False;False"+
"\nSimplePawn;d5;White;True;False;False;False"+
"\nSimplePawn;f2;White;True;False;False;False"+
"\nSimplePawn;g3;White;True;False;False;False"+
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True"+
"\nQueen;d8;Black;False;False;False;False"+
"\nRook;a8;Black;False;False;False;False"+
"\nRook;h8;Black;False;False;False;False"+
"\nBishop;b7;Black;False;False;False;False"+
"\nBishop;f8;Black;False;False;False;False"+
"\nKnight;d6;Black;False;False;False;False"+
"\nSimplePawn;a7;Black;True;False;False;False"+
"\nSimplePawn;c7;Black;True;False;False;False"+
"\nSimplePawn;d7;Black;True;False;False;False"+
"\nSimplePawn;e7;Black;True;False;False;False"+
"\nSimplePawn;f7;Black;True;False;False;False"+
"\nSimplePawn;g7;Black;True;False;False;False"+
"\nSimplePawn;h6;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);

      Assert.AreEqual(nodeResult.BestChildPosition, "b5");
    }

    [TestMethod]
    public void T76LeCavalierNoirEnD6DoitBouger()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True"+
"\nQueen;f3;White;False;False;False;False"+
"\nRook;a1;White;False;False;False;False"+
"\nRook;d1;White;False;False;False;False"+
"\nKnight;e2;White;False;False;False;False"+
"\nBishop;c1;White;False;False;False;False"+
"\nKnight;e5;White;False;False;False;False"+
"\nSimplePawn;b5;White;True;False;False;False"+
"\nSimplePawn;c5;White;True;False;False;False"+
"\nSimplePawn;d5;White;True;False;False;False"+
"\nSimplePawn;f2;White;True;False;False;False"+
"\nSimplePawn;g3;White;True;False;False;False"+
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True"+
"\nQueen;d8;Black;False;False;False;False"+
"\nRook;a8;Black;False;False;False;False"+
"\nRook;h8;Black;False;False;False;False"+
"\nBishop;b7;Black;False;False;False;False"+
"\nBishop;f8;Black;False;False;False;False"+
"\nKnight;d6;Black;False;False;False;False"+
"\nSimplePawn;a7;Black;True;False;False;False"+
"\nSimplePawn;c7;Black;True;False;False;False"+
"\nSimplePawn;d7;Black;True;False;False;False"+
"\nSimplePawn;e7;Black;True;False;False;False"+
"\nSimplePawn;f7;Black;True;False;False;False"+
"\nSimplePawn;g7;Black;True;False;False;False"+
"\nSimplePawn;h6;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

      var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);

      Assert.AreEqual(nodeResult.Location, "d6");
    }
    */

    /*  [TestMethod]
      public void T3300aLePionBlancNeDoitPasPrendreLeCavalier()
      {
        //Le pion blanch ne doit pas prendre le cavalier en d4



        var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
        mainWindow.ComputerColore = "White";
        
         
        
        mainWindow.CleanPawnList();
        var pawnListWhite = new List<Pawn>();
        var pawnListBlack = new List<Pawn>();



        //WHITEList
        var whiteListString = "" +
         "Rook;h1;White;False;False;False;False" +
         "\nKnight;g3;White;False;False;False;False" +
  "\nKnight;g1;White;False;False;False;False" +
  "\nSimplePawn;h2;White;True;False;False;False"+
  "\nSimplePawn;e3;White;False;False;False;False";
        var whiteList = whiteListString.Split('\n');
        foreach (var line in whiteList)
        {
          var datas = line.Split(';');
          var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnListWhite.Add(newPawn);
        }

        //BLACKList
        var blackListString = "" +
  "Bishop;b7;Black;False;False;False;False" +
  "\nKnight;d4;Black;False;False;False;False";
        var blackList = blackListString.Split('\n');
        foreach (var line in blackList)
        {
          var datas = line.Split(';');
          var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnListBlack.Add(newPawn);
        }



        mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


        var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
        //Le poin doit pas se mettre en e3
        Assert.AreEqual(nodeResult.BestChildPosition, "e4");


      }


      [TestMethod]
      public void T3300bLePionBlancDoitPrendreLeCavalier()
      {
        //Le pion blanch  doit prendre le cavalier en d4



        var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
        mainWindow.ComputerColore = "White";
        
         
        
        mainWindow.CleanPawnList();
        var pawnListWhite = new List<Pawn>();
        var pawnListBlack = new List<Pawn>();



        //WHITEList
        var whiteListString = "" +
  "Knight;g1;White;False;False;False;False" +
  "\nSimplePawn;e3;White;False;False;False;False";
        var whiteList = whiteListString.Split('\n');
        foreach (var line in whiteList)
        {
          var datas = line.Split(';');
          var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnListWhite.Add(newPawn);
        }

        //BLACKList
        var blackListString = "" +
  "Knight;d4;Black;False;False;False;False" +
  "\nSimplePawn;b7;Black;True;False;False;False";
        var blackList = blackListString.Split('\n');
        foreach (var line in blackList)
        {
          var datas = line.Split(';');
          var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnListBlack.Add(newPawn);
        }



        mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


        var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
        //Le poin doit  se mettre en d4
        Assert.AreEqual(nodeResult.BestChildPosition, "d4");


      }

      */

    //    [TestMethod]
    //    public void T33aLePionBlancNeDoitPasPrendreLeCavalier()
    //    {
    //      /*Le pion blanch ne doit pas prendre le cavalier en d4*/



    //      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
    //      mainWindow.ComputerColore = "White";


    //      
    //       
    //      
    //      mainWindow.CleanPawnList();
    //      var pawnListWhite = new List<Pawn>();
    //      var pawnListBlack = new List<Pawn>();



    //      //WHITEList
    //      var whiteListString = "" +
    //       "King;e1;White;False;True;True;True" +
    //"\nQueen;d1;White;False;False;False;False" +
    //"\nRook;a1;White;False;False;False;False" +
    //"\nRook;h1;White;False;False;False;False" +
    //"\nBishop;c1;White;False;False;False;False" +
    //"\nKnight;g3;White;False;False;False;False" +
    //"\nKnight;g1;White;False;False;False;False" +
    //"\nSimplePawn;a4;White;False;False;False;False" +
    //"\nSimplePawn;b2;White;True;False;False;False" +
    //"\nSimplePawn;c2;White;True;False;False;False" +
    //"\nSimplePawn;d2;White;True;False;False;False" +
    //"\nSimplePawn;e3;White;False;False;False;False" +
    //"\nSimplePawn;f4;White;False;False;False;False" +
    //"\nSimplePawn;h2;White;False;False;False;False" +
    //"\nSimplePawn;g4;White;True;False;False;False";
    //      var whiteList = whiteListString.Split('\n');
    //      foreach (var line in whiteList)
    //      {
    //        var datas = line.Split(';');
    //        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
    //        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
    //        newPawn.IsFirstMove = bool.Parse(datas[3]);
    //        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
    //        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
    //        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
    //        pawnListWhite.Add(newPawn);
    //      }

    //      //BLACKList
    //      var blackListString = "" +
    //"King;e8;Black;False;True;True;True" +
    //"\nQueen;a5;Black;False;False;False;False" +
    //"\nRook;a8;Black;False;False;False;False" +
    //"\nRook;h8;Black;False;False;False;False" +
    //"\nBishop;b7;Black;False;False;False;False" +
    //"\nBishop;f8;Black;False;False;False;False" +
    //"\nKnight;d4;Black;False;False;False;False" +
    //"\nKnight;g8;Black;False;False;False;False" +
    //"\nSimplePawn;a7;Black;True;False;False;False" +
    //"\nSimplePawn;b4;Black;False;False;False;False" +
    //"\nSimplePawn;c5;Black;False;False;False;False" +
    //"\nSimplePawn;d7;Black;True;False;False;False" +
    //"\nSimplePawn;e7;Black;True;False;False;False" +
    //"\nSimplePawn;f7;Black;True;False;False;False" +
    //"\nSimplePawn;g7;Black;True;False;False;False" +
    //"\nSimplePawn;h7;Black;True;False;False;False";
    //      var blackList = blackListString.Split('\n');
    //      foreach (var line in blackList)
    //      {
    //        var datas = line.Split(';');
    //        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
    //        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
    //        newPawn.IsFirstMove = bool.Parse(datas[3]);
    //        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
    //        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
    //        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
    //        pawnListBlack.Add(newPawn);
    //      }



    //      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


    //      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
    //      //Le poin doit pas se mettre en e3
    //      Assert.AreEqual(nodeResult.BestChildPosition, "e4");


    //    }
    //    [TestMethod]
    public void T33bLePionBlancDoitPrendreLeCavalier()
    {
      /*Le pion blanch prendre le cavalier en d4*/



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";


      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
       "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;b3;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;g4;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;a5;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;d4;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b4;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
      //Le poin doit pas se mettre en d4
      Assert.AreEqual(nodeResult.BestChildPosition, "d4");


    }



  }


  [TestClass]
  public class ChessIATestMultithreading
  {
    private string testsDirrectory = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.Combine(Environment.CurrentDirectory)).ToString()).ToString()).ToString(), "TESTS");

    [TestMethod]
    public void  MTT00aLeKnigntBlanchNeDoitPasAttaquer()
    {
      /*La cavalier blanch ne doit pas attaquer*/
      //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7" 


     

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "Rook;a1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nKnight;b5;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nQueen;d1;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nKing;e1;White;False;True;True;True" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
      "SimplePawn;a7;Black;True;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nKing;e8;Black;False;True;True;True" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nBishop;b4;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nRook;h8;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7"
        Assert.AreNotEqual(nodeResult.BestChildPosition, "a7", "c7");
      }
    }


    [TestMethod]
    public void  MTT00aMultithreadingLeKnigntBlanchNeDoitPasAttaquer()
    {
      /*La cavalier blanch ne doit pas attaquer*/
      //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7" 

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "Rook;a1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nKnight;b5;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nQueen;d1;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nKing;e1;White;False;True;True;True" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
      "SimplePawn;a7;Black;True;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nKing;e8;Black;False;True;True;True" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nBishop;b4;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nRook;h8;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        // var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7"
        Assert.AreNotEqual(nodeResult.BestChildPosition, "a7", "c7");
      }
    }


    [TestMethod]
    public void  MTT00bLeKnigntNoirNeDoitPasAttaquer()
    {
      /*La cavalier noit ne doit pas attaquer*/
      //Positions final du cavalier noir ne doit pas etre  ni "a2" ni "c2" 

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "Rook;a1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nKnight;b5;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nQueen;d1;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nKing;e1;White;False;True;True;True" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
      "SimplePawn;a7;Black;True;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nKing;e8;Black;False;True;True;True" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nBishop;b4;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nRook;h8;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {

        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //Positions final du cavalier noir ne doit pas etre  ni "a2" ni "c2" 
        Assert.AreNotEqual(nodeResult.BestChildPosition, "a2", "c2");
      }
    }
    [TestMethod]
    public void  MTT00bMultithreadingLeKnigntNoirNeDoitPasAttaquer()
    {
      /*La cavalier noit ne doit pas attaquer*/
      //Positions final du cavalier noir ne doit pas etre  ni "a2" ni "c2" 

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "Rook;a1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nKnight;b5;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nQueen;d1;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nKing;e1;White;False;True;True;True" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
      "SimplePawn;a7;Black;True;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nKing;e8;Black;False;True;True;True" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nBishop;b4;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nRook;h8;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //Positions final du cavalier noir ne doit pas etre  ni "a2" ni "c2" 
        Assert.AreNotEqual(nodeResult.BestChildPosition, "a2", "c2");
      }
    }



    [TestMethod]
    public void  MTT01QuenLaReineNoirNeDoitPasPrendreLeCavalier()
    {
      /*La reine noir ne doit pas prendre le cavalier*/
      //Position final de la reine Noir ne doit pas etre "g5"

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "King;g1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;f1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g5;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;b3;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b5;Black;False;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d5;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h4;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //Position final de la reine Noir ne doit pas etre "g5"
        Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");
      }
    }


    [TestMethod]
    public void  MTT02aLeRookBlanchNeDoitPasPrendresLePion()
    {
      /*Le Rook blanc ne doit pas prendre le pion*/
      //Position final du Rook blanch  ne doit pas etre "a7"

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nRook;a1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;c4;White;False;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nQueen;h1;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
       "King;d8;Black;False;True;True;True" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;f5;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nQueen;a8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //Position final du rook blanch  ne doit pas etre "a7"
        Assert.AreNotEqual(nodeResult.BestChildPosition, "a7");
      }
    }

    [TestMethod]
    public void  MTT02aMultithreadingLeRookBlanchNeDoitPasPrendresLePion()
    {
      /*Le Rook blanc ne doit pas prendre le pion*/
      //Position final du Rook blanch  ne doit pas etre "a7"

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nRook;a1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;c4;White;False;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nQueen;h1;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
       "King;d8;Black;False;True;True;True" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;f5;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nQueen;a8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //Position final du rook blanch  ne doit pas etre "a7"
        Assert.AreNotEqual(nodeResult.BestChildPosition, "a7");
      }
    }

    [TestMethod]
    public void  MTT02bMultithreadingLeRookNoirNeDoitPasPrendresLePion()
    {
      /*Le Rook noir ne doit pas prendre le pion*/
      //Position final du Rook blanch  ne doit pas etre "h2"

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nRook;a1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;c4;White;False;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nQueen;h1;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
       "King;d8;Black;False;True;True;True" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;f5;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nQueen;a8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //Position final du rook blanch  ne doit pas etre "a7"
        Assert.AreNotEqual(nodeResult.BestChildPosition, "h2");
      }
    }


    /*
        [TestMethod]
        public void  MTT04LePionBlanchNeDoitPasprendreLeRookNoir()
        {


          var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
          mainWindow.ComputerColore = "White";




          mainWindow.CleanPawnList();
          var pawnListWhite = new List<Pawn>();
          var pawnListBlack = new List<Pawn>();


          //WHITEList
          var whiteListString = "" +
            "King;f2;White;False;False;True;False" +
            "\nQueen;d1;White;False;False;False;False" +
    "\nRook;a1;White;False;False;False;False" +
    "\nRook;h2;White;False;False;False;False" +
    "\nBishop;c1;White;False;False;False;False" +
    "\nBishop;f1;White;False;False;False;False" +
    "\nKnight;g1;White;False;False;False;False" +
    "\nSimplePawn;a2;White;True;False;False;False" +
    "\nSimplePawn;b2;White;True;False;False;False" +
    "\nSimplePawn;c2;White;True;False;False;False" +
    "\nSimplePawn;d3;White;False;False;False;False" +
    "\nSimplePawn;e3;White;False;False;False;False" +
    "\nSimplePawn;f4;White;False;False;False;False" +
    "\nSimplePawn;g3;White;False;False;False;False" +
    "\nSimplePawn;h4;White;False;False;False;False";
          var whiteList = whiteListString.Split('\n');
          foreach (var line in whiteList)
          {
            var datas = line.Split(';');
            var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnListWhite.Add(newPawn);
          }

          //BLACKList
          var blackListString = "" +
           "King;e8;Black;False;True;False;True" +
    "\nQueen;d8;Black;False;False;False;False" +
    "\nRook;a3;Black;False;False;False;False" +
    "\nRook;h8;Black;False;False;False;False" +
    "\nBishop;b7;Black;False;False;False;False" +
    "\nBishop;g7;Black;False;False;False;False" +
    "\nKnight;b8;Black;False;False;False;False" +
    "\nKnight;h6;Black;False;False;False;False" +
    "\nSimplePawn;b6;Black;False;False;False;False" +
    "\nSimplePawn;c7;Black;True;False;False;False" +
    "\nSimplePawn;d5;Black;False;False;False;False" +
    "\nSimplePawn;e7;Black;True;False;False;False" +
    "\nSimplePawn;f7;Black;True;False;False;False" +
    "\nSimplePawn;g6;Black;False;False;False;False" +
    "\nSimplePawn;h7;Black;True;False;False;False";
          var blackList = blackListString.Split('\n');
          foreach (var line in blackList)
          {
            var datas = line.Split(';');
            var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnListBlack.Add(newPawn);
          }


          mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


          var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
          //Position final du pion blanch  ne doit pas etre "a3"
          Assert.AreNotEqual(nodeResult.BestChildPosition, "a3");

        }
    */
    [TestMethod]
    public void  MTT05LeFousBlacheDoitSeSaccrifierPourProtegerLeRook()
    {
      /*Le Fous blanc doit attaquer le pion noir
       * les noirs*/
      //Position final du Fous blanch  doit etre "a7"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "Rook;a1;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;e3;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nQueen;d1;White;False;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nKing;e1;White;False;True;True;True" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
       "SimplePawn;a7;Black;True;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nQueen;b2;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nKing;e8;Black;False;True;True;True" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nBishop;d6;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nRook;h8;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        Assert.AreNotEqual(nodeResult.BestChildPosition, "c4");
      }
    }



    [TestMethod]
    public void  MTT07aEchecRookBlancDoitAttaquerLeRoiNoir()
    {
      /*Le Rook blanc doit attaquer le roir noir pout  MTTout de suite mettre en echec 
       * les noirs*/
      //Position final du rook blanch  doit etre "d8"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "King;h4;White;False;False;False;True" +
"\nQueen;e1;White;False;False;False;False" +
"\nRook;d5;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a3;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;g4;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "King;g8;Black;False;False;False;False" +
        "\nQueen;g6;Black;False;False;False;False" +
"\nRook;c6;Black;False;False;False;False" +
"\nKnight;a7;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        Assert.AreEqual(nodeResult.AsssociateNodeChess2.RandomEquivalentList.Count, 0);
        //rook blanch  doit etre "d8"
        // Assert.AreEqual(nodeResult.AssociatePawn.Name, "Rook");
        Assert.AreEqual(nodeResult.BestChildPosition, "d8");
      }
    }


    [TestMethod]
    public void  MTT07bEchecRookOuReineBlancDoitAttaquerLeRoiNoir()
    {
      /*Le Rook ou la reinne blanc doit attaquer le roir noir pout  MTTout de suite mettre en echec 
       * les noirs*/
      //Position final  blanche  doit etre "d8" ou "e8"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "King;h4;White;False;False;False;True" +
"\nQueen;e1;White;False;False;False;False" +
"\nRook;d5;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "King;g8;Black;False;True;False;True" +
        "\nQueen;g6;Black;False;False;False;False" +
"\nRook;c6;Black;False;False;False;False" +
"\nKnight;a7;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //Position final blanche  doit etre "d8" ou "e8"
        //Assert.AreEqual(nodeResult.AssociatePawn.Name, "Rook");
        Assert.AreEqual(nodeResult.AsssociateNodeChess2.RandomEquivalentList.Count, 0);

        var isSucces = false;
        if (nodeResult.BestChildPosition == "d8" || nodeResult.BestChildPosition == "e8")
          isSucces = true;
        Assert.IsTrue(isSucces);
      }
    }


    [TestMethod]
    public void  MTT11LaReineBlancNeDoitPasAttaqueLePion()
    {
      /*La reine blanc ne doit pas attaquer le pion noir en g6*/
      //la reine blanche ne doit se mettre sur "g6"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "Rook;a1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nQueen;c2;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nKing;e1;White;False;True;True;True" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nSimplePawn; h2; White;  true; False; False; False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "SimplePawn;a7;Black;True;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nKing;e8;Black;False;True;True;True" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nRook;h8;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //la reine blanche ne doit se mettre sur "g6"
        Assert.AreNotEqual(nodeResult.BestChildPosition, "g6");
      }
    }


    [TestMethod]
    public void  MTT15LaReineBlanchNeDoitPasPrendreLePion()
    {
      /*La reine blanc ne doit pas attaquer le pion noir en a6*/
      ////la reine blanche ne doit se mettre sur "a6"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "SimplePawn;a2;White;True;False;False;False" +
        "\nSimplePawn;a3;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nBishop;b2;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nQueen;a4;White;False;False;False;False" +
"\nKing;e2;White;False;False;True;True";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "SimplePawn;a6;Black;False;False;False;False" +
        "\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d5;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;f8;Black;False;False;False;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nKing;g8;Black;False;True;True;True";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //la reine blanche ne doit se mettre sur "a6"
        Assert.AreNotEqual(nodeResult.BestChildPosition, "a6");
      }
    }

    [TestMethod]
    public void  MTT16SeulLePionDoitProtegerLeRoiNoir()
    {
      /*seul le poin doit protéger le roi noir*/
      ////le poin noir doit se mettre sur "f6"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;g5;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e7;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        ////le poin noir  doit se mettre sur "f6"
        //Assert.AreEqual(nodeResult.AssociatePawn.Name, "SimplePawn");
        Assert.AreEqual(nodeResult.BestChildPosition, "f6");
      }
    }


    [TestMethod]
    public void  MTT17LeRoirNoirNeDoitPasAttaquer()
    {
      /*le roi noir ne doit pas attaquer */
      ////le roi noir ne doit pas se mettre sur "f6"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;f6;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e7;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        ////le roi noir ne doit pas se mettre sur "f6"
        //Assert.AreNotEqual(nodeResult.AssociatePawn.Name, "King");
        Assert.AreNotEqual(nodeResult.BestChildPosition, "f6");
      }
    }

    [TestMethod]
    public void  MTT18suiteDe16LeCavalierNoirDoitPrendreLeFouBlanc()
    {
      /*le cavalier noir  doit  attaquer */
      ////le cavalier noir  doit se mettre sur "f6"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;f6;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e7;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        ////le cavalier noir  doit se mettre sur "f6"
        //Assert.AreEqual(nodeResult.AssociatePawn.Name, "Knight");
        Assert.AreEqual(nodeResult.BestChildPosition, "f6");
      }
    }

    /*  [TestMethod]
      public void  MTT19aLeBishopBlanchDoitMenacerLeRoiNoir()
      {

        ////le Bishop blanch doit se mettre sur "b5"




        var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
        mainWindow.ComputerColore = "White";
        
         
        
        mainWindow.CleanPawnList();
        var pawnListWhite = new List<Pawn>();
        var pawnListBlack = new List<Pawn>();



        //WHITEList
        var whiteListString = "" +
          "King;e1;White;False;True;True;True"+
  "\nQueen;d1;White;False;False;False;False"+
  "\nRook;a1;White;False;False;False;False"+
  "\nRook;h1;White;False;False;False;False"+
  "\nBishop;c1;White;False;False;False;False"+
  "\nBishop;f1;White;False;False;False;False"+
  "\nKnight;b1;White;False;False;False;False"+
  "\nKnight;g1;White;False;False;False;False"+
  "\nSimplePawn;a2;White;True;False;False;False"+
  "\nSimplePawn;b3;White;False;False;False;False"+
  "\nSimplePawn;c2;White;True;False;False;False"+
  "\nSimplePawn;d2;White;True;False;False;False"+
  "\nSimplePawn;e3;White;False;False;False;False"+
  "\nSimplePawn;f3;White;False;False;False;False"+
  "\nSimplePawn;g2;White;True;False;False;False"+
  "\nSimplePawn;h3;White;False;False;False;False";
        var whiteList = whiteListString.Split('\n');
        foreach (var line in whiteList)
        {
          var datas = line.Split(';');
          var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnListWhite.Add(newPawn);
        }

        //BLACKList
        var blackListString = "" +
          "King;e8;Black;False;True;True;True"+
  "\nQueen;d6;Black;False;False;False;False"+
  "\nRook;a8;Black;False;False;False;False"+
  "\nRook;h8;Black;False;False;False;False"+
  "\nBishop;c8;Black;False;False;False;False"+
  "\nBishop;g7;Black;False;False;False;False"+
  "\nKnight;b8;Black;False;False;False;False"+
  "\nKnight;g8;Black;False;False;False;False"+
  "\nSimplePawn;a7;Black;True;False;False;False"+
  "\nSimplePawn;b7;Black;True;False;False;False"+
  "\nSimplePawn;c7;Black;True;False;False;False"+
  "\nSimplePawn;d5;Black;False;False;False;False"+
  "\nSimplePawn;e7;Black;True;False;False;False"+
  "\nSimplePawn;f7;Black;True;False;False;False"+
  "\nSimplePawn;g5;Black;False;False;False;False"+
  "\nSimplePawn;h7;Black;True;False;False;False";
        var blackList = blackListString.Split('\n');
        foreach (var line in blackList)
        {
          var datas = line.Split(';');
          var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnListBlack.Add(newPawn);
        }



        mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        ////le cavalier noir  doit se mettre sur "f6"
        Assert.AreEqual(nodeResult.AssociatePawn.Name, "Bishop");
        Assert.AreEqual(nodeResult.BestChildPosition, "b5");
      }

      */
    /*   [TestMethod]
       public void  MTT19aLeBishopBlanchDoitNenacerleRoir()
       {
         //le Bishop blanch doit menacer le roi 
         ////le bishop blanch doit se mettre sur "b5"




         var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
         mainWindow.ComputerColore = "White";
         
          
         
         mainWindow.CleanPawnList();
         var pawnListWhite = new List<Pawn>();
         var pawnListBlack = new List<Pawn>();



         //WHITEList
         var whiteListString = "" +
   "King;e1;White;False;True;True;True"+
   "\nQueen;d1;White;False;False;False;False"+
   "\nRook;a1;White;False;False;False;False"+
   "\nRook;h1;White;False;False;False;False"+
   "\nBishop;c1;White;False;False;False;False"+
   "\nBishop;f1;White;False;False;False;False"+
   "\nKnight;b1;White;False;False;False;False"+
   "\nKnight;g1;White;False;False;False;False"+
   "\nSimplePawn;a2;White;True;False;False;False"+
   "\nSimplePawn;b3;White;False;False;False;False"+
   "\nSimplePawn;c3;White;True;False;False;False"+
   "\nSimplePawn;d2;White;True;False;False;False"+
   "\nSimplePawn;e3;White;False;False;False;False"+
   "\nSimplePawn;f3;White;False;False;False;False"+
   "\nSimplePawn;g2;White;True;False;False;False" +
   "\nSimplePawn;h3;White;False;False;False;False";
         var whiteList = whiteListString.Split('\n');
         foreach (var line in whiteList)
         {
           var datas = line.Split(';');
           var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
           //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
           newPawn.IsFirstMove = bool.Parse(datas[3]);
           newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
           newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
           newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
           pawnListWhite.Add(newPawn);
         }

         //BLACKList
         var blackListString = "" +
           "King;e8;Black;False;True;True;True"+
   "\nQueen;d6;Black;False;False;False;False"+
   "\nRook;a8;Black;False;False;False;False"+
   "\nRook;h8;Black;False;False;False;False"+
   "\nBishop;c8;Black;False;False;False;False"+
   "\nBishop;g7;Black;False;False;False;False"+
   "\nKnight;b8;Black;False;False;False;False"+
   "\nKnight;g8;Black;False;False;False;False"+
   "\nSimplePawn;a7;Black;True;False;False;False"+
   "\nSimplePawn;b7;Black;True;False;False;False"+
   "\nSimplePawn;c7;Black;True;False;False;False"+
   "\nSimplePawn;d5;Black;False;False;False;False"+
   "\nSimplePawn;e7;Black;True;False;False;False"+
   "\nSimplePawn;f7;Black;True;False;False;False"+
   "\nSimplePawn;g5;Black;False;False;False;False"+
   "\nSimplePawn;h7;Black;True;False;False;False";
         var blackList = blackListString.Split('\n');
         foreach (var line in blackList)
         {
           var datas = line.Split(';');
           var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
           //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
           newPawn.IsFirstMove = bool.Parse(datas[3]);
           newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
           newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
           newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
           pawnListBlack.Add(newPawn);
         }



         mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


         var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
         ////le bishop blanch doit se mettre sur "b5"
         Assert.AreEqual(nodeResult.BestChildPosition, "b5");
       }
   */
    [TestMethod]
    public void  MTT19bLeFouBlanchDoitnenacerLaReineOulePionDoitProtegerLeTour()
    {
      ////////le poin blanch doit se mettre sur ""




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b3;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f3;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e8;Black;False;True;True;True" +
"\nQueen;d6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d5;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g5;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //Assert.IsNull(randomList);
        ////////le poin blanch doit se mettre sur "c3"
        var isSucces = false;
        if (nodeResult.BestChildPosition == "d4" || nodeResult.BestChildPosition == "c3" || nodeResult.BestChildPosition == "a3")
          isSucces = true;
        Assert.IsTrue(isSucces);
      }
    }



    [TestMethod]
    public void  MTT20LePionDoitPrendreLeCavalier()
    {
      /*le pion blanch doit prendre le cavalier */
      ////le pion blanch doit se mettre sur "d3"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;d2;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;b3;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;g4;Black;False;False;False;False" +
"\nKnight;d3;Black;False;False;False;False" +
"\nKnight;e4;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        ////le pion blanch doit se mettre sur "d3"
        // Assert.AreEqual(nodeResult.AssociatePawn.Name, "SimplePawn");
        Assert.AreEqual(nodeResult.BestChildPosition, "d3");
      }
    }


    [TestMethod]
    public void  MTT21LeRoiBlanchDoitSeMettreEnd3()
    {
      /*La roi blanch doit se mettre en d3*/
      //Positions final du roi blanch doit etre d3 

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "" +
        "King;e2;White;False;False;True;False" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h5;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b5;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;d5;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
      "King;e8;Black;False;True;True;False" +
"\nQueen;g2;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;h6;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;e3;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g4;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7"
        //Assert.AreNotEqual(nodeResult.BestChildPosition, "a7", "c7");
        // Assert.AreEqual(nodeResult.AssociatePawn.Name, "King");
        Assert.AreEqual(nodeResult.BestChildPosition, "d3");
      }
    }

    [TestMethod]
    public void  MTT22LeBishopOuLeRoiNoirDoitPrendreLePion()
    {
      /*Le Bishop Noir Doit Prendre le pion */
      ////le Bishop noir  doit se mettre sur "e7"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;f1;White;False;False;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;e2;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;e7;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f3;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e8;Black;False;True;True;True" +
        "\nQueen;c4;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //  Assert.IsNull(randomList);
        Assert.AreEqual(nodeResult.BestChildPosition, "e7");
      }
    }


    [TestMethod]
    public void  MTT23LeCavalierNoirNeDoitPasMenacerLeRoiBlanch()
    {
      /*Le Cavalier noir ne doit pas menacer le roi blanc*/
      ////le Cavalier noir ne doit pas se mettre sur "b3"




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;d2;White;False;False;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;a1;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        ////le Cavalier noir ne doit pas se mettre sur "b3"
        //Assert.AreEqual(nodeResult.AssociatePawn.Name, "Bishop");
        Assert.AreNotEqual(nodeResult.BestChildPosition, "b3");
      }
    }


    [TestMethod]
    public void  MTT24LeCavalierNoirNeDoitPasBouger()
    {
      /*Le Cavalier noir ne doit pas bouger*/




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;d2;White;False;False;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;a1;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {

        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.AreNotEqual(nodeResult.Location, "a1");
      }

    }

    [TestMethod]
    public void  MTT25LeCavalierNoirDoitMenacerLeRoiBlanch()
    {
      /*Le Cavalier noir doit mencer le roi blanc*/




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;d2;White;False;False;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;c2;White;False;False;False;False" +
"\nKnight;d1;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
        "King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;a1;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);


        //TODO A REVERIFIER
        //Assert.AreEqual(nodeResult.AssociatePawn.Name, "Knight");
        // Assert.AreEqual(nodeResult.BestChildPosition, "b3");

        Assert.AreEqual(nodeResult.BestChildPosition, "b3");
      }

    }

    [TestMethod]
    public void  MTT26LeCavalierNoirDoitBouger()
    {
      /*Le Cavalier noir en f6 doit se deplacer*/




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;d3;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;h6;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        /*Le Cavalier noir en f6 doit se deplacer*/
        // Assert.AreEqual(nodeResult.AssociatePawn.Name, "Knight");
        Assert.AreEqual(nodeResult.Location, "f6");
      }

    }
    [TestMethod]
    public void  MTT01MultiThreadCPUsPawn()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";
      var testName = "T01QuenLaReineNoirNeDoitPasPrendreLeCavalier";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);





        Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");
      }

    }



    [TestMethod]
    public void  MTT27LeBishopBlancDoitSeMettreEnA8()
    {
      /*Le Bishop blanc doit attaque le rook en a8 et non pas le cavalier*/
      // Le Bishop blanc doit se mettre en a8



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c3;White;False;False;False;False" +
"\nBishop;c6;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b3;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;d7;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;f4;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g5;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        // Le Bishop blanc doit se mettre en a8
        var isSucces = false;
        if (nodeResult.BestChildPosition == "g7" || nodeResult.BestChildPosition == "g8")
          isSucces = true;
        Assert.IsTrue(isSucces);
      }

    }

    [TestMethod]
    public void  MTT28LePionNoirDoitPrendreLeCavalier()
    {
      /*Le pion noir doit attaque le cavavier en d6*/
      // Le pion noir doit se mettre en d6



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;d6;White;False;False;False;False" +
"\nKnight;f3;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a6;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        // // Le pion noir doit se mettre en d6
        Assert.AreEqual(nodeResult.BestChildPosition, "d6");
      }


    }

    [TestMethod]
    public void  MTT29PourProtegerDEchec()
    {
      /*Le pion blanch doit se mettre en h4 ou le Bishop doit se mettre en g2 ou reine en c2  pour proder de l'check*/
      // Le pion blanc doit se mettre en h4 ou le Bishop doit se mettre en g2 ou ou reine en c2



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b3;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;g4;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;f6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;e3;Black;False;False;False;False" +
"\nSimplePawn;e4;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        // Le pion blanc doit se mettre en h4 ou le Bishop doit se mettre en g2 ou reine en c2
        var isSuccess = false;
        string[] accepdedArray = { "g5", "c2", "h4", "h2", "g2", "d5", "d4", "c1" };

        if (accepdedArray.Contains(nodeResult.BestChildPosition))
          isSuccess = true;
        Assert.IsTrue(isSuccess);
      }


    }

    [TestMethod]
    public void  MTT30LaReineNoirNeDoitPasPrendreLeFouEnG4()
    {
      /*La reinne noir ne doit pas se mettre en g4*/
      // La reinne noir ne doit pas se mettre en g4



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;g1;White;False;False;True;True" +
"\nQueen;h8;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;e3;White;False;False;False;False" +
"\nBishop;g4;White;False;False;False;False" +
"\nKnight;e4;White;False;False;False;False" +
"\nKnight;f2;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;f8;Black;False;False;False;True" +
"\nQueen;g6;Black;False;False;False;False" +
"\nRook;a6;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //La reinne noir ne doit pas se mettre en g4
        Assert.AreNotEqual(nodeResult.BestChildPosition, "g4");
      }


    }


    [TestMethod]
    public void  MTT31LaReineNoirDoitPrendreLaReineBlanch()
    {
      /*La reinne noir ne doit pas se mettre en a8*/



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;g1;White;False;True;True;True" +
"\nQueen;a8;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;a3;White;False;False;False;False" +
"\nKnight;f3;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g4;White;False;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;d7;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f5;Black;False;False;False;False" +
"\nSimplePawn;f4;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {

        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //La reinne noir ne doit pas se mettre en g4
        Assert.AreEqual(nodeResult.BestChildPosition, "a8");
      }


    }

    [TestMethod]
    public void  MTT32LaReineBlanchDoitAttaquerEnB7()
    {




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;b5;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;d7;Black;False;False;False;False" +
"\nBishop;f6;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;h6;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;g5;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);


        //La reinne noir  doit se mettre en b7
        Assert.AreEqual(nodeResult.BestChildPosition, "b7");
      }


    }
    [TestMethod]
    public void  MTT33LaReineBlanchDoitAttaquerEnB7()
    {




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;b5;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;d7;Black;False;False;False;False" +
"\nBishop;f6;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;h6;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;g5;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        // Assert.IsNull(randomList);
        //La reinne noir  doit se mettre en b7
        Assert.AreEqual(nodeResult.BestChildPosition, "b7");
      }


    }

    [TestMethod]
    public void  MTT35LePoinNoirNeDoitPasSeMettreEnG5()
    {




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
        "King;e1;White;False;True;True;True" +
        "\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;f4;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;a5;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);



      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;





        //  Assert.IsNull(randomList.FirstOrDefault(x => x.ToIndex == 30));
        Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");
      }



    }


    [TestMethod]
    public void  MTT36LePoinNoirNeDoitPasSeMettreEnD6()
    {




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;f2;White;False;False;False;False" +
"\nBishop;a8;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;e2;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;e3;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a6;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;f6;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);



        Assert.AreNotEqual(nodeResult.BestChildPosition, "d6");
      }


    }


    [TestMethod]
    public void  MTT37LaTourDoitEtreProtegE()
    {




      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;f4;White;False;False;False;False" +
"\nBishop;d5;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.AreEqual(nodeResult.BestChildPosition, "c6");
      }


    }

    [TestMethod]
    public void  MTT38LePionNoirNeDoitPasSeMettreSurA3()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c3;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;f5;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;b5;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;d6;White;False;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a7;Black;False;False;False;False" +
"\nRook;h7;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nKnight;h5;Black;False;False;False;False" +
"\nSimplePawn;a4;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);


        Assert.AreNotEqual(nodeResult.BestChildPosition, "a3");
      }
    }

    [TestMethod]
    public void  MTT39LePionNoirNeDoitPasSeMettreSurC3()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g2;White;False;False;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;f2;White;False;False;False;False" +
"\nBishop;h8;White;False;False;False;False" +
"\nKnight;a2;White;False;False;False;False" +
"\nSimplePawn;f5;White;False;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;True" +
"\nQueen;a5;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;d6;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;b5;Black;False;False;False;False" +
"\nSimplePawn;c4;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e5;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.AreNotEqual(nodeResult.BestChildPosition, "c3");
      }
    }


    [TestMethod]
    public void  MTT40LePionNoirNeDoitPasSeMettreSurA2()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g2;White;False;False;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;f2;White;False;False;False;False" +
"\nBishop;h8;White;False;False;False;False" +
"\nKnight;c1;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;True" +
"\nQueen;a5;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;d6;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;a3;Black;False;False;False;False" +
"\nSimplePawn;b5;Black;False;False;False;False" +
"\nSimplePawn;c4;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.AreNotEqual(nodeResult, "a2");
      }
    }


    [TestMethod]
    public void  MTT41LaReineBlancheDoitMenacerLeRoiEnH5OuPrendreLaReineD6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f2;White;False;False;True;False" +
"\nQueen;h7;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;g6;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c2;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b3;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;d5;Black;False;False;True;True" +
"\nQueen;d6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nBishop;b7;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b5;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d4;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);


        // var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "a2");

        var isSucces = false;
        if (nodeResult.BestChildPosition == "h5" || nodeResult.BestChildPosition == "d6")
          isSucces = true;
        Assert.IsTrue(isSucces);
      }
    }

    /*
        [TestMethod]
        public void  MTT43LeCavalierNoirNeDoitPasprendreLePionEnF2()
        {
          var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
          mainWindow.ComputerColore = "Black";




          mainWindow.CleanPawnList();
          var pawnListWhite = new List<Pawn>();
          var pawnListBlack = new List<Pawn>();



          //WHITEList
          var whiteListString = "" +
    "King;e1;White;False;True;True;True" +
    "\nQueen;e2;White;False;False;False;False" +
    "\nRook;a1;White;False;False;False;False" +
    "\nRook;h1;White;False;False;False;False" +
    "\nBishop;c1;White;False;False;False;False" +
    "\nBishop;c4;White;False;False;False;False" +
    "\nKnight;b1;White;False;False;False;False" +
    "\nKnight;h3;White;False;False;False;False" +
    "\nSimplePawn;a2;White;True;False;False;False" +
    "\nSimplePawn;b2;White;True;False;False;False" +
    "\nSimplePawn;c2;White;True;False;False;False" +
    "\nSimplePawn;d2;White;True;False;False;False" +
    "\nSimplePawn;e5;White;False;False;False;False" +
    "\nSimplePawn;f2;White;True;False;False;False" +
    "\nSimplePawn;g2;White;True;False;False;False" +
    "\nSimplePawn;h2;White;True;False;False;False";
          var whiteList = whiteListString.Split('\n');
          foreach (var line in whiteList)
          {
            var datas = line.Split(';');
            var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnListWhite.Add(newPawn);
          }

          //BLACKList
          var blackListString = "" +
    "King;e8;Black;False;True;True;True" +
    "\nQueen;d8;Black;False;False;False;False" +
    "\nRook;a8;Black;False;False;False;False" +
    "\nRook;h8;Black;False;False;False;False" +
    "\nBishop;c8;Black;False;False;False;False" +
    "\nBishop;c5;Black;False;False;False;False" +
    "\nKnight;b8;Black;False;False;False;False" +
    "\nKnight;e4;Black;False;False;False;False" +
    "\nSimplePawn;a7;Black;True;False;False;False" +
    "\nSimplePawn;b7;Black;True;False;False;False" +
    "\nSimplePawn;c7;Black;True;False;False;False" +
    "\nSimplePawn;d7;Black;True;False;False;False" +
    "\nSimplePawn;e6;Black;False;False;False;False" +
    "\nSimplePawn;f7;Black;True;False;False;False" +
    "\nSimplePawn;g7;Black;True;False;False;False" +
    "\nSimplePawn;h7;Black;True;False;False;False";
          var blackList = blackListString.Split('\n');
          foreach (var line in blackList)
          {
            var datas = line.Split(';');
            var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnListBlack.Add(newPawn);
          }



          mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


          var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
          var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
          Assert.IsNull(randomList);

          // var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "a2");
          Assert.AreNotEqual(nodeResult.BestChildPosition, "f2");
        }
        */
    [TestMethod]
    public void  MTT44LePionNoirPasRamdumeB5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;e2;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;f2;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;c5;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        // var  MTT_value = nodeResult.Weight;
        //var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "b5");
        Assert.AreNotEqual(nodeResult.BestChildPosition, "b5");
      }
    }



    [TestMethod]
    public void  MTT45LeChevalierBlacnDoitSeNettreEnG5SpecificPosition0()
    {

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      //Pour les SpecificPositions il faut se connecter à la base
      mainWindow.SetIsConnectedDB(true);


      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;f3;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        // var  MTT_value = nodeResult.Weight;
        //var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "b5");
        Assert.AreEqual(nodeResult.BestChildPosition, "g5");
      }
    }



    [TestMethod]
    public void  MTT46LeFouBlacnDoitSeNettreEncC4SpecificPosition0()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      //Pour les SpecificPositions il faut se connecter à la base
      mainWindow.SetIsConnectedDB(true);


      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;g5;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        // var  MTT_value = nodeResult.Weight;
        //var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "b5");
        Assert.AreEqual(nodeResult.BestChildPosition, "c4");
      }
    }


    [TestMethod]
    public void  MTT47LesNoirsDoiventEviterLeSpecificPosition0()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      //Pour les SpecificPositions il faut se connecter à la base
      mainWindow.SetIsConnectedDB(true);
      mainWindow.ComputerColore = "Black";



      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;f3;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        var isSucces = false;
        if (nodeResult.BestChildPosition == "g4" || nodeResult.BestChildPosition == "e6" || nodeResult.BestChildPosition == "h6" || nodeResult.BestChildPosition == "c8" || nodeResult.BestChildPosition == "c7")
          isSucces = true;
        Assert.IsTrue(isSucces);
      }
    }

    //    [TestMethod]
    //    public void  MTT48LaTourNoirDoitSeMetteEnA7OuPionEnF5()
    //    {
    //      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
    //      mainWindow.ComputerColore = "Black";

    //      
    //       
    //      
    //      mainWindow.CleanPawnList();
    //      var pawnListWhite = new List<Pawn>();
    //      var pawnListBlack = new List<Pawn>();



    //      //WHITEList
    //      var whiteListString = "" +
    //"King;g1;White;False;True;True;True" +
    //"\nQueen;f4;White;False;False;False;False" +
    //"\nRook;f3;White;False;False;False;False" +
    //"\nBishop;c4;White;False;False;False;False" +
    //"\nKnight;b1;White;False;False;False;False" +
    //"\nKnight;h7;White;False;False;False;False" +
    //"\nSimplePawn;a2;White;True;False;False;False" +
    //"\nSimplePawn;c2;White;True;False;False;False" +
    //"\nSimplePawn;e4;White;False;False;False;False" +
    //"\nSimplePawn;f2;White;True;False;False;False" +
    //"\nSimplePawn;g2;White;True;False;False;False" +
    //"\nSimplePawn;h2;White;True;False;False;False";
    //      var whiteList = whiteListString.Split('\n');
    //      foreach (var line in whiteList)
    //      {
    //        var datas = line.Split(';');
    //        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
    //        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
    //        newPawn.IsFirstMove = bool.Parse(datas[3]);
    //        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
    //        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
    //        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
    //        pawnListWhite.Add(newPawn);
    //      }

    //      //BLACKList
    //      var blackListString = "" +
    //"King;e8;Black;False;True;True;False" +
    //"\nQueen;d8;Black;False;False;False;False" +
    //"\nRook;a8;Black;False;False;False;False" +
    //"\nRook;f8;Black;False;False;False;False" +
    //"\nBishop;b7;Black;False;False;False;False" +
    //"\nBishop;a1;Black;False;False;False;False" +
    //"\nKnight;b8;Black;False;False;False;False" +
    //"\nSimplePawn;a5;Black;False;False;False;False" +
    //"\nSimplePawn;b6;Black;False;False;False;False" +
    //"\nSimplePawn;c7;Black;True;False;False;False" +
    //"\nSimplePawn;d7;Black;True;False;False;False" +
    //"\nSimplePawn;e6;Black;False;False;False;False" +
    //"\nSimplePawn;f7;Black;True;False;False;False" +
    //"\nSimplePawn;h5;Black;False;False;False;False" +
    //"\nSimplePawn;h6;Black;False;False;False;False";
    //      var blackList = blackListString.Split('\n');
    //      foreach (var line in blackList)
    //      {
    //        var datas = line.Split(';');
    //        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
    //        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
    //        newPawn.IsFirstMove = bool.Parse(datas[3]);
    //        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
    //        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
    //        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
    //        pawnListBlack.Add(newPawn);
    //      }



    //      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


    //      var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

    //      var isSucces = false;
    //      if (nodeResult.BestChildPosition == "a7" || nodeResult.BestChildPosition == "f5" || nodeResult.BestChildPosition == "c8")
    //        isSucces =  true;
    //      Assert.IsTrue(isSucces);
    //    }


    [TestMethod]
    public void  MTT49LesNoirsDoiventprotegerLeRoiMenacE()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



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
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

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
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);


        // var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        // Assert.IsNull(randomList);


        Assert.AreEqual(nodeResult.BestChildPosition, "e2");
      }
    }


    [TestMethod]
    public void  MTT50LaToureNoirDoitSeMettreEnA7()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;c3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;a7;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b4;White;False;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;h6;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f6;Black;False;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);


        Assert.AreEqual(nodeResult.BestChildPosition, "a7");
      }
    }

    [TestMethod]
    public void  MTT51aLeFouBlanchDoiSeMettreSurH5SecificPosition1()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      //Pour les SpecificPositions il faut se connecter à la base
      mainWindow.SetIsConnectedDB(true);
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;f1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;e2;White;False;False;False;False" +
"\nKnight;h4;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;b7;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;d5;Black;False;False;False;False" +
"\nSimplePawn;f6;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h5;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);


        Assert.AreEqual(nodeResult.BestChildPosition, "h5");
      }
    }


    [TestMethod]
    public void  MTT51bLeFouNoirDoitSeMettreSurH4SecificPosition1Symetri()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      //Pour les SpecificPositions il faut se connecter à la base
      mainWindow.SetIsConnectedDB(true);
      mainWindow.ComputerColore = "Black";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;b2;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b3;White;False;False;False;False" +
"\nSimplePawn;c4;White;False;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;f3;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;g8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nKnight;h5;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;e5;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);


        Assert.AreEqual(nodeResult.BestChildPosition, "h4");
      }
    }


    [TestMethod]
    /*tsiry;26-08-2021*/
    public void  MTT52LaReineNoirNeDoitPasSeMettreEnC2()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h5;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;g6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;d6;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a6;Black;False;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);


        Assert.AreNotEqual(nodeResult.BestChildPosition, "c2");
      }
    }


    [TestMethod]
    /*tsiry;26-08-2021*/
    public void  MTT53LaPositionFinalNoirNeDoitPasEtreE6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;

        //var succes = false;
        //if (randomList.Count != 0)
        //{
        //  if (randomList.Count == 1)
        //    succes =  true;
        //}
        //else
        //  succes =  true;
        //Assert.IsTrue(succes);
        Assert.AreNotEqual(nodeResult.BestChildPosition, "e6");
      }
    }


    [TestMethod]
    /*tsiry;27-08-2021*/
    public void  MTT54ALesBlanchDoiventEviterLEvolutionDuPion()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;d1;White;False;False;True;True" +
"\nQueen;e3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;


        var succes = false;

        if (randomList.Count == 0)
          succes = true;



        Assert.IsTrue(succes);

        Assert.AreEqual(nodeResult.BestChildPosition, "b1");
      }
    }


    [TestMethod]
    /*tsiry;27-08-2021*/
    public void  MTT54BLaRaineBlancDoitMenacerLeRoiEtSeMettreEnG6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;d1;White;False;False;True;True" +
"\nQueen;d3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.AreEqual(nodeResult.BestChildPosition, "g6");
      }
    }


    [TestMethod]
    /*tsiry;27-08-2021*/
    public void  MTT54CLePionNoirDoitEvoluerDoitSeMettreEnC1()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;d1;White;False;False;True;True" +
"\nQueen;e3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.AreEqual(nodeResult.BestChildPosition, "a1");
      }
    }


    [TestMethod]
    /*tsiry;27-08-2021*/
    public void  MTT54ELePionNoirDoitEvoluerDoitSeMettreEnA1()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e2;White;False;False;True;True" +
"\nQueen;d3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.AreEqual(nodeResult.BestChildPosition, "a1");
      }
    }
    [TestMethod]
    /*tsiry;14-10-2021*/
    public void  MTT54FLaReineNoirMenaverleRoiBlanchEtSeMettreEnD6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;d1;White;False;False;True;True" +
"\nQueen;e3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);



      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        var isSucces = true;
        if (randomList != null)
        {
          //  Pour  MTTester que  MTT69
          foreach (var item in randomList)
          {
            if (item.ToIndex == 41)
            {
              isSucces = false;
              break;
            }
          }
        }
        Assert.IsTrue(isSucces);




        isSucces = false;
        if (nodeResult.BestChildPosition == "d6" || nodeResult.BestChildPosition == "a1" || nodeResult.BestChildPosition == "b3")
          isSucces = true;
        Assert.IsTrue(isSucces);
      }
    }



    [TestMethod]
    /*tsiry;27-08-2021*/
    public void  MTT54DLePionNoirDoitEvoluerETSeMettreEnB1()//  MTT54DLaReinneNoirDoitSeMettreEnC4()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e2;White;False;False;True;True" +
"\nQueen;e3;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
//"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.AreEqual(nodeResult.BestChildPosition, "b1");
      }
    }


    [TestMethod]
    /*tsiry;27-08-2021*/
    public void  MTT54GLaReinneNoirDoitAttaquerEnC4()//  MTT54DLaReinneNoirDoitSeMettreEnC4()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e2;White;False;False;True;True" +
"\nQueen;e3;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;False;False" +
"\nQueen;b4;Black;False;False;False;False" +
"\nBishop;h1;Black;False;False;False;False" +
"\nBishop;e7;Black;False;False;False;False" +
"\nSimplePawn;b2;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        //Assert.AreEqual(nodeResult.BestChildPosition, "c4");
        Assert.AreEqual(nodeResult.BestChildPosition, "b1");
      }
    }

    [TestMethod]
    /*tsiry;30-08-2021*/
    public void  MTT55SecificPositionLeCavalierBlanchDoitSeMettreSurG6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b5;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;h4;White;False;False;False;False" +
"\nSimplePawn;a3;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a4;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f5;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);


        Assert.AreEqual(nodeResult.BestChildPosition, "g6");
      }
    }


    [TestMethod]
    /*tsiry;30-08-2021*/
    public void  MTT56ToNotSecificPositionMesNoirDoiventEmpecherLeCavalierBlanchDeSeMettreSurG6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b5;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;h4;White;False;False;False;False" +
"\nSimplePawn;a3;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a4;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f5;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.AreNotEqual(nodeResult.BestChildPosition, "c6");
        Assert.AreNotEqual(nodeResult.BestChildPosition, "b7");
      }
    }

    [TestMethod]
    /*tsiry;30-08-2021*/
    public void  MTT57SeulLeRookDoitBougerNotRandomD5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f1;White;False;False;True;False" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;g1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;f4;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;f6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b5;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e5;Black;False;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");



        // var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "d5");
        // Assert.IsNull(result);
        Assert.AreNotEqual(nodeResult.BestChildPosition, "d5");
      }
    }


   /* [TestMethod]
    //tsiry;30-08-2021
    public void  MTT58PourEviterLeNullSeulLeRookNoirNeDoitSeMettreEnD2()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;b2;White;False;True;True;True" +
"\nRook;c1;White;False;False;False;False" +
"\nSimplePawn;h4;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;d3;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }
      mainWindow.SetDebugTextBlockText("" +
        "" +
        "\nWhite: Pawn  e2 => e4" +
"\nBlack: Knight  b8 => a6" +
"\nWhite: Queen d1 => f3" +
"\nBlack: Knight  a6 => b8" +
"\nWhite: Bishop  f1 => c4" +
"\nBlack: Knight  g8 => f6" +
"\nWhite: Pawn  e4 => e5" +
"\nBlack: Pawn  g7 => g6" +
"\nWhite: Pawn  e5 => f6" +
"\nBlack: Pawn  e7 => e6" +
"\nWhite: Knight  b1 => c3" +
"\nBlack: Rook  h8 => g8" +
"\nWhite: Pawn  b2 => b4" +
"\nBlack: Bishop  f8 => b4" +
"\nWhite: Knight  c3 => b5" +
"\nBlack: Pawn  d7 => d6" +
"\nWhite: Pawn  c2 => c3" +
"\nBlack: Pawn  d6 => d5" +
"\nWhite: Pawn  d2 => d3" +
"\nBlack: Pawn  d5 => c4" +
"\nWhite: Bishop  c1 => f4" +
"\nBlack: Bishop  b4 => a5" +
"\nWhite: Pawn  d3 => c4" +
"\nBlack: Queen d8 => f6" +
"\nWhite: Rook  a1 => d1" +
"\nBlack: Queen f6 => f5" +
"\nWhite: Pawn  c4 => c5" +
"\nBlack: Queen f5 => c5" +
"\nWhite: Queen f3 => d3" +
"\nBlack: Knight  b8 => c6" +
"\nWhite: Bishop  f4 => e3" +
"\nBlack: Queen c5 => e5" +
"\nWhite: Knight  g1 => f3" +
"\nBlack: Queen e5 => h8" +
"\nWhite: Knight  b5 => c7" +
"\nBlack: Bishop  a5 => c7" +
"\nWhite: Knight  f3 => e5" +
"\nBlack: Bishop  c7 => e5" +
"\nWhite: Pawn  f2 => f4" +
"\nBlack: Bishop  e5 => c3" +
"\nWhite: King  e1 => f1" +
"\nBlack: Pawn  g6 => g5" +
"\nWhite: King  f1 => g1" +
"\nBlack: Pawn  g5 => f4" +
"\nWhite: Bishop  e3 => f4" +
"\nBlack: Bishop  c3 => e5" +
"\nWhite: Bishop  f4 => e5" +
"\nBlack: Queen h8 => e5" +
"\nWhite: Pawn  h2 => h4" +
"\nBlack: Queen e5 => c5" +
"\nWhite: King  g1 => f1" +
"\nBlack: Queen c5 => f5" +
"\nWhite: King  f1 => e1" +
"\nBlack: Queen f5 => d3" +
"\nWhite: Rook  d1 => d3" +
"\nBlack: Knight  c6 => b4" +
"\nWhite: Rook  d3 => a3" +
"\nBlack: Knight  b4 => c2" +
"\nWhite: King  e1 => d2" +
"\nBlack: Rook  g8 => g2" +
"\nWhite: King  d2 => c3" +
"\nBlack: Knight  c2 => a3" +
"\nWhite: Rook  h1 => c1" +
"\nBlack: Rook  g2 => a2" +
"\nWhite: King  c3 => b3" +
"\nBlack: Rook  a2 => d2" +
"\nWhite: King  b3 => a3" +
"\nBlack: Rook  d2 => d3" +
"\nWhite: King  a3 => b2" +
"\nBlack: Rook  d3 => d2" +
"\nWhite: King  b2 => a3" +
"\nBlack: Rook  d2 => d3" +
"\nWhite: King  a3 => b2");



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);


      Assert.AreNotEqual(nodeResult.BestChildPosition, "d2");
    }
    */


    /*tsiry;06-10-2021*/
    [TestMethod]
    public void  MTT59FinDePartieEviterMortDuRoiNoir()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;b1;White;False;False;False;False" +
"\nRook;a7;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d5;White;False;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;c7;Black;False;False;False;False" +
"\nRook;g2;Black;False;False;False;False" +
"\nBishop;h2;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        var isSuccess = true;
        if (randomList != null)
        {
          //  Pour  MTTester que  MTT59
          foreach (var item in randomList)
          {
            if (item.ToIndex == 62)
            {
              isSuccess = false;
              break;
            }
          }
        }
        Assert.IsTrue(isSuccess);
        Assert.AreNotEqual(nodeResult.BestChildPosition, "g1");
      }
    }


    [TestMethod]
    public void MTT61aPourBestSpecificPosition3White()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      //Pour les SpecificPositions il faut se connecter à la base
      mainWindow.SetIsConnectedDB(true);
      mainWindow.ComputerColore = "White";
      var testName = "T61aPourBestSpecificPosition3White";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //Assert.IsNull(randomList);
        //echec si nodeResult.Location ==  nodeResult.BestChildPosition
        Assert.AreEqual(nodeResult.BestChildPosition, "e6");

      }

    }

    /*tsiry;12-10-2021*/
    [TestMethod]
    public void MTT60leRoisNoirDoitEvierDeMourirDoitSeDeplacerEnF8()
    {
      //Pour les SpecificPositions il faut se connecter à la base
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      var testName = "T60leRoisNoirDoitEvierDeMourirDoitSeDeplacerEnF8";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //Assert.IsNull(randomList);
        //echec si nodeResult.Location ==  nodeResult.BestChildPosition
        Assert.AreEqual(nodeResult.BestChildPosition, "f8");
      }




    }


    /*tsiry;12-10-2021*/
    [TestMethod]
    public void  MTT61PourEviterBestSpecificPosition3White()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True" +
"\nQueen;g4;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;f1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;d2;White;False;False;False;False" +
"\nKnight;g5;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;False" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;f7;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e5;Black;False;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        Assert.AreNotEqual(nodeResult.BestChildPosition, "g7");
      }
    }

    /*tsiry;12-10-2021*/
    [TestMethod]
    public void  MTT62LePionNoirDoitAttaqueLaReineBlancEnH5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;h5;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;e2;White;False;False;False;False" +
"\nKnight;g5;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d5;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;f5;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;e4;Black;False;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");



        // var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "d5");
        // Assert.IsNull(result);
        Assert.AreEqual(nodeResult.BestChildPosition, "h5");
      }
    }


    /*tsiry;14-10-2021*/
    [TestMethod]
    public void  MTT65LeRookBlanchNeDoitPasSeMettreEnA6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f3;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;d3;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h4;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;g8;Black;False;True;True;True" +
"\nQueen;d6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;e8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;a6;Black;False;False;False;False" +
"\nKnight;e4;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        Assert.AreNotEqual(nodeResult.BestChildPosition, "a6");
      }
    }


    /*tsiry;18-10-2021*/
    [TestMethod]
    public void  MTT67EchecBlancLeRoiBlanchDoitBougerPourNePasPerdre()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f1;White;False;False;True;True" +
"\nQueen;c3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c4;White;False;False;False;False" +
"\nSimplePawn;h4;White;False;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;c8;Black;False;True;True;False" +
"\nQueen;h2;Black;False;False;False;False" +
"\nRook;d8;Black;False;False;False;False" +
"\nRook;f4;Black;False;False;False;False" +
"\nKnight;d4;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h3;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        Assert.AreEqual(nodeResult.BestChildPosition, "e1");
      }
    }

    /*tsiry;19-10-2021*/
    [TestMethod]
    public void  MTT68LeRoiBlanchNeDoitPasSeMettreEnG6()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f5;White;False;False;False;True" +
"\nRook;c5;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;b2;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h5;White;False;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;h7;Black;False;False;False;True" +
"\nRook;e3;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;a2;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        Assert.AreNotEqual(nodeResult.BestChildPosition, "g6");
      }
    }


    /*tsiry;21-10-2021*/
    [TestMethod]
    public void  MTT69LeRoiBanchNeDoitPasPrendreLePionEnG2()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f2;White;False;False;False;True" +
"\nRook;a1;White;False;False;False;False" +
"\nKnight;e2;White;False;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;h2;Black;False;False;False;False" +
"\nBishop;d5;Black;False;False;False;False" +
"\nSimplePawn;a2;Black;False;False;False;False" +
"\nSimplePawn;g2;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        var isSuccess = true;
        if (randomList != null)
        {
          //  Pour  MTTester que  MTT69
          foreach (var item in randomList)
          {
            if (item.ToIndex == 54)
            {
              isSuccess = false;
              break;
            }
          }
        }
        Assert.IsTrue(isSuccess);

        Assert.AreNotEqual(nodeResult.BestChildPosition, "g2");
      }
    }





    /*tsiry;25-10-2021*/
    [TestMethod]
    public void  MTT71LeRoisBlantNeDoitPasPrendreLeRookEnF5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e4;White;False;True;True;True" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;d3;White;False;False;False;False" +
"\nKnight;g4;White;False;False;False;False" +
"\nSimplePawn;b4;White;True;False;False;False" +
"\nSimplePawn;b3;White;True;False;False;False" +
"\nSimplePawn;c4;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h4;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e6;Black;False;True;True;True" +
"\nRook;d8;Black;False;False;False;False" +
"\nRook;f5;Black;False;False;False;False" +
"\nSimplePawn;a2;Black;True;False;False;False" +
"\nSimplePawn;b6;Black;True;False;False;False" +
"\nSimplePawn;c5;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);


        Assert.AreNotEqual(nodeResult.BestChildPosition, "f5");
      }
    }

    /*tsiry;25-10-2021*/
    [TestMethod]
    public void  MTT72LaReineNoirDoitPrendreLePionEnD5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;d5;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;


        var isSuccess = false;
        if (randomList.Count == 0)
          isSuccess = true;
        Assert.IsTrue(isSuccess);

        Assert.AreEqual(nodeResult.BestChildPosition, "d5");
      }
    }

    /*tsiry;25-10-2021*/
    [TestMethod]
    public void  MTT72BLaReineNoirDoitPrendreLePionEnD5()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";
      var testName = "T72BLaReineBlanchDoitPrendreLePionEnD4";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        var isSuccess = false;
        if (randomList.Count == 0 || randomList.Count == 1)
          isSuccess = true;
        Assert.IsTrue(isSuccess);

        Assert.AreEqual(nodeResult.BestChildPosition, "d4");
      }
    }


    /*tsiry;25-10-2021*/
    [TestMethod]
    public void  MTT73LeFouNoirNeDoitPasPrendreLePionEnB2()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";

      var testName = "T73LeFouNoirNeDoitPasPrendreLePionEnB2";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //Assert.IsNull(randomList);

        Assert.AreNotEqual(nodeResult.BestChildPosition, "b2");
      }
    }

    /*tsiry;28-10-2021*/
    [TestMethod]
    public void  MTT74LesBlanchsDoiventPrendreLePionEnD4()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();

      var testName = "T74LesBlanchsDoiventPrendreLePionEnD4";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        Assert.AreEqual(0, randomList.Count);

        Assert.AreEqual(nodeResult.BestChildPosition, "d4");
      }
    }

    /*tsiry;28-10-2021*/
    [TestMethod]
    public void MTT78ProtectionDuRookDesNoirs()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";

      var testName = "T78ProtectionDuRookDesNoirs";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        // var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //  Assert.IsNull(randomList);
        Assert.AreEqual(nodeResult.Location, "c1");
        Assert.AreEqual(nodeResult.BestChildPosition, "b2");
      }
    }


    /*tsiry;28-10-2021*/
    [TestMethod]
    public void  MTT79LeRoisBlanchDoitSeMettreEnG1()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;f1;White;False;True;True;True" +
"\nRook;g3;White;False;False;False;False" +
"\nBishop;a2;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g4;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nRook;h2;Black;False;False;False;False" +
"\nBishop;a6;Black;False;False;False;False" +
"\nBishop;a5;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;d4;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //Assert.IsNull(randomList);
        Assert.AreEqual(0, randomList.Count);

        Assert.AreEqual(nodeResult.BestChildPosition, "g1");
      }
    }


    /*tsiry;12-11-2021*/
    [TestMethod]
    public void  MTT80LeRoiNoirDoitBougerEtLaReineNoirNeDoitPasSeMettreEn()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g3;White;False;True;True;True" +
"\nQueen;g8;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c3;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;g5;White;True;False;False;False" +
"\nSimplePawn;c4;White;True;False;False;False" +
"\nSimplePawn;d3;White;True;False;False;False" +
"\nSimplePawn;e4;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;d8;Black;False;True;True;True" +
"\nQueen;d1;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h4;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c5;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;g6;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        Assert.AreEqual(0, randomList.Count);

        Assert.AreEqual(nodeResult.BestChildPosition, "c7");
      }
    }


    /*tsiry;12-11-2021*/
    [TestMethod]
    public void  MTT81LeCavalierBlanchNeDoitPasPrendreLaReinEtLesBlanchDoiventEviterLEchec()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "White";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;c1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;e4;White;False;False;False;False" +
"\nBishop;f1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;d3;White;True;False;False;False" +
"\nSimplePawn;e2;White;True;False;False;False" +
"\nSimplePawn;f3;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;g8;Black;False;True;True;True" +
"\nQueen;f6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;e8;Black;False;False;False;False" +
"\nKnight;c6;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;b4;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d4;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //Assert.IsNotNull(randomList);

        Assert.AreNotEqual(nodeResult.BestChildPosition, "f6");
      }
    }


    [TestMethod]
    public void  MTT82Null2LesNoirDoiventEviterLeNull()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;c5;White;False;False;True;True";

      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;f7;Black;False;False;True;True" +
"\nQueen;f1;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      //ajout des movements
      if (Chess2Console.Utils.MovingList == null)
        Chess2Console.Utils.MovingList = new List<string>();
      Chess2Console.Utils.MovingList.Add("5(K|B)>13(__)");
      Chess2Console.Utils.MovingList.Add("33(K|W)>34(__)");

      Chess2Console.Utils.MovingList.Add("53(Q|B)>61(__)");
      Chess2Console.Utils.MovingList.Add("34(K|W)>26(__)");
      Chess2Console.Utils.MovingList.Add("61(Q|B)>53(__)");
      Chess2Console.Utils.MovingList.Add("26(K|W)>34(__)");
      Chess2Console.Utils.MovingList.Add("53(Q|B)>61(__)");
      Chess2Console.Utils.MovingList.Add("34(K|W)>26(__)");
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //var t_movingList = Chess2Console.Utils.MovingList;
        var notValide = randomList.FirstOrDefault(x => x.FromIndex == 61 && x.ToIndex == 53);
        Assert.IsNull(notValide);
      }

      // Assert.AreNotEqual(nodeResult.BestChildPosition, "f6");
    }

    /*tsiry;12-11-2021*/
    [TestMethod]
    public void  MTT84EchecEtMatNoir()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True" +
"\nQueen;d8;White;False;False;False;False" +
"\nRook;f1;White;False;False;False;False" +
"\nBishop;e3;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;e4;White;True;False;False;False" +
"\nSimplePawn;a3;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;f8;Black;False;True;True;True" +
"\nRook;c7;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;a6;Black;False;False;False;False" +
"\nBishop;c3;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;c6;Black;True;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.IsNull(nodeResult);
      }

    }


    [TestMethod]
    public void  MTT84BEchecEtMatNoir()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";




      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True" +
"\nQueen;d8;White;False;False;False;False" +
"\nRook;f1;White;False;False;False;False" +
"\nBishop;e3;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;e4;White;True;False;False;False" +
"\nSimplePawn;a3;White;True;False;False;False";

      ;
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;f8;Black;False;True;True;True" +
"\nRook;c7;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;a6;Black;False;False;False;False" +
"\nBishop;c3;Black;False;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;c6;Black;True;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        //  var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        Assert.IsNull(nodeResult);
        //echec si nodeResult.Location ==  nodeResult.BestChildPosition
        // Assert.AreEqual(nodeResult.Location, nodeResult.BestChildPosition);
      }
    }


    /*tsiry;16-12-2021*/
    [TestMethod]
    public void  MTT85LaToureNoirDoitPrendreLePionEnA5()
    {


      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      var testName = "T85LaToureNoirDoitPrendreLePionEnA5";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //Assert.IsNull(randomList);
        //echec si nodeResult.Location ==  nodeResult.BestChildPosition
        Assert.AreEqual(nodeResult.BestChildPosition, "a5");
      }
    }


    /*tsiry;11-01-2022
     * */
    [TestMethod]
    public void MTT86ApplicationDownOutOfmemories()
    {


      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      var testName = "T86ApplicationDownOutOfmemories";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //Assert.IsNull(randomList);
        //echec si nodeResult.Location ==  nodeResult.BestChildPosition
        Assert.AreEqual("f3", nodeResult.BestChildPosition);
      }
    }
    /*tsiry;11-01-2022
    * */
    [TestMethod]
    public void MTT87BlackWinL2()
    {


      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      var testName = "T87BlackInChessInL2";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        Assert.AreEqual(nodeResult.BestChildPosition, "f2");
      } //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition

      /*    -2  d7 => e6
    - 2  d8 => a5
     - 2  f8 => b4
      - 2  e8 => e7
       - 2  g8 => f6
        - 2  d7 => e6
         - 2  d8 => f6
          - 2  f8 => c5*/

    }
    [TestMethod]
    public void MTT87WhiteAvoidInChessInL2()
    {


      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      var testName = "T87BlackInChessInL2";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //Assert.IsNull(randomList);
        //echec si nodeResult.Location ==  nodeResult.BestChildPosition

        var isSuccess = false;
        string[] accepdedArray = { "e6", "a5", "b4", "e7", "f6", "e6", "c5", "e3" };

        isSuccess = accepdedArray.Contains(nodeResult.BestChildPosition);
        Assert.IsTrue(isSuccess);
      }
      
      /*    -2  d7 => e6
    - 2  d8 => a5
     - 2  f8 => b4
      - 2  e8 => e7
       - 2  g8 => f6
        - 2  d7 => e6
         - 2  d8 => f6
          - 2  f8 => c5*/

    }

    [TestMethod]
    public void MTT88LesBlanchDoiventEviterLEchec()
    {


      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";
      
      var testName = "T88LesBlanchDoiventEviterLEchec";
      var testPath = Path.Combine(testsDirrectory, testName);

      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //Assert.IsNull(randomList);
        //echec si nodeResult.Location ==  nodeResult.BestChildPosition


        Assert.AreEqual(nodeResult.BestChildPosition, "e3");
      }
      

    }
    [TestMethod]
    public void MTT88LesNoirDoiventSeMettreEnF2()
    {


      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      var testName = "T88LesBlanchDoiventEviterLEchec";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //Assert.IsNull(randomList);
        //echec si nodeResult.Location ==  nodeResult.BestChildPosition


        Assert.AreEqual(nodeResult.BestChildPosition, "f2");
      }
      

    }


    /*tsiry;16-03-2022*/
    [TestMethod]
    public void MTT89LeFouNoirNeDoitPasSeMettreEnB4()
    {


      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      var testName = "T89LeFouNoirNeDoitPasSeMettreEnB4";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.AreNotEqual(nodeResult.BestChildPosition, "b4");
      }
      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition


      


    }

    /*tsiry;16-03-2022*/
    [TestMethod]
    public void MTT90LePoinNoirNeDoitPasSeMettreEnH5()
    {


      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      var testName = "T90LePoinNoirNeDoitPasSeMettreEnH5";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.AreNotEqual(nodeResult.Location, "h7");
        Assert.AreNotEqual(nodeResult.BestChildPosition, "h5");
      }
      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition





    }
    /*tsiry;17-03-2022*/
    [TestMethod]
    public void MTT91LePoinNoirNeDoitPasSeMettreEnH5()
    {


      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";
      var testName = "T91LaReineNoirDoitSeMettreEnH5";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

        Assert.AreEqual(nodeResult.Location, "g4");
        Assert.AreEqual(nodeResult.BestChildPosition, "h5");
      }
      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition





    }


        /*tsiry;16-05-2022*/
        [TestMethod]
        public void MTT92ALaReineNoirNeDoitPasSeMettreEnC3()
        {


            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
            mainWindow.ComputerColore = "Black";
            var testName = "T92ALaReineNoirNeDoitPasSeMettreEnC3";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

                //Assert.AreEqual(nodeResult.Location, "g4");
                Assert.AreNotEqual(nodeResult.BestChildPosition, "c3");
            }
            //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
            //Assert.IsNull(randomList);
            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }
        /*tsiry;17-05-2022*/
        [TestMethod]
        public void MTT92BLeCavalierNoirDoitPartieDeF6()
        {


            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
            mainWindow.ComputerColore = "Black";
            var testName = "T92BLeCavalierNoirDoitPartieDeF6";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

                //Assert.AreEqual(nodeResult.Location, "g4");
                Assert.AreEqual(nodeResult.Location, "f6");
            }
            //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
            //Assert.IsNull(randomList);
            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }


        [TestMethod]
        public void MTT93ALaReineNoirDoitSeMettreEnG3()
        {


            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
            mainWindow.ComputerColore = "Black";
            var testName = "T93ALaReineNoirDoitSeMettreEnG3";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

                //Assert.AreEqual(nodeResult.Location, "g4");
                Assert.AreEqual(nodeResult.BestChildPosition, "g3");
            }
            //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
            //Assert.IsNull(randomList);
            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }


        /*[TestMethod]
        public void MTT93BLePionNoirDoitSeMettreEnF4()
        {


            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
            mainWindow.ComputerColore = "Black";
            var testName = "T93BLePionNoirDoitSeMettreEnF4";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

                //Assert.AreEqual(nodeResult.Location, "g4");
                Assert.AreEqual(nodeResult.BestChildPosition, "e5");
            }
            //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
            //Assert.IsNull(randomList);
            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }
        */

        /*tsiry;28-10-2021*/
        /*[TestMethod]
        public void  MTT75LeCavalierNoirDoitPrendreLePionEnB5()
        {
          var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

          mainWindow.ComputerColore = "Black";




          mainWindow.CleanPawnList();
          var pawnListWhite = new List<Pawn>();
          var pawnListBlack = new List<Pawn>();



          //WHITEList
          var whiteListString = "" +
    "King;g1;White;False;True;True;True"+
    "\nQueen;f3;White;False;False;False;False"+
    "\nRook;a1;White;False;False;False;False"+
    "\nRook;d1;White;False;False;False;False"+
    "\nKnight;e2;White;False;False;False;False"+
    "\nBishop;c1;White;False;False;False;False"+
    "\nKnight;e5;White;False;False;False;False"+
    "\nSimplePawn;b5;White;True;False;False;False"+
    "\nSimplePawn;c2;White;True;False;False;False"+
    "\nSimplePawn;d5;White;True;False;False;False"+
    "\nSimplePawn;f2;White;True;False;False;False"+
    "\nSimplePawn;g3;White;True;False;False;False"+
    "\nSimplePawn;h2;White;True;False;False;False";

          ;
          var whiteList = whiteListString.Split('\n');
          foreach (var line in whiteList)
          {
            var datas = line.Split(';');
            var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnListWhite.Add(newPawn);
          }

          //BLACKList
          var blackListString = "" +
    "King;e8;Black;False;True;True;True"+
    "\nQueen;d8;Black;False;False;False;False"+
    "\nRook;a8;Black;False;False;False;False"+
    "\nRook;h8;Black;False;False;False;False"+
    "\nBishop;b7;Black;False;False;False;False"+
    "\nBishop;f8;Black;False;False;False;False"+
    "\nKnight;d6;Black;False;False;False;False"+
    "\nSimplePawn;a7;Black;True;False;False;False"+
    "\nSimplePawn;c7;Black;True;False;False;False"+
    "\nSimplePawn;d7;Black;True;False;False;False"+
    "\nSimplePawn;e7;Black;True;False;False;False"+
    "\nSimplePawn;f7;Black;True;False;False;False"+
    "\nSimplePawn;g7;Black;True;False;False;False"+
    "\nSimplePawn;h6;Black;True;False;False;False";
          var blackList = blackListString.Split('\n');
          foreach (var line in blackList)
          {
            var datas = line.Split(';');
            var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnListBlack.Add(newPawn);
          }



          mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
          var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

          var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
          //Assert.IsNull(randomList);

          Assert.AreEqual(nodeResult.BestChildPosition, "b5");
        }

        [TestMethod]
        public void  MTT76LeCavalierNoirEnD6DoitBouger()
        {
          var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

          mainWindow.ComputerColore = "Black";




          mainWindow.CleanPawnList();
          var pawnListWhite = new List<Pawn>();
          var pawnListBlack = new List<Pawn>();



          //WHITEList
          var whiteListString = "" +
    "King;g1;White;False;True;True;True"+
    "\nQueen;f3;White;False;False;False;False"+
    "\nRook;a1;White;False;False;False;False"+
    "\nRook;d1;White;False;False;False;False"+
    "\nKnight;e2;White;False;False;False;False"+
    "\nBishop;c1;White;False;False;False;False"+
    "\nKnight;e5;White;False;False;False;False"+
    "\nSimplePawn;b5;White;True;False;False;False"+
    "\nSimplePawn;c5;White;True;False;False;False"+
    "\nSimplePawn;d5;White;True;False;False;False"+
    "\nSimplePawn;f2;White;True;False;False;False"+
    "\nSimplePawn;g3;White;True;False;False;False"+
    "\nSimplePawn;h2;White;True;False;False;False";

          ;
          var whiteList = whiteListString.Split('\n');
          foreach (var line in whiteList)
          {
            var datas = line.Split(';');
            var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnListWhite.Add(newPawn);
          }

          //BLACKList
          var blackListString = "" +
    "King;e8;Black;False;True;True;True"+
    "\nQueen;d8;Black;False;False;False;False"+
    "\nRook;a8;Black;False;False;False;False"+
    "\nRook;h8;Black;False;False;False;False"+
    "\nBishop;b7;Black;False;False;False;False"+
    "\nBishop;f8;Black;False;False;False;False"+
    "\nKnight;d6;Black;False;False;False;False"+
    "\nSimplePawn;a7;Black;True;False;False;False"+
    "\nSimplePawn;c7;Black;True;False;False;False"+
    "\nSimplePawn;d7;Black;True;False;False;False"+
    "\nSimplePawn;e7;Black;True;False;False;False"+
    "\nSimplePawn;f7;Black;True;False;False;False"+
    "\nSimplePawn;g7;Black;True;False;False;False"+
    "\nSimplePawn;h6;Black;True;False;False;False";
          var blackList = blackListString.Split('\n');
          foreach (var line in blackList)
          {
            var datas = line.Split(';');
            var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnListBlack.Add(newPawn);
          }



          mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
          var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

          var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
          //Assert.IsNull(randomList);

          Assert.AreEqual(nodeResult.Location, "d6");
        }
        */

        /*  [TestMethod]
          public void  MTT3300aLePionBlancNeDoitPasPrendreLeCavalier()
          {
            //Le pion blanch ne doit pas prendre le cavalier en d4



            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
            mainWindow.ComputerColore = "White";



            mainWindow.CleanPawnList();
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
             "Rook;h1;White;False;False;False;False" +
             "\nKnight;g3;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False"+
      "\nSimplePawn;e3;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
              var datas = line.Split(';');
              var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
              //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
              newPawn.IsFirstMove = bool.Parse(datas[3]);
              newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
              newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
              newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
              pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "Bishop;b7;Black;False;False;False;False" +
      "\nKnight;d4;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
              var datas = line.Split(';');
              var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
              //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
              newPawn.IsFirstMove = bool.Parse(datas[3]);
              newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
              newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
              newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
              pawnListBlack.Add(newPawn);
            }



            mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


            var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
            //Le poin doit pas se mettre en e3
            Assert.AreEqual(nodeResult.BestChildPosition, "e4");


          }


          [TestMethod]
          public void  MTT3300bLePionBlancDoitPrendreLeCavalier()
          {
            //Le pion blanch  doit prendre le cavalier en d4



            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
            mainWindow.ComputerColore = "White";



            mainWindow.CleanPawnList();
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "Knight;g1;White;False;False;False;False" +
      "\nSimplePawn;e3;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
              var datas = line.Split(';');
              var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
              //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
              newPawn.IsFirstMove = bool.Parse(datas[3]);
              newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
              newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
              newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
              pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "Knight;d4;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
              var datas = line.Split(';');
              var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
              //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
              newPawn.IsFirstMove = bool.Parse(datas[3]);
              newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
              newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
              newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
              pawnListBlack.Add(newPawn);
            }



            mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


            var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
            //Le poin doit  se mettre en d4
            Assert.AreEqual(nodeResult.BestChildPosition, "d4");


          }

          */

        //    [TestMethod]
        //    public void  MTT33aLePionBlancNeDoitPasPrendreLeCavalier()
        //    {
        //      /*Le pion blanch ne doit pas prendre le cavalier en d4*/



        //      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
        //      mainWindow.ComputerColore = "White";


        //      
        //       
        //      
        //      mainWindow.CleanPawnList();
        //      var pawnListWhite = new List<Pawn>();
        //      var pawnListBlack = new List<Pawn>();



        //      //WHITEList
        //      var whiteListString = "" +
        //       "King;e1;White;False;True;True;True" +
        //"\nQueen;d1;White;False;False;False;False" +
        //"\nRook;a1;White;False;False;False;False" +
        //"\nRook;h1;White;False;False;False;False" +
        //"\nBishop;c1;White;False;False;False;False" +
        //"\nKnight;g3;White;False;False;False;False" +
        //"\nKnight;g1;White;False;False;False;False" +
        //"\nSimplePawn;a4;White;False;False;False;False" +
        //"\nSimplePawn;b2;White;True;False;False;False" +
        //"\nSimplePawn;c2;White;True;False;False;False" +
        //"\nSimplePawn;d2;White;True;False;False;False" +
        //"\nSimplePawn;e3;White;False;False;False;False" +
        //"\nSimplePawn;f4;White;False;False;False;False" +
        //"\nSimplePawn;h2;White;False;False;False;False" +
        //"\nSimplePawn;g4;White;True;False;False;False";
        //      var whiteList = whiteListString.Split('\n');
        //      foreach (var line in whiteList)
        //      {
        //        var datas = line.Split(';');
        //        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        //        newPawn.IsFirstMove = bool.Parse(datas[3]);
        //        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        //        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        //        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        //        pawnListWhite.Add(newPawn);
        //      }

        //      //BLACKList
        //      var blackListString = "" +
        //"King;e8;Black;False;True;True;True" +
        //"\nQueen;a5;Black;False;False;False;False" +
        //"\nRook;a8;Black;False;False;False;False" +
        //"\nRook;h8;Black;False;False;False;False" +
        //"\nBishop;b7;Black;False;False;False;False" +
        //"\nBishop;f8;Black;False;False;False;False" +
        //"\nKnight;d4;Black;False;False;False;False" +
        //"\nKnight;g8;Black;False;False;False;False" +
        //"\nSimplePawn;a7;Black;True;False;False;False" +
        //"\nSimplePawn;b4;Black;False;False;False;False" +
        //"\nSimplePawn;c5;Black;False;False;False;False" +
        //"\nSimplePawn;d7;Black;True;False;False;False" +
        //"\nSimplePawn;e7;Black;True;False;False;False" +
        //"\nSimplePawn;f7;Black;True;False;False;False" +
        //"\nSimplePawn;g7;Black;True;False;False;False" +
        //"\nSimplePawn;h7;Black;True;False;False;False";
        //      var blackList = blackListString.Split('\n');
        //      foreach (var line in blackList)
        //      {
        //        var datas = line.Split(';');
        //        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        //        newPawn.IsFirstMove = bool.Parse(datas[3]);
        //        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        //        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        //        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        //        pawnListBlack.Add(newPawn);
        //      }



        //      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


        //      var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //      //Le poin doit pas se mettre en e3
        //      Assert.AreEqual(nodeResult.BestChildPosition, "e4");


        //    }
        [TestMethod]
        public void  MTT33bLePionBlancDoitPrendreLeCavalier()
    {
      /*Le pion blanch prendre le cavalier en d4*/



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";





      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
       "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;b3;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a4;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;f4;White;False;False;False;False" +
"\nSimplePawn;g4;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;a5;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;d4;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b4;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);
        //Le poin doit pas se mettre en d4
        Assert.AreEqual(nodeResult.BestChildPosition, "d4");
      }


    }



  }


  [TestClass]
  public class ChessDBTest
  {
    /*[TestMethod]
     public void InsertToGamePart()
     {


       var dateTimeNow = DateTime.Now;
       var serviceChessDB = new ServiceChessDB();
       serviceChessDB.CreateNewGamePart("insertiontest", dateTimeNow,"Test");
       var lastInsertInChessDB = serviceChessDB.GetLastGamePart();
     //  var newTestGamePart = "";
       //la date heur de la dérnier insestion doit etre égal à dateTimeNow
       Assert.AreEqual(lastInsertInChessDB.GamePartStartDateTime?.ToString("dd/MM/yyyy hh:mm:ss"), dateTimeNow.ToString("dd/MM/yyyy hh:mm:ss"));
     }*/



    /*  
      [TestMethod]
      public void InsertTurn()
      {

        var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
        mainWindow.ComputerColore = "White";
        
         
        
        mainWindow.CleanPawnList();
        var pawnListWhite = new List<Pawn>();
        var pawnListBlack = new List<Pawn>();
        //WHITEList
        var whiteListString = "" +
          "Rook;a1;White;False;False;False;False" +
  "\nSimplePawn;a2;White;True;False;False;False" +
  "\nKnight;b5;White;False;False;False;False" +
  "\nSimplePawn;b2;White;True;False;False;False" +
  "\nBishop;c1;White;False;False;False;False" +
  "\nSimplePawn;c2;White;True;False;False;False" +
  "\nQueen;d1;White;False;False;False;False" +
  "\nSimplePawn;d2;White;True;False;False;False" +
  "\nKing;e1;White;False;True;True;True" +
  "\nSimplePawn;e2;White;True;False;False;False" +
  "\nBishop;f1;White;False;False;False;False" +
  "\nSimplePawn;f2;White;True;False;False;False" +
  "\nKnight;g1;White;False;False;False;False" +
  "\nSimplePawn;g2;White;True;False;False;False" +
  "\nRook;h1;White;False;False;False;False" +
  "\nSimplePawn;h2;White;True;False;False;False";
        var whiteList = whiteListString.Split('\n');
        foreach (var line in whiteList)
        {
          var datas = line.Split(';');
          var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnListWhite.Add(newPawn);
        }

        //BLACKList
        var blackListString = "" +
        "SimplePawn;a7;Black;True;False;False;False" +
  "\nRook;a8;Black;False;False;False;False" +
  "\nSimplePawn;b7;Black;True;False;False;False" +
  "\nKnight;b8;Black;False;False;False;False" +
  "\nSimplePawn;c7;Black;True;False;False;False" +
  "\nBishop;c8;Black;False;False;False;False" +
  "\nSimplePawn;d7;Black;True;False;False;False" +
  "\nQueen;d8;Black;False;False;False;False" +
  "\nSimplePawn;e6;Black;False;False;False;False" +
  "\nKing;e8;Black;False;True;True;True" +
  "\nSimplePawn;f7;Black;True;False;False;False" +
  "\nBishop;b4;Black;False;False;False;False" +
  "\nSimplePawn;g7;Black;True;False;False;False" +
  "\nKnight;g8;Black;False;False;False;False" +
  "\nSimplePawn;h7;Black;True;False;False;False" +
  "\nRook;h8;Black;False;False;False;False";
        var blackList = blackListString.Split('\n');
        foreach (var line in blackList)
        {
          var datas = line.Split(';');
          var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnListBlack.Add(newPawn);
        }


        mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
        var dateTimeNow = DateTime.Now;
        var serviceChessDB = new ServiceChessDB();
        serviceChessDB.CreateNewGamePart("insertionGamePartAndInsertionTurnTests", dateTimeNow);
        var lastInsertInChessDB = serviceChessDB.GetLastGamePart();
        //var odlCount = lastInsertInChessDB.Turns.Count();
        serviceChessDB.InserTurn(lastInsertInChessDB.GamePartID, mainWindow.PawnList, mainWindow.ComputerColore);
        serviceChessDB.InserTurn(lastInsertInChessDB.GamePartID, mainWindow.PawnList, mainWindow.ComputerColore);
        serviceChessDB.InserTurn(lastInsertInChessDB.GamePartID, mainWindow.PawnList, mainWindow.ComputerColore);

        lastInsertInChessDB = serviceChessDB.GetGamePart(lastInsertInChessDB.GamePartID);
        var turns = serviceChessDB.GetGameTurns(lastInsertInChessDB.GamePartID);
        Assert.AreEqual(turns.Count, 3);

      }
   */



    
  }

  [TestClass]
  public class ChessPositionTest
  {

    [TestMethod]
    public void GetDiffTest()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");


      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;c3;White;False;False;False;False" +
"\nKnight;f3;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";


      var blackListString = "" +
          "King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";


      var whiteListStringFutur = "" +
          "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;g5;White;False;False;False;False" +
"\nKnight;f3;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";


      var blackListStringFutur = "" +
          "King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nKnight;f6;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c6;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";

      var acutalList = mainWindow.GetWhiteAndBlackList(whiteListString, blackListString);
      var futurList = mainWindow.GetWhiteAndBlackList(whiteListStringFutur, blackListStringFutur);
      var mainPawnOpinion = mainWindow.GetDiff(acutalList, futurList);



      //Knight;g5
      Assert.AreEqual(mainPawnOpinion[0].Name, "Knight");
      Assert.AreEqual(mainPawnOpinion[0].Location, "g5");
    }

    [TestMethod]
    public void IsProtectedTestC6()
    {

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d2;White;True;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g5;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nSimplePawn;a7;Black;True;False;False;False" +
"\nSimplePawn;b7;Black;True;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      var isProtected = mainWindow.LoactionIsProtected("c7", "c6", "Black", mainWindow.PawnList);
      Assert.IsTrue(isProtected);


    }
    [TestMethod]
    public void IsNotProtectedTestD5()
    {

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();

      //WHITEList
      var whiteListString = "" +
"King;f1;White;False;False;True;False" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;g1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;f4;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;f6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b5;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e5;Black;False;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      var isProtected = mainWindow.LoactionIsProtected("d6", "d5", "Black", mainWindow.PawnList);
      Assert.IsFalse(isProtected);


    }

    [TestMethod]
    public void IsMenacedTestD5()
    {

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();

      //WHITEList
      var whiteListString = "" +
"King;f1;White;False;False;True;False" +
"\nQueen;f3;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;g1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nKnight;f4;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d3;White;False;False;False;False" +
"\nSimplePawn;g3;White;False;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;f6;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;g7;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b5;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d6;Black;False;False;False;False" +
"\nSimplePawn;e5;Black;False;False;False;False" +
"\nSimplePawn;g6;Black;False;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      var isMenacer = mainWindow.LoactionIsMenaced("d5", "Black", mainWindow.PawnList);
      Assert.IsTrue(isMenacer);


    }



    [TestMethod]
    public void GenereteSymetriTest()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");


      //WHITEList
      var whiteListString = "" +
"King;g1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;f1;White;False;False;False;False" +
"\nKnight;b1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;e2;White;False;False;False;False" +
"\nKnight;h4;White;False;False;False;False" +
"\nSimplePawn;a2;White;True;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c4;White;False;False;False;False" +
"\nSimplePawn;e4;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";


      var blackListString = "" +
"King;e8;Black;False;True;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;b7;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a5;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c5;Black;False;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;d5;Black;False;False;False;False" +
"\nSimplePawn;f6;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h5;Black;False;False;False;False";



      var originalList = mainWindow.GetWhiteAndBlackList(whiteListString, blackListString);
      var result = mainWindow.GetSymmetryList(originalList);

      mainWindow.Save(result);
      var c5 = result.FirstOrDefault(x => x.Colore == "Black" && x.Location == "c5");

      Assert.IsNotNull(c5);


      //Assert.IsNotNull(a8);

    }


   

    [TestMethod]
    public void GetMenacedListTestForT56()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b5;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;g6;White;False;False;False;False" +
"\nSimplePawn;a3;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a4;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f5;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }

      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);

      var menacerList = mainWindow.GetMenacedList(mainWindow.PawnList, "Black");

      var menacedKing = menacerList.FirstOrDefault(x => x.Name == "King" && x.Location == "e7");

      Assert.IsNotNull(menacedKing);

    }



    /*tsiry;06-09-2021*/
    [TestMethod]
    public void GetIsmenacedInL2TestForT56()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "Black";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();



      //WHITEList
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;b5;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
"\nKnight;h4;White;False;False;False;False" +
"\nSimplePawn;a3;White;False;False;False;False" +
"\nSimplePawn;b2;White;True;False;False;False" +
"\nSimplePawn;c2;White;True;False;False;False" +
"\nSimplePawn;d4;White;False;False;False;False" +
"\nSimplePawn;e5;White;False;False;False;False" +
"\nSimplePawn;f2;White;True;False;False;False" +
"\nSimplePawn;g2;White;True;False;False;False" +
"\nSimplePawn;h2;White;True;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "" +
"King;e7;Black;False;False;True;True" +
"\nQueen;d8;Black;False;False;False;False" +
"\nRook;a8;Black;False;False;False;False" +
"\nRook;h8;Black;False;False;False;False" +
"\nKnight;b8;Black;False;False;False;False" +
"\nBishop;c8;Black;False;False;False;False" +
"\nBishop;f8;Black;False;False;False;False" +
"\nKnight;g8;Black;False;False;False;False" +
"\nSimplePawn;a4;Black;False;False;False;False" +
"\nSimplePawn;b6;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;d7;Black;True;False;False;False" +
"\nSimplePawn;e6;Black;False;False;False;False" +
"\nSimplePawn;f5;Black;False;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h6;Black;False;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }



      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var result = mainWindow.GetIsMancedInLevel2(mainWindow.PawnList);
      Assert.IsTrue(result);
    }


   

    [TestMethod]
    public void GetIsInChessInLevel1ForT07()
    {





      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();


      //WHITEList
      var whiteListString = "King;h4;White;False;False;False;True" +
"\nQueen;e1;White;False;False;False;False" +
"\nRook;d5;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a3;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;g4;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "King;g8;Black;False;False;False;False" +
        "\nQueen;g6;Black;False;False;False;False" +
"\nRook;c6;Black;False;False;False;False" +
"\nKnight;a7;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }


      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);


      var result = mainWindow.GetIsInChessInLevel1(mainWindow.PawnList, mainWindow.ComputerColore);
      //rook blanch  doit etre "d8"
      Assert.IsTrue(result);

    }


    [TestMethod]
    public void GetMenacedListTestForT07a()
    {
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";

      
       
      
      mainWindow.CleanPawnList();
      var pawnListWhite = new List<Pawn>();
      var pawnListBlack = new List<Pawn>();




      //WHITEList
      var whiteListString = "King;h4;White;False;False;False;True" +
"\nQueen;e1;White;False;False;False;False" +
"\nRook;d8;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nKnight;g1;White;False;False;False;False" +
"\nSimplePawn;a3;White;False;False;False;False" +
"\nSimplePawn;c3;White;False;False;False;False" +
"\nSimplePawn;e3;White;False;False;False;False" +
"\nSimplePawn;g4;White;False;False;False;False" +
"\nSimplePawn;h3;White;False;False;False;False";
      var whiteList = whiteListString.Split('\n');
      foreach (var line in whiteList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListWhite.Add(newPawn);
      }

      //BLACKList
      var blackListString = "King;g8;Black;False;False;False;False" +
        "\nQueen;g6;Black;False;False;False;False" +
"\nRook;c6;Black;False;False;False;False" +
"\nKnight;a7;Black;False;False;False;False" +
"\nSimplePawn;c7;Black;True;False;False;False" +
"\nSimplePawn;f7;Black;True;False;False;False" +
"\nSimplePawn;g7;Black;True;False;False;False" +
"\nSimplePawn;h7;Black;True;False;False;False";
      var blackList = blackListString.Split('\n');
      foreach (var line in blackList)
      {
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnListBlack.Add(newPawn);
      }

      mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      var menacerList = mainWindow.GetMenacedList(mainWindow.PawnList, "Black");

      var menacedKing = menacerList.FirstOrDefault(x => x.Name == "King");

      Assert.IsNotNull(menacedKing);

    }

  }


    [TestClass]
    public class HistoryWebToHistoryAppTest
    {

        [TestMethod]
        public void oneLineHistoryWeb_to_oneLineHistoryTest()
        {
            var enter = "52(P|W)>36(__)";
            var result = Chess.Utils.Chess2Utils.OneLineHistoryWebToOneLineHistoryApp(enter);
            var execptedResult = "White:	Pawn	e2 => e4";
            Assert.AreEqual(execptedResult, result);

        }


        [TestMethod]
        public void oneLineHistoryWeb_to_oneLineHistoryTest2()
        {
            var enter = "7(T|B)>6(__)";
            var result = Chess.Utils.Chess2Utils.OneLineHistoryWebToOneLineHistoryApp(enter);
            var execptedResult = "Black:	Rook	h8 => g8";
            Assert.AreEqual(execptedResult, result);

        }

        [TestMethod]
        public void HistoryWeb_to_HistoryTest()
        {
            var enter1 = "52(P|W)>36(__)";
            var enter2 = "8(P|B)>24(__)";
            var interText = $"{enter1}\n{enter2}";
            var result = Chess.Utils.Chess2Utils.HistoryWebToHistoryApp(interText);
            Assert.IsTrue(result.Contains("White:	Pawn	e2 => e4"));

        }
    }

}
